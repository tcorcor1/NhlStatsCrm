using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Features.Players.GetAllPlayers
{
	public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<Player?>>
	{
		private IDynamicsRepository<Player> _playersRepository;

		public GetAllPlayersHandler (IDynamicsRepository<Player> playersRepository)
		{
			_playersRepository = playersRepository;
		}

		public async Task<IEnumerable<Player?>> Handle (GetAllPlayersQuery request, CancellationToken cancellationToken)
		{
			return await _playersRepository.GetAllAsync();
		}
	}
}