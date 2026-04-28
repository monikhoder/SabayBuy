using System.Collections.Generic;

namespace POS.Dtos
{
    public class PaginationDto<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<T> Data { get; set; }
    }
}
