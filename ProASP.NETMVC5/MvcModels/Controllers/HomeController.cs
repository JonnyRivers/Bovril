using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcModels.Models;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private Person[] m_people = {
            new Person {PersonId = 1, FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person {PersonId = 2, FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person {PersonId = 3, FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person {PersonId = 4, FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
        };
        
        public ActionResult Index(int? id = 1)
        {
            Person person = m_people.First(p => p.PersonId == id);
            return View(person);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("Index", person);
        }

        public ActionResult DisplaySummary([Bind(Prefix="HomeAddress")]AddressSummary summary)
        {
            return View(summary);
        }

        public ActionResult Names(IList<String> names)
        {
            names = names ?? new List<String>();
            return View(names);
        }

        public ActionResult Address()
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            UpdateModel(addresses);
            return View(addresses);
        }
    }
}