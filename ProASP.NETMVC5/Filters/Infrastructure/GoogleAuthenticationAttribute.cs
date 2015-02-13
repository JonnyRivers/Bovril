using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;

namespace Filters.Infrastructure
{
    public class GoogleAuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity identity = filterContext.Principal.Identity;
            if (!identity.IsAuthenticated || !identity.Name.EndsWith("@google.com")) 
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        // This method can be called twice:
        // 1) If authentication fails
        // 2) After the action method has been executed
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        {"controller", "GoogleAccount"},
                        {"action", "Login"},
                        {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                    }
                );
            }
            else
            {
                // This just forces relogin every time
                FormsAuthentication.SignOut();
            }
        }
    }
}