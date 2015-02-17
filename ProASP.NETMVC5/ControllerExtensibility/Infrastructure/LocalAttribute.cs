using System;
using System.Reflection;
using System.Web.Mvc;

namespace ControllerExtensibility.Infrastructure
{
    // This is an action method selector attriubute, like HttpPost, NonAction, etc.
    public class LocalAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request.IsLocal;
        }
    }
}