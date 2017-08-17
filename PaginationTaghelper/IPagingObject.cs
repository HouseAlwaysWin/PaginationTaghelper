using System;
using System.Collections.Generic;
using System.Text;

namespace PaginationTaghelper
{
    public interface IPagingObject
    {
        int Page { get; set; }
        int ItemPerPage { get; set; }
    }
}
