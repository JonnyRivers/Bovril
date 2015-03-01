using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkingWithRazor2.Infrastructure
{
    public class CustomLocationViewEngine : RazorViewEngine
    {
        public CustomLocationViewEngine()
        {
            ViewLocationFormats = new String[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Common/{0}.cshtml"
            };
        }
    }
}