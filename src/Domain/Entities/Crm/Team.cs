using System.ComponentModel.DataAnnotations;

namespace NhlStatsCrm.Domain.Entities.Crm
{
	public class Team
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