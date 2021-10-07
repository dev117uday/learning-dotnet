using System.Threading.Tasks;
using AspJwt.Models;

namespace AspJwt.Data
{
	public interface IUserRepo
	{
		Task CreateUser(User user);
	}
}