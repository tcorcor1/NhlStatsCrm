using NhlStatsCrm.Domain.Entities.Nhl;
using NhlStatsCrm.Application.Interfaces.Repositories;

namespace NhlStatsCrm.Application.Features.Stats.UpsertPlayerStat
{
	public class UpsertPlayerStatHandler : IRequestHandler<UpsertPlayerStatCommand, Guid?>
	{
		private readonly IDynamicsRepository<Stat> _statsRepository;

		public UpsertPlayerStatHandler (IDynamicsRepository<Stat> statsRepository)
		{
			_statsRepository = statsRepository;
		}

		public async Task<Guid?> Handle (UpsertPlayerStatCommand request, CancellationToken cancellationToken)
		{
			return await _statsRepository.PatchAsync(request.Stat);
		}
	}
}