using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Website.Base.ViewNeed.app
{
    public class UserPaymentInfoExistsViewNeed
    {
        public ViewNeedClass CheckNeed(long userId)
        {
            if (UserPaymentInfoEN.GetService("").GetCount(new FilterExpression(vUserPaymentInfo.ColumnNames.UserPaymentInfoID, userId)) < 1)
            {
                return new ViewNeedClass("Your payment information not found. Please fill it first", "UserPaymentInfo-Form");
            }
            return null;
        }

    }
}