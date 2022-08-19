namespace NhlStatsCrm.Domain.Entities.NHL
{
	[JsonObject("Teams")]
	public class TeamsDetail
	{
		[JsonProperty("away")]
		public AwayTeamDetail AwayTeam { get; set; }

		[JsonProperty("home")]
		public HomeTeamDetail HomeTeam { get; set; }
	}
}