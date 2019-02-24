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
    public class WebApiClientService : ServiceBase<WebApiClient, vWebApiClient>, IWebApiClientService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        /// <summary>
        /// Gets the data by client code
        /// </summary>
        /// <param name="clientCode">client code</param>
        /// <returns></returns>
        public vWebApiClient GetByClientCode(string clientCode)
        {
            FilterExpression filter = new FilterExpression(vWebApiClient.ColumnNames.ClientCode, clientCode);
            var list = GetByFilterV(new GetByFilterParameters(filter, null, 0, 1, null, GetSourceTypeEnum.View));
            if (list.Count == 0)
                return null;
            else
                return list[0];
        }
		

		#endregion

    }
}

