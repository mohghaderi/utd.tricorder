using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IFitActivityService : IServiceBaseT<FitActivity, vFitActivity>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Gets all data.
        /// </summary>
        /// <returns></returns>
        IList<FitActivity> GetAllData();

		#endregion
    }
}

