using NhlStatsCrm.Domain.Entities.Crm;
using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeamsByAltKey
{
	public class GetAllTeamsByAltKeyHandler : IRequestHandler<GetAllTeamsByAltKeyQuery, Team>
	{
		private readonly ITeamsRepository _teamsRepository;

		public GetAllTeamsByAltKeyHandler (ITeamsRepository teamsRepository)
		{
			_teamsRepository = teamsRepository;
		}

		public async Task<Team> Handle (GetAllTeamsByAltKeyQuery request, CancellationToken cancellationToken)
		{
			return await _teamsRepository.GetByAltKeyAsync(request.TeamId);
		}
	}
}