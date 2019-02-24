using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.BusinessRule
{
    public class FoodGroupBR : BusinessRuleBase<FoodGroup, vFoodGroup>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            if (fnName == RuleFunctionSEnum.Update)
            {
                //var foodGroupId = FWUtils.EntityUtils.GetObjectFieldValue(entitySet, vFoodGroup.ColumnNames.FoodGroupID);
                //var groupService = UTD.Tricorder.Common.EntityInfos.FoodGroupItemEN.GetService();
                //var itemsCount = groupService.GetCount(new FilterExpression(vFoodGroupItem.ColumnNames.FoodGroupID, foodGroupId));
                //if (itemsCount == 0)
                //{
                //    errors.Add(new BusinessRuleError(){ ColumnName="", ColumnTitle="", ErrorDescription= BusinessErrorStrings.FoodGroup.NotItemInFoodGroup});
                //}
            }


        }
		

		#endregion

    }
}

