using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Messages;
using NhlStatsCrm.Domain.Entities.Crm;
using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Infrastructure.Persistence.Repositories
{
	public class TeamsRepository : ITeamsRepository
	{
		private readonly IOrganizationServiceAsync _service;
		private readonly ILogger<TeamsRepository> _logger;
		private readonly IMapper _mapper;
		private readonly string _entity = "yyz_team";
		private readonly string _alternateKey = "yyz_legacy_id";

		private readonly string[] _columns = new[] {
			"yyz_team_name",
			"yyz_abbreviation",
			"yyz_link",
			"yyz_franchise_id",
			"yyz_legacy_id",
			"yyz_teamid",
			"yyz_short_name",
			"statecode",
			"statuscode"
		};

		public TeamsRepository (ILogger<TeamsRepository> logger, IOrganizationServiceAsync service, IMapper mapper)
		{
			_service = service;
			_logger = logger;
			_mapper = mapper;
		}

		public async Task<IEnumerable<Team>> GetAllAsync ()
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

				response = await _service.RetrieveMultipleAsync(query);

				if (response.MoreRecords)
				{
					pageNumber++;
					pagingCookie = response.PagingCookie;
				}

				result.AddRange(response.Entities);
			}
			while (response.MoreRecords);

			var teamCollection = result.Select(entity =>
			{
				var teamAttrDictionary = entity.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

				return _mapper.Map<Team>(teamAttrDictionary);
			});

			return teamCollection;
		}

		public async Task<Team> GetByGuidAsync (Guid id)
		{
			var entity = await _service.RetrieveAsync(_entity, id, new ColumnSet(_columns));

			var teamAttrDictionary = entity.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

			return _mapper.Map<Team>(teamAttrDictionary);
		}

		public async Task<Team?> GetByAltKeyAsync (string id)
		{
			var query = new QueryExpression(_entity)
			{
				ColumnSet = new ColumnSet(_columns)
			};
			query.Criteria.Conditions.Add(new ConditionExpression(_alternateKey, ConditionOperator.Equal, id));

			var entityCollection = await _service.RetrieveMultipleAsync(query);

			if (entityCollection.Entities.Count() == 0)
				return null;

			var teamAttrDictionary = entityCollection.Entities.First()
				.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

			return _mapper.Map<Team>(teamAttrDictionary);
		}

		public async Task<Guid?> PatchAsync (Team team)
		{
			var upsertTeam = new UpsertRequest()
			{
				Target = new Entity(_entity, _alternateKey, team.LegacyId)
				{
					["yyz_team_name"] = team.TeamName,
					["yyz_short_name"] = team.ShortName,
					["yyz_link"] = team.Link,
					["yyz_franchise_id"] = team.FranchiseId,
					["yyz_abbreviation"] = team.Abbreviation
				}
			};

			var upsertRes = (UpsertResponse)await _service.ExecuteAsync(upsertTeam);

			return upsertRes.RecordCreated
				? upsertRes.Target.Id
				: null;
		}
	}
}