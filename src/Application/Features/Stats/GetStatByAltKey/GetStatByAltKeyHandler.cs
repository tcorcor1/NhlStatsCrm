using NhlStatsCrm.Application.Dto;
using NhlStatsCrm.Domain.Entities.Nhl;
using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Application.Features.Stats.GetAllStatsByAltKey
{
	public class GetStatByAltKeyHandler : IRequestHandler<GetStatByAltKeyQuery, StatDto?>
	{
		private readonly IDynamicsRepository<Stat> _statsRepository;
		private readonly IMapper _mapper;

		public GetStatByAltKeyHandler (IDynamicsRepository<Stat> statsRepository, IMapper mapper)
		{
			_statsRepository = statsRepository;
			_mapper = mapper;
		}

		public async Task<StatDto?> Handle (GetStatByAltKeyQuery request, CancellationToken cancellationToken)
		{
			var response = await _statsRepository.GetByAltKeyAsync(request.StatId);

			var entityAttrDictionary = response.Entities.First()
				.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

			return _mapper.Map<StatDto>(entityAttrDictionary);
		}
	}
}