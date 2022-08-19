namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("content")]
	public class Content
	{
		[JsonProperty("link")]
		public string Link { get; set; }
	}
}