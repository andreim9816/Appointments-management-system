using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appointments_management_system.Models
{
    public class AppointmentRequestModel
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public string ChosenAppointmentHour { get; set; }
        public IEnumerable<SelectListItem> AppointmentHours { get; set; }
    }
}