using System;
using System.Collections.Generic;
using System.Text;
using CoffeeShop.Core.Entities;

namespace CoffeeShop.Core.ApplicationService
{
    public interface ICoffeeService
    {
            //New Coffee
            Coffee NewCoffee(string coffeeName);

            //Create/Post
            Coffee CreateCoffee(Coffee coffee);

            //Read/Get
            Coffee FindCoffeeById(int id);
            List<Coffee> GetAllCoffees();
            List<Coffee> GetAllByCoffeeName(string name);

            //Update/Put
            Coffee UpdateCoffee(Coffee coffeeUpdate);

            //Delete
            Coffee DeleteCoffee(int id);

    }
}
