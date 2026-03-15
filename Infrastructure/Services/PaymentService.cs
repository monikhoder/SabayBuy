using System;
using Core.Entities;
using Core.Interface;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class PaymentService(
        IConfiguration configuration,
        ICartService cartService,
        IGenericRepository<Product> productRepo,
        IGenericRepository<DeliveryMethod> deliveryMethodRepo
    ) : IPaymentService
    {
        public Task<ShoppingCard?> CreateOrUpdatePaymentIntent(string basketId)
        {
            throw new NotImplementedException();
        }
    }
