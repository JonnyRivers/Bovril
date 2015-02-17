using System;
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

        // ActionName, NonAction, HttpPost, etc are subytypes of ActionMethodSelectorAttribute.

        // It's possible to override action names.
        // This could be useful if the method name clashes with some reserved name.
        // This is proabably useless but was at page 543 so I typed it in!
        [ActionName("Enumerate")]
        public ViewResult List()
        {
            Result result = new Result
            {
                ControllerName = "Customer",
                ActionName = "List"
            };

            return View("Result", result);
        }

        // The NonActionAttribute is useful to prevent the default action invoker from calling a method.
        // An obvious alternative is to simply make the method private/protected/internal, which may be more correct.
        [NonAction]
        public ActionResult MyAction()
        {
            return View();
        }
    }
}