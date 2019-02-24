using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UTD.Tricorder.Website.Controllers
{
    /// <summary>
    /// General controller for handling request errors in asp.net mvc
    /// </summary>
    public class ErrorController : Controller
    {

        [PreventDirectAccess]
        public ActionResult ServerError500()
        {
            return View("ServerError500");
        }

        [PreventDirectAccess]
        public ActionResult AccessDenied403()
        {
            return View("AccessDenied403");
        }

        public ActionResult NotFound404()
        {
            return View("NotFound404");
        }

        [PreventDirectAccess]
        //public ActionResult GenericHttpError(int httpStatusCode)
        public ActionResult GenericHttpError()
        {
            return View("GenericHttpError");
        }

        private class PreventDirectAccessAttribute : FilterAttribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                object value = filterContext.RouteData.Values["fromAppErrorEvent"];
                if (!(value is bool && (bool)value))
                    filterContext.Result = new ViewResult { ViewName = "NotFound404" };
            }
        }


    }
}