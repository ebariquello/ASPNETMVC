using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.MyContacts.MVC.Controllers
{
    [Produces("application/json")]
    [Route("api/ContactEmail")]
    public class ContactEmailController : Controller
    {
        //// GET: api/ContactEmail
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ContactEmail/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/ContactEmail
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/ContactEmail/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
