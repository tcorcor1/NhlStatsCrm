namespace NhlStatsCrm.Domain.Entities.NHL
{
	[JsonObject("content")]
	public class Content
	{
		[JsonProperty("link")]
		public string Link { get; set; }
	}
}