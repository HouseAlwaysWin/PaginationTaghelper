using PaginationTagHelper.Pagination;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PaginationTagHelper.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ToSearchByList<T>(
            this IQueryable<T> query,
            string searchByObj,
            string searchName)
        {
            if (String.IsNullOrWhiteSpace(searchName))
            {
                return query;
            }

            return query.WhereContains(searchByObj, searchName);
        }

        public static IQueryable<T> ToOrderByList<T>(
            this IQueryable<T> query,
            string sortByObj,
            bool isSortDescending)
        {
            if (String.IsNullOrWhiteSpace(sortByObj))
            {
                return query;
            }

            if (isSortDescending)
            {
                return query.OrderByDescending(sortByObj);
            }
            else
            {
                return query.OrderBy(sortByObj);
            }
        }

        public static IQueryable<T> ToPageList<T>(
            this IQueryable<T> query, int currentPage, int ItemPerPage = 5)
        {
            if (currentPage == 0)
            {
                currentPage = 1;
            }

            return query.Skip((currentPage - 1) * ItemPerPage)
                .Take(ItemPerPage);
        }

    }
}
