namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("Rootobject")]
	public class ScheduleResponse
	{
		[JsonProperty("copyright")]
		public string Copyright { get; set; }

		[JsonProperty("totalItems")]
		public int TotalItems { get; set; }

		[JsonProperty("totalEvents")]
		public int TotalEvents { get; set; }

		[JsonProperty("totalGames")]
		public int TotalGames { get; set; }

		[JsonProperty("totalMatches")]
		public int TotalMatches { get; set; }

		[JsonProperty("metaData")]
		public Metadata MetaData { get; set; }

		[JsonProperty("wait")]
		public int Wait { get; set; }

		[JsonProperty("dates")]
		public GameDate[] GameDates { get; set; }
	}
}