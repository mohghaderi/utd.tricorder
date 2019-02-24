using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTD.Tricorder.Website.Base;

namespace UTD.Tricorder.Website.Controllers
{
    public class jsController : ViewControllerBase
    {
        [AllowAnonymous]
        public ActionResult stringmsgs_js()
        {
            return this.JavaScriptFromView();
        }

    }
}