using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using NhlStatsCrm.Application.Common.Exceptions;
using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Infrastructure.Persistence.Repositories
{
	public class PlayersRepository : RepositoryBase<Player>, IDynamicsRepository<Player>
	{
		private readonly IOrganizationServiceAsync _service;
		private readonly ILogger<PlayersRepository> _logger;

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

		public PlayersRepository (ILogger<PlayersRepository> logger, IOrganizationServiceAsync service) : base(logger, service)
		{
			_service = service;
			_logger = logger;
		}

		public override async Task<EntityCollection> GetByAltKeyAsync (string id)
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

			return retrieveMultipleRes.EntityCollection;
		}

		public override async Task<EntityCollection> GetAllAsync ()
		{
			var pageNumber = 1;
			var pagingCookie = string.Empty;
			var result = new EntityCollection();
			var response = new EntityCollection();

			var query = new QueryExpression(Entity)
			{
				EntityName = Entity,
				ColumnSet = new ColumnSet(Columns)
			};

			var link = query.AddLink("yyz_team", "yyz_team_id", "yyz_teamid", JoinOperator.Inner);
			link.Columns.AddColumn("yyz_legacy_id");
			link.EntityAlias = "team";

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

				result.Entities.AddRange(response.Entities);
			}
			while (response.MoreRecords);

			return result;
		}

		public async Task<Guid?> PatchAsync (Player player)
		{
			var playerId = player.Person.Id.ToString();

			var upsertPlayer = new UpsertRequest()
			{
				Target = new Entity(Entity, AlternateKey, playerId)
				{
					["yyz_full_name"] = player.Person.FullName,
					["yyz_team_id"] = new EntityReference("yyz_team", "yyz_legacy_id", player.TeamId),
					["yyz_link"] = player.Person.Link,
					["yyz_position_name"] = player.Position.Name,
					["yyz_position_type"] = player.Position.Type,
					["yyz_jersey_number"] = Convert.ToInt32(player.JerseyNumber),
				}
			};

			_logger.LogInformation("Patching Player: {PlayerId}", playerId);

			var upsertRes = (UpsertResponse)await _service.ExecuteAsync(upsertPlayer);

			_logger.LogInformation($"Patching: {player.Person.FullName}");

			return upsertRes.RecordCreated
				? upsertRes.Target.Id
				: null;
		}
	}
}