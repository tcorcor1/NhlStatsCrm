using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Common.Responses
{
	public class LiveTeamsResponse
	{
		public string GameDay = String.Empty;
		public IEnumerable<Game> GameCollection = new List<Game> { };
		public IEnumerable<TeamInfo> TeamInfoCollection = new List<TeamInfo> { };
	}
}