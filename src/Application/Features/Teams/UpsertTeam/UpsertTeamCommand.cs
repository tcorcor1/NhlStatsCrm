using NhlStatsCrm.Domain.Entities.Nhl;

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