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
    public class SiteDomainService : ServiceBase<SiteDomain, vSiteDomain>, ISiteDomainService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Gets site identifier by its domain name
        /// </summary>
        /// <param name="hostName">host name</param>
        /// <returns>SiteID or if it couldn't find null</returns>
        public int? GetSiteIDByHostName(string hostName)
        {
            if (string.IsNullOrEmpty(hostName))
                return null;

            hostName = hostName.ToLower();

            FilterExpression filter = new FilterExpression();
            filter.AddFilter(vSiteDomain.ColumnNames.SiteDomainName, hostName);

            var list = GetByFilterV(new GetByFilterParameters(filter));
            if (list.Count > 0)
                return list[0].SiteID;
            else
                return null;
        }


		#endregion

    }
}

