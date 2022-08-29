using NhlStatsCrm.Domain.Entities.Nhl;
using NhlStatsCrm.Application.Common.Responses;

namespace NhlStatsCrm.Application.Interfaces
{
	public interface INhlService
	{
		Task<NhlServiceResponse<LiveTeamsResponse>> GetLiveTeams (string? date = null);

		Task<NhlServiceResponse<RosterResponse>> GetRoster (TeamInfo teaminfo);

		Task<NhlServiceResponse<Stat>> GetPlayerStat (Player player);
	}
}