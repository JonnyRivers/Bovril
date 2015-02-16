using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Filters.Infrastructure;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        private Stopwatch m_stopwatch;

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

        // Filtering via the Controller class's virtual filter methods.
        // Here we add profiling to all controller actions.
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            m_stopwatch = Stopwatch.StartNew();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            m_stopwatch.Stop();
            filterContext.HttpContext.Response.Write(
                String.Format("<div>Total elapsed time: {0:F6}</div>", m_stopwatch.Elapsed.TotalSeconds));
        }

        [ProfileAction]
        [ProfileResult]
        [ProfileAll]
        public String ProfileTest()
        {
            return "This is the ActionFilterTest action";
        }
    }
}