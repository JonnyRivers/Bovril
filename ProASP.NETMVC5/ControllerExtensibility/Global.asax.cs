using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using ControllerExtensibility.Infrastructure;

namespace ControllerExtensibility
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Global namepsace prioritization (dummy values)
            ControllerBuilder.Current.DefaultNamespaces.Add("MyControllerNamespace");
            ControllerBuilder.Current.DefaultNamespaces.Add("MyProject.*");

            // Overriding the controller factory (superseded below)
            ControllerBuilder.Current.SetControllerFactory(
                new CustomControllerFactory());

            // Using the default controller factory but supplying the controller activator
            ControllerBuilder.Current.SetControllerFactory(
                new DefaultControllerFactory(
                    new CustomControllerActivator()));
        }
    }
}
