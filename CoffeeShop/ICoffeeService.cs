﻿using CoffeeShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core
{
    public interface ICoffeeService
    {
        //New Coffee
        Coffee NewCoffee(string coffeeName,
            double coffeePrice, int coffeeStrength, string CoffeeDescription,
            string CoffeePicUrl);

        //Create/Post
        Coffee CreateCoffee(Coffee coffee);

        //Read/Get
        Coffee FindCoffeeById(int id);
        List<Coffee> GetAllCoffees();
        List<Coffee> GetAllByCoffeeName(string name);
        List<Coffee> GetFilteredCoffee(Filter filter);

        //Update/Put
        Coffee UpdateCoffee(Coffee coffeeUpdate);

        //Delete
        Coffee DeleteCoffee(int id);

    }
}
