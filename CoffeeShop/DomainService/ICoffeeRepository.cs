using CoffeeShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.ApplicationService.DomainService
{
    public interface ICoffeeRepository
    {
        //CoffeeRepository Interface
        //Create Data
        //No Id when enter, but Id when exits
        Coffee Create(Coffee coffee);

        //Read Data
        Coffee ReadyById(int id);
        IEnumerable<Coffee> ReadAll(Filter filter = null);
        int Count();

        //Update Data
        Coffee Update(Coffee coffeeUpdate);

        //Delete Data
        Coffee Delete(int id);

    }

}
