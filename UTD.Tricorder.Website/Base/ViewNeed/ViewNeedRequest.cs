using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTD.Tricorder.Website.Base.ViewNeed
{
    public class ViewNeedRequest
    {
        public ViewNeedRequest()
        {
            this.Parameters = new Dictionary<string, string>();
        }

        public string ViewName { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

    }
}