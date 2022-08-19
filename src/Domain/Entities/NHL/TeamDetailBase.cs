namespace NhlStatsCrm.Domain.Entities.NHL
{
	public abstract class TeamDetailBase
	{
		[JsonProperty("leagueRecord")]
		public LeagueRecord LeagueRecord { get; set; }

		[JsonProperty("score")]
		public int Score { get; set; }

		[JsonProperty("team")]
		public TeamInfo Team { get; set; }

		/// <summary>
		/// This will only be provided from the BoxscoreResponse
		/// </summary>
		[JsonProperty("players")]
		public Dictionary<string, GameLogPlayer> GameLogPlayers { get; set; }
	}
}