using NhlStatsCrm.Application.Dto;
using NhlStatsCrm.Domain.Entities.Nhl;
using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Application.Features.Stats.GetAllStats
{
	public class GetAllStatsHandler : IRequestHandler<GetAllStatsQuery, IEnumerable<StatDto>>
	{
		private readonly IDynamicsRepository<Stat> _statsRepository;
		private readonly IMapper _mapper;

		public GetAllStatsHandler (IDynamicsRepository<Stat> statsRepository, IMapper mapper)
		{
			_statsRepository = statsRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<StatDto>> Handle (GetAllStatsQuery request, CancellationToken cancellationToken)
		{
			var response = await _statsRepository.GetAllAsync();

			return response.Entities.Take(2).Select(entity =>
			{
				var entityAttrDictionary = entity.Attributes.ToDictionary(pair => pair.Key, pair => pair.Value);

				return _mapper.Map<StatDto>(entityAttrDictionary);
			});
		}
	}
}