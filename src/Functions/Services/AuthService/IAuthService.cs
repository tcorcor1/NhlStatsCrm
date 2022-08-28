using System.Threading.Tasks;

namespace NhlStatsCrm.Functions.Services.AuthService
{
	public interface IAuthService
	{
		Task<string> GetAccessTokenAsync ();
	}
}