﻿namespace NhlStatsCrm.Domain.Entities.NHL
{
	[JsonObject("franchise")]
	public class Franchise
	{
		[JsonProperty("franchiseId")]
		public int FranchiseId { get; set; }

		[JsonProperty("teamName")]
		public string TeamName { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }
	}
}