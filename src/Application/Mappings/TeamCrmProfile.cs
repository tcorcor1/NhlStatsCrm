using NhlStatsCrm.Application.Dto;

namespace NhlStatsCrm.Application.Mapping
{
	public class TeamCrmProfile : Profile
	{
		public TeamCrmProfile ()
		{
			CreateMap<IDictionary<string, object>, TeamDto>()
				.ForMember(dest => dest.TeamName, src => src.MapFrom(x => x["yyz_team_name"]))
				.ForMember(dest => dest.ShortName, src => src.MapFrom(x => x["yyz_short_name"]))
				.ForMember(dest => dest.FranchiseId, src => src.MapFrom(x => x["yyz_franchise_id"]))
				.ForMember(dest => dest.Abbreviation, src => src.MapFrom(x => x["yyz_abbreviation"]))
				.ForMember(dest => dest.Link, src => src.MapFrom(x => x["yyz_link"]))
				.ForMember(dest => dest.LegacyId, src => src.MapFrom(x => x["yyz_legacy_id"]));
		}
	}
}