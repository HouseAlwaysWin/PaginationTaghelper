using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using PaginationTaghelperExample.Models;
using PaginationTagHelper.Extensions;
using PaginationTaghelperExample.Data;
using Newtonsoft.Json;

namespace PaginationTaghelperExample.Controllers
{
    public class HomeController : Controller
    {
        private CustomerDbContext DbContext;

        public HomeController()
        {
            DbContext = new CustomerDbContext();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult DefaultQuery(CustomerViewModel model)
        {
            var query = DbContext.Customer.AsQueryable();

            query = query.ToSearchByList(model.SearchBy, model.SearchItem);
            query = query.ToOrderByList(model.SortBy, model.IsSortDescending);

            // TotalItems is must be set before ApplyPaging Extensions
            int totalItems = query.Count();

            //query = query.ApplyPaging(model);
            query = query.ToPageList(model.Page, 3);

            Dictionary<string, string> queryOptionsDict = new Dictionary<string, string>
            {
                ["SearchItem"] = model.SearchItem,
                ["SearchBy"] = model.SearchBy,
                ["SortBy"] = model.SortBy,
                ["IsSortDescending"] = model.IsSortDescending.ToString()
            };

            var queryOptions = JsonConvert.SerializeObject(queryOptionsDict);


            var result = new CustomerViewModel
            {
                SearchBy = model.SearchBy,
                SearchItem = model.SearchItem,
                IsSortDescending = model.IsSortDescending,
                Page = model.Page,
                ItemPerPage = model.ItemPerPage,
                SortBy = model.SortBy,
                QueryOptions = queryOptions,
                Items = query,
                TotalItems = totalItems
            };

            return View(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CustomQuery(CustomerViewModel model)
        {
            var query = DbContext.Customer.AsQueryable();

            query = query.ToSearchByList(model.SearchBy, model.SearchItem);
            query = query.ToOrderByList(model.SortBy, model.IsSortDescending);


            // TotalItems is must be set before ApplyPaging Extensions
            int totalItems = query.Count();

            query = query.ToPageList(model.Page);
            //query = query.ApplyPaging(model);
            // if not set ItemPerPage the default is 5

            Dictionary<string, string> queryOptionsDict = new Dictionary<string, string>
            {
                ["SearchItem"] = model.SearchItem,
                ["SearchBy"] = model.SearchBy,
                ["SortBy"] = model.SortBy,
                ["IsSortDescending"] = model.IsSortDescending.ToString()
            };

            var queryOptions = JsonConvert.SerializeObject(queryOptionsDict);


            var result = new CustomerViewModel
            {
                SearchBy = model.SearchBy,
                SearchItem = model.SearchItem,
                IsSortDescending = model.IsSortDescending,
                Page = model.Page,
                ItemPerPage = model.ItemPerPage,
                SortBy = model.SortBy,
                ShowAll = model.ShowAll,
                QueryOptions = queryOptions,
                Items = query,
                TotalItems = totalItems
            };

            return View(result);
        }


    }
}
