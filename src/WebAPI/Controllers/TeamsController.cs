using Microsoft.AspNetCore.Authorization;
using NhlStatsCrm.Domain.Entities.Nhl;
using NhlStatsCrm.Application.Features.Teams.GetAllTeams;
using NhlStatsCrm.Application.Features.Teams.GetAllTeamsByAltKey;
using NhlStatsCrm.Application.Features.Teams.UpsertTeam;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize(Policy = "RequireContributorRole")]
	public class TeamsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TeamsController (IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAllTeams ()
		{
			var query = new GetAllTeamsQuery();
			var result = await _mediator.Send(query);

			return Ok(result);
		}

		[HttpGet("{teamId}")]
		public async Task<IActionResult> GetTeamByAltKey (string teamId)
		{
			var query = new GetAllTeamsByAltKeyQuery(teamId);
			var result = await _mediator.Send(query);

			return Ok(result);
		}

		[HttpPatch("")]
		public async Task<IActionResult> UpsertTeam ([FromBody] Team team)
		{
			var command = new UpsertTeamCommand(team);
			var guid = await _mediator.Send(command);

			return guid.Equals(null)
				? NoContent()
				: Created($"/teams/{guid}", guid);
		}
	}
}