namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("gameType")]
	public class Gametype
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("postseason")]
		public bool Postseason { get; set; }
	}
}