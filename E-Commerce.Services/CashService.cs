using E_Commerce.Domain.Interfaces.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class CashService : ICashService
    {
        private readonly IDatabase _database;

        public CashService(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }
        public async Task<string?> GetCashResponseAysnc(string Key)
        {
            var getcash = await _database.StringGetAsync(Key);
            return getcash.IsNullOrEmpty? null :getcash.ToString();
        }

        public async Task SetCashResponseAysnc(string Key, object Value, TimeSpan time)
        {
            var format = JsonSerializer.Serialize(Value,new JsonSerializerOptions{PropertyNamingPolicy= JsonNamingPolicy.CamelCase });
             await _database.StringSetAsync(Key, format, time);
            
        }
    }
}
