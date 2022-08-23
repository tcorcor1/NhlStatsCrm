using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using NhlStatsCrm.Domain.Entities.Crm;
using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Infrastructure.Persistence.Repositories
{
	public class TeamsRepository : RepositoryBase<Team>, IDynamicsRepository<Team>
	{
		private readonly IOrganizationServiceAsync _service;
		private readonly ILogger<TeamsRepository> _logger;
		private readonly IMapper _mapper;

		public override string Entity => "yyz_team";
		public override string AlternateKey => "yyz_legacy_id";

		public override string[] Columns => new[] {
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

		public TeamsRepository (ILogger<TeamsRepository> logger, IOrganizationServiceAsync service, IMapper mapper) : base(logger, service, mapper)
		{
			_logger = logger;
			_service = service;
			_mapper = mapper;
		}

		public async Task<Guid?> PatchAsync (Team team)
		{
			var upsertTeam = new UpsertRequest()
			{
				Target = new Entity(Entity, AlternateKey, team.LegacyId)
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