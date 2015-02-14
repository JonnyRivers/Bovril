using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Filters.Infrastructure;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Users="admin")]
        public String Index()
        {
            return "This is the Index action on the Home controller";
        }

        [GoogleAuthentication]// ensures that the username ends is @google.com and that any failure redirects to GoogleAccount/Login
        [Authorize(Users="bob@google.com")]// ensures that the username is bob@google.com
        // The end result is any failure going to GoogleAccount/Login
        // Note that it's possible to create 'authentication impossibilities'
        public String List()
        {
            return "This is the List action on the Home controller";
        }

        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        public String RangeTest(int id)
        {
            if (id > 100)
            {
                return String.Format("The id value is: {0}", id);
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }

        [CustomAction]
        public String FilterTest()
        {
            return "This is the FilterTest action";
        }

        [ProfileAction]
        public String ProfileTest()
        {
            return "This is the ActionFilterTest action";
        }
    }
}