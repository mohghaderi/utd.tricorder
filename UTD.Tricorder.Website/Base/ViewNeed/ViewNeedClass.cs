using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTD.Tricorder.Website.Base.ViewNeed
{
    public class ViewNeedClass
    {
        public ViewNeedClass(string message, string fulfillviewUrl)
        {
            this.Message = message;
            this.FulfillView = fulfillviewUrl;
        }

        /// <summary>
        /// Message to be shown to the user
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Link to the view to fulfill the needs
        /// </summary>
        public string FulfillView { get; set; }
    }
}