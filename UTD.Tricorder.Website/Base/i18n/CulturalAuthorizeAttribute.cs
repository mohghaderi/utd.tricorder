using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UTD.Tricorder.Website.Base.Attributes
{
    public class CulturalAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                        {
                                { "culture", filterContext.RouteData.Values[ "culture" ] },
                                { "controller", "Default" },
                                { "action", "Login" },
                                { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                        });
            }
        }
    }

}