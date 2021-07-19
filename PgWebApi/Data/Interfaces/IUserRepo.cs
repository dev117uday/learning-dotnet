using System.Threading.Tasks;
using PgWebApi.Models;

namespace PgWebApi.Data
{
	public interface IUserRepo
	{
		Task<User> CreateUser(User user);
		Task<User> GetUserById(int userId);
		Task<User> UpdateUser(User user);
		Task<bool> DeleteUser(int userId);
	}
}