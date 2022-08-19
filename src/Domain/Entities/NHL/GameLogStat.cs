namespace NhlStatsCrm.Domain.Entities.NHL
{
	[JsonObject("skaterStats")]
	public class GameLogStat
	{
		public int PlayerId { get; set; }

		public DateTime Date { get; set; }

		public string? GameType { get; set; }

		[JsonProperty("faceOffWins")]
		public int FaceOffWins { get; set; }

		[JsonProperty("faceoffTaken")]
		public int FaceoffTaken { get; set; }

		[JsonProperty("takeaways")]
		public int Takeaways { get; set; }

		[JsonProperty("giveaways")]
		public int Giveaways { get; set; }

		[JsonProperty("powerPlayAssists")]
		public int PowerPlayAssists { get; set; }

		[JsonProperty("shortHandedAssists")]
		public int ShortHandedAssists { get; set; }

		[JsonProperty("timeOnIce")]
		public string? TimeOnIce { get; set; }

		[JsonProperty("assists")]
		public int Assists { get; set; }

		[JsonProperty("goals")]
		public int Goals { get; set; }

		[JsonProperty("pim")]
		public int Pim { get; set; }

		[JsonProperty("shots")]
		public int Shots { get; set; }

		[JsonProperty("games")]
		public int Games { get; set; }

		[JsonProperty("hits")]
		public int Hits { get; set; }

		[JsonProperty("powerPlayGoals")]
		public int PowerPlayGoals { get; set; }

		[JsonProperty("powerPlayPoints")]
		public int PowerPlayPoints { get; set; }

		[JsonProperty("powerPlayTimeOnIce")]
		public string? PowerPlayTimeOnIce { get; set; }

		[JsonProperty("evenTimeOnIce")]
		public string? EvenTimeOnIce { get; set; }

		[JsonProperty("penaltyMinutes")]
		public string? PenaltyMinutes { get; set; }

		[JsonProperty("faceOffPct")]
		public float FaceOffPct { get; set; }

		[JsonProperty("shotPct")]
		public float ShotPct { get; set; }

		[JsonProperty("gameWinningGoals")]
		public int GameWinningGoals { get; set; }

		[JsonProperty("overTimeGoals")]
		public int OverTimeGoals { get; set; }

		[JsonProperty("shortHandedGoals")]
		public int ShortHandedGoals { get; set; }

		[JsonProperty("shortHandedPoints")]
		public int ShortHandedPoints { get; set; }

		[JsonProperty("shortHandedTimeOnIce")]
		public string? ShortHandedTimeOnIce { get; set; }

		[JsonProperty("blocked")]
		public int Blocked { get; set; }

		[JsonProperty("plusMinus")]
		public int PlusMinus { get; set; }

		[JsonProperty("points")]
		public int Points { get; set; }

		[JsonProperty("shifts")]
		public int Shifts { get; set; }

		[JsonProperty("timeOnIcePerGame")]
		public string? TimeOnIcePerGame { get; set; }

		[JsonProperty("evenTimeOnIcePerGame")]
		public string? EvenTimeOnIcePerGame { get; set; }

		[JsonProperty("shortHandedTimeOnIcePerGame")]
		public string? ShortHandedTimeOnIcePerGame { get; set; }

		[JsonProperty("powerPlayTimeOnIcePerGame")]
		public string? PowerPlayTimeOnIcePerGame { get; set; }

		[JsonProperty("gamesStarted")]
		public int GamesStarted { get; set; }

		[JsonProperty("goalAgainstAverage")]
		public decimal GoalsAgainstAverage { get; set; }

		[JsonProperty("savePercentage")]
		public decimal SavePercentage { get; set; }

		[JsonProperty("shotsAgainst")]
		public int ShotsAgainst { get; set; }

		[JsonProperty("goalsAgainst")]
		public int GoalsAgainst { get; set; }

		[JsonProperty("saves")]
		public int Saves { get; set; }

		[JsonProperty("wins")]
		public int Wins { get; set; }

		[JsonProperty("losses")]
		public int Losses { get; set; }

		[JsonProperty("shutouts")]
		public int Shutouts { get; set; }

		[JsonProperty("evenStrengthSavePercentage")]
		public decimal EvenStrengthSavePercentage { get; set; }

		[JsonProperty("powerPlaySavePercentage")]
		public decimal PowerPlaySavePercentage { get; set; }

		[JsonProperty("shortHandedSavePercentage")]
		public decimal ShortHandedSavePercentage { get; set; }
	}
}