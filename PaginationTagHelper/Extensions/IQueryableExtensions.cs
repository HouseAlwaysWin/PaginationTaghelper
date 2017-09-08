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
            string searchType,
            string searchItem)
        {
            if (String.IsNullOrWhiteSpace(searchItem))
            {
                return query;
            }

            return query.WhereContains(searchType, searchItem);
        }

        public static IEnumerable<T> ToSearchByList<T>(
            this IEnumerable<T> query,
            string searchType,
            string searchItem)
        {
            if (String.IsNullOrWhiteSpace(searchItem))
            {
                return query;
            }

            return query.WhereContains(searchType, searchItem);
        }

        public static IQueryable<T> ToOrderByList<T>(
            this IQueryable<T> query,
            string sortType,
            bool isSortDescending)
        {
            if (String.IsNullOrWhiteSpace(sortType))
            {
                return query;
            }

            if (isSortDescending)
            {
                return query.OrderByDescending(sortType);
            }
            else
            {
                return query.OrderBy(sortType);
            }
        }

        public static IEnumerable<T> ToOrderByList<T>(
           this IEnumerable<T> query,
           string sortType,
           bool isSortDescending)
        {
            if (String.IsNullOrWhiteSpace(sortType))
            {
                return query;
            }

            if (isSortDescending)
            {
                return query.OrderByDescending(sortType);
            }
            else
            {
                return query.OrderBy(sortType);
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

        public static IEnumerable<T> ToPageList<T>(
            this IEnumerable<T> query, int currentPage, int ItemPerPage = 5)
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
