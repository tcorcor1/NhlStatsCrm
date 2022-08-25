using System.ComponentModel.DataAnnotations;

namespace NhlStatsCrm.Application.Dto
{
	public class TeamDto
	{
		[Required]
		public string LegacyId { get; set; }

		[Required]
		public string FranchiseId { get; set; }

		public string? TeamName { get; set; }

		public string? ShortName { get; set; }

		public string? Link { get; set; }

		public string? Abbreviation { get; set; }
	}
}