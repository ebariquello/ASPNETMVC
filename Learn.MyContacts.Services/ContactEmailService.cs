using Learn.MyContacts.Models;
using Learn.MyContacts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.MyContacts.Services
{
    public class ContactEmailService : IContactCollGenericService<ContactEmail>
    {
        private readonly IContactCollGenericRepository<ContactEmail> _repository;

        public ContactEmailService(IContactCollGenericRepository<ContactEmail> repository)
        {
            _repository = repository;
        }

        public async Task<List<ContactEmail>> GetAll(int entityID)
        {


            return await _repository.GetAll(entityID) ;
        }

        public async Task<ContactEmail> GetByID(int itemCollEntityID)
        {
            return await _repository.GetByID(itemCollEntityID);
        }

        public async Task<int> Save(ContactEmail itemCollEntity)
        {
            return await _repository.Save(itemCollEntity);
        }

        public async Task<int> Delete(int itemCollEntityID)
        {
            return await _repository.Delete(itemCollEntityID);
        }
    }
}
