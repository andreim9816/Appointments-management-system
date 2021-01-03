using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appointments_management_system.Models
{
    public class ClinicSpecialityDoctorViewModel
    {
        public int ChosenClinicId { get; set; }
        public int ChosenSpecialityId { get; set; }
        public IEnumerable<Speciality> SpecialityList { get; set; }
        public IEnumerable<Clinic> ClinicList { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}