using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using NhlStatsCrm.Domain.Entities.Nhl;
using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Infrastructure.Persistence.Repositories
{
	public class StatsRepository : RepositoryBase<Stat>, IDynamicsRepository<Stat>
	{
		private readonly IOrganizationServiceAsync _service;
		private readonly ILogger<StatsRepository> _logger;

		public override string Entity => "yyz_stat";
		public override string AlternateKey => "yyz_legacy_id";

		public override string[] Columns => new[] {
			"yyz_assists",
			"yyz_blocked",
			"yyz_empty_net_goals",
			"yyz_even_shots",
			"yyz_even_strength_save_percentage",
			"yyz_even_time_on_ice",
			"yyz_face_off_pct",
			"yyz_gaa",
			"yyz_game_winning_goals",
			"yyz_games",
			"yyz_games_started",
			"yyz_goals",
			"yyz_goals_against",
			"yyz_goals_in_first_period",
			"yyz_goals_in_second_period",
			"yyz_goals_in_third_period",
			"yyz_goals_leading_by_one",
			"yyz_goals_leading_by_three_plus",
			"yyz_goals_trailing_by_one",
			"yyz_goals_trailing_by_three_plus",
			"yyz_goals_trailing_by_two",
			"yyz_goals_when_tied",
			"yyz_hits",
			"yyz_legacy_id",
			"yyz_losses",
			"yyz_ot_wins",
			"yyz_overtime_goals",
			"yyz_penalty_goals",
			"yyz_penalty_shots",
			"yyz_pim",
			"yyz_player_id",
			"yyz_plus_minus",
			"yyz_points",
			"yyz_power_play_goals",
			"yyz_power_play_points",
			"yyz_power_play_time_on_ice",
			"yyz_powerplay_save_percentage",
			"yyz_save_percentage",
			"yyz_saves",
			"yyz_season_name",
			"yyz_shifts",
			"yyz_shoot_out_goals",
			"yyz_shoot_out_shots",
			"yyz_short_handed_goals",
			"yyz_short_handed_save_percentage",
			"yyz_short_handed_time_on_ice",
			"yyz_shot_handed_points",
			"yyz_shot_pct",
			"yyz_shots",
			"yyz_shots_against",
			"yyz_shutouts",
			"yyz_statid",
			"yyz_time_on_ice",
			"yyz_wins",
			"statecode"
		};

		public StatsRepository (ILogger<StatsRepository> logger, IOrganizationServiceAsync service) : base(logger, service)
		{
			_logger = logger;
			_service = service;
		}

		public async Task<Guid?> PatchAsync (Stat playerStat)
		{
			var upsertPlayer = new UpsertRequest()
			{
				Target = new Entity(Entity, AlternateKey, $"{playerStat.SeasonName}{playerStat.PlayerId}")
				{
					["yyz_player_id"] = new EntityReference("yyz_player", AlternateKey, playerStat.PlayerId),
					["yyz_season_name"] = playerStat.SeasonName,
					["yyz_games"] = playerStat.Games,
					["yyz_goals"] = playerStat.Goals,
					["yyz_assists"] = playerStat.Assists,
					["yyz_points"] = playerStat.Points,
					["yyz_shots"] = playerStat.Shots,
					["yyz_hits"] = playerStat.Hits,
					["yyz_plus_minus"] = playerStat.PlusMinus,
					["yyz_pim"] = playerStat.Pim,
					["yyz_game_winning_goals"] = playerStat.GameWinningGoals,
					["yyz_power_play_goals"] = playerStat.PowerPlayGoals,
					["yyz_power_play_points"] = playerStat.PowerPlayPoints,
					["yyz_short_handed_goals"] = playerStat.ShortHandedGoals,
					["yyz_shot_handed_points"] = playerStat.ShortHandedPoints,
					["yyz_shot_pct"] = (int)Math.Floor(playerStat.ShotPct),
					["yyz_face_off_pct"] = (int)Math.Floor(playerStat.FaceOffPct),
					["yyz_blocked"] = playerStat.Blocked,
					["yyz_shifts"] = playerStat.Shifts,
					["yyz_time_on_ice"] = playerStat.TimeOnIce,
					["yyz_short_handed_time_on_ice"] = playerStat.ShortHandedTimeOnIce,
					["yyz_power_play_time_on_ice"] = playerStat.PowerPlayTimeOnIce,
					["yyz_even_time_on_ice"] = playerStat.EvenTimeOnIce,
					["yyz_games_started"] = playerStat.GamesStarted,
					["yyz_gaa"] = playerStat.GoalAgainstAverage,
					["yyz_save_percentage"] = playerStat.SavePercentage,
					["yyz_shots_against"] = playerStat.ShotsAgainst,
					["yyz_goals_against"] = playerStat.GoalsAgainst,
					["yyz_saves"] = playerStat.Saves,
					["yyz_wins"] = playerStat.Wins,
					["yyz_losses"] = playerStat.Losses,
					["yyz_shutouts"] = playerStat.Shutouts,
					["yyz_powerplay_save_percentage"] = playerStat.PowerPlaySavePercentage,
					["yyz_even_strength_save_percentage"] = playerStat.EvenStrengthSavePercentage,
					["yyz_short_handed_save_percentage"] = playerStat.ShortHandedSavePercentage,
				}
			};

			var upsertRes = (UpsertResponse)await _service.ExecuteAsync(upsertPlayer);

			return upsertRes.RecordCreated
				? upsertRes.Target.Id
				: null;
		}
	}
}