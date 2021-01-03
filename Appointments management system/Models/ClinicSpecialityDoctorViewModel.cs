using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appointments_management_system.Models
{
    public class ClinicSpecialityDoctorViewModel
    {
        public int ChosenClinicId { get; set; }
        public int ChosenSpecialityId { get; set; }
        public IEnumerable<SelectListItem> SpecialityList { get; set; }
        public IEnumerable<SelectListItem> ClinicList { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Details { get; set; }
        public int DoctorId { get; set; }
    }
}