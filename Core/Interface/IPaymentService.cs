using System;
using Core.Entities;

namespace Core.Interface;

public interface IPaymentService
{
    Task<ShoppingCard?> GetTotalPrice(string cartId, string shippingId);
    Task<object?> ProcessPaymentAsync(ShoppingCard cart, string paymentMethod);
}
