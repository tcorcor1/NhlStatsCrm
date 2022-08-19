namespace NhlStatsCrm.Application.Interfaces.Repositories
{
	public interface IDynamicsRepository<T> where T : class
	{
		public Task<T> GetByGuidAsync (Guid id);

		public Task<IEnumerable<T>> GetAllAsync ();

		//public Task DeleteAsync (string id);
	}
}