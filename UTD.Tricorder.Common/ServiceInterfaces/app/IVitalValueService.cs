using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IVitalValueService : IServiceBaseT<VitalValue, vVitalValue>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Gets all chart data.
        /// </summary>
        /// <param name="p">The parameters</param>
        /// <returns></returns>
        List<vVitalValue> GetAllChartData(GetAllChartDataSP p);


        /// <summary>
        /// Gets all chart data json.
        /// </summary>
        /// <param name="p">The parameters</param>
        /// <returns></returns>
        string GetAllChartDataJson(GetAllChartDataSP p);

		#endregion
    }
}

