using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Features.Stats.UpsertPlayerStat
{
	public class UpsertPlayerStatCommand : IRequest<Guid?>
	{
		public Stat Stat;

		public UpsertPlayerStatCommand (Stat stat)
		{
			Stat = stat;
		}
	}
}