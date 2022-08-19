namespace NhlStatsCrm.Domain.Entities.Nhl
{
	public class Game
	{
		[JsonProperty("gamePk")]
		public int GamePk { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }

		[JsonProperty("gameType")]
		public string GameType { get; set; }

		[JsonProperty("season")]
		public string Season { get; set; }

		[JsonProperty("gameDate")]
		public DateTime GameDate { get; set; }

		[JsonProperty("status")]
		public Game Status { get; set; }

		[JsonProperty("teams")]
		public TeamsDetail Teams { get; set; }

		[JsonProperty("venue")]
		public Venue Venue { get; set; }

		[JsonProperty("content")]
		public Content Content { get; set; }
	}
}