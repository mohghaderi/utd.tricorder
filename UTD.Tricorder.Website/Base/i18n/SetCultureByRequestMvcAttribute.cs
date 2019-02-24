using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UTD.Tricorder.Website.Base.i18n
{
    public class SetCultureByRequestMvcAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var RouteData = filterContext.RouteData;
            var Request = filterContext.RequestContext.HttpContext.Request;
            var Response = filterContext.HttpContext.Response;
            //Log("OnActionExecuting", filterContext.RouteData);
            string cultureName = RouteData.Values["culture"] as string;


            // Attempt to read the culture cookie from Request

            if (cultureName == null)

                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages


            // Validate culture name

            //cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe



            if (RouteData.Values["culture"] as string != cultureName)
            {



                // Force a valid culture in the URL

                RouteData.Values["culture"] = cultureName.ToLowerInvariant(); // lower case too


                // Redirect user

                Response.RedirectToRoute(RouteData.Values);

            }




            // Modify current thread's cultures  
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            }
            catch (CultureNotFoundException)
            {
                // TODO: handle all culture errors later
                throw;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}