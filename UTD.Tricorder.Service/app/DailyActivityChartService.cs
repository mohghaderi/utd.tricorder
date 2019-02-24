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
    public class DailyActivityChartService : ServiceBase<vDailyActivityChart, vDailyActivityChart>, IDailyActivityChartService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public IList<vDailyActivityChart> GetByUserID(GetByUserIDSP p)
        {
            OwnerPatientOrADoctorSecurity.CheckValue("Get data", p.UserID);

            FilterExpression filter = new FilterExpression();
            filter.AddFilter(vDailyActivityChart.ColumnNames.UserID, p.UserID);
            var list = GetByFilterV(new GetByFilterParameters(filter, null, 0, 10000, null, GetSourceTypeEnum.View));
            if (list.Count > 0)
                OwnerPatientOrADoctorSecurity.Check("Get data", list[0], vDailyActivityChart.ColumnNames.UserID);

            return list;
        }
		

		#endregion

    }
}

