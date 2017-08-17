using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PaginationTaghelper
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySearching<T>(
             this IQueryable<T> query,
             IQueryObject queryObj,
              Dictionary<string, Expression<Func<T, bool>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(queryObj.SearchBy) ||
              !columnsMap.ContainsKey(queryObj.SearchBy))
            {
                return query;
            }

            if (queryObj.ShowAll)
            {
                return query;
            }

            return query = query.Where(columnsMap[queryObj.SearchBy]);
        }

        public static IQueryable<T> ApplyOrdering<T>(
            this IQueryable<T> query,
            IQueryObject queryObj,
            Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(queryObj.SortBy) ||
               !columnsMap.ContainsKey(queryObj.SortBy))
            {
                return query;
            }

            if (queryObj.IsSortAscending)
            {
                return query.OrderBy(columnsMap[queryObj.SortBy]);
            }
            else
            {
                return query.OrderByDescending(columnsMap[queryObj.SortBy]);
            }
        }

        public static IQueryable<T> ApplyPaging<T>(
            this IQueryable<T> query,
            IPagingObject pagingObj)
        {
            if (pagingObj.Page <= 0)
            {
                pagingObj.Page = 1;
            }

            if (pagingObj.ItemPerPage <= 0)
            {
                pagingObj.ItemPerPage = 5;
            }

            return query.Skip((pagingObj.Page - 1) * pagingObj.ItemPerPage)
                .Take(pagingObj.ItemPerPage);
        }
    }
}
