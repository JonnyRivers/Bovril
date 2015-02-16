using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class ProfileResultAttribute : FilterAttribute, IResultFilter
    {
        private Stopwatch m_stopwatch;

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            m_stopwatch.Stop();

            filterContext.HttpContext.Response.Write(
                String.Format("<div>Result elapsed time: {0:F6}</div>", m_stopwatch.Elapsed.TotalSeconds));
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            m_stopwatch = Stopwatch.StartNew();
        }
    }
}