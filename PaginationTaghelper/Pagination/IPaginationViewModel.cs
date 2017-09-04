using PaginationTagHelper.Querying;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace PaginationTagHelper.Pagination
{
    public abstract class IPaginationViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItems { get; set; }
        public IQueryObject QueryObj { get; set; }
        public IPagingObject PagingObj { get; set; }
        public Dictionary<string,string> QueryOptions { get; set; }
    }
}
