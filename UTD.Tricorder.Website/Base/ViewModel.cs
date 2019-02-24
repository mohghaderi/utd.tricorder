using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UTD.Tricorder.Website
{
    public class GoogleAnlyticsViewModel
    {
        /// <summary>
        /// Is rendering needs angularJS scripts or not
        /// </summary>
        public bool RenderAngularJS { get; set; } 
    }


    public class CommonJSLinksViewModel
    {
        public bool IsDashboard { get; set; }
        public bool RenderAirBridge { get; set; }
        public bool RenderWebRtc { get; set; }
        public bool RenderVoiceCommand { get; set; }
        public bool RenderSignalR { get; set; }
    }


    public class DashboardTopNavBarViewModel
    {
        public MvcHtmlString SiteTitleHtml { get; set; }
    }
}