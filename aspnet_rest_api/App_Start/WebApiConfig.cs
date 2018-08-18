using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace aspnet_rest_api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Product Api",
                routeTemplate: "api/products/{id}",
                defaults: new { controller = "productapi", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
