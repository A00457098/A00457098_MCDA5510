using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Models
{
    public class BookingHistory
    {
        public string UserId { get; set; }
        [Key]
        [DisplayName("PNR")]
        public string PNR_Number { get; set; }
        [DisplayName("Flight Number")]
        public string Flight_Name { get; set; }
        [Required]
        [DisplayName("Departure")]
        public string Departure_City { get; set; }
        [Required]
        [DisplayName("Arrival")]
        public string Arrival_City { get; set; }
        [Required]
        [DisplayName("Departure Date")]
        public string Departure_Date { get; set; }

        [DisplayName("Arrival Date")]
        public string Arrival_Date { get; set; }

        [DisplayName("Price")]
        public int Price { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        public string Birth_Date { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Phone")]
        public string Phone_Num { get; set; }

        [DisplayName("Gender")] 
        public string Gender { get; set; }
    }
}
