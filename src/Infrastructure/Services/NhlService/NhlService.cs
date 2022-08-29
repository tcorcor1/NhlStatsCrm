using NhlStatsCrm.Application.Common.Responses;
using NhlStatsCrm.Application.Interfaces;
using NhlStatsCrm.Domain.Entities.Nhl;

namespace NhlStatsCrm.Infrastructure.Services.NhlService
{
	public class NhlService : INhlService
	{
		private IHttpClientFactory _httpClientFactory;
		private ILogger _logger;
		private IMapper _mapper;

		public NhlService (IHttpClientFactory httpClientFactory, ILogger<NhlService> logger, IMapper mapper)
		{
			_httpClientFactory = httpClientFactory;
			_logger = logger;
			_mapper = mapper;
		}

		public async Task<NhlServiceResponse<LiveTeamsResponse>> GetLiveTeams (string? date = null)
		{
			string url = string.IsNullOrWhiteSpace(date)
				? "/api/v1/schedule"
				: $"/api/v1/schedule?date={date}"; // api/v1/schedule?date=2021-11-24

			var httpClient = _httpClientFactory.CreateClient("NHL-API");
			var response = await httpClient.GetAsync(url);

			if (!response.IsSuccessStatusCode)
				throw new HttpRequestException(response.ReasonPhrase);

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
			ArgumentNullException.ThrowIfNull(teamInfo);

			var httpClient = _httpClientFactory.CreateClient("NHL-API");

			var response = await httpClient.GetAsync($"/api/v1/teams?teamId={teamInfo.Id}&expand=team.roster");

			if (!response.IsSuccessStatusCode)
				throw new HttpRequestException(response.ReasonPhrase);

			var json = await response.Content.ReadAsStringAsync();

			var rosterResponse = JsonConvert.DeserializeObject<RosterResponse>(json);

			if (rosterResponse == null)
				return new NhlServiceResponse<RosterResponse>(response.IsSuccessStatusCode, response.StatusCode, "Invalid/empty roster response", new RosterResponse());

			return new NhlServiceResponse<RosterResponse>(response.IsSuccessStatusCode, response.StatusCode, "Success", rosterResponse);
		}

		public async Task<NhlServiceResponse<PlayerStat>> GetPlayerStat (Player player)
		{
			throw new NotImplementedException();

			//var httpClientNhl = _httpClientFactory.CreateClient("NHL-API");

			//var res = await httpClientNhl.GetAsync($"/api/v1/people/{player.Person.Id}/stats?stats=statsSingleSeason");

			//if (!res.IsSuccessStatusCode)
			//{
			//	_logger.LogError($"##GG## -- Could not get player stat - {player.Person.Id}");

			//	return new NhlServiceResponse<PlayerStat>()
			//	{
			//		StatusCode = res.StatusCode,
			//		IsSuccess = res.IsSuccessStatusCode,
			//		Message = res.ReasonPhrase,
			//		Body = null
			//	};
			//}

			//var json = await res.Content.ReadAsStringAsync();

			//var playerStatsResponse = JsonConvert.DeserializeObject<StatsResponse>(json);

			//if (playerStatsResponse.StatDetailCollection[0].Splits.Length == 0)
			//{
			//	_logger.LogError($"##GG## -- No seasons available - {player.Person.Id}");

			//	return new NhlServiceResponse<PlayerStat>()
			//	{
			//		StatusCode = HttpStatusCode.NoContent,
			//		IsSuccess = false,
			//		Message = res.ReasonPhrase,
			//		Body = null
			//	};
			//};

			//var stat = playerStatsResponse.StatDetailCollection[0].Splits[0].Stat;

			//var playerStat = _mapper.Map<PlayerStat>(
			//	stat, opt =>
			//	{
			//		opt.Items["PlayerId"] = player.Person.Id;
			//		opt.Items["SeasonName"] = playerStatsResponse.StatDetailCollection[0].Splits[0].Season;
			//	}
			//);

			//return new NhlServiceResponse<PlayerStat>()
			//{
			//	StatusCode = res.StatusCode,
			//	IsSuccess = true,
			//	Message = res.ReasonPhrase,
			//	Body = playerStat
			//};
		}
	}
}