using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.MyContacts.Models
{
   
    public class ContactEmail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactEmailID { get; set; }
        public int ContactID { get; set; }
        public string Email { get; set; }
        public InfoType EmailType { get; set; }
        public Contact Contact { get; set; }
      
    }
}