using NhlStatsCrm.Domain.Entities.Crm;
using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeamsByAltKey
{
	public class GetAllTeamsByAltKeyHandler : IRequestHandler<GetAllTeamsByAltKeyQuery, Team?>
	{
		private readonly IDynamicsRepository<Team> _teamsRepository;

		public GetAllTeamsByAltKeyHandler (IDynamicsRepository<Team> teamsRepository)
		{
			_teamsRepository = teamsRepository;
		}

		public async Task<Team?> Handle (GetAllTeamsByAltKeyQuery request, CancellationToken cancellationToken)
		{
			return await _teamsRepository.GetByAltKeyAsync(request.TeamId);
		}
	}
}