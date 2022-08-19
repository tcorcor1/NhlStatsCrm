namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("type")]
	public class StatType
	{
		[JsonProperty("displayName")]
		public string DisplayName { get; set; }

		[JsonProperty("gameType")]
		public Gametype GameType { get; set; }
	}
}