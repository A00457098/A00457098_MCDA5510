using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Models
{
    public class Customer
    {
        [Key]
        public string Username { get; set; }

        public string Password{ get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        //[RegularExpression("[a-z]")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string ContactNo { get; set; }

        [RegularExpression(@"^4[0-9]{15}$")]
        [Required]
        [StringLength(16)]
        public string CardNumber {get; set; }

        public int CVV { get; set; }

        public string CardExpiry { get; set; }

        

    }
}
