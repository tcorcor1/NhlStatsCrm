using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Common.Responses
{
	public class LiveTeamsResponse
	{
		public string? GameDay;
		public IEnumerable<Game>? GameCollection;
		public IEnumerable<TeamInfo>? TeamInfoCollection;
	}
}