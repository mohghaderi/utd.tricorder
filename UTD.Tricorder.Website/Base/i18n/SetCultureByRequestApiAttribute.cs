using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace UTD.Tricorder.Website.Base.i18n
{
    public class SetCultureByRequestApiAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var RouteData = actionContext.ControllerContext.RouteData;

            string cultureName = RouteData.Values["culture"] as string;

            if (string.IsNullOrEmpty(cultureName) == false)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            }

            base.OnActionExecuting(actionContext);
        }
    }
}