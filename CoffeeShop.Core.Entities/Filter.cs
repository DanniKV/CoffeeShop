using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Core.Entities
{
    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
