using System;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Http;
using NhlStatsCrm.Domain.Entities.Nhl;
using NhlStatsCrm.Application.Interfaces;

namespace Functions
{
	public class TestTriggers : ControllerBase
	{
		private IHttpClientFactory _httpClientFactory;
		private INhlService _nhlService;

		public TestTriggers (IHttpClientFactory httpClientFactory, INhlService nhlService)
		{
			_httpClientFactory = httpClientFactory;
			_nhlService = nhlService;
		}

		[FunctionName("PatchPlayers")]
		public async Task<IActionResult> RunPatchPlayers (
			[HttpTrigger(AuthorizationLevel.Function, "get", Route = "players/{date?}")] HttpRequest req, ILogger log, string date = null)
		{
			var liveTeamsRes = await _nhlService.GetLiveTeams(date); //2021-11-19

			var playersCollection = new List<Player>();

			foreach (var team in liveTeamsRes.Body.TeamInfoCollection)
			{
				var rosterRes = await _nhlService.GetRoster(team);

				var updateRosterTeamId = rosterRes.Body.Teams[0].RosterInfo.PlayerCollection
					.Select(player =>
					{
						player.TeamId = team.Id;
						return player;
					})
					.ToList();

				playersCollection.AddRange(updateRosterTeamId);
			}

			//var httpClient = _httpClientFactory.CreateClient("NhlStatsCrm");

			//foreach (var p in playersCollection)
			//{
			//	var content = new StringContent(
			//		JsonConvert.SerializeObject(p),
			//		Encoding.UTF8,
			//		"application/json"
			//	);

			//	var res = await httpClient.PatchAsync("/api/players", content);

			//	if (!res.IsSuccessStatusCode)
			//		log.LogError($"Could not patch player: {p.Person.FullName}. Error: {res.ReasonPhrase}");
			//}

			return Ok();
		}

		[FunctionName("PatchStats")]
		public async Task<IActionResult> RunPatchStats (
			[HttpTrigger(AuthorizationLevel.Function, "get", Route = "stats/player/{date?}")] HttpRequest req, ILogger log, string date = null)
		{
			var liveTeamsRes = await _nhlService.GetLiveTeams(date); //2021-11-19

			//var playersCollection = new List<Player>();

			//foreach (var team in liveTeamsRes.Body.TeamInfoCollection)
			//{
			//	var rosterRes = await _nhlService.GetRoster(team);

			//	var updateRosterTeamId = rosterRes.Body.Teams[0].RosterInfo.PlayerCollection
			//		.Select(player =>
			//		{
			//			player.TeamId = team.Id;
			//			return player;
			//		})
			//		.ToList();

			//	playersCollection.AddRange(updateRosterTeamId);
			//}

			//var playerStatCollection = new List<PlayerStat>();

			//foreach (var player in playersCollection)
			//{
			//	var playerStatRes = await _nhlService.GetPlayerStat(player);

			//	if (playerStatRes.IsSuccess)
			//		playerStatCollection.Add(playerStatRes.Body);
			//}

			//var httpClientGateway = _httpClientFactory.CreateClient("E5-Gateway");

			//foreach (var playerStat in playerStatCollection)
			//{
			//	var content = new StringContent(
			//		JsonConvert.SerializeObject(playerStat),
			//		Encoding.UTF8,
			//		"application/json"
			//	);

			//	var res = await httpClientGateway.PatchAsync("/api/stats/player", content);

			//	if (!res.IsSuccessStatusCode)
			//		log.LogError($"Could not patch stats for: {playerStat.PlayerId}. Error: {res.ReasonPhrase}");
			//}

			return Ok();
		}
	}
}