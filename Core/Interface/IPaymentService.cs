using System;
using Core.Entities;

namespace Core.Interface;

public interface IPaymentService
{
    Task<ShoppingCard?> CreateOrUpdatePaymentIntent(string basketId);

}
