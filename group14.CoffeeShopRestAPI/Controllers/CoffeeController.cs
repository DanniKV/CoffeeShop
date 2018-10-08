using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Core.ApplicationService;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Coffee/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/Coffee
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Coffee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Coffee/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
