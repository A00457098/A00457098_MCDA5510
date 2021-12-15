using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Models
{
    public class Payment
    {
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
        [DisplayName("Card Type")]
        public string CardType { get; set; }


        [RegularExpression(@"^5[1-5][0-9]{14}$|^3[47][0-9]{13}$|^4[0-9]{15}$", ErrorMessage = "Invalid Card Number")]
        [Required]
        [StringLength(16, ErrorMessage = "Card Number should not contain more than 16 characters")]
        [DisplayName("Card Number")]
        public string CardNumber {get; set; }

        [RegularExpression(@"[0-9]{3}", ErrorMessage = "Invalid CVV")]
        [Required]
        [MaxLength(3, ErrorMessage = "Invalid CVV")]
        [DisplayName("CVV")]
        public int CVV { get; set; }

        [Required]
        [DisplayName("Expiry Month")]
        public string CardExpiryMonth { get; set; }

        [Required]
        [DisplayName("Expiry Year")]
        public string CardExpiryYear { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Street Name should not contain any special characters or numbers")]
        [StringLength(20, ErrorMessage = "Name should not contain more than 20 characters")]
        [DisplayName("Street Name")]
        public string StreetName { get; set; }

        [Required]
        [DisplayName("Street Number")]
        public int StreetNumber { get; set; }
        [Required]
        [DisplayName("Unit Number")]
        public int UnitNumber { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "City should not contain any special characters or numbers")]
        [StringLength(20, ErrorMessage = "City should not contain more than 20 characters")]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Province/State should not contain any special characters or numbers")]
        [StringLength(20, ErrorMessage = "Province/State should not contain more than 20 characters")]
        [DisplayName("Province/State")]
        public string Province { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Country should not contain any special characters or numbers")]
        [DisplayName("Country")]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]\d[a-zA-Z][-\s]\d[a-zA-Z]\d$|^\d{5}(?:[-\s]\d{4})?$", 
            ErrorMessage = "Invalid ZIP Code")]
        [StringLength(7, ErrorMessage = "Invalid ZIP Code")]
        [DisplayName("ZIP")]
        public string ZIP { get; set; }
    }


}
