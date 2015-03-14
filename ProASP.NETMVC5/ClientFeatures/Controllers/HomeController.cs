using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClientFeatures.Models;

namespace ClientFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult MakeBooking()
        {
            Appointment appointment = new Appointment
            {
                ClientName = "Adam",
                TermsAccepted = true
            };
            return View(appointment);
        }

        [HttpPost]
        public JsonResult MakeBooking(Appointment appointment)
        {
            return Json(appointment, JsonRequestBehavior.AllowGet);
        }
    }
}