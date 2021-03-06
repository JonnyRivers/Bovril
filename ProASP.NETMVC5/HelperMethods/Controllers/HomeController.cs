﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Fruits = new String[] { "Apple", "Orange", "Pear" };
            ViewBag.Cities = new String[] { "New York", "London", "Paris" };

            String message = "This is an HTML element: <input>";

            return View((Object)message);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("DisplayPerson", person);
        }
    }
}