using System.ComponentModel.DataAnnotations;

namespace NhlStatsCrm.Domain.Entities.Crm
{
	public class Player
	{
		[Required]
		public string? LegacyId { get; set; }

		[Required]
		public string? FullName { get; set; }

		[Required]
		public string? TeamId { get; set; }

		public string? TeamName { get; set; }

		[Required]
		public string? Link { get; set; }

		[Required]
		public int? JerseyNumber { get; set; }

		[Required]
		public string? PositionName { get; set; }

		[Required]
		public string? PositionType { get; set; }
	}
}