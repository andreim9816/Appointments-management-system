using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appointments_management_system.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="Street Name should have at least 3 characters"),
        MaxLength(20, ErrorMessage ="Street Name should have maximum 20 characters")]
        public string Street { get; set; }

        public int No { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "City should have at least 3 characters"),
        MaxLength(20, ErrorMessage = "City should have maximum 20 characters")]
        public string City { get; set; }

        //one-to-one relationship
        public virtual Clinic Clinic { get; set; }
    }
}