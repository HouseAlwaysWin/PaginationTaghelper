using System;
using System.Collections.Generic;
using System.Text;

namespace PaginationTaghelper
{
    public interface IQueryObject
    {
        string SearchBy { get; set; }
        string SearchItem { get; set; }
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
        bool ShowAll { get; set; }
    }
}
