using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface ICardService
    {
        Task<ShoppingCard?> GetCardAsync(string key);
        Task<ShoppingCard?> SetCardAsync(ShoppingCard shoppingCard);
        Task<bool> DeleteCardAsync(string key);
    }
}
