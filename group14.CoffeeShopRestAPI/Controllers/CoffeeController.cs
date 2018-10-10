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
            if (id < 1)
            {
                return BadRequest("Id must be greater than 0!");
            }
            //Needs additional Exception for ID Match!
            return _CoffeeService.FindCoffeeById(id);
        }

        // POST api/Coffee -- Create!
        [HttpPost]
        public ActionResult<Coffee> Post([FromBody] Coffee coffee)
        {
            //Exceptions!
            if (string.IsNullOrEmpty(coffee.CoffeeName))
            {
                return BadRequest("Coffee Name Required!");
            }
            if (double.IsNegative(coffee.CoffeePrice) || coffee.CoffeePrice < 1)
            {
                return BadRequest("Coffee needs a price above 1!");
            }
            if (coffee.CoffeeStrength < 0)
            {
                return BadRequest("The lowest strength is 0!");
            }
            if (coffee.CoffeeStrength > 5)
            {
                return BadRequest("The highest coffee strength is 5!");
            }
            if (string.IsNullOrEmpty(coffee.CoffeeDescription))
            {
                return BadRequest("You need to insert a description!");
            }
            
            return _CoffeeService.CreateCoffee(coffee);
        }

        // PUT api/Coffee/5 -- Update!
        [HttpPut("{id}")]
        public ActionResult<Coffee> Put(int id, [FromBody] Coffee coffee)
        {
            //Exceptions!
            if (id < 1 || id != coffee.Id)
            {
                return BadRequest("The ID you are looking for does not exist!");
            }
            if (string.IsNullOrEmpty(coffee.CoffeeName))
            {
                return BadRequest("Coffee Name Required!");
            }
            if (double.IsNegative(coffee.CoffeePrice) || coffee.CoffeePrice < 1)
            {
                return BadRequest("Coffee needs a price above 1!");
            }
            if (coffee.CoffeeStrength < 0)
            {
                return BadRequest("The lowest strength is 0!");
            }
            if (coffee.CoffeeStrength > 5)
            {
                return BadRequest("The highest coffee strength is 5!");
            }
            if (string.IsNullOrEmpty(coffee.CoffeeDescription))
            {
                return BadRequest("You need to insert a description!");
            }
            return Ok(_CoffeeService.UpdateCoffee(coffee));
        }

        // DELETE api/Coffee/5 -- Delete!
        [HttpDelete("{id}")]
        public ActionResult<Coffee> Delete(int id)
        {
            //Exceptions!
            var coff = _CoffeeService.DeleteCoffee(id);

            if (coff == null)
            {
                return BadRequest("Id Does not exist!");
                //return StatusCode(404,"Could not find a coffee with that ID!" + id);
            }
            
            return Ok($"Coffe with the id: {id} is succesfully deleted");

        }
    }
}
