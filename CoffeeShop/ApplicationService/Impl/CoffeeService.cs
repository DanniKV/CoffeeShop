using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeShop.Core.ApplicationService.DomainService;
using CoffeeShop.Core.Entities;
using CoffeeShop.Core;
using System.IO;

namespace CoffeeShop.Core.ApplicationService.Impl
{
    public class CoffeeService : ICoffeeService
    {
        readonly ICoffeeRepository _coffeeRepo;
        public CoffeeService(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepo = coffeeRepository;
        }

        public Coffee NewCoffee(string coffeeName, 
            double coffeePrice, int coffeeStrength, string coffeeDescription)
        {
            var coff = new Coffee()
            {
                CoffeeName = coffeeName,
                CoffeePrice = coffeePrice,
                CoffeeStrength = coffeeStrength,
                CoffeeDescription = coffeeDescription
            };
            return coff;
        }

        public Coffee CreateCoffee(Coffee coffee)
        {
            if (string.IsNullOrEmpty(coffee.CoffeeName))
            {
                throw new InvalidDataException("You have to enter a name for the coffee");
            }
            return _coffeeRepo.Create(coffee);
        }

        public Coffee FindCoffeeById(int id)
        {
            return _coffeeRepo.ReadyById(id);
        }

        public List<Coffee> GetAllCoffees()
        {
            return _coffeeRepo.ReadAll().ToList();
        }

        public List<Coffee> GetFilteredCoffee(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPerPage < 0)
            {
                throw new InvalidDataException("Current Page and Items Per Page must be 0 or higher!");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPerPage) >= _coffeeRepo.Count())
            {
                throw new InvalidDataException("CurrentPage is set too high!");
            }
            return _coffeeRepo.ReadAll(filter).ToList();
        }

        public List<Coffee> GetAllByCoffeeName(string name)
        {
            var list = _coffeeRepo.ReadAll();
            var queryContinued = list.Where(coff => coff.CoffeeName.Equals(name));
            queryContinued.OrderBy(coffee => coffee.CoffeeName);
            //Not executed anything yet
            return queryContinued.ToList();
        }

        public Coffee UpdateCoffee(Coffee coffeeUpdate)
        {
            return _coffeeRepo.Update(coffeeUpdate);
        }

        public Coffee DeleteCoffee(int id)
        {
            return _coffeeRepo.Delete(id);
        }

        
    }
}
