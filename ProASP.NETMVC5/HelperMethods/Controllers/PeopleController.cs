using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] m_people = {
            new Person {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person {FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person {FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
        };

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetPeopleData(String selectedRoleText)
        {
            IEnumerable<Person> people = m_people;
            if (selectedRoleText != "All")
            {
                Role selectedRole = (Role)Enum.Parse(typeof(Role), selectedRoleText);
                people = m_people.Where(p => p.Role == selectedRole);
            }

            return PartialView(people);
        }

        public ActionResult GetPeople(String selectedRoleText = "All")
        {
            return View((Object)selectedRoleText);
        }
    }
}