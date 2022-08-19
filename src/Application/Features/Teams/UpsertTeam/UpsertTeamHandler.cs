using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Application.Features.Teams.UpsertTeam
{
	public class UpsertTeamHandler : IRequestHandler<UpsertTeamCommand, Guid?>
	{
		private readonly ITeamsRepository _teamsRepository;

		public UpsertTeamHandler (ITeamsRepository teamsRepository)
		{
			_teamsRepository = teamsRepository;
		}

		public async Task<Guid?> Handle (UpsertTeamCommand request, CancellationToken cancellationToken)
		{
			return await _teamsRepository.PatchAsync(request.Team);
		}
	}
}