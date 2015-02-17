﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Views.Infrastructure;

namespace Views
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Make sure we only have one albeit shonky IViewEngine implemenation
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new DebugDataViewEngine());
        }
    }
}
