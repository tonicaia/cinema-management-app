using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CineM8
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //users route
            config.Routes.MapHttpRoute(
           name: "Users",
           routeTemplate: "api/users/{id}",
           defaults: new { controller = "user", id = RouteParameter.Optional }
       );

            //movie route
            config.Routes.MapHttpRoute(
           name: "Movie",
           routeTemplate: "api/movie/{id}",
           defaults: new { controller = "movie", id = RouteParameter.Optional }
       );
        }
    }
}
