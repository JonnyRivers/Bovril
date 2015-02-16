using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class ProfileAllAttribute : ActionFilterAllAttribute
    {
        private Stopwatch m_stopwatch;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            m_stopwatch = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            m_stopwatch.Stop();
            filterContext.HttpContext.Response.Write(
                String.Format("<div>Total elapsed time: {0:F6}</div>", m_stopwatch.Elapsed.TotalSeconds));
        }
    }
}