using NhlStatsCrm.Application.Dto;

namespace NhlStatsCrm.Application.Features.Stats.GetAllStats
{
	public class GetAllStatsQuery : IRequest<IEnumerable<StatDto>>
	{
		public GetAllStatsQuery ()
		{
		}
	}
}