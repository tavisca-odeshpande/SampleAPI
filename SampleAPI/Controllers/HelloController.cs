using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.Controllers
{
    [Route("/users/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        // GET users/hello
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hi";
        }

        // GET users/hello/name
        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            return "Hi "+name;
        }

        // POST users/hello
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT users/hello/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE users/hello/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
