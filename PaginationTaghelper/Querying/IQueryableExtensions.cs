using PaginationTaghelper.Pagination;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PaginationTaghelper.Querying
{
    public static class IQueryableExtensions
    {

        public static IQueryable<T> ApplySearching<T>(
             this IQueryable<T> query,
             IQueryObject queryObj,
             Dictionary<string, Expression<Func<T,bool>>> compareMap)
        {
            if (String.IsNullOrWhiteSpace(queryObj.SearchBy) ||
              !compareMap.ContainsKey(queryObj.SearchBy))
            {
                return query;
            }

            if (queryObj.ShowAll)
            {
                return query;
            }

            query = query.Where(compareMap[queryObj.SearchBy]);

            return query;
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
