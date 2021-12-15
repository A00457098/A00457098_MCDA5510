using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Models
{
    public class Flight
    {
        [Key]
        public string ID { get; set; }

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
       
        [DisplayName("Economy")]
        public int Price { get; set; }


    }
}
