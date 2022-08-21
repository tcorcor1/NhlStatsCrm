namespace NhlStatsCrm.Application.Interfaces.Repositories
{
	public interface IDynamicsRepository<T> where T : class
	{
		Task<T?> GetByAltKeyAsync (string id);

		Task<IEnumerable<T>> GetAllAsync ();

		Task<Guid?> PatchAsync (T entity);

		//public Task DeleteAsync (string id);
	}
}