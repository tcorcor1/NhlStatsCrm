namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("Rootobject")]
	public class StatsResponse
	{
		[JsonProperty("copyright")]
		public string Copyright { get; set; }

		[JsonProperty("stats")]
		public StatDetail[] StatDetailCollection { get; set; }
	}
}