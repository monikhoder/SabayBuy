using System;
using System.Collections.Generic;

namespace POS.Dtos
{
    public class CreatePOSOrderDto
    {
        public List<CreatePOSOrderItemDto> Items { get; set; } = new List<CreatePOSOrderItemDto>();
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.cod;
        public Guid? DeliveryMethodId { get; set; }
        public string CustomerName { get; set; } = "Walk-in Customer";
        public string CustomerPhone { get; set; } = string.Empty;
    }

    public class CreatePOSOrderItemDto
    {
        public Guid ProductVariantId { get; set; }
        public int Quantity { get; set; }
    }

    public enum PaymentMethod
    {
        aba = 0,
        cod = 1,
        stripe = 2,
        khqr = 3
    }
}
