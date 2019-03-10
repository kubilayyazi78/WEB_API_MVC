using Programming.API.Attributes;
using Programming.API.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Programming.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ApiExceptionAttribute());
            config.MessageHandlers.Add(new ApiKeyHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
