﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoffeeShop.Core.ApplicationService.DomainService;
using CoffeeShop.Core.Entities;
using CoffeeShop.Core;

namespace CoffeeShop.Core.ApplicationService.Impl
{
    public class CoffeeService : ICoffeeService
    {
        readonly ICoffeeRepository _coffeeRepo;
        public CoffeeService(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepo = coffeeRepository;
        }

        public Coffee NewCoffee(string coffeeName)
        {
            var coff = new Coffee()
            {
                CoffeeName = coffeeName
            };
            return coff;
        }

        public Coffee CreateCoffee(Coffee coffee)
        {
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
            var coffee = FindCoffeeById(coffeeUpdate.Id);
            coffee.CoffeeName = coffeeUpdate.CoffeeName;
            return coffee;
        }

        public Coffee DeleteCoffee(int id)
        {
            return _coffeeRepo.Delete(id);
        }
    }
}
