using Microsoft.AspNetCore.Authorization;
using NhlStatsCrm.Application.Features.Stats.GetAllStats;
using NhlStatsCrm.Application.Features.Stats.GetAllStatsByAltKey;
using NhlStatsCrm.Application.Features.Stats.UpsertPlayerStat;
using NhlStatsCrm.Domain.Entities.Nhl;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize(Policy = "RequireContributorRole")]
	public class StatsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public StatsController (IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAllStats ()
		{
			var query = new GetAllStatsQuery();
			var result = await _mediator.Send(query);

			return Ok(result);
		}

		[HttpGet("{statId}")]
		public async Task<IActionResult> GetStatByAltKey (string statId)
		{
			var query = new GetStatByAltKeyQuery(statId);
			var result = await _mediator.Send(query);

			return Ok(result);
		}

		[HttpPatch("player")]
		public async Task<IActionResult> UpsertPlayerStat ([FromBody] Stat stat)
		{
			var command = new UpsertPlayerStatCommand(stat);
			var guid = await _mediator.Send(command);

			return guid.Equals(null)
				? NoContent()
				: Created($"/stats/{guid}", guid);
		}
	}
}