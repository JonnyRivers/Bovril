using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
    public class ProductController : Controller
    {
        public ViewResult Index()
        {
            Result result = new Result
            {
                ControllerName = "Product",
                ActionName = "Index"
            };

            return View("Result", result);
        }

        public ViewResult List()
        {
            Result result = new Result
            {
                ControllerName = "Product",
                ActionName = "List"
            };

            return View("Result", result);
        }
    }
}