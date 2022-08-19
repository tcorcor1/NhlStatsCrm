namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("split")]
	public class Split
	{
		[JsonProperty("season")]
		public string Season { get; set; }

		[JsonProperty("stat")]
		public Stat Stat { get; set; }
	}
}