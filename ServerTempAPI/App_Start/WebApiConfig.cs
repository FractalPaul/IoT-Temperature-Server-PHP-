using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServerTempAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{d1}/{v1}/{d2}/{v2}/{d3}/{v3}",
                defaults: new { d1 = RouteParameter.Optional, v1= RouteParameter.Optional, d2 = RouteParameter.Optional, v2 = RouteParameter.Optional, d3 = RouteParameter.Optional, v3 = RouteParameter.Optional}
            );
        }
    }
}
