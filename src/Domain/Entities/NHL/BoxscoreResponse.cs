namespace NhlStatsCrm.Domain.Entities.NHL
{
	[JsonObject("Rootobject")]
	public class BoxscoreResponse
	{
		[JsonProperty("copyright")]
		public string Copyright { get; set; }

		[JsonProperty("officials")]
		public Official[] Officials { get; set; }

		[JsonProperty("teams")]
		public TeamsDetail Teams { get; set; }
	}
}