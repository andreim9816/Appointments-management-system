﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appointments_management_system.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int AppointmentHour { get; set; }
        public int AppointmentMinute { get; set; }
        //one-to-many relationship
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        //one-to-many relationship
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}