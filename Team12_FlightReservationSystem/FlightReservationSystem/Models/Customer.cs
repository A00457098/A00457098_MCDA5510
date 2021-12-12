using System;
using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem.Models
{
    public class Customer
    {
        [Key]
        public string Username { get; set; }

        public string Password{ get; set; }

        public string Name { get; set; }

        public string ContactNo { get; set; }

        public string CardNumber {get; set; }

        public int CVV { get; set; }

        public string CardExpiry { get; set; }

        

    }
}
