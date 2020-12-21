﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Appointments_management_system.Models;

namespace Appointments_management_system.Controllers
{
    public class ClinicController : Controller
    {
        private DbCtx DbCtx = new DbCtx();
        // GET: Clinic
        public ActionResult Index()
        {
            List<Clinic> clinics = DbCtx.Clinics.ToList();
            ViewBag.clinics = clinics;
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            ClinicAddressViewModel clinicAddressViewModel = new ClinicAddressViewModel();
            return View(clinicAddressViewModel);
        }

        [HttpPost]
        public ActionResult New(ClinicAddressViewModel objectRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Address address = new Address
                    {
                        Street = objectRequest.Street,
                        No = objectRequest.No,
                        City = objectRequest.City
                    };

                    Clinic clinic = new Clinic
                    {
                        PhoneNumber = objectRequest.PhoneNumber,
                        Name = objectRequest.Name,
                        Address = address
                    };

                    DbCtx.Addresses.Add(address);
                    DbCtx.Clinics.Add(clinic);
                    DbCtx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(objectRequest);
            }
            catch (Exception e)
            {
                return View(objectRequest);
            }
        }
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Clinic clinic = DbCtx.Clinics.Find(id);
                if (clinic != null)
                {
                    return View(clinic);
                }
                return HttpNotFound("Couldn't find the clinic with id " + id.ToString() + "!");
            }
            return HttpNotFound("Missing clinic id parameter!");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Clinic clinic = DbCtx.Clinics.Find(id);
                ViewBag.id = id;
                ClinicAddressViewModel vm = new ClinicAddressViewModel();

                vm.Name = clinic.Name;
                vm.PhoneNumber = clinic.PhoneNumber;
                vm.City = clinic.Address.City;
                vm.No = clinic.Address.No;
                vm.Street = clinic.Address.Street;
              
                if (clinic == null)
                {
                    return HttpNotFound("Couldn't find the clinic with id = " + id.ToString() + "!");
                }
                return View(vm);
            }
            return HttpNotFound("Missing clinic id parameter!");
        }

        [HttpPut]
        public ActionResult Edit(int id, ClinicAddressViewModel request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Clinic clinic = DbCtx.Clinics.Find(id);

                    if (TryUpdateModel(clinic))
                    {
                        clinic.Name = request.Name;
                        clinic.PhoneNumber = request.PhoneNumber;
                        clinic.Address.Street = request.Street;
                        clinic.Address.No = request.No;
                        clinic.Address.City = request.City;

                        DbCtx.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(request);
            }
            catch (Exception e)
            {
                return View(request);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Clinic clinic = DbCtx.Clinics.Find(id);
                if (clinic == null)
                {
                    return HttpNotFound("Couldn't find the clinic with id = " + id.ToString() + "!");
                }
                DbCtx.Addresses.Remove(clinic.Address);
                DbCtx.Clinics.Remove(clinic);
                DbCtx.SaveChanges();
                return RedirectToAction("Index", "Clinic");
            }
            return HttpNotFound("Missing clinic id parameter!");
        }
    }
}