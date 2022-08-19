namespace NhlStatsCrm.Domain.Entities.NHL
{
	[JsonObject("roster")]
	public class RosterInfo
	{
		[JsonProperty("roster")]
		public Player[] PlayerCollection { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }
	}
}