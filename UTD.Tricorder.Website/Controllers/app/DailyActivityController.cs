using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;
using UTD.Tricorder.Website.Base;
using Framework.Common;
using UTD.Tricorder.Website.Base.ViewNeed;

namespace UTD.Tricorder.Website.Controllers
{
    public class DailyActivityController : EntityServiceControllerBase
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.
        
        
        protected override ViewNeedResponse CheckViewNeeds(ViewNeedRequest p)
        {
            ViewNeedResponse r = new ViewNeedResponse();
            switch (p.ViewName)
            {
                case "FitActivityForm":
                    long userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
                    if (r.Needs.Count == 0)
                        r.AddNeed(new PersonExistsViewNeed().CheckNeed(userId));
                    break;
            }
            return r;
        }
		

		#endregion

    }
}

