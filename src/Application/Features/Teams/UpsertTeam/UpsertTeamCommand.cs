using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Features.Teams.UpsertTeam
{
	public class UpsertTeamCommand : IRequest<Guid?>
	{
		public Team Team;

		public UpsertTeamCommand (Team team)
		{
			Team = team;
		}
	}
}