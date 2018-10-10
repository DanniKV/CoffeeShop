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

        // GET api/Coffee -- ReadAll!
        [HttpGet]
        public ActionResult<IEnumerable<Coffee>> Get()
        {
            return _CoffeeService.GetAllCoffees();
        }

        // GET api/Coffee/5 -- Read By ID!
        [HttpGet("{id}")]
        public ActionResult<Coffee> Get(int id)
        {
            //exceptions!
            return _CoffeeService.FindCoffeeById(id);
        }

        // POST api/Coffee -- Create!
        [HttpPost]
        public ActionResult<Coffee> Post([FromBody] Coffee coffee)
        {
            //Exceptions!
            return _CoffeeService.CreateCoffee(coffee);
        }

        // PUT api/Coffee/5 -- Update!
        [HttpPut("{id}")]
        public ActionResult<Coffee> Put(int id, [FromBody] Coffee coffee)
        {
            //Exceptions!
            return Ok(_CoffeeService.UpdateCoffee(coffee));
        }

        // DELETE api/Coffee/5 -- Delete!
        [HttpDelete("{id}")]
        public ActionResult<Coffee> Delete(int id)
        {
            //Exceptions!
            var coff = _CoffeeService.DeleteCoffee(id);
            return Ok($"Coffe with this id: {id} is succesfully deleted");

        }
    }
}
