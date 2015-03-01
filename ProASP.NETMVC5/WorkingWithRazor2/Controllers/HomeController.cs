using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkingWithRazor2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            String[] names = { "Apples", "Orange", "Pear" };

            return View(names);
        }

        public ActionResult List()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Time()
        {
            return PartialView(DateTime.Now);
        }
    }
}