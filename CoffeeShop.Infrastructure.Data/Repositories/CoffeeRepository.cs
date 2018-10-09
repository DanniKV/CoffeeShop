﻿using CoffeeShop.Core.ApplicationService.DomainService;
using CoffeeShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace CoffeeShop.Infrastructure.Data.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        readonly CoffeeContext _ctx;

        public CoffeeRepository(CoffeeContext ctx)
        {
            _ctx = ctx;
        }





        public Coffee Create(Coffee coffee)
        {
            var coff = _ctx.Coffees.Add(coffee).Entity;
            _ctx.SaveChanges();
            return coff;
        }

        public Coffee Delete(int id)
        {
            var coffRemoved = _ctx.Remove(new Coffee { Id = id }).Entity;
            _ctx.SaveChanges();
            return coffRemoved;
        }

        public IEnumerable<Coffee> ReadAll()
        {
            return _ctx.Coffees;
        }

        public Coffee ReadyById(int id)
        {
            throw new NotImplementedException();
        }

        public Coffee ReadyByIdIncludeOrders(int id)
        {
            throw new NotImplementedException();
        }

        public Coffee Update(Coffee coffeeUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
