using NhlStatsCrm.Application.Dto;

namespace NhlStatsCrm.Application.Features.Stats.GetAllStatsByAltKey
{
	public class GetStatByAltKeyQuery : IRequest<StatDto?>
	{
		public readonly string StatId;

		public GetStatByAltKeyQuery (string statId)
		{
			StatId = statId;
		}
	}
}