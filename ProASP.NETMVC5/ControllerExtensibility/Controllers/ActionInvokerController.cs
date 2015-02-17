using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ControllerExtensibility.Infrastructure;

namespace ControllerExtensibility.Controllers
{
    public class ActionInvokerController : Controller
    {
        public ActionInvokerController()
        {
            // All handling of requests is henceforth the domain of CustomActionInvoker
            this.ActionInvoker = new CustomActionInvoker();
        }
    }
}