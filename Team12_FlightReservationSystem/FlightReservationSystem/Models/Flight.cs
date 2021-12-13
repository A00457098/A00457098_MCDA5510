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
       
        
        public String ID { get; set; }

        [DisplayName("Flight Number")]

        public String Flight_Name { get; set; }

        [DisplayName("Departure")]
        public String Departure_City { get; set; }

        [DisplayName("Arrival")]
        public String Arrival_City { get; set; }

        [DisplayName("Departure Date")]
        public String Departure_Date { get; set; }

        [DisplayName("Arrival Date")]
        public String Arrival_Date { get; set; }

        [DisplayName("Economy")]
        public int Price { get; set; }


    }
}
