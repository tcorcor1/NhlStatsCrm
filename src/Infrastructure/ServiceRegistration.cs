using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NhlStatsCrm.Application.Interfaces.Repositories;
using NhlStatsCrm.Infrastructure.Persistence.Repositories;
using NhlStatsCrm.Domain.Entities.Crm;
using E5NhlCrm.Infrastructure.Persistence.Repositories;

namespace NhlStatsCrm.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));

			services.AddAuthorization(options =>
			{
				options.AddPolicy("RequireContributorRole",
					 policy => policy.RequireRole("NhlStatsCrm.Contributor"));
			});

			services.AddScoped<IDynamicsRepository<Team>, TeamsRepository>();
			services.AddScoped<IDynamicsRepository<Player>, PlayersRepository>();
			//services.AddScoped<IStatsRepository, StatsRepository>();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			services.AddSingleton<IOrganizationServiceAsync>(srv => new ServiceClient(configuration.GetConnectionString("DATAVERSE")));
		}
	}
}