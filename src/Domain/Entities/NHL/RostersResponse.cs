namespace NhlStatsCrm.Domain.Entities.NHL
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