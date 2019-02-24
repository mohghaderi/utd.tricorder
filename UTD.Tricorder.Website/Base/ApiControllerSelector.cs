using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace UTD.Tricorder.Website
{
    public class ApiControllerSelector : DefaultHttpControllerSelector
    {
        public ApiControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
        }

        public override string GetControllerName(HttpRequestMessage request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            IHttpRouteData routeData = request.GetRouteData();

            if (routeData == null)
                return null;

            // Look up controller in route data
            object controllerName;
            routeData.Values.TryGetValue("controller", out controllerName);

            string controllerNameStr = (string)controllerName;
            if (controllerNameStr.IndexOf('-') > 0)
                controllerName = controllerNameStr.Substring(0, controllerNameStr.IndexOf('-'));

            return (string)controllerName;
        }
    }
}