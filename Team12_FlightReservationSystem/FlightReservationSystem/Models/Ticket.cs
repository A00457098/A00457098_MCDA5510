using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Models
{
    public class Ticket
    {
        [Key]
        public string ID { get; set; }

        public string UserID { get; set; }

        public string FlightID { get; set; }

        public string PassengerID { get; set; }

        public string PNR { get; set; }
    }
}
