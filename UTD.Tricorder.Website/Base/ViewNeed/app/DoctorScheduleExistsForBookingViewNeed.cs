using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Website.Base.ViewNeed;

namespace UTD.Tricorder.Website.Base
{
    public class DoctorScheduleExistsForBookingViewNeed
    {
        public ViewNeedClass CheckNeed(long doctorId)
        {
            var filter = new FilterExpression(vDoctorSchedule.ColumnNames.DoctorID, doctorId);
            filter.AddFilter(vDoctorSchedule.ColumnNames.SlotUnixEpoch, DateTimeEpoch.GetUtcNowEpoch(), FilterOperatorEnum.GreaterThan);
            filter.AddFilter(vDoctorSchedule.ColumnNames.NumberOfFreePositions, 0, FilterOperatorEnum.GreaterThan);
            if (DoctorScheduleEN.GetService().GetCount(filter) < 1)
            {
                return new ViewNeedClass("No available time is available for booking.", "DoctorSchedule-CalendarEdit");
            }

            return null;
        }
    }
}