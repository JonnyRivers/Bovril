using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private bool m_localAllowed;

        public CustomAuthorizeAttribute(bool localAllowed)
        {
            m_localAllowed = localAllowed;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal)
                return m_localAllowed;

            return true;
        }
    }
}