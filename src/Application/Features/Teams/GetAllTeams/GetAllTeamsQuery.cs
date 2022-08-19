using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeams
{
	public class GetAllTeamsQuery : IRequest<IEnumerable<Team>>
	{
	}
}