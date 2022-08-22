using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Messages;
using NhlStatsCrm.Domain.Entities.Crm;
using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Application.Common.Exceptions;

namespace NhlStatsCrm.Infrastructure.Persistence.Repositories
{
	public class TeamsRepository : IDynamicsRepository<Team>
	{
		private readonly IOrganizationServiceAsync _service;
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

		public TeamsRepository (IOrganizationServiceAsync service, IMapper mapper)
		{
			_service = service;
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

				return _mapper.Map<Team>(entityAttrDictionary);
			});
		}

		public async Task<Team?> GetByAltKeyAsync (string id)
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

			var teamAttrDictionary = retrieveMultipleRes.EntityCollection.Entities.First()
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