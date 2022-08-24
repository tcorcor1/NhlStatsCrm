using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using NhlStatsCrm.Application.Common.Exceptions;
using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Crm;
using NhlStatsCrm.Infrastructure.Persistence.Repositories;

namespace E5NhlCrm.Infrastructure.Persistence.Repositories
{
	public class PlayersRepository : RepositoryBase<Player>, IDynamicsRepository<Player>
	{
		private readonly IOrganizationServiceAsync _service;
		private readonly ILogger<PlayersRepository> _logger;
		private readonly IMapper _mapper;

		public override string Entity => "yyz_player";
		public override string AlternateKey => "yyz_legacy_id";

		public override string[] Columns => new[] {
			"yyz_playerid",
			"yyz_legacy_id",
			"yyz_team_id",
			"yyz_full_name",
			"yyz_link",
			"yyz_jersey_number",
			"yyz_position_name",
			"yyz_position_type",
		};

		public PlayersRepository (ILogger<PlayersRepository> logger, IOrganizationServiceAsync service, IMapper mapper) : base(logger, service, mapper)
		{
			_service = service;
			_logger = logger;
			_mapper = mapper;
		}

		public override async Task<Player?> GetByAltKeyAsync (string id)
		{
			var query = new QueryExpression(Entity)
			{
				ColumnSet = new ColumnSet(Columns)
			};
			query.Criteria.Conditions.Add(new ConditionExpression(AlternateKey, ConditionOperator.Equal, id));

			var link = query.AddLink("yyz_team", "yyz_team_id", "yyz_teamid", JoinOperator.Inner);
			link.Columns.AddColumn("yyz_legacy_id");
			link.EntityAlias = "team";

			var retrieveMultipleReq = new RetrieveMultipleRequest()
			{
				Query = query
			};
			var retrieveMultipleRes = (RetrieveMultipleResponse)await _service.ExecuteAsync(retrieveMultipleReq);

			if (retrieveMultipleRes.EntityCollection.Entities.Count() == 0)
				throw new DynamicsNotFoundException($"No record found with ID: {id}");

			var entityAttrDictionary = retrieveMultipleRes.EntityCollection.Entities.First()
				.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

			return _mapper.Map<Player>(entityAttrDictionary);
		}

		public async Task<Guid?> PatchAsync (Player player)
		{
			var upsertPlayer = new UpsertRequest()
			{
				Target = new Entity(Entity, AlternateKey, player.LegacyId)
				{
					["yyz_full_name"] = player.FullName,
					["yyz_team_id"] = new EntityReference("yyz_team", "yyz_legacy_id", player.TeamId),
					["yyz_link"] = player.Link,
					["yyz_position_name"] = player.PositionName,
					["yyz_position_type"] = player.PositionType,
					["yyz_jersey_number"] = player.JerseyNumber,
				}
			};

			var upsertRes = (UpsertResponse)await _service.ExecuteAsync(upsertPlayer);

			_logger.LogInformation($"Patching: {player.FullName}");

			return upsertRes.RecordCreated
				? upsertRes.Target.Id
				: null;
		}
	}
}