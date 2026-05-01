using System;
using System.Collections.Generic;

namespace POS.Dtos
{
    public class POSOrderDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string BuyerEmail { get; set; }
        public POSShippingAddressDto ShippingAddress { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal DeliveryPrice { get; set; }
        public List<POSOrderItemDto> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentIntentId { get; set; }
    }

    public class POSOrderItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid ProductVariantId { get; set; }
        public string VariantName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class POSShippingAddressDto
    {
        public string FullName { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
