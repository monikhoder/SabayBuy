using System;
using Core.Entities;

namespace Core.Interface;

public interface IPaymentService
{
    Task<ShoppingCard?> GetTotalPrice(string basketId);
    Task<object?> ProcessPaymentAsync(ShoppingCard cart, string paymentMethod);
}
