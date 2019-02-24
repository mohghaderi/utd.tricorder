using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Service
{
    public class UserInRoleService : ServiceBase<UserInRole, vUserInRole>, IUserInRoleService
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// returns roles of a specific user
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <returns></returns>
        public IList<vUserInRole> GetRolesByUserID(string userId)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vUserInRole.ColumnNames.UserID, userId));
            filter.AddFilter(new Filter(vUserInRole.ColumnNames.IsActive, true));
            var gParams = new GetByFilterParameters(filter, new SortExpression());
            var list = GetByFilterV(gParams);
            return list;
        }

        /// <summary>
        /// gets role ids of a certain user
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <returns></returns>
        public List<long> GetRolesIDUserID(string userId)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vUserInRole.ColumnNames.UserID, userId));
            filter.AddFilter(new Filter(vUserInRole.ColumnNames.IsActive, true));
            List<string> columns = new List<string>();
            columns.Add(vUserInRole.ColumnNames.RoleID);
            var gParams = new GetByFilterParameters(filter, new SortExpression(), 0, 1000, columns, GetSourceTypeEnum.Table);
            var list = GetByFilterV(gParams);

            List<long> results = new List<long>();
            foreach (var item in list)
                if (results.Contains(item.RoleID) == false)
                    results.Add(item.RoleID);
            return results;
        }

		#endregion

    }
}

