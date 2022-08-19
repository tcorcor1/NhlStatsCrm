using NhlStatsCrm.Domain.Entities.Crm;

namespace NhlStatsCrm.Application.Interfaces.Repositories
{
	public interface ITeamsRepository : IDynamicsRepository<Team>
	{
		Task<Team?> GetByAltKeyAsync (string id);

		Task<Guid?> PatchAsync (Team team);
	}
}