using NhlStatsCrm.Application.Dto;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeams
{
	public class GetAllTeamsQuery : IRequest<IEnumerable<TeamDto>>
	{
	}
}