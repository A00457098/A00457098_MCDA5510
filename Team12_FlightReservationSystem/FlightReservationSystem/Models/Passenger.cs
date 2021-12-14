using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Models
{
    public class Passenger
    {
        [Key]
        public string ID { get; set; }

        public string UserID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Birth_Date { get; set; }

        public string Email { get; set; }

        public string Phone_Num { get; set; }
        public string Gender { get; set; }

    }
}
