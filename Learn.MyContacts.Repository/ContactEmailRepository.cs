using Learn.MyContacts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.MyContacts.Repository
{
    public class ContactEmailRepository : IContactCollGenericRepository<ContactEmail>
    {
        private readonly MyContactsContext _context;

        public ContactEmailRepository(MyContactsContext context)
        {
            _context = context;
        }

        public async Task<List<ContactEmail>> GetAll(int entityID)
        {
            var contacts = await _context.ContactsEmails.Where(m => m.ContactID == entityID)
            .ToListAsync();

            return contacts;
        }

        public async Task<ContactEmail> GetByID(int itemCollEntityID)
        {
            var contacts = await _context.ContactsEmails.Where(m => m.ContactEmailID == itemCollEntityID)
            .SingleOrDefaultAsync();

            return contacts;
        }

        public async Task<int> Save(ContactEmail itemCollEntity)
        {
            if (itemCollEntity.ContactEmailID > 0)
            {
                _context.Update(itemCollEntity);
                return await _context.SaveChangesAsync();
            }
            else
            {
                _context.Add(itemCollEntity);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(int itemCollEntityID)
        {
            var contactEmailAux = await _context.ContactsEmails.SingleOrDefaultAsync(m => m.ContactEmailID == itemCollEntityID);
            _context.ContactsEmails.Remove(contactEmailAux);
            return await _context.SaveChangesAsync();
        }
    }
}
