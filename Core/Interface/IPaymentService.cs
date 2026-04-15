using System;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace Core.Interface;

public interface IPaymentService
{
    Task<ShoppingCart?> GetTotalPrice(string cartId, string shippingId);
    Task<object?> ProcessPaymentAsync(ShoppingCart cart, string paymentMethod, AppUser user);
    Task<string> VerifyAbaPaymentAsync(string tranId);
}
