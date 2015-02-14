using System;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class RangeExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled &&
                filterContext.Exception is ArgumentOutOfRangeException)
            {
                int value = (int)(((ArgumentOutOfRangeException)filterContext.Exception).ActualValue);
                filterContext.Result = new ViewResult{
                    ViewName = "RangeError",
                    ViewData = new ViewDataDictionary<int>(value)};
                filterContext.ExceptionHandled = true;
            }
        }
    }
}