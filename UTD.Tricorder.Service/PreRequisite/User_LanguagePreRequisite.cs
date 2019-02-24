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
    public class User_LanguagePreRequisite : PreRequisiteInfoBase
    {
        //private const string url = 

        public override string Check(User userInfo)
        {
            var service = User_LanguageEN.GetService("");
            if (service.GetCount(new FilterExpression(vUser_Language.ColumnNames.UserID, userInfo.UserID)) >= 1)
                return null;
            else
            {
                return "Register/User_Language";
            }
        }
    }
}
