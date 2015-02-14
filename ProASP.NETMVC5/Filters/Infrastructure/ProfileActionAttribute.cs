using System;
using System.Diagnostics;
using System.Web.Mvc;


namespace Filters.Infrastructure
{
    public class ProfileActionAttribute : FilterAttribute, IActionFilter
    {
        private Stopwatch m_stopwatch;
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            m_stopwatch.Stop();

            if (filterContext.Exception == null)
            {
                filterContext.HttpContext.Response.Write(
                    String.Format("<div>Action method elapsed time: {0:F6}</div>", m_stopwatch.Elapsed.TotalSeconds));
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            m_stopwatch = Stopwatch.StartNew();
        }
    }
}