﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
    public class CustomerController : Controller
    {
        public ViewResult Index()
        {
            Result result = new Result
            {
                ControllerName = "Customer",
                ActionName = "Index"
            };

            return View("Result", result);
        }

        public ViewResult List()
        {
            Result result = new Result
            {
                ControllerName = "Customer",
                ActionName = "List"
            };

            return View("Result", result);
        }
    }
}