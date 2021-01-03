using System;
using System.Collections.Generic;
using System.Linq;
using Appointments_management_system.Models;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace Appointments_management_system.Controllers
{
    public class DoctorController : Controller
    {
        private DbCtx DbCtx = new DbCtx();

        // GET: Doctor
        [HttpGet]
        public ActionResult Index()
        {
            List<Doctor> Doctors = DbCtx.Doctors.ToList();
            List<String> SpecialityList = new List<string>();
            foreach (var doctor in Doctors)
            {
                Speciality spec = DbCtx.Specialities.Find(doctor.SpecialityId);
                SpecialityList.Add(spec.SpecialityName);
            }

            ViewBag.Doctors = Doctors;
            ViewBag.SpecialityList = SpecialityList;

            return View();
        }

        [HttpGet]
        public ActionResult DoctorsFilter(int? SpecialityId, int? ClinicId)
        {
            var doctorList = DbCtx.Doctors
                .Where(d => d.ClinicId == ClinicId)
                .Where(d => d.SpecialityId == SpecialityId)
                .ToList();

            var clinic = DbCtx.Clinics
                .Where(c => c.ClinicId == ClinicId)
                .FirstOrDefault<Clinic>();

            var speciality = DbCtx.Specialities
                .Where(s => s.SpecialityId == SpecialityId).
                FirstOrDefault<Speciality>();

            ViewBag.doctorList = doctorList;
            ViewBag.specialityName = speciality.SpecialityName;
            ViewBag.clinicName = clinic.Name;

            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            ClinicSpecialityDoctorViewModel vm = new ClinicSpecialityDoctorViewModel
            {
                SpecialityList = DbCtx.Specialities.ToList(),
                ClinicList = DbCtx.Clinics.ToList(),
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult New(ClinicSpecialityDoctorViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    /* check that the speciality already exists in the selected clinic */
                    Clinic clinic = DbCtx.Clinics.Find(vm.ChosenClinicId);
                    Speciality speciality = DbCtx.Specialities.Find(vm.ChosenSpecialityId);

                    if (clinic == null)
                    {
                        return HttpNotFound("Couldn't find the clinic with id " + vm.ChosenClinicId.ToString() + "!");
                    }

                    if (speciality == null)
                    {
                        return HttpNotFound("Couldn't find the speciality with id " + vm.ChosenSpecialityId.ToString() + "!");
                    }

                    var obj = (from Clinic in DbCtx.Clinics.Where(c => c.ClinicId == vm.ChosenClinicId)
                               from Speciality in Clinic.Specialities.Where(spec => spec.SpecialityId == vm.ChosenSpecialityId)
                               select Clinic).FirstOrDefault();


                    if (obj == null)
                    {
                        return HttpNotFound("Speciality " + speciality.SpecialityName + " doesn't exist in the " + clinic.Name + " clinic!");
                    }


                    Doctor doctor = new Doctor
                    {
                        LastName = vm.LastName,
                        FirstName = vm.FirstName,
                        SpecialityId = vm.ChosenSpecialityId,
                        Clinic = clinic
                    };

                    DbCtx.Doctors.Add(doctor);

                    DbCtx.SaveChanges();
                    return RedirectToAction("Index", "Doctor");
                }
                return View(vm);
            }
            catch (Exception e)
            {
                return View(vm);
            }
        }
    }
}