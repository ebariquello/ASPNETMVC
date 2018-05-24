using Learn.MyContacts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.MyContacts.Repository
{
    public class MyContactsContext : DbContext

    {

        public MyContactsContext(DbContextOptions<MyContactsContext> options) : base(options)

        {

        }

       public DbSet<MyContacts.Models.Contact> Contacts { get; set; }

       public DbSet<MyContacts.Models.ContactEmail> ContactsEmails { get; set; }

       public DbSet<MyContacts.Models.ContactPhone> ConttactsPhones { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)

        { 
           modelBuilder.Entity<Contact>().ToTable("Contact");

           modelBuilder.Entity<ContactEmail>().ToTable("ContactEmail");

           modelBuilder.Entity<ContactPhone>().ToTable("ContactPhone");

       }

}
}
