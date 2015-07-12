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
        public ActionResult Index()
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
            Letter[] letters = new Letter[] {
                new Letter("A", .08167m),
                new Letter("B", .01492m),
                new Letter("C", .02782m),
                new Letter("D", .04253m),
                new Letter("E", .12702m),
                new Letter("F", .02288m),
                new Letter("G", .02015m),
                new Letter("H", .06094m),
                new Letter("I", .06966m),
                new Letter("J", .00153m),
                new Letter("K", .00772m),
                new Letter("L", .04025m),
                new Letter("M", .02406m),
                new Letter("N", .06749m),
                new Letter("O", .07507m),
                new Letter("P", .01929m),
                new Letter("Q", .00095m),
                new Letter("R", .05987m),
                new Letter("S", .06327m),
                new Letter("T", .09056m),
                new Letter("U", .02758m),
                new Letter("V", .00978m),
                new Letter("W", .02360m),
                new Letter("X", .00150m),
                new Letter("Y", .01974m),
                new Letter("Z", .00074m)
            };

            return Json(letters, JsonRequestBehavior.AllowGet);
        }
    }
}