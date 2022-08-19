using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Features.Teams.GetAllTeamsByGuid
{
	public class GetAllTeamsByTeamGuidQuery : IRequest<Team>
	{
		public Guid TeamGuid;

		public GetAllTeamsByTeamGuidQuery (Guid teamGuid)
		{
			TeamGuid = teamGuid;
		}
	}
}