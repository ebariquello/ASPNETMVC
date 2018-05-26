using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Learn.MyContacts.Models;
using Learn.MyContacts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learn.MyContacts.MVC.Angular.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

       
        [HttpGet, Route("ListContacts")]
        public async Task<List<Contact>> ListContacts()
        {
            var result = await _service.GetAll();
            return result;
        }

        [HttpGet, Route("GetContact/{id}")]
        public async Task<JsonResult> GetContact(int id)
        {
            var result = await _service.GetByID(id);
            return Json(result);  ;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Contact> Create([FromBody] Contact contact)
        {
            contact.ContactID = await _service.Save(contact);
            return contact;
        }

       

        [HttpPut]
        [Route("Edit")]
        public async Task<Contact> Edit([FromBody] Contact contact)
        {
            contact.ContactID = await _service.Save(contact);
            return contact;
        }

        [HttpDelete, Route("Delete/{id}")]
        public async Task<Contact> Delete(int id)
        {
            var contact = await _service.GetByID(id);
            contact.ContactID = await _service.Delete(id);
            return contact;
        }
    }
}
