namespace NhlStatsCrm.Domain.Entities.NHL
{
	public class GameLogPlayer : Player
	{
		[JsonProperty("stats")]
		public Dictionary<string, GameLogStat> GameLogStat { get; set; }
	}
}