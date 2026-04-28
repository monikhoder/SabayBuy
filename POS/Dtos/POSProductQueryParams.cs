using System.Collections.Generic;

namespace POS.Dtos
{
    public class POSProductQueryParams
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public List<string> Brands { get; set; } = new List<string>();
        public List<string> Categories { get; set; } = new List<string>();
        public bool InStockOnly { get; set; }
        public string Sort { get; set; }
        public string Search { get; set; }
    }
}
