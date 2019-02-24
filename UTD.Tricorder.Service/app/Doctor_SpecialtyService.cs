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
    public class Doctor_SpecialtyService : ServiceBase<Doctor_Specialty, vDoctor_Specialty>, IDoctor_SpecialtyService
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void OnAfterInitialize()
        {
            base.OnAfterInitialize();
            long userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            this.SecurityCheckers.Add(new MyRowViewAllEditMeEntitySecurity(this, vDoctor_USState.ColumnNames.DoctorID, userId));
        }

        /// <summary>
        /// Gets data by doctor id
        /// </summary>
        /// <param name="DoctorID">doctor identifier</param>
        /// <returns></returns>
        public IList<vDoctor_Specialty> GetByDoctorID(long DoctorID)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(vDoctor_Specialty.ColumnNames.DoctorID, DoctorID);
            SortExpression sort = new SortExpression(vDoctor_Specialty.ColumnNames.SpecialtyTitle);

            return GetByFilterV(new GetByFilterParameters(filter, sort, 0, int.MaxValue, null, GetSourceTypeEnum.View));
        }

		#endregion

    }
}

