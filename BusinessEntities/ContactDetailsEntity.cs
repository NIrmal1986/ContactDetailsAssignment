using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
    public class ContactDetailsEntity
    {
        public int ContactId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Please enter valid 10 digit Number")]
        public Int64 PhoneNumber { get; set; }
        public string Status { get; set; }
    }
}
