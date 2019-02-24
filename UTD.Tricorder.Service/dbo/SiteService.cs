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
    public class SiteService : ServiceBase<Site, vSite>, ISiteService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Gets site identifier by its code
        /// </summary>
        /// <param name="code">site code</param>
        /// <returns>site id and if it was not found null</returns>
        public int? GetSiteIDBySiteCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;

            FilterExpression filter = new FilterExpression();
            filter.AddFilter(vSite.ColumnNames.SiteCode, code.ToLower());

            var list = GetByFilterV(new GetByFilterParameters(filter));
            if (list.Count > 0)
                return list[0].SiteID;
            else
                return null;
        }
		

		#endregion

    }
}

