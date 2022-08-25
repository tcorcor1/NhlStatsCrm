namespace NhlStatsCrm.Application
{
	public static class ServiceRegistration
	{
		public static void AddApplicationServices (this IServiceCollection services)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		}
	}
}