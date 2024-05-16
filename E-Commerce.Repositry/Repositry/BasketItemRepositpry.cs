using E_Commerce.Domain.Entity.NewFolder;
using E_Commerce.Domain.Interfaces.Repositry;
using E_Commerce.Services.DataContext;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.Repositry
{
    public class BasketItemRepositpry : IBasketItemRepositpry
    {
       

        private readonly IDatabase _database;

        public BasketItemRepositpry(IConnectionMultiplexer connection)
        {
            _database=connection.GetDatabase();
        }

        public async Task<bool> DeleteCustomerBasketAsync(string id)=> await _database.KeyDeleteAsync(id);


        public async Task<CustomerBasket?> GetCustomerBasketAsync(string Id)
        {
           var basket=await  _database.StringGetAsync(Id);
            return basket.IsNullOrEmpty? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket?> UpdateCustomerBasketAsync(CustomerBasket basket)
        {
            var serializbasket=JsonSerializer.Serialize(basket);
            var result=await _database.StringSetAsync(basket.Id, serializbasket, TimeSpan.FromDays(30));
            return result ?await GetCustomerBasketAsync(basket.Id) : null;
        }
    }
}
