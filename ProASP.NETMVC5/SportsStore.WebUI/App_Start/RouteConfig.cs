﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // GET: /
            routes.MapRoute(
                null,
                "",
                new { 
                    controller = "Product",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            );

            // GET: /PageN
            routes.MapRoute(
                null,
                "Page{page}",
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null
                },
                new { page = @"\d+" }
            );

            // GET: /Category/
            routes.MapRoute(
                null,
                "{category}",
                new
                {
                    controller = "Product",
                    action = "List",
                    page = 1
                }
            );

            // GET: /Category/PageN
            routes.MapRoute(
                null,
                "{category}/Page{page}",
                new
                {
                    controller = "Product",
                    action = "List",
                },
                new { page = @"\d+" }
            );

            // Default
            // GET: /Controller/Action
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
