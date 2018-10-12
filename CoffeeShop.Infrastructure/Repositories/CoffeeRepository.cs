using System;
using System.Collections.Generic;
using System.Text;
using CoffeeShop.Core.DomainService;

namespace CoffeeShop.Infrastructure.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        readonly CoffeeShopContext _ctx;

        public CoffeeRepository(CoffeeShopContext ctx)
        {
            _ctx = ctx;
        }

        public Coffee Create(Coffee coffee)
        {
            throw new NotImplementedException();
        }

        public Coffee ReadyById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Coffee> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Coffee Update(Coffee coffeeUpdate)
        {
            throw new NotImplementedException();
        }

        public Coffee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Coffee ReadyByIdIncludeOrders(int id)
        {
            throw new NotImplementedException();
        }
    }
}
