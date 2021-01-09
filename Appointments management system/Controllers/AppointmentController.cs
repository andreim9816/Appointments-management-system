using Appointments_management_system.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appointments_management_system.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext DbCtx = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            List<Appointment> appointmentList = DbCtx.Appointments.Where(obj => obj.ApplicationUserId == userId).ToList();
            ViewBag.appointmentList = appointmentList;
            return View();
        }


        [HttpGet]
        public ActionResult New(int? id)
        {
            if (id.HasValue)
            {
                Doctor doctor = DbCtx.Doctors.Find(id);

                if (doctor == null)
                {
                    return HttpNotFound("There is no doctor with this id!");
                }

                ViewBag.DoctorLastName = doctor.LastName;
                ViewBag.DoctorFirstName = doctor.FirstName;

                AppointmentRequestModel appointmentRequestModel = new AppointmentRequestModel
                {
                    DoctorId = (int)id,
                    Date = new DateTime(2021, 1, 1),
                    ChosenAppointmentHour = "00:00",
                    AppointmentHours = new List<SelectListItem>()
                };

                return View(appointmentRequestModel);
            }
            return HttpNotFound("Missing doctor id parameter!");
        }

        [HttpPost]
        public ActionResult New(AppointmentRequestModel request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Appointment appointment = new Appointment
                    {
                        DoctorId = request.DoctorId,
                        AppointmentDate = request.Date,
                        Details = request.Details,
                        AppointmentHour = request.ChosenAppointmentHour,
                        ApplicationUserId = this.User.Identity.GetUserId()
                    };

                    DbCtx.Appointments.Add(appointment);

                    DbCtx.SaveChanges();
                    return RedirectToAction("New", "Appointment");
                }
                return View(request);
            }
            catch (Exception e)
            {
                return View(request);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Appointment appointment = DbCtx.Appointments.Find(id);

                if (appointment == null)
                {
                    return HttpNotFound("Couldn't find the appointment with id = " + id.ToString() + "!");
                }

                AppointmentRequestModel request = new AppointmentRequestModel
                {
                    AppointmentId = (int)id,
                    DoctorId = appointment.DoctorId,
                    Date = appointment.AppointmentDate,
                    Details = appointment.Details,
                    ChosenAppointmentHour = appointment.AppointmentHour,
                    AppointmentHours = GetAllAvailableHoursForEdit(appointment.AppointmentDate, appointment.DoctorId)
                };

                return View(request);
            }
            return HttpNotFound("Missing appointment id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, AppointmentRequestModel request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Appointment appointment = DbCtx.Appointments.Find(id);

                    if (TryValidateModel(appointment))
                    {
                        appointment.AppointmentDate = request.Date;
                        appointment.AppointmentHour = request.ChosenAppointmentHour;
                        appointment.Details = request.Details;

                        DbCtx.SaveChanges();
                    }
                    return RedirectToAction("Index", "Appointment");
                }
                return View(request);
            }
            catch (Exception e)
            {
                return View(request);
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id.HasValue)
            {
                Appointment appointment = DbCtx.Appointments.Find(id);
                if(appointment == null)
                {
                    return HttpNotFound("Couldn't find the appointment with id " + id.ToString() + "!");
                }
                Speciality speciality = DbCtx.Specialities.Find(appointment.Doctor.SpecialityId);

                ViewBag.SpecialityName = speciality.SpecialityName;
                return View(appointment);
            }
            return HttpNotFound("Missing appointment id parameter!");
        }


        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Appointment appointment = DbCtx.Appointments.Find(id);
                if (appointment == null)
                {
                    return HttpNotFound("Couldn't find the appointment with id = " + id.ToString() + "!");
                }
                DbCtx.Appointments.Remove(appointment);

                DbCtx.SaveChanges();
                return RedirectToAction("Index", "Appointment");
            }
            return HttpNotFound("Missing appointment id parameter!");
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllAvailableHoursForEdit(DateTime? date, int doctorId)
        {
            var selectList = new List<SelectListItem>();

            var AppointmentHourList = new List<String> { "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00" };

            Doctor doctor = DbCtx.Doctors.Find(doctorId);

            if (doctor == null)
            {
                return new List<SelectListItem>();
            }

            // get the doctor's appointment list on that date
            var appointmentList = doctor.Appointments
                .Where(obj => obj.AppointmentDate == date)
                .Select(obj => obj.AppointmentHour).ToList();

            // get the available hours
            var remainingHours = AppointmentHourList.Except(appointmentList).ToList();

            foreach (string hour in remainingHours)
            {
                // build the dropDownList elements
                selectList.Add(new SelectListItem
                {
                    Value = hour,
                    Text = hour,
                });
            }

            return selectList;
        }

        public ActionResult GetAllAvailableHours(DateTime? date, int doctorId)
        {
            var selectList = new List<string>();
            var AppointmentHourList = new List<String> { "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00" };

            Doctor doctor = DbCtx.Doctors.Find(doctorId);

            if (doctor == null)
            {
                return Json(new List<string>(), JsonRequestBehavior.AllowGet);
            }

            // get the doctor's appointment list on that date
            var appointmentList = doctor.Appointments
                .Where(obj => obj.AppointmentDate == date)
                .Select(obj => obj.AppointmentHour).ToList();

            // get the available hours
            var remainingHours = AppointmentHourList.Except(appointmentList).ToList();

            foreach (string hour in remainingHours)
            {
                // build the dropDownList elements
                selectList.Add(hour);
            }

            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
    }
}