using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace NhlStatsCrm.Functions.Services.AuthService
{
	internal class AuthService : IAuthService
	{
		private IConfidentialClientApplication _client;
		private string[] _scopes = new string[] { Environment.GetEnvironmentVariable("SCOPE") };

		public AuthService ()
		{
			_client = ConfidentialClientApplicationBuilder.Create(Environment.GetEnvironmentVariable("CLIENT_ID"))
				.WithClientSecret(Environment.GetEnvironmentVariable("CLIENT_SECRET"))
				.WithAuthority(new Uri(Environment.GetEnvironmentVariable("AUTH_URI")))
				.Build();
		}

		public async Task<string> GetAccessTokenAsync ()
		{
			var authResult = await _client.AcquireTokenForClient(_scopes).ExecuteAsync();

			return authResult.AccessToken;
		}
	}
}