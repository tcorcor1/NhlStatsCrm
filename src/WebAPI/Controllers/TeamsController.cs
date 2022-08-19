using Microsoft.AspNetCore.Authorization;
using NhlStatsCrm.Application.Features.Teams.GetAllTeams;
using NhlStatsCrm.Application.Features.Teams.GetAllTeamsByGuid;
using NhlStatsCrm.Application.Features.Teams.GetAllTeamsByAltKey;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize(Policy = "RequireContributorRole")]
	public class TeamsController : ControllerBase
	{
		private readonly ILogger<TeamsController> _logger;
		private readonly IMediator _mediator;

		public TeamsController (ILogger<TeamsController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpGet("")]
		public async Task<IActionResult> GetAllTeams ()
		{
			var query = new GetAllTeamsQuery();
			var result = await _mediator.Send(query);

			return Ok(result);
		}

		[HttpGet("{teamGuid:guid}")]
		public async Task<IActionResult> GetTeamByGuid (Guid teamGuid)
		{
			var query = new GetAllTeamsByTeamGuidQuery(teamGuid);
			var result = await _mediator.Send(query);

			return Ok(result);
		}

		[HttpGet("{teamId}")]
		public async Task<IActionResult> GetTeamById (string teamId)
		{
			var query = new GetAllTeamsByAltKeyQuery(teamId);
			var result = await _mediator.Send(query);

			return Ok(result);
		}
	}
}