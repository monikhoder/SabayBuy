using System;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace Core.Interface;

public interface IPaymentService
{
    Task<PaymentResult?> CreatePaymentForOrderAsync(PaymentMethod paymentMethod, decimal total, AppUser user, Guid orderId);
    Task<string> VerifyAbaPaymentAsync(string tranId);
}
