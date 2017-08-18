using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

using Microsoft.AspNetCore.Authorization;
using PaginationTaghelper.Querying;
using PaginationTaghelperExample.Models;
using PaginationTaghelperExample.Data;

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
        public IActionResult Index(CustomerViewModel model)
        {
            var query = DbContext.Customer.AsQueryable();


            // Set Searching method
            var searchMap =
               new Dictionary<string, Expression<Func<Customer, bool>>>()
               {
                   ["Id"] = c => c.Id.ToString().Contains(model.SearchItem),
                   ["Name"] = c => c.Name.Contains(model.SearchItem)
               };

            var sortedMap =
                new Dictionary<string, Expression<Func<Customer, object>>>()
                {
                    ["Id"] = c => c.Id,
                    ["Name"] = c => c.Name
                };


            query = query.ApplySearching(model, searchMap);
            query = query.ApplyOrdering(model, sortedMap);


            // TotalItems is must be set before ApplyPaging Extensions
            int totalItems = query.Count();

            // if not set ItemPerPage the default is 5
            model.ItemPerPage = 10;

            query = query.ApplyPaging(model);

            var result = new CustomerPaginationViewModel<Customer>
            {
                Items = query,
                TotalItems = totalItems,
                QueryObj = model,
                PagingObj = model
            };

            return View(result);
        }



    }
}
