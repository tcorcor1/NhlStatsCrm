using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Features.Players.UpsertPlayer
{
	public class UpsertPlayerHandler : IRequestHandler<UpsertPlayerCommand, Guid?>
	{
		private IDynamicsRepository<Player> _playersRepository;

		public UpsertPlayerHandler (IDynamicsRepository<Player> playersRepository)
		{
			_playersRepository = playersRepository;
		}

		public async Task<Guid?> Handle (UpsertPlayerCommand request, CancellationToken cancellationToken)
		{
			return await _playersRepository.PatchAsync(request.Player);
		}
	}
}