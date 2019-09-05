using FirstWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FirstWebApiDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            //Activation de l'authentification basic

            config.Filters.Add(new BasicAuthenticationAttribute());
            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
