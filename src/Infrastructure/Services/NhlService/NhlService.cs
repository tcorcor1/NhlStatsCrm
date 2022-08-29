using NhlStatsCrm.Application.Common.Responses;
using NhlStatsCrm.Application.Interfaces;
using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Infrastructure.Services.NhlService
{
	public class NhlService : INhlService
	{
		private IHttpClientFactory _httpClientFactory;
		private ILogger _logger;

		public NhlService (IHttpClientFactory httpClientFactory, ILogger<NhlService> logger)
		{
			_httpClientFactory = httpClientFactory;
			_logger = logger;
		}

		public async Task<NhlServiceResponse<LiveTeamsResponse>> GetLiveTeams (string? date = null)
		{
			string url = string.IsNullOrWhiteSpace(date)
				? "/api/v1/schedule"
				: $"/api/v1/schedule?date={date}"; // api/v1/schedule?date=2021-11-24

			var httpClient = _httpClientFactory.CreateClient("NHL-API");
			var response = await httpClient.GetAsync(url);

			if (!response.IsSuccessStatusCode)
				return new NhlServiceResponse<LiveTeamsResponse>(response.IsSuccessStatusCode, response.StatusCode, response.ReasonPhrase);

			var json = await response.Content.ReadAsStringAsync();
			var scheduleResponse = JsonConvert.DeserializeObject<ScheduleResponse>(json);

			if (scheduleResponse == null)
				return new NhlServiceResponse<LiveTeamsResponse>(response.IsSuccessStatusCode, response.StatusCode, "Invalid/empty schedule response", new LiveTeamsResponse());

			if (scheduleResponse.TotalGames == 0)
				return new NhlServiceResponse<LiveTeamsResponse>(response.IsSuccessStatusCode, response.StatusCode, "No games available", new LiveTeamsResponse());

			IEnumerable<TeamInfo> teamInfoCollection = new TeamInfo[] { };

			Game[] gamesCollection = scheduleResponse.GameDates[0].Games;

			teamInfoCollection = gamesCollection.SelectMany((game) =>
			{
				var awayTeamInfo = game.Teams.AwayTeam.Team;
				var homeTeamInfo = game.Teams.HomeTeam.Team;

				return new TeamInfo[] { awayTeamInfo, homeTeamInfo };
			});

			var liveTeamsResponse = new LiveTeamsResponse()
			{
				GameDay = scheduleResponse.GameDates[0].GameDay,
				GameCollection = gamesCollection,
				TeamInfoCollection = teamInfoCollection
			};

			return new NhlServiceResponse<LiveTeamsResponse>(response.IsSuccessStatusCode, response.StatusCode, "Success", liveTeamsResponse);
		}

		public async Task<NhlServiceResponse<RosterResponse>> GetRoster (TeamInfo teamInfo)
		{
			var httpClient = _httpClientFactory.CreateClient("NHL-API");

			var response = await httpClient.GetAsync($"/api/v1/teams?teamId={teamInfo.Id}&expand=team.roster");

			if (!response.IsSuccessStatusCode)
				return new NhlServiceResponse<RosterResponse>(response.IsSuccessStatusCode, response.StatusCode, response.ReasonPhrase);

			var json = await response.Content.ReadAsStringAsync();

			var rosterResponse = JsonConvert.DeserializeObject<RosterResponse>(json);

			if (rosterResponse == null)
				return new NhlServiceResponse<RosterResponse>(response.IsSuccessStatusCode, response.StatusCode, "Invalid/empty roster response", new RosterResponse());

			return new NhlServiceResponse<RosterResponse>(response.IsSuccessStatusCode, response.StatusCode, "Success", rosterResponse);
		}

		public async Task<NhlServiceResponse<Stat>> GetPlayerStat (Player player)
		{
			var httpClientNhl = _httpClientFactory.CreateClient("NHL-API");

			var res = await httpClientNhl.GetAsync($"/api/v1/people/{player.Person.Id}/stats?stats=statsSingleSeason");

			if (!res.IsSuccessStatusCode)
			{
				_logger.LogError($"Could not get player stat - {player.Person.Id}. Reason: {res.ReasonPhrase}");

				new NhlServiceResponse<Stat>(false, res.StatusCode, $"Could not retrieve player stat {player.Person.Id}", new Stat());
			}

			var json = await res.Content.ReadAsStringAsync();

			var playerStatsResponse = JsonConvert.DeserializeObject<StatsResponse>(json);

			if (playerStatsResponse.StatDetailCollection[0].Splits.Length == 0)
			{
				_logger.LogError($"No seasons available - {player.Person.Id}");

				return new NhlServiceResponse<Stat>(false, res.StatusCode, $"No seasons available - {player.Person.Id}", new Stat());
			};

			var stat = playerStatsResponse.StatDetailCollection[0].Splits[0].Stat;
			stat.PlayerId = player.Person.Id;
			stat.SeasonName = playerStatsResponse.StatDetailCollection[0].Splits[0].Season;

			return new NhlServiceResponse<Stat>(res.IsSuccessStatusCode, res.StatusCode, "Success", stat);
		}
	}
}