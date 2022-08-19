namespace NhlStatsCrm.Domain.Entities.NHL
{
	public class LiveTeamsResponse
	{
		public string? GameDay;
		public IEnumerable<Game>? GameCollection;
		public IEnumerable<TeamInfo>? TeamInfoCollection;
	}
}