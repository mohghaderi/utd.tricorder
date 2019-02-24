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
    public class WebApiTokenService : ServiceBase<WebApiToken, vWebApiToken>, IWebApiTokenService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Adds a token to the database
        /// </summary>
        /// <param name="token">token</param>
        public void AddToken(WebApiToken token)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(vWebApiToken.ColumnNames.UserID, token.UserID);
            filter.AddFilter(vWebApiToken.ColumnNames.WebApiClientID, token.WebApiClientID);
            var list = GetByFilterT(new GetByFilterParameters(filter));
            foreach (var item in list)
                Delete(item);
            Insert(token);
        }
		

		#endregion

    }
}

