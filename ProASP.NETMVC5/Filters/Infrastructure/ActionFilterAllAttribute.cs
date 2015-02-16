using System;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class ActionFilterAllAttribute : FilterAttribute, IActionFilter, IResultFilter
    {
        public virtual void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public virtual void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }

        public virtual void OnResultExecuted(ResultExecutedContext filterContext)
        {
            
        }

        public virtual void OnResultExecuting(ResultExecutingContext filterContext)
        {
            
        }
    }
}