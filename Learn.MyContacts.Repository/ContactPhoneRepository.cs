using Learn.MyContacts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.MyContacts.Repository
{
    public class ContactPhoneRepository : IContactCollGenericRepository<ContactPhone>
    {
        private readonly MyContactsContext _context;

        public ContactPhoneRepository(MyContactsContext context)
        {
            _context = context;
        }

        public async Task<List<ContactPhone>> GetAll(int entityID)
        {
            var contacts = await _context.ContactsPhones.Where(m => m.ContactID == entityID)
            .ToListAsync();

            return contacts;
        }

        public async Task<ContactPhone> GetByID(int itemCollEntityID)
        {
            var contacts = await _context.ContactsPhones.Where(m => m.ContactPhoneID == itemCollEntityID)
            .SingleOrDefaultAsync();

            return contacts;
        }

        public async Task<int> Save(ContactPhone itemCollEntity)
        {
            if (itemCollEntity.ContactPhoneID > 0)
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
            var contactPhoneux = await _context.ContactsPhones.SingleOrDefaultAsync(m => m.ContactPhoneID == itemCollEntityID);
            _context.ContactsPhones.Remove(contactPhoneux);
            return await _context.SaveChangesAsync();
        }
    }
}
