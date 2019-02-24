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
    public class PaymentController : EntityServiceControllerBase
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        /// <summary>
        /// Checks for view pre requisites if any
        /// </summary>
        /// <param name="p">parameters</param>
        protected override ViewNeedResponse CheckViewNeeds(ViewNeedRequest p)
        {
            ViewNeedResponse r = new ViewNeedResponse();
            switch (p.ViewName)
            {
                case "InsertForm":
                    long userId = Convert.ToInt64(p.Parameters["UserID"]);
                    r.AddNeed(new DoctorInfoExistsViewNeed().CheckNeed(userId));
                    break;
                default:
                    throw new NotImplementedException();
            }
            return r;
        }


        #endregion

    }
}

