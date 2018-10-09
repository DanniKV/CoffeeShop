using CoffeeShop.Core.ApplicationService.DomainService;
using CoffeeShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return _ctx.Coffees.FirstOrDefault(c => c.Id == id);
        }
        

        public Coffee Update(Coffee coffeeUpdate)
        {
            _ctx.Attach(coffeeUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return coffeeUpdate;
        }
    }
}
