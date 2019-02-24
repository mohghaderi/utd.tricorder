using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UTD.Tricorder.Website.Controllers
{
    public class cssController : Controller
    {
        [AllowAnonymous]
        public ActionResult app_css()
        {
            return this.CssFromView();
        }

    }
}