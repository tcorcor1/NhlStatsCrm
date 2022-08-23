using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
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

		public PlayersRepository (ILogger<PlayersRepository> logger, IOrganizationServiceAsync service, IMapper mapper) : base(logger, service, mapper)
		{
			_service = service;
			_logger = logger;
			_mapper = mapper;
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