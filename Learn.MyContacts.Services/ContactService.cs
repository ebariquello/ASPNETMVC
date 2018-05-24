using Learn.MyContacts.Models;
using Learn.MyContacts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.MyContacts.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _repository;
        public ContactService(IContactRepository repository)
        {
            this._repository = repository;
        }

        public async Task<int> Delete(int contactID)
        {
            return await this._repository.Delete(contactID);
        }

        public async Task<List<Contact>> GetAll()
        {
            return await this._repository.GetAll();
        }

        public async Task<Contact> GetByID(int contactID)
        {
            return await this._repository.GetByID(contactID);
        }

        public bool Exists(int contactID)
        {
            return this._repository.Exists(contactID);
        }

        public async Task<int> Save(Contact contact)
        {
            return await this._repository.Save(contact);
        }
    }
}
