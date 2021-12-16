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

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name should not contain any special characters or numbers")]
        [StringLength(20, ErrorMessage = "Name should not contain more than 20 characters")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name should not contain any special characters or numbers")]
        [StringLength(20, ErrorMessage = "Name should not contain more than 20 characters")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public string Birth_Date { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "A email address is required")]
        //[DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10}$",ErrorMessage ="Enter a valid phone number")]
        [Phone(ErrorMessage = "A phone number is required")]
        [DisplayName("Phone")]
        public string Phone_Num { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string Gender { get; set; }

    }
}
