using Newtonsoft.Json;

namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("division")]
	public class Division
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("nameShort")]
		public string NameShort { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }

		[JsonProperty("abbreviation")]
		public string Abbreviation { get; set; }
	}
}