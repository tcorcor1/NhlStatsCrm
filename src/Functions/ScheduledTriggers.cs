using System.Text;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using NhlStatsCrm.Domain.Entities.Nhl;
using NhlStatsCrm.Application.Interfaces;
using NhlStatsCrm.Functions.Services.AuthService;

namespace NhlStatsCrm.Functions
{
	public class ScheduledTriggers : ControllerBase
	{
		private IHttpClientFactory _httpClientFactory;
		private INhlService _nhlService;
		private IAuthService _authService;

		public ScheduledTriggers (IHttpClientFactory httpClientFactory, INhlService nhlService, IAuthService authService)
		{
			_httpClientFactory = httpClientFactory;
			_nhlService = nhlService;
			_authService = authService;
		}

		[FunctionName("PatchPlayersMessage")]
		public async Task RunPatchPlayers ([TimerTrigger("0 0 6 * * *")] TimerInfo myTimer, ILogger log)
		{
			var liveTeamsRes = await _nhlService.GetLiveTeams();

			if (!liveTeamsRes.IsSuccess || liveTeamsRes.Body.GameCollection.Count() == 0)
				return;

			var playersCollection = new List<Player>();

			foreach (var team in liveTeamsRes.Body.TeamInfoCollection)
			{
				var rosterRes = await _nhlService.GetRoster(team);

				if (!rosterRes.IsSuccess)
				{
					log.LogError($"Could not retrieve roster for team: {team.Name}/{team.Id}. Error: {rosterRes.Message}");
					continue;
				}

				var updateRosterTeamId = rosterRes.Body.Teams[0].RosterInfo.PlayerCollection
					.Select(player =>
					{
						player.TeamId = team.Id;
						return player;
					})
					.ToList();

				playersCollection.AddRange(updateRosterTeamId);
			}

			var httpClient = _httpClientFactory.CreateClient("NhlStatsCrm");

			var accessToken = await _authService.GetAccessTokenAsync();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			foreach (var p in playersCollection)
			{
				var content = new StringContent(
					JsonConvert.SerializeObject(p),
					Encoding.UTF8,
					"application/json"
				);

				var res = await httpClient.PatchAsync("/api/players", content);

				if (!res.IsSuccessStatusCode)
					log.LogError($"Could not patch player: {p.Person.FullName}. Error: {res.ReasonPhrase}");
			}
		}

		[FunctionName("PatchPlayerStatsMessage")]
		public async Task RunPatchPlayerStats ([TimerTrigger("0 0 8 * * *")] TimerInfo myTimer, ILogger log)
		{
			var liveTeamsRes = await _nhlService.GetLiveTeams();

			if (!liveTeamsRes.IsSuccess || liveTeamsRes.Body.GameCollection.Count() == 0)
				return;

			var playersCollection = new List<Player>();

			foreach (var team in liveTeamsRes.Body.TeamInfoCollection)
			{
				var rosterRes = await _nhlService.GetRoster(team);

				if (!rosterRes.IsSuccess)
				{
					log.LogError($"Could not retrieve roster for team: {team.Name}/{team.Id}. Error: {rosterRes.Message}");
					continue;
				}

				var updateRosterTeamId = rosterRes.Body.Teams[0].RosterInfo.PlayerCollection
					.Select(player =>
					{
						player.TeamId = team.Id;
						return player;
					})
					.ToList();

				playersCollection.AddRange(updateRosterTeamId);
			}

			var playerStatCollection = new List<Stat>();

			foreach (var player in playersCollection)
			{
				var playerStatRes = await _nhlService.GetPlayerStat(player);

				if (playerStatRes.IsSuccess)
					playerStatCollection.Add(playerStatRes.Body);
			}

			var httpClient = _httpClientFactory.CreateClient("NhlStatsCrm");

			var accessToken = await _authService.GetAccessTokenAsync();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			foreach (var playerStat in playerStatCollection)
			{
				var content = new StringContent(
					JsonConvert.SerializeObject(playerStat),
					Encoding.UTF8,
					"application/json"
				);

				var res = await httpClient.PatchAsync("/api/stats/player", content);

				if (!res.IsSuccessStatusCode)
					log.LogError($"Could not patch stats for: {playerStat.PlayerId}. Error: {res.ReasonPhrase}");
			}
		}
	}
}