namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("roster")]
	public class Player
	{
		[JsonProperty("person")]
		public Person Person { get; set; }

		[JsonProperty("jerseyNumber")]
		public string JerseyNumber { get; set; }

		[JsonProperty("position")]
		public Position Position { get; set; }

		[JsonProperty("teamId")]
		public int? TeamId { get; set; }
	}
}