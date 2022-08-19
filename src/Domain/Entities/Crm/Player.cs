namespace NhlStatsCrm.Domain.Entities.Crm
{
	public class Player
	{
		public Guid PlayerId { get; set; }
		public Guid? TeamId { get; set; }
		public string? LegacyId { get; set; }
		public string? FullName { get; set; }
		public string? BirthCountry { get; set; }
		public int? BirthDate { get; set; }
		public string? Link { get; set; }
		public string? PositionName { get; set; }
		public string? PositionType { get; set; }
		public int? JerseyNumber { get; set; }
		public int? Weight { get; set; }
		public string? Height { get; set; }
		public decimal? AvgGoals { get; set; }
		public decimal? AvgAssists { get; set; }
		public decimal? AvgPoints { get; set; }
		public decimal? AvgHits { get; set; }
		public decimal? AvgPim { get; set; }
		public decimal? AvgShots { get; set; }
	}
}