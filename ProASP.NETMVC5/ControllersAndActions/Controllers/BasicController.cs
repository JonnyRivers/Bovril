using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllersAndActions.Controllers
{
    public class BasicController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            String controller = (String)requestContext.RouteData.Values["controller"];
            String action = (String)requestContext.RouteData.Values["action"];

            if (String.Equals(action, "redirect", StringComparison.CurrentCultureIgnoreCase))
            {
                requestContext.HttpContext.Response.Redirect("/Derived/Index");
            }
            else
            {
                requestContext.HttpContext.Response.Write(
                String.Format("Controller: {0}, Action: {1}", controller, action));
            }
        }
    }
}