using PaginationTagHelper.Pagination;
using PaginationTagHelper.Querying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationTaghelperExample.Models
{
    public class CustomerViewModel : IQueryObject, IPagingObject
    {

        public string SearchBy { get; set; }
        public string SearchItem { get; set; }
        public string SortBy { get; set; }
        public bool IsSortDescending { get; set; }
        public bool ShowAll { get; set; }
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public int ItemPerPage { get; set; }
        public IQueryable<Customer> Items { get; set; }
        public string QueryOptions { get; set; }
        
    }
}
