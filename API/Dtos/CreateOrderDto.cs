using Core.Entities.OrderAggregate;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateOrderDto
    {
        [Required]
        public string CartId { get; set; } = string.Empty;
        [Required]
        public Guid DeliveryMethodId { get; set; }
        [Required]
        public ShippingAddress ShippingAddress { get; set; } = null!;
        [Required]
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.cod;
        public string? PaymentIntentId { get; set; }
    }
}
