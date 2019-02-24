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
    public class InsurancePlanService : ServiceBase<InsurancePlan, vInsurancePlan>, IInsurancePlanService
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Gets all insurance plans associated with one insurance company
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        public IList<vInsurancePlan> GetByInsuranceID(InsurancePlanGetByInsuranceIDSP p)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vInsurancePlan.ColumnNames.InsuranceID, p.InsuranceID));
            SortExpression sort = new SortExpression(vInsurancePlan.ColumnNames.InsurancePlanTitle);
            return GetByFilterV(new GetByFilterParameters(filter, sort, 0, int.MaxValue));
        }

        /// <summary>
        /// Gets insurance plans that is not in Doctor_Insurance list of a doctor
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        public IList<vInsurancePlan> GetNotSelectedPlans(InsurancePlanGetNotSelectedPlansSP p)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vInsurancePlan.ColumnNames.InsuranceID, p.InsuranceID));
            SortExpression sort = new SortExpression(vInsurancePlan.ColumnNames.InsurancePlanTitle);
            IList<vInsurancePlan> plansList = GetByFilterV(new GetByFilterParameters(filter, sort, 0, int.MaxValue));

            IList<long> selectedList = Doctor_InsuranceEN.GetService().GetSelectedPlanIDsByUserID(p.UserID, p.InsuranceID);

            List<vInsurancePlan> notSelectedPlans = new List<vInsurancePlan>();

            foreach (vInsurancePlan plan in plansList)
                if (selectedList.Contains(plan.InsurancePlanID) == false)
                    notSelectedPlans.Add(plan);

            return notSelectedPlans;
        }
		

		#endregion

    }
}

