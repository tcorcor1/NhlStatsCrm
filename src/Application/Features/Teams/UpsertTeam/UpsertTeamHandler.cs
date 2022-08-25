using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Features.Teams.UpsertTeam
{
	public class UpsertTeamHandler : IRequestHandler<UpsertTeamCommand, Guid?>
	{
		private readonly IDynamicsRepository<Team> _teamsRepository;

		public UpsertTeamHandler (IDynamicsRepository<Team> teamsRepository)
		{
			_teamsRepository = teamsRepository;
		}

		public async Task<Guid?> Handle (UpsertTeamCommand request, CancellationToken cancellationToken)
		{
			return await _teamsRepository.PatchAsync(request.Team);
		}
	}
}