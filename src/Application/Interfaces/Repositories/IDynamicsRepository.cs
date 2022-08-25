namespace NhlStatsCrm.Application.Interfaces.Repositories
{
	public interface IDynamicsRepository<T> where T : class
	{
		Task<EntityCollection> GetByAltKeyAsync (string id);

		Task<EntityCollection> GetAllAsync ();

		Task<Guid?> PatchAsync (T entity);

		//public Task DeleteAsync (string id);
	}
}