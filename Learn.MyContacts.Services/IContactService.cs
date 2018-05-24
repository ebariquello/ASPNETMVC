using Learn.MyContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.MyContacts.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetByID(int contactID);
        Task<int> Save(Contact contact);
        Task<int> Delete(int contactID);

        bool Exists(int contactID);
    }
}
