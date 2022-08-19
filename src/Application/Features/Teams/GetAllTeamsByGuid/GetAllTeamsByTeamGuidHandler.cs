using NhlStatsCrm.Domain.Entities.Crm;
using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeamsByGuid
{
	public class GetAllTeamsByTeamGuidHandler : IRequestHandler<GetAllTeamsByTeamGuidQuery, Team>
	{
		private readonly ITeamsRepository _teamsRepository;

		public GetAllTeamsByTeamGuidHandler (ITeamsRepository teamsRepository)
		{
			_teamsRepository = teamsRepository;
		}

		public async Task<Team> Handle (GetAllTeamsByTeamGuidQuery request, CancellationToken cancellationToken)
		{
			return await _teamsRepository.GetByGuidAsync(request.TeamGuid);
		}
	}
}