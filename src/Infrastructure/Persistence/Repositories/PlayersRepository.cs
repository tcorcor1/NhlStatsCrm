using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Messages;
using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Crm;
using NhlStatsCrm.Application.Common.Exceptions;

namespace E5NhlCrm.Infrastructure.Persistence.Repositories
{
	public class PlayersRepository : IDynamicsRepository<Player>
	{
		private readonly IOrganizationServiceAsync _service;
		private readonly ILogger<PlayersRepository> _logger;
		private readonly IMapper _mapper;
		private readonly string _entity = "yyz_player";
		private readonly string _alternateKey = "yyz_legacy_id";

		private readonly string[] _columns =
		{
			"yyz_playerid",
			"yyz_full_name",
			"yyz_birth_country",
			"yyz_birth_date",
			"yyz_link",
			"yyz_position_name",
			"yyz_position_type",
			"yyz_jersey_number",
			"yyz_team_id",
			"yyz_weight",
			"yyz_height",
			"yyz_avg_goals",
			"yyz_avg_assists",
			"yyz_avg_points",
			"yyz_avg_hits",
			"yyz_avg_pim",
			"yyz_avg_shots"
		};

		public PlayersRepository (ILogger<PlayersRepository> logger, IOrganizationServiceAsync service, IMapper mapper)
		{
			_service = service;
			_logger = logger;
			_mapper = mapper;
		}

		public async Task<IEnumerable<Player>> GetAllAsync ()
		{
			var pageNumber = 1;
			var pagingCookie = string.Empty;
			var result = new List<Entity>();
			var response = new EntityCollection();

			var query = new QueryExpression(_entity)
			{
				EntityName = _entity,
				ColumnSet = new ColumnSet(_columns)
			};

			do
			{
				if (pageNumber != 1)
				{
					query.PageInfo.PageNumber = pageNumber;
					query.PageInfo.PagingCookie = pagingCookie;
				}

				var retrieveMultipleReq = new RetrieveMultipleRequest()
				{
					Query = query
				};
				var retrieveMultipleRes = (RetrieveMultipleResponse)await _service.ExecuteAsync(retrieveMultipleReq);

				response = retrieveMultipleRes.EntityCollection;

				if (response.MoreRecords)
				{
					pageNumber++;
					pagingCookie = response.PagingCookie;
				}

				result.AddRange(response.Entities);
			}
			while (response.MoreRecords);

			return result.Select(entity =>
			{
				var entityAttrDictionary = entity.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

				return _mapper.Map<Player>(entityAttrDictionary);
			});
		}

		public async Task<Player?> GetByAltKeyAsync (string id)
		{
			var query = new QueryExpression(_entity)
			{
				ColumnSet = new ColumnSet(_columns)
			};
			query.Criteria.Conditions.Add(new ConditionExpression(_alternateKey, ConditionOperator.Equal, id));

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
				Target = new Entity(_entity, _alternateKey, player.LegacyId)
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