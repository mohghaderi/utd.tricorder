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
    public class FoodGroupService : ServiceBase<FoodGroup, vFoodGroup>, IFoodGroupService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        /// <summary>
        /// Gets the unsaved food group.
        /// </summary>
        /// <param name="p">The paramters</param>
        /// <returns></returns>
        public FoodGroup GetUnsavedFoodGroup(FoodGroup_GetUnsavedFoodGroupSP p)
        {
            var filter = new FilterExpression();
            filter.AddFilter(vFoodGroup.ColumnNames.UserID, p.UserID);
            filter.AddFilter(vFoodGroup.ColumnNames.IsGroupSaved, false);
            filter.AddFilter(vFoodGroup.ColumnNames.FoodServingTimeTypeID, p.FoodServingTimeTypeID);
            var list = GetByFilterT(new GetByFilterParameters(filter));
            if (list.Count > 0)
                return list[0];
            else
            {
                var g = new FoodGroup
                {
                    FoodServingTimeTypeID = p.FoodServingTimeTypeID,
                    IsGroupSaved = false,
                    UserID = p.UserID,
                    RecordDateTimeUserLocal = DateTime.Now
                };
                Insert(g);
                return g;
            }
        }


        protected override bool onBeforeUpdate(object entitySet, UpdateParameters parameters)
        {
            var dailyActivityService = DailyActivityEN.GetService();
            var f = (FoodGroup)entitySet;
            var list = dailyActivityService.GetByTypeAndExternalEntityAndUser(new DailyActivity_GetByTypeAndExternalEntityAndUserSP()
            {
                UserID = f.UserID,
                ExternalEntityID = f.FoodGroupID,
                DailyActivityTypeID = (int)EntityEnums.DailyActivityTypeEnum.Eating
            });
            f.IsGroupSaved = true;

            if (list.Count == 0) // if we didn't have a saved daily activity just add it, computation will be done later
            {
                var obj = new DailyActivity
                {
                    DailyActivityID = Guid.NewGuid(),
                    DurationSeconds = 15*60,
                    ExternalEntityID = f.FoodGroupID,
                    DailyActivityTypeID = (int) EntityEnums.DailyActivityTypeEnum.Eating,
                    IsManualEntry = true,
                    RecordDateTimeUserLocal = f.RecordDateTimeUserLocal,
                    UserID = f.UserID
                };

                parameters.DetailEntityObjects.Add(new DetailObjectInfo()
                {
                    EntityName = vDailyActivity.EntityName,
                    EntitySet = obj,
                    FnName = RuleFunctionSEnum.Insert
                });
            }

            return true; //do update
        }

        protected override void onAfterUpdate(object entitySet, UpdateParameters parameters)
        {
            var f = (FoodGroup)entitySet;

            UpdateDailyActivitySums(f);
        }


        /// <summary>
        /// Updates daily activity information by group id
        /// </summary>
        /// <param name="foodGroupId"></param>
        public void UpdateDailyActivityByGroupID(long foodGroupId)
        {
            //var filter = new FilterExpression(vFoodGroup.ColumnNames.FoodGroupID, foodGroupId);
            //var list = GetByFilterT(new GetByFilterParameters(filter));
            //if (list.Count > 0)
            //    UpdateDailyActivitySums(list[0]);
            UpdateDailyActivitySums(GetByIDT(foodGroupId));
        }


        /// <summary>
        /// Updates DailyActivitySum by FoodGroup information
        /// </summary>
        /// <param name="f">FoodGroup information</param>
        public static void UpdateDailyActivitySums(FoodGroup f)
        {
            if (f.IsGroupSaved)
            {
                var foodgroupSumService = FoodGroupSumEN.GetService();
                var filter = new FilterExpression(vFoodGroupSum.ColumnNames.FoodGroupID, f.FoodGroupID);
                var sumList = foodgroupSumService.GetByFilterV(new GetByFilterParameters(filter));
                if (sumList.Count > 0) 
                {
                    var dailyActivityService = DailyActivityEN.GetService();

                    var list =
                        dailyActivityService.GetByTypeAndExternalEntityAndUser(new DailyActivity_GetByTypeAndExternalEntityAndUserSP
                        {
                            UserID = f.UserID,
                            ExternalEntityID = f.FoodGroupID,
                            DailyActivityTypeID = (int)EntityEnums.DailyActivityTypeEnum.Eating
                        });

                    var activity = list[0];
                    
                    if (sumList[0].CalorieSum.HasValue)
                        activity.Calorie = sumList[0].CalorieSum.Value;
                    if (sumList[0].CarbSum.HasValue)
                        activity.Carb = sumList[0].CarbSum.Value;
                    if (sumList[0].ProteinSum.HasValue)
                        activity.Protein = sumList[0].ProteinSum.Value;
                    if (sumList[0].FatSum.HasValue)
                        activity.Fat = sumList[0].FatSum.Value;

                    dailyActivityService.Update(activity, null);
                }
            }
        }

        #endregion

    }
}

