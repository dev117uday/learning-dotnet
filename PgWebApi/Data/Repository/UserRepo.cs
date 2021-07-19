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
		static private IDbConnection db;

		public UserRepo(IConfiguration configuration)
		{
			var pgSettings = configuration.GetSection(nameof(PgSettings)).Get<PgSettings>();
			db = new NpgsqlConnection(pgSettings.ConnectionString);
			db.Open();
		}

		public async Task<User> CreateUser(User user)
		{
			var sql = @"INSERT INTO users (name, email) 
                            values ( @UserName, @UserEmail) returning id";

			var result = await db.QueryFirstOrDefaultAsync<int>(sql,
				new { UserName = user.Name, UserEmail = user.Email });
			user.Id = result;

			return user;
		}

		public async Task<bool> DeleteUser(int userId)
		{
			var sql = @"DELETE FROM users WHERE id = @Id";
			var affectedRows = await db.ExecuteAsync(sql, new { Id = userId });
			if (affectedRows == 1)
			{
				return true;
			}

			return false;
		}

		public async Task<User> GetUserById(int userId)
		{
			User result1 = await db.QueryFirstOrDefaultAsync<User>("SELECT * FROM users WHERE id = @Id;",
				new { Id = userId });
			return result1;
		}

		public async Task<User> UpdateUser(User user)
		{
			var sql = @"UPDATE users 
                SET name = @UserName, email = @UserEmail 
                WHERE id = @UserId;";
			var result = await db.ExecuteAsync(sql,
				new { UserName = user.Name, UserEmail = user.Email, UserId = user.Id });
			if (result == 1)
			{
				return user;
			}
			return null;

		}
	}
}