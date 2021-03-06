using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Service
{
    public class Doctor_USStateService : ServiceBase<Doctor_USState, vDoctor_USState>, IDoctor_USStateService
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void OnAfterInitialize()
        {
            base.OnAfterInitialize();
            long userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            this.SecurityCheckers.Add(new MyRowViewAllEditMeEntitySecurity(this, vDoctor_USState.ColumnNames.DoctorID, userId));
        }
		

		#endregion

    }
}

