namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("stats")]
	public class StatDetail
	{
		[JsonProperty("type")]
		public StatType StatType { get; set; }

		[JsonProperty("splits")]
		public Split[] Splits { get; set; }
	}
}