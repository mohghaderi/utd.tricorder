using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IInsurancePlanService : IServiceBaseT<InsurancePlan, vInsurancePlan>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Gets all insurance plans associated with one insurance company
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        IList<vInsurancePlan> GetByInsuranceID(InsurancePlanGetByInsuranceIDSP p);

        /// <summary>
        /// Gets insurance plans that is not in Doctor_Insurance list of a doctor
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        IList<vInsurancePlan> GetNotSelectedPlans(InsurancePlanGetNotSelectedPlansSP p);

		#endregion
    }
}

