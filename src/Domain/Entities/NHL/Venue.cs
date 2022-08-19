namespace NhlStatsCrm.Domain.Entities.NHL
{
	[JsonObject("venue")]
	public class Venue
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("timeZone")]
		public Timezone TimeZone { get; set; }
	}
}