using Appointments_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appointments_management_system.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        DbCtx DbCtx = new DbCtx();
        public ActionResult Index()
        {
            List<Address> addresses = DbCtx.Addresses.ToList();
            ViewBag.addresses = addresses;
            return View();
        }
    }
}