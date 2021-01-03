using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appointments_management_system.Models
{
    public class ClinicSpecialityViewModel
    {
        public int ClinicId;
        public String ClinicName;
        public int ChosenSpecialityId { get; set; }
        public IEnumerable<Speciality> SpecialityType { get; set; }
    }
}