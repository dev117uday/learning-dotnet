using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using PgWebApi.Models;
using PgWebApi.Settings;

namespace PgWebApi.Data
{
	public class UserRepo : IUserRepo
	{
		private static IDbConnection _db;

		public UserRepo(string cs)
		{
			_db = new NpgsqlConnection(cs);
			_db.Open();
		}

		public async Task<User> CreateUser(User user)
		{
			var sql = @"INSERT INTO users (name, email) 
                            values ( @UserName, @UserEmail) returning id";

			var result = await _db.QueryFirstOrDefaultAsync<int>(sql,
				new { UserName = user.Name, UserEmail = user.Email });
			user.Id = result;

			return user;
		}

		public async Task<bool> DeleteUser(int userId)
		{
			var sql = @"DELETE FROM users WHERE id = @Id";
			var affectedRows = await _db.ExecuteAsync(sql, new { Id = userId });
			if (affectedRows == 1)
			{
				return true;
			}

			return false;
		}

		public async Task<User> GetUserById(int userId)
		{
			User result1 = await _db.QueryFirstOrDefaultAsync<User>("SELECT * FROM users WHERE id = @Id;",
				new { Id = userId });
			return result1;
		}

		public async Task<User> UpdateUser(User user)
		{
			var sql = @"UPDATE users 
                SET name = @UserName, email = @UserEmail 
                WHERE id = @UserId;";
			var result = await _db.ExecuteAsync(sql,
				new { UserName = user.Name, UserEmail = user.Email, UserId = user.Id });
			if (result == 1)
			{
				return user;
			}
			return null;

		}
	}
}