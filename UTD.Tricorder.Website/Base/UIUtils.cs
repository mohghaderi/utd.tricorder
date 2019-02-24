using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace UTD.Tricorder.Website.Base
{
    public class UIUtils
    {
        public static ServiceActionResult GetExceptionActionResult(Exception ex)
        {
            var msg = FWUtils.WebUIUtils.GetExtExceptionMessageString(ex, true);
            return new ServiceActionResult(null, msg);
        }

        public static RedirectResult GetRedirectResult(string path)
        {
            Check.Require(string.IsNullOrEmpty(path) == false);
            Check.Require(path.StartsWith("~") == false);

            StringBuilder sb = new StringBuilder();
            sb.Append("~/").Append(UIText.CultureName());
            if (path[0] != '/')
                sb.Append("/");
            sb.Append(path);

            return new RedirectResult(sb.ToString());
        }


    }
}