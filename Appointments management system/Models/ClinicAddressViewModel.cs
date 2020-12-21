using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appointments_management_system.Models
{
    public class ClinicAddressViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Clinic name should be at least 5 characters long"),
        MaxLength(30, ErrorMessage = "Clinic name should have maximum 30 characters")]
        public string Name { get; set; }

        [RegularExpression(@"07([0-9]){8}", ErrorMessage = "Please enter a valid phone number!")]
        public string PhoneNumber { get; set; }

        [MinLength(3, ErrorMessage = "Street name should be at least 3 characters long"),
        MaxLength(20, ErrorMessage = "Street name should have maximum 20 characters")]
        public string Street { get; set; }

        public int No { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "City name should be at least 3 characters long"),
        MaxLength(30, ErrorMessage = "City name should have maximum 30 characters")]
        public string City { get; set; }
    }
}