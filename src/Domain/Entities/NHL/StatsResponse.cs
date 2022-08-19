namespace NhlStatsCrm.Domain.Entities.NHL
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