using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeams
{
	public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsQuery, IEnumerable<Team>>
	{
		private readonly ITeamsRepository _teamsRepository;

		public GetAllTeamsHandler (ITeamsRepository teamsRepository)
		{
			_teamsRepository = teamsRepository;
		}

		public async Task<IEnumerable<Team>> Handle (GetAllTeamsQuery request, CancellationToken cancellationToken)
		{
			return await _teamsRepository.GetAllAsync();
		}
	}
}