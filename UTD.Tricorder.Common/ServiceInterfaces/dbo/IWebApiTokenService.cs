using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IWebApiTokenService : IServiceBaseT<WebApiToken, vWebApiToken>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Adds a token to the database
        /// </summary>
        /// <param name="token">token</param>
        void AddToken(WebApiToken token);

		#endregion
    }
}

