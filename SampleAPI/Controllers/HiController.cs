using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.Controllers
{
    [Route("/users/[controller]")]
    [ApiController]
    public class HiController : Controller
    {
        
        // GET /users/hi
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Say hello";
        }

        // GET /users/hi/name
        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            return name+" Say hello";
        }

        // POST /users/hi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT /users/hi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE /users/hi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}