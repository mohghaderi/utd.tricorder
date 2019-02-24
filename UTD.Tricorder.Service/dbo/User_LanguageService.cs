using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Service
{
    public class User_LanguageService : ServiceBase<User_Language, vUser_Language>, IUser_LanguageService
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        public override void OnAfterInitialize()
        {
            base.OnAfterInitialize();
            long userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            this.SecurityCheckers.Add(new MyRowViewAllEditMeEntitySecurity(this, vUser_Language.ColumnNames.UserID, userId));
        }
		


		#endregion

    }
}

