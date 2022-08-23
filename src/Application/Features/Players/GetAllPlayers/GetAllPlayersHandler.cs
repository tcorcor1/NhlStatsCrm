//using NhlStatsCrm.Application.Interfaces.Repositories;
//using NhlStatsCrm.Domain.Entities.Crm;

//namespace NhlStatsCrm.Application.Features.Players.GetAllPlayers
//{
//	public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<Player?>>
//	{
//		private IMapper _mapper;
//		private IDynamicsRepository<Player> _playersRepository;

//		public GetAllPlayersHandler (IDynamicsRepository<Player> playersRepository, IMapper mapper)
//		{
//			_mapper = mapper;
//			_playersRepository = playersRepository;
//		}

//		public async Task<IEnumerable<Player?>> Handle (GetAllPlayersQuery request, CancellationToken cancellationToken)
//		{
//			var playersEtn = await _playersRepository.GetAllAsync();

//			return playersEtn.Select(p =>
//			{
//				return _mapper.Map<Player>(p.Attributes.ToDictionary(e => e.Key, e => e.Value));
//			});
//		}
//	}
//}