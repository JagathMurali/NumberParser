using NumberParser.ServiceClass;
using NumberParser.ServiceClass.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace NumberParser
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Dependency Configuration
            var container = new UnityContainer();
            container.RegisterType<INumberToWordsService, NumberToWordsService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
