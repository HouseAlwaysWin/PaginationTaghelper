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
        public IActionResult PageWithoutQuery(CustomerViewModel model)
        {
            var query = DbContext.Customer.AsQueryable();

            query = query.ToSearchByList(model.SearchBy, model.SearchItem);
            query = query.ToOrderByList(model.SortBy, model.IsSortDescending);

            // Count total Items before pagination
            int totalItems = query.Count();

            query = query.ToPageList(model.Page, 8);

            var result = new CustomerViewModel
            {
                SearchBy = model.SearchBy,
                SearchItem = model.SearchItem,
                IsSortDescending = model.IsSortDescending,
                SortBy = model.SortBy,

                Page = model.Page,
                ItemPerPage = model.ItemPerPage,
                Items = query,
                TotalItems = totalItems
            };

            return View(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult PageWithQuery(CustomerViewModel model)
        {
            var query = DbContext.Customer.AsQueryable();

            query = query.ToSearchByList(model.SearchBy, model.SearchItem);
            query = query.ToOrderByList(model.SortBy, model.IsSortDescending);

            int totalItems = query.Count();

            model.ItemPerPage = 5;
            query = query.ToPageList(model.Page, model.ItemPerPage);

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
                SortBy = model.SortBy,
                QueryOptions = queryOptions,

                Page = model.Page,
                ItemPerPage = model.ItemPerPage,
                Items = query,
                TotalItems = totalItems
            };

            return View(result);
        }


    }
}
