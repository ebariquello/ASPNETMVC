using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learn.MyContacts.Models
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }
        [Display(Name = "Nome do Contato")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Preencha o Nome do Contato")]
        public string Name { get; set; }
        [Display(Name = "Endereço do Contato")]
        public string Address { get; set; }
        [Display(Name = "Empresa do Contato")]
        public string Company { get; set; }
        [Display(Name = "Emails do Contato")]
        public ICollection<ContactEmail> ContactEmails { get; set; }
        [Display(Name = "Telefones do Contato")]
        public ICollection<ContactPhone> ContactPhones { get; set; }
    }
}

