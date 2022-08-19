namespace NhlStatsCrm.Domain.Entities.NHL
{
	public class Official
	{
		[JsonProperty("official")]
		public OfficialInfo OfficialInfo { get; set; }

		[JsonProperty("officialType")]
		public string OfficialType { get; set; }
	}
}