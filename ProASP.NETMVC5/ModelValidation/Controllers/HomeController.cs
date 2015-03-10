using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appointment)
        {
            // TODO: store the appointment

            return View("Completed", appointment);
        }
    }
}