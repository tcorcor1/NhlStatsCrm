//using NhlStatsCrm.Application.Interfaces.Repositories;
//using NhlStatsCrm.Domain.Entities.Crm;

//namespace NhlStatsCrm.Application.Features.Players.GetAllPlayersByAltKey
//{
//	public class GetAllPlayersByPlayerAltKeyHandler : IRequestHandler<GetAllPlayersByPlayerAltKeyQuery, Player>
//	{
//		private IMapper _mapper;
//		private IDynamicsRepository<Player> _playersRepository;

//		public GetAllPlayersByPlayerAltKeyHandler (IDynamicsRepository<Player> playersRepository, IMapper mapper)
//		{
//			_mapper = mapper;
//			_playersRepository = playersRepository;
//		}

//		public async Task<Player> Handle (GetAllPlayersByPlayerAltKeyQuery request, CancellationToken cancellationToken)
//		{
//			var playerEtn = await _playersRepository.GetByAltKeyAsync(request.PlayerId);

//			var playerDic = playerEtn.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

//			return _mapper.Map<Player>(playerDic);
//		}
//	}
//}