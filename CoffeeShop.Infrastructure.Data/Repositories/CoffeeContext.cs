using System;
using System.Collections.Generic;
using System.Text;
using CoffeeShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Infrastructure.Data.Repositories
{   //Connection Point to the Database, only contains parts of the DB
    //Only contains content that we are working with at a given time
    public class CoffeeContext : DbContext
    {
        //SuperClass 
        //Options for database: Sql, in-Memory and so on...
        public CoffeeContext(DbContextOptions<CoffeeContext> Opt) : base(Opt)
        {

        }
        //Fluint API Model-Builder-- DB Table Relations (one to many) and so on
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        public DbSet<Coffee> Coffees { get; set; }
    }
    
}
