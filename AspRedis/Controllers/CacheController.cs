using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace AspRedis.Controllers
{
    [ApiController]
    [Route("api")]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _database;

        public CacheController(IDatabase database)
        {
            _database = database;
        }
        
        [HttpGet]
        public string Get( [FromQuery] string key )
        {
            return _database.StringGet(key);
        }

        [HttpPost]
        public void Post([FromBody] KeyValue keyValue)
        {
            Console.WriteLine("hello world");
            Console.WriteLine(keyValue.ToString());
           _database.StringSet(keyValue.Key, keyValue.Value);
        }
    }
}
