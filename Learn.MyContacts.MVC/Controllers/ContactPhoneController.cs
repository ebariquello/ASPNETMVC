using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn.MyContacts.Models;
using Learn.MyContacts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.MyContacts.MVC.Controllers
{
  
    public class ContactPhoneController : Controller
    {
        private readonly IContactCollGenericService<ContactPhone> _service;

        public ContactPhoneController(IContactCollGenericService<ContactPhone> service)
        {
            _service = service;
        }

        // GET: api/ContactPhone/5
        [HttpGet]
        public async Task<JsonResult> GetContactPhoneByID(int id)
        {
            var cp = await _service.GetByID(id);
            return Json(cp);
        }
        // GET: api/ContactPhone/5
        [HttpGet]
        public async Task<JsonResult> GetContactPhoneByContactID(int id)
        {
            var cps = await _service.GetAll(id);
            return Json(cps);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ContactPhone cp)
        {
            cp.ContactPhoneID = await _service.Save(cp);
            return Json(cp);
        }
        

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Json(await _service.Delete(id));
        }

    }
}
