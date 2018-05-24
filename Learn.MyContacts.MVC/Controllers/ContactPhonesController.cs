using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn.MyContacts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.MyContacts.MVC.Controllers
{
    [Produces("application/json")]
    [Route("api/ContactPhones")]
    public class ContactPhonesController : Controller
    {
        [HttpGet]
        public IEnumerable<ContactPhone> Get()
        {
            return null;
        }
    }
}