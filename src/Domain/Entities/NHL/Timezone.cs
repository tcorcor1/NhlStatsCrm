namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("timeZone")]
	public class Timezone
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("offset")]
		public int Offset { get; set; }

		[JsonProperty("tz")]
		public string TZ { get; set; }
	}
}