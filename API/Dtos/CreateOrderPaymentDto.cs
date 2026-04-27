using Core.Entities.OrderAggregate;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class CreateOrderPaymentDto
{
    [Required]
    [RegularExpression(@".*\S.*", ErrorMessage = "Cart id cannot be whitespace")]
    public string CartId { get; set; } = string.Empty;

    [Required]
    public Guid DeliveryMethodId { get; set; }

    [Required]
    public ShippingAddress ShippingAddress { get; set; } = null!;

    [Required]
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.cod;
}
