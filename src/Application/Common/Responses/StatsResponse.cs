using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Common.Responses
{
	[JsonObject("Rootobject")]
	public class StatsResponse
	{
		[JsonProperty("copyright")]
		public string Copyright { get; set; }

		[JsonProperty("stats")]
		public StatDetail[] StatDetailCollection { get; set; }
	}
}