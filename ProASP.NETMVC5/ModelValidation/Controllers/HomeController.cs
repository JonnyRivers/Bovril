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
            // Validate the model - an alternative to other methods of model validation
            //if (String.IsNullOrEmpty(appointment.ClientName))
            //{
            //    ModelState.AddModelError("ClientName", "Please enter your name");
            //}

            //if (ModelState.IsValidField("Date") && appointment.Date <= DateTime.Now)
            //{
            //    ModelState.AddModelError("Date", "Please enter a date in the future");
            //}

            //if (!appointment.TermsAccepted)
            //{
            //    ModelState.AddModelError("TermsAccepted", "You must accept the terms");
            //}

            //// Here we show a cross-property or model-level error
            //if (ModelState.IsValidField("ClientName") && 
            //    ModelState.IsValidField("Date") &&
            //    appointment.ClientName == "Joe" &&
            //    appointment.Date.DayOfWeek == DayOfWeek.Monday)
            //{
            //    ModelState.AddModelError("", "Joe cannot book appointments on Mondays");
            //}

            if (ModelState.IsValid)
            {
                // TODO: store the appointment

                return View("Completed", appointment);
            }
            else
            {
                return View();
            }
        }
    }
}