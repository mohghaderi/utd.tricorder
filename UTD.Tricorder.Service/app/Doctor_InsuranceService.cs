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
    public class Doctor_InsuranceService : ServiceBase<Doctor_Insurance, vDoctor_Insurance>, IDoctor_InsuranceService
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
        /// Gets ids of the selected plans by its user id
        /// </summary>
        /// <param name="userID">user identifier</param>
        /// <returns></returns>
        public IList<long> GetSelectedPlanIDsByUserID(long userID)
        {
            FilterExpression filter = new FilterExpression(vDoctor_Insurance.ColumnNames.DoctorID, userID);
            IList<vDoctor_Insurance> list = GetByFilterV(new GetByFilterParameters(filter));

            List<long> selectedIds = new List<long>();
            foreach (vDoctor_Insurance item in list)
                selectedIds.Add(item.InsurancePlanID);

            return selectedIds;
        }

        /// <summary>
        /// Gets ids of the selected plans by its user id
        /// </summary>
        /// <param name="userID">user identifier</param>
        /// <returns></returns>
        public IList<long> GetSelectedPlanIDsByUserID(long userID, long insuranceId)
        {
            FilterExpression filter = new FilterExpression(vDoctor_Insurance.ColumnNames.DoctorID, userID);
            filter.AddFilter(vDoctor_Insurance.ColumnNames.InsuranceID, insuranceId);
            IList<vDoctor_Insurance> list = GetByFilterV(new GetByFilterParameters(filter));

            List<long> selectedIds = new List<long>();
            foreach (vDoctor_Insurance item in list)
                selectedIds.Add(item.InsurancePlanID);

            return selectedIds;
        }
		

		#endregion

    }
}

