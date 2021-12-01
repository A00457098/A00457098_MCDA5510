using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Models
{
    public class Customer
    {
        [Key]
        public String Username { get; set; }

        public String Password{ get; set; }

        public String Name { get; set; }

        public String ContactNo { get; set; }

        public String CardNumber {get; set; }

        public int CVV { get; set; }

        public String CardExpiry { get; set; }

        

    }
}
