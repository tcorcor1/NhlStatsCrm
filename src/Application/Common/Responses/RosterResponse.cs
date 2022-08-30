using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Application.Common.Responses
{
	[JsonObject("Rootobject")]
	public class RosterResponse
	{
		[JsonProperty("copyright")]
		public string Copyright { get; set; } = String.Empty;

		[JsonProperty("teams")]
		public Team[] Teams { get; set; } = new Team[] { };
	}
}