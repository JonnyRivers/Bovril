using System;
using System.Web;
using System.Web.Routing;

namespace UrlsAndRoutes.Infrastructure
{
    // This is a custom constraint that can be used to route requests from a particular browser (e.g. Chrome)
    public class UserAgentConstraint : IRouteConstraint
    {
        private String m_requiredUserAgent;

        public UserAgentConstraint(String requiredUserAgent) {
            m_requiredUserAgent = requiredUserAgent;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection) {
            return httpContext.Request.UserAgent != null &&
                httpContext.Request.UserAgent.Contains(m_requiredUserAgent);
        }
    }
}