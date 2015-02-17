using System;
using System.IO;
using System.Web.Mvc;

namespace Views.Infrastructure
{
    public class DebugDataView : IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            Write(writer, "---Routing Data---");
            foreach (String key in viewContext.RouteData.Values.Keys)
            {
                Write(
                    writer, 
                    "Key: {0}, Value: {1}",
                    key,
                    viewContext.RouteData.Values[key]);
            }

            Write(writer, "---View Data---");
            foreach (String key in viewContext.ViewData.Keys)
            {
                Write(
                    writer,
                    "Key: {0}, Value: {1}",
                    key,
                    viewContext.ViewData[key]);
            }
        }

        private void Write(TextWriter writer, String template, params Object[] values)
        {
            writer.Write(String.Format(template, values) + "<p/>");
        }
    }
}