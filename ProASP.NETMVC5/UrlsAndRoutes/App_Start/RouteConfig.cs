using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
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
                    //httpMethod = new HttpMethodConstraint("GET")  // THIS KILLS THE TESTS!
                },
                new[]                                              // namespaces to look in
                {
                    "UrlsAndRoutes.Controllers"
                });
        }
    }
}
