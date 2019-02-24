using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace UTD.Tricorder.Website.Helpers
{
    public static class DoctorReview
    {


        /// <summary>
        /// Gets section header for doctor's review form
        /// </summary>
        /// <param name="modelPrefix">model prefix</param>
        /// <param name="sectionId">section id</param>
        /// <param name="sectionTitle">section title</param>
        /// <returns></returns>
        public static MvcHtmlString GetSectionHeader(string modelPrefix, string sectionId, string sectionTitle)
        {
            string checkedYesText = "Applicable";
            string checkedNoText = "Not Applicable";

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class=\"row info-panel-heading\">");
            sb.Append("    <div class=\"col-md-8\">");
            sb.Append("        <label>").Append(sectionTitle).Append("</label>");
            sb.Append("    </div>");
            sb.Append("    <div class=\"col-md-4\">");
            sb.Append("        <div class=\"form-group\">");
            sb.Append(FWHtml.YesNoRadios(modelPrefix, sectionId, false, checkedYesText, checkedNoText));
            sb.Append("        </div>");
            sb.Append("    </div>");
            sb.Append("</div>");
            sb.Append("<div>");
            sb.Append("    <div ng-hide=\"(").Append(modelPrefix).Append(sectionId).Append(" === undefined) || (").Append(modelPrefix).Append(sectionId).Append(" === false)\">");

            return new MvcHtmlString(sb.ToString());
        }


        /// <summary>
        /// Gets section footer for doctor's review form
        /// </summary>
        /// <param name="modelPrefix">model prefix</param>
        /// <param name="sectionId">section id</param>
        /// <param name="sectionTitle">section title</param>
        /// <returns></returns>
        public static MvcHtmlString GetSectionFooter(string modelPrefix, string sectionId, string sectionTitle)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("        <input type=\"text\" class=\"form-control\" ")
                .Append("name=\"").Append(sectionId).Append("Comment\"")
                .Append(" placeholder=\"Comment\"")
                .Append(" data-ng-model=\"").Append(modelPrefix).Append(sectionId).Append("Comment")
                .Append("\" />");
            sb.Append("    </div>");
            sb.Append("</div>");
            sb.Append("<hr />");

            return new MvcHtmlString(sb.ToString());
        
        }


    }
}