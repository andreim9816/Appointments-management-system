using Appointments_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appointments_management_system.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        
        [HttpGet]
        public ActionResult Index()
        {

            ViewBag.UsersList = ctx.Users.ToList();
            foreach(var user in ctx.Users.ToList())
            {
                var x = 2;
            }
            return View();
        }
    }
}