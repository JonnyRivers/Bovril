using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace ControllerExtensibility.Controllers
{
    // Here we disable session state to allow simultaneous method calls per session.
    // This disables access to HttpContext.Session, which becomes null.
    [SessionState(SessionStateBehavior.Disabled)]
    public class FastController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}