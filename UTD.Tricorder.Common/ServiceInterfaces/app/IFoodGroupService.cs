using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IFoodGroupService : IServiceBaseT<FoodGroup, vFoodGroup>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        FoodGroup GetUnsavedFoodGroup(FoodGroup_GetUnsavedFoodGroupSP p);
        void UpdateDailyActivityByGroupID(long foodGroupId);


		#endregion
    }
}

