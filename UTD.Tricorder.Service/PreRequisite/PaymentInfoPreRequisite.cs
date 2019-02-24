using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Service.PreRequisite
{
    public class PaymentInfoPreRequisite : PreRequisiteInfoBase
    {
        //private const string url = 

        public override string Check(User userInfo)
        {
            var service = UserPaymentInfoEN.GetService("");
            if (service.GetCount(new FilterExpression(vUserPaymentInfo.ColumnNames.UserPaymentInfoID, userInfo.UserID)) == 1)
                return null;
            else
                return "Register/UserPaymentInfo";
        }
    }
}
