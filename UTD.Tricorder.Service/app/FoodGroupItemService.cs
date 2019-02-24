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
    public class FoodGroupItemService : ServiceBase<FoodGroupItem, vFoodGroupItem>, IFoodGroupItemService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        protected override void onAfterInsert(object entitySet, InsertParameters parameters)
        {
            var foodGroupId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entitySet, vFoodGroupItem.ColumnNames.FoodGroupID);
            FoodGroupEN.GetService().UpdateDailyActivityByGroupID(foodGroupId);
        }

        protected override void onAfterUpdate(object entitySet, UpdateParameters parameters)
        {
            var foodGroupId = (long) FWUtils.EntityUtils.GetObjectFieldValue(entitySet, vFoodGroupItem.ColumnNames.FoodGroupID);
            FoodGroupEN.GetService().UpdateDailyActivityByGroupID(foodGroupId);
        }

		#endregion

    }
}

