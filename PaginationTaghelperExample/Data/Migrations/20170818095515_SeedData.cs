using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using PaginationTaghelperExample.Data;
using PaginationTaghelperExample.Models;
using System;
using System.Collections.Generic;

namespace PaginationTaghelperExample.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var context = new CustomerDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var customers = new List<Customer>
                {
                    new Customer { Id=1,Name="Jon Snow" },
                    new Customer { Id=2,Name="Sansa Stark" },
                    new Customer { Id=3,Name="Ned Stark" },
                    new Customer { Id=4,Name="Arya Stark" },
                    new Customer { Id=5,Name="Sansa Stark" },
                    new Customer { Id=6,Name="Bran Stark" },
                    new Customer { Id=7,Name="Benjen Stark" },
                    new Customer { Id=8,Name="Tormund" },
                    new Customer { Id=9,Name="Edmure Tully" },
                    new Customer { Id=10,Name="Hodor" },
                    new Customer { Id=11,Name="Cersei Lannister" },
                    new Customer { Id=12,Name="Tyrion Lannister" },
                    new Customer { Id=13,Name="Jaime Lannister" },
                    new Customer { Id=14,Name="Tywin Lannister" },
                    new Customer { Id=15,Name="Daenerys Targaryen" },
                    new Customer { Id=16,Name="Rhaegar Targaryen" },
                    new Customer { Id=17,Name="Joffrey Baratheon" },
                    new Customer { Id=18,Name="Myrcella Baratheon" },
                    new Customer { Id=19,Name="Tommen Baratheon" },
                    new Customer { Id=20,Name="Gregor Clegane" },
                    new Customer { Id=21,Name="Qyburn" },
                    new Customer { Id=22,Name="Catelyn Tully" },
                    new Customer { Id=23,Name="Bronn" },
                    new Customer { Id=24,Name="Vary" },
                    new Customer { Id=25,Name="Yara Greyjoy" },
                    new Customer { Id=26,Name="Theon Greyjoy" },
                    new Customer { Id=27,Name="Grey Worm" },
                    new Customer { Id=28,Name="Olenna Tyrell" },
                    new Customer { Id=29,Name="Ramsay Bolton" },
                    new Customer { Id=30,Name="Petyr Baelish" },
                    new Customer { Id=31,Name="Lysa Tully" },
                    new Customer { Id=32,Name="Robin Arryn" },
                    new Customer { Id=33,Name="Rickon Stark" },
                    new Customer { Id=34,Name="Brynden Tully" },
                    new Customer { Id=35,Name="Lyanna Mormont" },
                    new Customer { Id=36,Name="Jorah Mormont" },
                    new Customer { Id=37,Name="Jeor Mormont" },
                    new Customer { Id=38,Name="Maege Mormont" },
                    new Customer { Id=39,Name="Gilly" },
                    new Customer { Id=40,Name="Melisandre" },
                    new Customer { Id=41,Name="Gendry" },
                    new Customer { Id=42,Name="Davos Seaworth" },
                    new Customer { Id=43,Name="Robert Baratheon" },
                    new Customer { Id=44,Name="Stannis Baratheon" },
                    new Customer { Id=45,Name="Selyse Baratheon" },
                    new Customer { Id=46,Name="Loras Tyrell" },
                    new Customer { Id=47,Name="Renly Baratheon" },
                    new Customer { Id=48,Name="Margaery Tyrell " },
                    new Customer { Id=49,Name="Shireen Baratheon" },
                    new Customer { Id=50,Name="Samwell Tarly" },
                };

                    context.Customer.AddRange(customers);
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Customer] ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Customer] OFF");
                    transaction.Commit();
                }
               
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
