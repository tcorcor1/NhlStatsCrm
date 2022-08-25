using NhlStatsCrm.Application.Dto;
using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Features.Players.GetAllPlayers
{
	public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<PlayerDto>>
	{
		private IDynamicsRepository<Player> _playersRepository;
		private IMapper _mapper;

		public GetAllPlayersHandler (IDynamicsRepository<Player> playersRepository, IMapper mapper)
		{
			_playersRepository = playersRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<PlayerDto>> Handle (GetAllPlayersQuery request, CancellationToken cancellationToken)
		{
			var response = await _playersRepository.GetAllAsync();

			return response.Entities.Select(entity =>
			{
				var entityAttrDictionary = entity.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

				return _mapper.Map<PlayerDto>(entityAttrDictionary);
			});
		}
	}
}