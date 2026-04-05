using System;
using Core.Entities;

namespace Core.Interface;

public interface IPaymentService
{
    Task<ShoppingCart?> GetTotalPrice(string cartId, string shippingId);
    Task<object?> ProcessPaymentAsync(ShoppingCart cart, string paymentMethod, AppUser user);
}
