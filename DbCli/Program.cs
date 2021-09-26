using System;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json;
using Npgsql;

namespace dbcli
{
    public class User
    {
        public string Sub { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    class Program
    {
        public static async Task Main(string[] args)
        {

        }
    }
}