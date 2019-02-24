using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IWebApiClientService : IServiceBaseT<WebApiClient, vWebApiClient>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		/// <summary>
        /// Gets the data by client code
        /// </summary>
        /// <param name="clientCode">client code</param>
        /// <returns></returns>
        vWebApiClient GetByClientCode(string clientCode);

		#endregion
    }
}

