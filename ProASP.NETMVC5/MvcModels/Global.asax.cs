using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using MvcModels.Infrastructure;
using MvcModels.Models;

namespace MvcModels
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Here we have an example of a value provider factory that dishes out a CountryValueProvider
            //ValueProviderFactories.Factories.Insert(0, new CustomValueProviderFactory());

            // Here we specify the model binder for a particular type.
            // This is an alternative method to the tagging of a ModelBinder attribute.
            //ModelBinders.Binders.Add(typeof(AddressSummary), new AddressSummaryBinder());
        }
    }
}
