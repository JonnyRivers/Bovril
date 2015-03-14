using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebServices.Models;

namespace WebServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(ReservationRepository.Current.GetAll());
        }

        public ActionResult Add(Reservation item)
        {
            if (ModelState.IsValid)
            {
                ReservationRepository.Current.Add(item);

                return RedirectToAction("Index");
            }

            return View("Index");
        }

        public ActionResult Remove(int id)
        {
            ReservationRepository.Current.Remove(id);

            return RedirectToAction("Index");
        }

        public ActionResult Update(Reservation item)
        {
            if (ModelState.IsValid && ReservationRepository.Current.Update(item))
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}