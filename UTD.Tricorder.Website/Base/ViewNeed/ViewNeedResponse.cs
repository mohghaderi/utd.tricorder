using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTD.Tricorder.Website.Base.ViewNeed
{
    /// <summary>
    /// Response for View needs
    /// </summary>
    public class ViewNeedResponse
    {
        public List<ViewNeedClass> Needs = new List<ViewNeedClass>();

        public void AddNeed(string message, string fulfillViewUrl)
        {
            Needs.Add(new ViewNeedClass(message, fulfillViewUrl));
        }

        public void AddNeed(ViewNeedClass c)
        {
            if (c != null)
                this.Needs.Add(c);
        }
    }

}