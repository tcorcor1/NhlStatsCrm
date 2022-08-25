using NhlStatsCrm.Application.Dto;
using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Features.Players.GetAllPlayersByAltKey
{
	public class GetAllPlayersByPlayerAltKeyHandler : IRequestHandler<GetAllPlayersByPlayerAltKeyQuery, PlayerDto?>
	{
		private IDynamicsRepository<Player> _playersRepository;
		private IMapper _mapper;

		public GetAllPlayersByPlayerAltKeyHandler (IDynamicsRepository<Player> playersRepository, IMapper mapper)
		{
			_playersRepository = playersRepository;
			_mapper = mapper;
		}

		public async Task<PlayerDto?> Handle (GetAllPlayersByPlayerAltKeyQuery request, CancellationToken cancellationToken)
		{
			var response = await _playersRepository.GetByAltKeyAsync(request.PlayerId);

			var entityAttrDictionary = response.Entities.First()
				.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

			return _mapper.Map<PlayerDto>(entityAttrDictionary);
		}
	}
}