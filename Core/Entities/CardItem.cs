using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CardItem
    {
        public required string ProductName { get; set; }
        public required string ProductId { get; set; }
        public required string ProductVariantId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public required string ImageUrl { get; set; }
        public required string Brand { get; set; }
        public required string Category { get; set; }

    }
}
