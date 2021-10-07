using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspJwt.Models;
using Dapper;
using Npgsql;

namespace AspJwt.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly IDbConnection _connection;

        public UserRepo(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public async Task CreateUser(User user)
        {
            // TODO : ADD EXCEPTION HANDLING
            string sql = "INSERT INTO users (sub,name,email) values (@Sub,@Name,@Email) ON CONFLICT DO NOTHING;";
            await _connection.ExecuteAsync(sql, new {user.Sub, user.Name, user.Email});
        }
    }
}