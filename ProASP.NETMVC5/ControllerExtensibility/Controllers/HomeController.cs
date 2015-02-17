using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ControllerExtensibility.Infrastructure;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Result result = new Result
            {
                ControllerName = "Home",
                ActionName = "Index"
            };

            return View("Result", result);
        }

        // Here the combination of two action method selector attributes creates the possibility
        // of a seperate method invocation when requested by the server
        [Local]
        [ActionName("Index")]
        public ActionResult LocalIndex()
        {
            Result result = new Result
            {
                ControllerName = "Home",
                ActionName = "LocalIndex"
            };

            return View("Result", result);
        }

        // Here we handle action method lookup failure for just this controller.
        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write(
                String.Format("You requested the {0} action", actionName));
        }
    }
}