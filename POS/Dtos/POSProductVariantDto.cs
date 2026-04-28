using System;

namespace POS.Dtos
{
    public class POSProductVariantDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public string Brand { get; set; }
        public string CategoryName { get; set; }
        public Guid VariantId { get; set; }
        public string VariantName { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string VariantImageUrl { get; set; }
    }
}
