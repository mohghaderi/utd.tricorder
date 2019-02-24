using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTD.Tricorder.Website.Models
{
    /// <summary>
    /// To get raw data from Post and Put commands.
    /// Web API doesn't support string and other raw data as an input (stupid MVC design)
    /// and it is very hard to do a workaround: http://weblog.west-wind.com/posts/2013/Dec/13/Accepting-Raw-Request-Body-Content-with-ASPNET-Web-API
    /// 
    /// This class fakes the posted data as json string
    /// </summary>
    public class FWPostBody
    {
        public string data { get; set; }

        public FWPostBody()
        {
 
        }

        public FWPostBody(string data)
        {
            this.data = data;
        }
    }
}