using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTD.Tricorder.Common.EntityInfos;

namespace UTD.Tricorder.Website.Base
{
    public class ViewControllerBase : Controller
    {
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult RedirectToIndex()
        {
            this.RouteData.Values["Action"] = "Index";
            try
            {
                string culture = (string)this.RouteData.Values["culture"]; 
                if (string.IsNullOrEmpty(culture) == true)
                {
                    var siteId = FWUtils.SecurityUtils.GetCurrentSiteID();
                    var siteInfo = SiteEN.GetService().GetByIDV(siteId, null);
                    this.RouteData.Values["culture"] = siteInfo.LanguageCode;
                    //this.RouteData.Values["Culture"] = // Get site default culture
                }

            }
            catch (Exception)
            {
            }

            // set en as default culture
            if (string.IsNullOrEmpty((string)this.RouteData.Values["culture"]))
                this.RouteData.Values["culture"] = "en";

            return new RedirectToRouteResult(this.RouteData.Values);
        }

    }
}