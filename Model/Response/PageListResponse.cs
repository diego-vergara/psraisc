using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class PageListResponse<T> where T:class
    {
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }
        public List<T> Data { get; set; }
    }
}
