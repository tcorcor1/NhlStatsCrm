using NhlStatsCrm.Application.Dto;

namespace NhlStatsCrm.Application.Mapping
{
	public class PlayerCrmProfile : Profile
	{
		public PlayerCrmProfile ()
		{
			CreateMap<IDictionary<string, object>, PlayerDto>()
				.ForMember(dest => dest.LegacyId, src => src.MapFrom(x => x.ContainsKey("yyz_legacy_id") ? x["yyz_legacy_id"] : null))
				.ForMember(dest => dest.FullName, src => src.MapFrom(x => x.ContainsKey("yyz_full_name") ? x["yyz_full_name"] : null))
				.ForMember(dest => dest.TeamId, src => src.MapFrom(x => x.ContainsKey("team.yyz_legacy_id") ? ((AliasedValue)x["team.yyz_legacy_id"]).Value : null))
				.ForMember(dest => dest.TeamName, src => src.MapFrom(x => ((EntityReference)x["yyz_team_id"]).Name))
				.ForMember(dest => dest.Link, src => src.MapFrom(x => x.ContainsKey("yyz_link") ? x["yyz_link"] : null))
				.ForMember(dest => dest.PositionName, src => src.MapFrom(x => x.ContainsKey("yyz_position_name") ? x["yyz_position_name"] : null))
				.ForMember(dest => dest.PositionType, src => src.MapFrom(x => x.ContainsKey("yyz_position_type") ? x["yyz_position_type"] : null))
				.ForMember(dest => dest.JerseyNumber, src => src.MapFrom(x => x.ContainsKey("yyz_jersey_number") ? x["yyz_jersey_number"] : null));
		}
	}
}