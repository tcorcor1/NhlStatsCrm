namespace NhlStatsCrm.Domain.Entities.Nhl
{
	public class GameLogPlayer : Player
	{
		[JsonProperty("stats")]
		public Dictionary<string, GameLogStat> GameLogStat { get; set; }
	}
}