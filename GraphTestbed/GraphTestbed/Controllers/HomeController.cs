using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GraphTestbed.Models;

namespace GraphTestbed.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Letters()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult BuildSystemStats()
        {
            return View();
        }

        public JsonResult GetNumbers()
        {
            int[] numbers = new int[] { 4, 8, 15, 16, 23, 42 };
            return Json(numbers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPeople()
        {
            // We should be returning a view model here, not the model data
            Person[] people = new Person[] {
                new Person("Jonny", "Rivers", new DateTime(1979, 8, 16)),
                new Person("Michelle", "Rivers", new DateTime(1978, 1, 6))
            };
            return Json(people, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLetterFrequencies()
        {
            var items = new OrdinalBarChartItem[] {
                new OrdinalBarChartItem("A", .08167m),
                new OrdinalBarChartItem("B", .01492m),
                new OrdinalBarChartItem("C", .02782m),
                new OrdinalBarChartItem("D", .04253m),
                new OrdinalBarChartItem("E", .12702m),
                new OrdinalBarChartItem("F", .02288m),
                new OrdinalBarChartItem("G", .02015m),
                new OrdinalBarChartItem("H", .06094m),
                new OrdinalBarChartItem("I", .06966m),
                new OrdinalBarChartItem("J", .00153m),
                new OrdinalBarChartItem("K", .00772m),
                new OrdinalBarChartItem("L", .04025m),
                new OrdinalBarChartItem("M", .02406m),
                new OrdinalBarChartItem("N", .06749m),
                new OrdinalBarChartItem("O", .07507m),
                new OrdinalBarChartItem("P", .01929m),
                new OrdinalBarChartItem("Q", .00095m),
                new OrdinalBarChartItem("R", .05987m),
                new OrdinalBarChartItem("S", .06327m),
                new OrdinalBarChartItem("T", .09056m),
                new OrdinalBarChartItem("U", .02758m),
                new OrdinalBarChartItem("V", .00978m),
                new OrdinalBarChartItem("W", .02360m),
                new OrdinalBarChartItem("X", .00150m),
                new OrdinalBarChartItem("Y", .01974m),
                new OrdinalBarChartItem("Z", .00074m)
            };

            var viewModel = new OrdinalBarChartViewModel("Letter Frequencies", "Letter", "Frequency", items);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSuccessRate()
        {
            var items = new OrdinalBarChartItem[] {
                new OrdinalBarChartItem("27/6/15", .8123m),
                new OrdinalBarChartItem("4/7/15", .9212m),
                new OrdinalBarChartItem("11/7/15", .9001m),
                new OrdinalBarChartItem("18/7/15", .8839m),
                new OrdinalBarChartItem("25/7/15", .8349m),
                new OrdinalBarChartItem("1/8/15", .9301m)
            };

            var viewModel = new OrdinalBarChartViewModel("Success Rate", "Week", "Rate", items);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}