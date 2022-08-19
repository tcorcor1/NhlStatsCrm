namespace NhlStatsCrm.Domain.Entities.NHL
{
	[JsonObject("position")]
	public class Position
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("abbreviation")]
		public string Abbreviation { get; set; }
	}
}