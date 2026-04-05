using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ICartService
    {
        Task<ShoppingCart?> GetCardAsync(string key);
        Task<ShoppingCart?> SetCardAsync(ShoppingCart shoppingCart);
        Task<bool> DeleteCardAsync(string key);
    }
}
