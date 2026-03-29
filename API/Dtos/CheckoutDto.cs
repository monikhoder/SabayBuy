using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CheckoutDto
    {
        [Required]
        public string CartId { get; set; } = string.Empty;
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string DeliveryMethodId { get; set; }
        [Required]
        public string ShippingAddressId { get; set; }
    }
}
