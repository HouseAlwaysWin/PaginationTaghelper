using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaginationTaghelperExample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PaginationTaghelperExample.Data
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {

        }
        public CustomerDbContext()
        {
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            //Called by parameterless ctor Usually Migrations
            var environmentName = Environment.GetEnvironmentVariable("Development") ?? "";

            optionsBuilder.UseSqlServer(
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false)
                    .Build()
                    .GetConnectionString("CustomerConnection")
            );
        }

    }
}
