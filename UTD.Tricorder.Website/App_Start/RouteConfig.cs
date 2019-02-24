using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UTD.Tricorder.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.RouteExistingFiles = true;

            //routes.MapRoute(
            //    name: "staticFileRoute",
            //    url: "Content/{*file}/",
            //    defaults: new { controller = "Home", action = "SomeAction" }
            //);

            //// service mapping
            //routes.MapRoute(
            //    name: "EntityServiceRoute",
            //    url: "api/{controller}-{adk}/{action}/{id}",
            //    defaults: new { action = "Get", id = UrlParameter.Optional }
            //);


            routes.MapRoute(
                name: "Default",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { culture="", controller = "Default", action = "RedirectToIndex", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{lang}/{controller}/{action}/{id}",
            //    defaults: new { id = UrlParameter.Optional }
            //);



        }
    }
}
