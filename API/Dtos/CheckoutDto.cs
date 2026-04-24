using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CheckoutDto
    {
        [Required(ErrorMessage = "Cart id is required")]
        [RegularExpression(@".*\S.*", ErrorMessage = "Cart id cannot be whitespace")]
        public string CartId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Payment method is required")]
        [RegularExpression("^(aba|stripe|cod)$", ErrorMessage = "Payment method is invalid")]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required(ErrorMessage = "Delivery method id is required")]
        [RegularExpression(
            @"^[{(]?[0-9A-Fa-f]{8}([-]?[0-9A-Fa-f]{4}){3}[-]?[0-9A-Fa-f]{12}[)}]?$",
            ErrorMessage = "Delivery method id must be a valid GUID")]
        public string DeliveryMethodId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Shipping address id is required")]
        [RegularExpression(
            @"^[{(]?[0-9A-Fa-f]{8}([-]?[0-9A-Fa-f]{4}){3}[-]?[0-9A-Fa-f]{12}[)}]?$",
            ErrorMessage = "Shipping address id must be a valid GUID")]
        public string ShippingAddressId { get; set; } = string.Empty;
    }
}
