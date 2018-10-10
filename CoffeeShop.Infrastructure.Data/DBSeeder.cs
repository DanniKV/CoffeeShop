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

            //Coffee Entities
            var coff1 = ctx.Coffees.Add(new Coffee()
            {
                CoffeeName = "Wake up!",
                CoffeePrice = 20,
                CoffeeStrength = 5,
                CoffeeDescription = "Det her er en meget meget meget meget meget go kaff' - køb den!"
            }).Entity;

            var coff2 = ctx.Coffees.Add(new Coffee()
            {
                CoffeeName = "Weak stuff",
                CoffeePrice = 15.00,
                CoffeeStrength = 1,
                CoffeeDescription = "Denne her kaff' lugter af tis, iz no good, la vær me at køb!"
            });

            ctx.SaveChanges();
        }
    }
}
