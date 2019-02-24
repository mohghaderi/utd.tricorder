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
    public class TimeSeriesStripService : ServiceBase<TimeSeriesStrip, vTimeSeriesStrip>, ITimeSeriesStripService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.
        public override void OnAfterInitialize()
        {
            base.OnAfterInitialize();

            if (!FWUtils.SecurityUtils.HasRole(EntityEnums.RoleSEnum.SystemAdmin) ||
                this.AdditionalDataKey == TimeSeriesStripEN.AdditionalData_MyVital)
            {
                MyRowEntitySecurity sec = new MyRowEntitySecurity(this, vTimeSeriesStrip.ColumnNames.UserID, FWUtils.SecurityUtils.GetCurrentUserIDLong());
                this.SecurityCheckers.Add(sec);
            }
        }

        protected override bool onBeforeInsert(object entitySet, InsertParameters parameters)
        {
            TimeSeriesStrip obj = (TimeSeriesStrip)entitySet;

            Guid stripId = Guid.NewGuid();
            if (obj.TimeSeriesStripID == Guid.Empty)
                obj.TimeSeriesStripID = stripId;

            obj.StartDateOffset = DateTimeEpoch.GetUtcNowEpoch();
            obj.EndDateOffset = obj.StartDateOffset;

            if (this.AdditionalDataKey == VitalValueEN.AdditionalData_MyVital)
                obj.UserID = FWUtils.SecurityUtils.GetCurrentUserIDLong();

            return true;
        }

		#endregion

    }
}

