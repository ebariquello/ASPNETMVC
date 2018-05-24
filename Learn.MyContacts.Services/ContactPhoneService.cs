using Learn.MyContacts.Models;
using Learn.MyContacts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.MyContacts.Services
{
    public class ContactPhoneService : IContactCollGenericService<ContactPhone>
    {
        private readonly IContactCollGenericRepository<ContactPhone> _repository;

        public ContactPhoneService(IContactCollGenericRepository<ContactPhone> repository)
        {
            _repository = repository;
        }

        public async Task<List<ContactPhone>> GetAll(int entityID)
        {


            return await _repository.GetAll(entityID) ;
        }

        public async Task<ContactPhone> GetByID(int itemCollEntityID)
        {
            return await _repository.GetByID(itemCollEntityID);
        }

        public async Task<int> Save(ContactPhone itemCollEntity)
        {
            return await _repository.Save(itemCollEntity);
        }

        public async Task<int> Delete(int itemCollEntityID)
        {
            return await _repository.Delete(itemCollEntityID);
        }
    }
}
