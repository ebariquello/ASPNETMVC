using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.MyContacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn.MyContacts.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly MyContactsContext _context;

        public ContactRepository(MyContactsContext context)
        {
            _context = context;
        }


        public async Task<List<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByID(int contactID)
        {
            //return await _context.Contacts
            //   .SingleOrDefaultAsync(m => m.ContactID == contactID);

            var contacts = await _context.Contacts
             .Include(c => c.ContactEmails)
             .Include(c => c.ContactPhones)
             .AsNoTracking()
             .SingleOrDefaultAsync(m => m.ContactID == contactID);

            return contacts;

        }

        public bool  Exists(int contactID)
        {
            return _context.Contacts.Any(e => e.ContactID == contactID);
        }

        public async Task<int> Save(Contact contact)
        {
            if (contact.ContactID > 0)
            {
                _context.Update(contact);
                return await _context.SaveChangesAsync();
            }
            else
            {
                _context.Add(contact);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(int contactID)
        {
            var contactAux = await _context.Contacts.SingleOrDefaultAsync(m => m.ContactID == contactID);
            _context.Contacts.Remove(contactAux);
            return await _context.SaveChangesAsync();
        }

    }
}
