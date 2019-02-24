using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IUserInRoleService : IServiceBaseT<UserInRole, vUserInRole>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// returns roles of a specific user
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <returns></returns>
        IList<vUserInRole> GetRolesByUserID(string userId);


        /// <summary>
        /// gets role ids of a certain user
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <returns></returns>
        List<long> GetRolesIDUserID(string userId);

		#endregion
    }
}

