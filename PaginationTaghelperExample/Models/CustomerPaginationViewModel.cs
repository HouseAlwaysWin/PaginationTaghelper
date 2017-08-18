using PaginationTaghelper.Pagination;
using PaginationTaghelper.Querying;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationTaghelperExample.Models
{
    public class CustomerPaginationViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItems { get; set; }
        public IQueryObject QueryObj { get; set; }
        public IPagingObject PagingObj { get; set; }
        public ExpandoObject QueryOption { get; set; }
    }
}
