using Learn.MyContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.MyContacts.Repository
{
    public class DbInitializer
    {
        public static void Initialize(MyContactsContext context)
        {
            context.Database.EnsureCreated();
            var contacts = new MyContacts.Models.Contact[]
            {
                new Contact{Name="CT 1",Company="Emp 1" , Address = "End 1"},
            new Contact{Name="CT 2",Company="Emp 2",  Address = "End 2"},
            new Contact{Name="CT 3",Company="Emp 3", Address = "End 3"},
            new Contact{Name="Eduardo Bariquello",Company="Programmers", Address = "Rua Duque de Caxias 475, Apto 85"},

            };
            foreach (Contact c in contacts)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();

            var contactEmails = new List<ContactEmail>();
            foreach (Contact c in context.Contacts)
            {
                contactEmails.Add(new ContactEmail
                {
                    ContactID = c.ContactID,
                    Email = "xpto01@teste.com",
                    EmailType = InfoType.Casa
                });
                contactEmails.Add(new ContactEmail
                {
                    ContactID = c.ContactID,
                    Email = "xpto02@teste.com",
                    EmailType = InfoType.Outro
                });
            }


            foreach (ContactEmail ce in contactEmails)
            {
                context.ContactsEmails.Add(ce);
            }
            context.SaveChanges();

            var contactPhones = new List<ContactPhone>();
            foreach (Contact c in context.Contacts)
            {
                contactPhones.Add(new ContactPhone
                {
                    ContactID = c.ContactID,
                    Phone = "3444444",
                    PhoneType = InfoType.Casa
                });
                contactPhones.Add(new ContactPhone
                {
                    ContactID = c.ContactID,
                    Phone = "3242323",
                    PhoneType = InfoType.Outro
                });
            }


            foreach (ContactPhone cp in contactPhones)
            {
                context.ConttactsPhones.Add(cp);
            }
            context.SaveChanges();
        }
    }
}
