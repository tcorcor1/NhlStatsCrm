using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeamsByAltKey
{
	public class GetAllTeamsByAltKeyQuery : IRequest<Team?>
	{
		public string TeamId;

		public GetAllTeamsByAltKeyQuery (string teamId)
		{
			TeamId = teamId;
		}
	}
}