
using System.Collections.Generic;

namespace PaginationTagHelper.Pagination
{
    public interface IPagingObject<T>
    {
        int Page { get; set; }
        int ItemPerPage { get; set; }
        int TotalItems { get; set; }
        IEnumerable<T> Items { get; set; }
    }
}
