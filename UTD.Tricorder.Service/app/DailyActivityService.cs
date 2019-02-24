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
    public class DailyActivityService : ServiceBase<DailyActivity, vDailyActivity>, IDailyActivityService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public IList<DailyActivity> GetByTypeAndExternalEntityAndUser(DailyActivity_GetByTypeAndExternalEntityAndUserSP p)
        {
            var filter = new FilterExpression();
            filter.AddFilter(vDailyActivity.ColumnNames.ExternalEntityID, p.ExternalEntityID);
            filter.AddFilter(vDailyActivity.ColumnNames.DailyActivityTypeID, p.DailyActivityTypeID);
            filter.AddFilter(vDailyActivity.ColumnNames.UserID, p.UserID);
            return GetByFilterT(new GetByFilterParameters(filter));
        }


		#endregion

    }
}

