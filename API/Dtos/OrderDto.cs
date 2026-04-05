using System;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace API.Dtos;

public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public required string BuyerEmail { get; set; }
        public ShippingAddress ShippingAddress { get; set; } = null!;
        public string DeliveryMethod { get; set; } = null!;
        public decimal DeliveryPrice { get; set; }
        public required List<OrderItemDto> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total => Subtotal + DeliveryPrice;
        public required string Status { get; set; }
        public required string PaymentMethod { get; set; }
        public string? PaymentIntentId { get; set; }
    }
public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public Guid ProductVariantId { get; set; }
        public required string VariantName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }