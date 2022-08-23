using Microsoft.AspNetCore.Authorization;
using NhlStatsCrm.Application.Features.Players.UpsertPlayer;
using NhlStatsCrm.Domain.Entities.Crm;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize(Policy = "RequireContributorRole")]
	public class PlayersController : ControllerBase
	{
		private readonly ILogger<PlayersController> _logger;
		private readonly IMediator _mediator;

		public PlayersController (ILogger<PlayersController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		//[HttpGet("")]
		//public async Task<IActionResult> GetAllPlayers ()
		//{
		//	var query = new GetAllPlayersQuery();
		//	var result = await _mediator.Send(query);

		//	return Ok(result);
		//}

		//[HttpGet("{PlayerId}")]
		//public async Task<IActionResult> GetPlayerById (string playerId)
		//{
		//	var query = new GetAllPlayersByPlayerIdQuery(playerId);
		//	var result = await _mediator.Send(query);

		//	return Ok(result);
		//}

		[HttpPatch("")]
		public async Task<IActionResult> UpsertPlayer ([FromBody] Player player)
		{
			var command = new UpsertPlayerCommand(player);
			var guid = await _mediator.Send(command);

			return guid.Equals(null)
				? NoContent()
				: Created($"/players/{guid}", guid);
		}
	}
}