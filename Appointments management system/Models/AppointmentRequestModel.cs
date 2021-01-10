using Appointments_management_system.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appointments_management_system.Models
{
    public class AppointmentRequestModel
    {
        public int AppointmentId { get; set; }

        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Appointment date must be set")]
        [AppointmentDateRequestDateValidator]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please type in a short description for the appointment")]
        [MinLength(10, ErrorMessage = "Description cannot be less than 10 characters!"),
        MaxLength(200, ErrorMessage = "Description cannot be more than 200 characters!")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Hour must be set")]
        public string ChosenAppointmentHour { get; set; }

        [Required(ErrorMessage = "First name must exist!")]
        [MinLength(3, ErrorMessage = "First name should be at least 3 characters long"),
        MaxLength(20, ErrorMessage = "First name should have maximum 20 characters")]
        [RegularExpression(@"^[A-Z][a-zA-Z]+$", ErrorMessage = "First name should start with Capital letter and can only contains letters")]
        public string DoctorFirstName { get; set; }

        [Required(ErrorMessage = "Last name must exist!")]
        [MinLength(3, ErrorMessage = "Last name should be at least 3 characters long"),
        MaxLength(20, ErrorMessage = "Last name should have maximum 20 characters")]
        [RegularExpression(@"^[A-Z][a-zA-Z]+$", ErrorMessage = "Last name should start with Capital letter and can only contains letters")]
        public string DoctorLastName { get; set; }

        [Required(ErrorMessage = "Clinic name must exist!")]
        public string ClinicName { get; set; }

        [Required(ErrorMessage = "City must exist!")]
        public string City { get; set; }

        public IEnumerable<SelectListItem> AppointmentHours { get; set; }
    }
}