using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Appointments_management_system.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public int SpecialityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // one-to-many relationship
        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}