using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IDoctor_InsuranceService : IServiceBaseT<Doctor_Insurance, vDoctor_Insurance>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		/// <summary>
        /// Gets ids of the selected plans by its user id
        /// </summary>
        /// <param name="userID">user identifier</param>
        /// <returns></returns>
        IList<long> GetSelectedPlanIDsByUserID(long userID);


        /// <summary>
        /// Gets ids of the selected plans by its user id
        /// </summary>
        /// <param name="userID">user identifier</param>
        /// <returns></returns>
        IList<long> GetSelectedPlanIDsByUserID(long userID, long insuranceId);

		#endregion
    }
}

