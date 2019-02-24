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
    public class FitActivityService : ServiceBase<FitActivity, vFitActivity>, IFitActivityService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Gets all data
        /// </summary>
        /// <returns></returns>
        public IList<FitActivity> GetAllData()
        {
            return GetAllT();
        }

		#endregion

    }
}

