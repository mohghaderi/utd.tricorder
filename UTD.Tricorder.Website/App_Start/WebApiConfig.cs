using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using UTD.Tricorder.Website.Base.i18n;

namespace UTD.Tricorder.Website
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // removing XMLFormatter activates json formatter (by default both are there)
            // http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var jsonformatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonformatter.SerializerSettings.ContractResolver = null;  // we don't want to do any formatting because we would like to use the same propertyname everywhere
            jsonformatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc; // UTC time for all date times

            //// changing json formatter for CamelCases
            //jsonformatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //// for pascalcase : http://stackoverflow.com/questions/9247478/pascal-case-dynamic-properties-with-json-net
            //jsonformatter.SerializerSettings.Converters = List<JsonConverter> { new CamelCaseToPascalCaseExpandoObjectConverter() }

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "EntityWithADKApi",
            //    routeTemplate: "api/{controller}-{adk}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // it doesn't work because it interfers with other entities
            // we have more than a simple crud for our entities
            // so, we need to keep actions in our forms

            //config.Routes.MapHttpRoute(
            //    name: "EntityWithADKApiExec",
            //    routeTemplate: "sapi/{controller}-{adk}/Exec/{methodName}",
            //    defaults: new { action = "Exec" }
            //);


            //config.Routes.MapHttpRoute(
            //    name: "EntityWithADKApi2",
            //    routeTemplate: "sapi/{controller}-{adk}/{action}/{id}",
            //    defaults: new { }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApiexec",
                routeTemplate: "{culture}/sapi/{controller}/Exec/{methodName}",
                defaults: new { action = "Exec", id = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "{culture}/sapi/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //config.Routes.MapHttpRoute(
            //    name: "AjaxView",
            //    routeTemplate: "ajaxview/{id}",
            //    defaults: new { controller="AjaxView", action="render", id = RouteParameter.Optional }
            //);

            config.Filters.Add(new SetCultureByRequestApiAttribute());

        }
    }
}
