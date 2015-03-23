using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TaxMe.Models;

namespace TaxMe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IncomeAndDeductions incomeAndDeductions)
        {
            TaxBreakdown taxBreakdown = TaxCalculator.Calculate(incomeAndDeductions);
            return View("TaxBreakdown", taxBreakdown);
        }

        public ActionResult TaxBreakdown()
        {
            return View();
        }
    }
}