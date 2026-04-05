using Core.Entities;
using Core.Interface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CartService(IConnectionMultiplexer redis) : ICartService
    {
        private readonly IDatabase database = redis.GetDatabase();

        public async Task<bool> DeleteCardAsync(string key)
        {
            return await database.KeyDeleteAsync(key);
        }

        public async Task<ShoppingCart?> GetCardAsync(string key)
        {
                var data = await database.StringGetAsync(key);
                return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCart?>(data!);

        }

        public async Task<ShoppingCart?> SetCardAsync(ShoppingCart shoppingCart)
        {
            var created = await database.StringSetAsync(shoppingCart.Id, JsonSerializer.Serialize(shoppingCart), TimeSpan.FromDays(30));
            if (!created)
            {
                return null;
            }
            return shoppingCart;
        }
    }
}
