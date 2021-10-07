using System.Threading.Tasks;
using AspJwt.Models;

namespace AspJwt.Data
{
	public interface IJwtAuthManager
	{
		string Authenticate(string userId, string email);

		User GoogleVerification(IdToken idToken);
	}
}