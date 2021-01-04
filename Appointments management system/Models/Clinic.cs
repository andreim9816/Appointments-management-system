using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Appointments_management_system.Models
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }

        [Required]
        [MinLength(5, ErrorMessage ="Clinic name should be at least 5 characters long"),
        MaxLength(30, ErrorMessage = "Clinic name should have maximum 30 characters")]
        public string Name { get; set; }

        [RegularExpression(@"07([0-9]){8}", ErrorMessage = "Please enter a valid phone number!")]
        public string PhoneNumber { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        // one-to-many relationship
        public virtual ICollection<Doctor> Doctors { get; set; }
        // many-to-many relationship
        public virtual ICollection<Speciality> Specialities { get; set; }
    }
}