using System;
using Dapper;
using Newtonsoft.Json;
using Npgsql;

namespace dbcli
{
	class Program
	{
		static void Main(string[] args)
		{
			var cs = "User ID=postgres;Password=password;Host=localhost;Port=5432;Database=firsttemp;Pooling=true;";
			var db = new NpgsqlConnection(cs);
			db.Open();
		}
	}
}