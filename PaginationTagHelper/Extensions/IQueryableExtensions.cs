using PaginationTagHelper.Pagination;
using PaginationTagHelper.Querying;
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

        //public static IQueryable<T> ApplySearching<T>(
        //     this IQueryable<T> query,
        //     IQueryObject queryObj,
        //     Dictionary<string, Expression<Func<T, bool>>> compareMap)
        //{
        //    if (String.IsNullOrWhiteSpace(queryObj.SearchBy) ||
        //      !compareMap.ContainsKey(queryObj.SearchBy))
        //    {
        //        return query;
        //    }

        //    if (queryObj.ShowAll)
        //    {
        //        return query;
        //    }

        //    query = query.Where(compareMap[queryObj.SearchBy]);

        //    return query;
        //}

        public static IQueryable<T> ToSearchByList<T>(
            this IQueryable<T> query,
            string searchByObj,
            string searchName)
        {
            if (String.IsNullOrWhiteSpace(searchByObj))
            {
                return query;
            }

            return query.Where(searchByObj, searchName);
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
                return query.OrderBy(sortByObj + "descending");
            }
            else
            {
                return query.OrderBy(sortByObj);
            }
        }

        //public static IQueryable<T> ApplyOrdering<T>(
        //this IQueryable<T> query,
        //IQueryObject queryObj,
        //Dictionary<string, Expression<Func<T, object>>> columnsMap)
        //{
        //    if (String.IsNullOrWhiteSpace(queryObj.SortBy) ||
        //       !columnsMap.ContainsKey(queryObj.SortBy))
        //    {
        //        return query;
        //    }
        //    if (queryObj.IsSortDescending)
        //    {
        //        return query.OrderByDescending(columnsMap[queryObj.SortBy]);
        //    }
        //    else
        //    {
        //        return query.OrderBy(columnsMap[queryObj.SortBy]);
        //    }
        //}



        //public static IQueryable<T> ApplyPaging<T>(
        //    this IQueryable<T> query,
        //    IPagingObject pagingObj)
        //{
        //    if (pagingObj.Page <= 0)
        //    {
        //        pagingObj.Page = 1;
        //    }

        //    if (pagingObj.ItemPerPage <= 0)
        //    {
        //        pagingObj.ItemPerPage = 5;
        //    }

        //    return query.Skip((pagingObj.Page - 1) * pagingObj.ItemPerPage)
        //        .Take(pagingObj.ItemPerPage);
        //}

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
