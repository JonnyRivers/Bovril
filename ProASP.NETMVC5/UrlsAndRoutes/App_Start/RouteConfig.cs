using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // This demonstrates the ability to define your own constraints.
            // In this example we are detecting the client's browser and routing
            // them accordingly.
            // See UrlsAndRoutes.Infrastructure.UserAgentConstraint for impl details.

            //routes.MapRoute(
            //    "ChromeRoute",
            //    "{*catchall}",
            //    new
            //    {
            //        controller = "Home",
            //        action = "Chrome"
            //    },
            //    new { customConstraint = new UserAgentConstraint("Chrome") });

            routes.MapRoute(
                "MyRoute",                                          // route name
                "{controller}/{action}/{id}/{*catchall}",           // url
                new                                                 // default values for url segments
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new                                                 // constraints
                {
                    controller = "^H.*",                            // controller must begin(^) with H
                    action = "^Index$|^About$",                     // action must be either Index or About
                    //id = new RangeRouteConstraint(10, 20)         // put a range on the id
                    //id = new CompoundRouteConstraint(             // make a compound constraint
                    //    new IRouteConstraint[] { 
                    //        new AlphaRouteConstraint(),
                    //        new MinLengthRouteConstraint(6)})
                    //httpMethod = new HttpMethodConstraint("GET")  // THIS KILLS THE TESTS!
                },
                new[]                                              // namespaces to look in
                {
                    "UrlsAndRoutes.Controllers"
                });
        }
    }
}
