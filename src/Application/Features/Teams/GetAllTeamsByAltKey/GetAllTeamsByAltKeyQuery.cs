using NhlStatsCrm.Application.Dto;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeamsByAltKey
{
	public class GetAllTeamsByAltKeyQuery : IRequest<TeamDto>
	{
		public string TeamId;

		public GetAllTeamsByAltKeyQuery (string teamId)
		{
			TeamId = teamId;
		}
	}
}