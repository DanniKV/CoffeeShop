using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Core.ApplicationService;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Core.Entities;
using CoffeeShop.Core;

namespace group14.CoffeeShopRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _CoffeeService;

        public CoffeeController(ICoffeeService coffeeService)
        {
            _CoffeeService = coffeeService;
        }

        // GET api/Coffee
        [HttpGet]
        public ActionResult<IEnumerable<Coffee>> Get()
        {
            return _CoffeeService.GetAllCoffees();
        }

        // GET api/Coffee/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/Coffee
        [HttpPost]
        public ActionResult<Coffee> Post([FromBody] Coffee coffee)
        {
            return _CoffeeService.CreateCoffee(coffee);
        }

        // PUT api/Coffee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Coffee/5
        [HttpDelete("{id}")]
        public ActionResult<Coffee> Delete(int id)
        {

            var coff = _CoffeeService.DeleteCoffee(id);
            return Ok($"Coffe with this id: {id} is succesfully deleted");

        }
    }
}
