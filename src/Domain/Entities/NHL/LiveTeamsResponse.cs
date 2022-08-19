namespace NhlStatsCrm.Domain.Entities.Nhl
{
	public class LiveTeamsResponse
	{
		public string? GameDay;
		public IEnumerable<Game>? GameCollection;
		public IEnumerable<TeamInfo>? TeamInfoCollection;
	}
}