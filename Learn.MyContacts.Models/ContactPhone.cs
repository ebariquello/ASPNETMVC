using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.MyContacts.Models
{
    public class ContactPhone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactPhoneID { get; set; }
        public int ContactID { get; set; }
        public string Phone { get; set; }
        public InfoType PhoneType { get; set; }
        public Contact Contact { get; set; }

        public bool IsPrincipal { get; set; }
    }
}