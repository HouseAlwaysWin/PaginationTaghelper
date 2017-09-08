using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationTaghelperExample.Models
{
    public class CustomerViewModel 
    {

        public string SearchType { get; set; }
        public string SearchItem { get; set; }
        public string SortType { get; set; }
        public bool IsSortDescending { get; set; }
        public int Page { get; set; } = 1;
        public int TotalItems { get; set; }
        public int ItemPerPage { get; set; }
        public IEnumerable<Customer> Items { get; set; }
        public string QueryOptions { get; set; }
    }
}
