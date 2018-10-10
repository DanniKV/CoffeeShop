using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.Entities
{
    public class Coffee
    {
        public int Id { get; set; }
        public String CoffeeName { get; set; }


        public double CoffeePrice { get; set; }
        public int CoffeeStrength { get; set; }
        public string CoffeeDescription { get; set; }

        //Relations
    }
}
