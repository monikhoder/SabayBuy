using System;

namespace Core.Entities;

public class ShoppingCard
{
    public required string Id { get; set; }
    public List<CardItem> Items { get; set; } = [];
    public Guid? DeliveryMethodId { get; set; }
    public string? ClientSecret { get; set; }
    public string? PaymentIntentId { get; set; }
}
