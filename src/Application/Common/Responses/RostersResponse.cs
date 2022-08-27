using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Common.Responses
{
	[JsonObject("Rootobject")]
	public class RostersResponse
	{
		[JsonProperty("copyright")]
		public string Copyright { get; set; }

		[JsonProperty("teams")]
		public Team[] Teams { get; set; }
	}
}