using System;

namespace Core.Entities;

public class ShoppingCard
{
    public required string Id { get; set; }
    public List<CardItem> Items { get; set; } = [];


}
