using NhlStatsCrm.Application.Dto;

namespace NhlStatsCrm.Application.Mappings
{
	public class StatCrmProfile : Profile
	{
		public StatCrmProfile ()
		{
			CreateMap<IDictionary<string, object>, StatDto>()
				.ForMember(dest => dest.PlayerName, src => src.MapFrom(x => ((EntityReference)x["yyz_player_id"]).Name))
				.ForMember(dest => dest.SeasonName, src => src.MapFrom(x => x.ContainsKey("yyz_season_name") ? x["yyz_season_name"] : null))
				.ForMember(dest => dest.Games, src => src.MapFrom(x => x.ContainsKey("yyz_games") ? x["yyz_games"] : null))
				.ForMember(dest => dest.GamesStarted, src => src.MapFrom(x => x.ContainsKey("yyz_games_started") ? x["yyz_games_started"] : null))
				.ForMember(dest => dest.Goals, src => src.MapFrom(x => x.ContainsKey("yyz_goals") ? x["yyz_goals"] : null))
				.ForMember(dest => dest.Assists, src => src.MapFrom(x => x.ContainsKey("yyz_assists") ? x["yyz_assists"] : null))
				.ForMember(dest => dest.Points, src => src.MapFrom(x => x.ContainsKey("yyz_points") ? x["yyz_points"] : null))
				.ForMember(dest => dest.Shots, src => src.MapFrom(x => x.ContainsKey("yyz_shots") ? x["yyz_shots"] : null))
				.ForMember(dest => dest.Hits, src => src.MapFrom(x => x.ContainsKey("yyz_hits") ? x["yyz_hits"] : null))
				.ForMember(dest => dest.Pim, src => src.MapFrom(x => x.ContainsKey("yyz_pim") ? x["yyz_pim"] : null))
				.ForMember(dest => dest.PlusMinus, src => src.MapFrom(x => x.ContainsKey("yyz_plus_minus") ? x["yyz_plus_minus"] : null))
				.ForMember(dest => dest.PowerPlayGoals, src => src.MapFrom(x => x.ContainsKey("yyz_power_play_goals") ? x["yyz_power_play_goals"] : null))
				.ForMember(dest => dest.PowerPlayPoints, src => src.MapFrom(x => x.ContainsKey("yyz_power_play_points") ? x["yyz_power_play_points"] : null))
				.ForMember(dest => dest.ShortHandedPoints, src => src.MapFrom(x => x.ContainsKey("yyz_shot_handed_points") ? x["yyz_shot_handed_points"] : null))
				.ForMember(dest => dest.GameWinningGoals, src => src.MapFrom(x => x.ContainsKey("yyz_game_winning_goals") ? x["yyz_game_winning_goals"] : null))
				.ForMember(dest => dest.GoalsAgainst, src => src.MapFrom(x => x.ContainsKey("yyz_goals_against") ? x["yyz_goals_against"] : null))
				.ForMember(dest => dest.GoalsAgainstAverage, src => src.MapFrom(x => x.ContainsKey("yyz_gaa") ? x["yyz_gaa"] : null))
				.ForMember(dest => dest.SavePercentage, src => src.MapFrom(x => x.ContainsKey("yyz_save_percentage") ? x["yyz_save_percentage"] : null))
				.ForMember(dest => dest.Shutouts, src => src.MapFrom(x => x.ContainsKey("yyz_shutouts") ? x["yyz_shutouts"] : null))
				.ForMember(dest => dest.Wins, src => src.MapFrom(x => x.ContainsKey("yyz_wins") ? x["yyz_wins"] : null))
				.ForMember(dest => dest.PowerPlaySavePercentage, src => src.MapFrom(x => x.ContainsKey("yyz_powerplay_save_percentage") ? x["yyz_powerplay_save_percentage"] : null))
				.ForMember(dest => dest.Blocked, src => src.MapFrom(x => x.ContainsKey("yyz_blocked") ? x["yyz_blocked"] : null))
				.ForMember(dest => dest.EvenStrengthSavePercentage, src => src.MapFrom(x => x.ContainsKey("yyz_even_strength_save_percentage") ? x["yyz_even_strength_save_percentage"] : null))
				.ForMember(dest => dest.EvenTimeOnIce, src => src.MapFrom(x => x.ContainsKey("yyz_even_time_on_ice") ? x["yyz_even_time_on_ice"] : null))
				.ForMember(dest => dest.FaceOffPct, src => src.MapFrom(x => x.ContainsKey("yyz_face_off_pct") ? x["yyz_face_off_pct"] : null))
				.ForMember(dest => dest.Losses, src => src.MapFrom(x => x.ContainsKey("yyz_losses") ? x["yyz_losses"] : null))
				.ForMember(dest => dest.OverTimeGoals, src => src.MapFrom(x => x.ContainsKey("yyz_overtime_goals") ? x["yyz_overtime_goals"] : null))
				.ForMember(dest => dest.Saves, src => src.MapFrom(x => x.ContainsKey("yyz_saves") ? x["yyz_saves"] : null))
				.ForMember(dest => dest.Shifts, src => src.MapFrom(x => x.ContainsKey("yyz_shifts") ? x["yyz_shifts"] : null))
				.ForMember(dest => dest.ShortHandedGoals, src => src.MapFrom(x => x.ContainsKey("yyz_short_handed_goals") ? x["yyz_short_handed_goals"] : null))
				.ForMember(dest => dest.ShotPct, src => src.MapFrom(x => x.ContainsKey("yyz_shot_pct") ? x["yyz_shot_pct"] : null))
				.ForMember(dest => dest.ShotsAgainst, src => src.MapFrom(x => x.ContainsKey("yyz_shots_against") ? x["yyz_shots_against"] : null))
				.ForMember(dest => dest.TimeOnIce, src => src.MapFrom(x => x.ContainsKey("yyz_time_on_ice") ? x["yyz_time_on_ice"] : null));
		}
	}
}