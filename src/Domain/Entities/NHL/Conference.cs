namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("conference")]
	public class Conference
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }
	}
}