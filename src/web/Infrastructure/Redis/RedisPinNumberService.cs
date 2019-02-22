using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Web.Infrastructure.Redis
{
    public class RedisPinNumberService : IPinNumberDataService
    {
        private IDatabase _database;

        public RedisPinNumberService(ConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> Exists(int number)
        {
            return await _database.KeyExistsAsync(number.ToString());
        }

        public async Task Save(int number)
        {
            await _database.StringSetAsync(number.ToString(), number);
        }
    }
}
