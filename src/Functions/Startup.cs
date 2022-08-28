using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using NhlStatsCrm.Infrastructure.Services.NhlService;
using NhlStatsCrm.Application.Interfaces;
using NhlStatsCrm.Functions.Services.AuthService;

[assembly: FunctionsStartup(typeof(Functions.Startup))]

namespace Functions
{
	public class Startup : FunctionsStartup
	{
		public override void Configure (IFunctionsHostBuilder builder)
		{
			ArgumentNullException.ThrowIfNull(builder);

			builder.Services.AddHttpClient("NHL-API", c =>
			{
				c.BaseAddress = new Uri("https://statsapi.web.nhl.com");
				c.DefaultRequestHeaders.Add("Accept", "application/json");
			});

			builder.Services.AddHttpClient("NhlStatsCrm", c =>
			{
				c.BaseAddress = new Uri(Environment.GetEnvironmentVariable("NHL_STATS_CRM"));
				c.DefaultRequestHeaders.Add("Accept", "application/json; charset=utf8");
			});

			builder.Services.AddScoped<INhlService, NhlService>();
			builder.Services.AddScoped<IAuthService, AuthService>();

			//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			//builder.Services.AddSingleton<IOrganizationServiceAsync>(srv => new ServiceClient(Environment.GetEnvironmentVariable("DATAVERSE")));
		}
	}
}