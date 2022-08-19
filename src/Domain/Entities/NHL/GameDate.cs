namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("Date")]
	public class GameDate
	{
		[JsonProperty("date")]
		public string GameDay { get; set; }

		[JsonProperty("totalItems")]
		public int TotalItems { get; set; }

		[JsonProperty("totalEvents")]
		public int TotalEvents { get; set; }

		[JsonProperty("totalGames")]
		public int TotalGames { get; set; }

		[JsonProperty("totalMatches")]
		public int TotalMatches { get; set; }

		[JsonProperty("games")]
		public Game[] Games { get; set; }

		[JsonProperty("events")]
		public object[] Events { get; set; }

		[JsonProperty("matches")]
		public object[] Matches { get; set; }
	}
}