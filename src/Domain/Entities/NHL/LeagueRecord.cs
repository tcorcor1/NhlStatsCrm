namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("Leaguerecord")]
	public class LeagueRecord
	{
		[JsonProperty("wins")]
		public int Wins { get; set; }

		[JsonProperty("losses")]
		public int Losses { get; set; }

		[JsonProperty("ot")]
		public int OT { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}