namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("Rootobject")]
	public class RostersResponse
	{
		[JsonProperty("copyright")]
		public string Copyright { get; set; }

		[JsonProperty("teams")]
		public Team[] Teams { get; set; }
	}
}