namespace NhlStatsCrm.Domain.Entities.Nhl
{
	public class Official
	{
		[JsonProperty("official")]
		public OfficialInfo OfficialInfo { get; set; }

		[JsonProperty("officialType")]
		public string OfficialType { get; set; }
	}
}