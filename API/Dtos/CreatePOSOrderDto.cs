using Core.Entities.OrderAggregate;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class CreatePOSOrderDto
{
    [Required]
    [MinLength(1, ErrorMessage = "POS order must contain at least one item")]
    public List<CreatePOSOrderItemDto> Items { get; set; } = [];

    [Required]
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.cod;

    public Guid? DeliveryMethodId { get; set; }
    public string CustomerName { get; set; } = "Walk-in Customer";
    public string CustomerPhone { get; set; } = string.Empty;
}

public class CreatePOSOrderItemDto
{
    [Required]
    public Guid ProductVariantId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
    public int Quantity { get; set; }
}
