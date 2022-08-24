using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Features.Players.GetAllPlayersByAltKey
{
	public class GetAllPlayersByPlayerAltKeyHandler : IRequestHandler<GetAllPlayersByPlayerAltKeyQuery, Player?>
	{
		private IDynamicsRepository<Player> _playersRepository;

		public GetAllPlayersByPlayerAltKeyHandler (IDynamicsRepository<Player> playersRepository)
		{
			_playersRepository = playersRepository;
		}

		public async Task<Player?> Handle (GetAllPlayersByPlayerAltKeyQuery request, CancellationToken cancellationToken)
		{
			return await _playersRepository.GetByAltKeyAsync(request.PlayerId);
		}
	}
}