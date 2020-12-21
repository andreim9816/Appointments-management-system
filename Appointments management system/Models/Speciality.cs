using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appointments_management_system.Models
{
    public class Speciality
    {
        [Key]
        public int SpecialityId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Speciality should have at least 3 characters!"),
        MaxLength(30, ErrorMessage = "Speciality should have maximum 30 characters!")]
        public string SpecialityName { get; set; }

        // many-to-many relationship
        public virtual ICollection<Clinic> Clinics { get; set; }

    }
}