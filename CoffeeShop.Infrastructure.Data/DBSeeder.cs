using System;
using System.Collections.Generic;
using System.Text;
using CoffeeShop.Core.Entities;

namespace CoffeeShop.Infrastructure.Data.Repositories
{
    public class DBSeeder

    {
        public static void SeedTheDB(CoffeeContext ctx)
        {
            //This ensures that the DB is deleted. before seeding
            //MAKE SURE TO BE UNDER THE SECTION "env.IsDevelopment()" 
            //else it can delete complete production DB !!!DØD BABY!!!

            ctx.Database.EnsureDeleted();

            //Ensures the DB is created with the startup customers and orders
            //Seeds the Data into the DB - stacks with each startup
            ctx.Database.EnsureCreated();


            var coff1 = ctx.Coffee.Add(new Coffee)
            {
                CoffeeName = "",

            }
            //CoffeeEntities
            
        }
    }
}
