using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Website.Base.ViewNeed
{
    public class UserVerifiedPhoneNumberViewNeed
    {
        public ViewNeedClass CheckNeed(long userId)
        {
            var filter = new FilterExpression(vUser.ColumnNames.UserID, userId);
            filter.AddFilter(new Filter(vUser.ColumnNames.IsPhoneVerified, true));
            if (UserEN.GetService().GetCount(filter) < 1)
            {
                return new ViewNeedClass("You need a verified PhoneNumber to access this form", "User-VerifyPhoneNumber");
            }
            return null;
        }

    }
}