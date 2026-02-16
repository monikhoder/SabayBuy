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
    public class CardService(IConnectionMultiplexer redis) : ICardService
    {
        private readonly IDatabase database = redis.GetDatabase();
        
        public async Task<bool> DeleteCardAsync(string key)
        {
            return await database.KeyDeleteAsync(key);
        }

        public async Task<ShoppingCard?> GetCardAsync(string key)
        {
            var data = await database.StringGetAsync(key);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCard?>(data!);
        }

        public async Task<ShoppingCard?> SetCardAsync(ShoppingCard shoppingCard)
        {
            var created = await database.StringSetAsync(shoppingCard.Id, JsonSerializer.Serialize(shoppingCard), TimeSpan.FromDays(30));
            if (!created)
            {
                return null;
            }
            return shoppingCard;
        }
    }
}
