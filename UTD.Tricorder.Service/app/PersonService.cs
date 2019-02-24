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
    public class PersonService : ServiceBase<Person, vPerson>, IPersonService
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        protected override bool onBeforeInsert(object entitySet, InsertParameters parameters)
        {
            //IUserService userService = (IUserService)EntityFactory.GetEntityServiceByName(User.EntityName, "");
            //User user = (User)userService.GetByID(((Person)entitySet).PersonID, new GetByIDParameters() { SourceType = GetSourceTypeEnum.Table });
            //user.UserApprovalStatusID = (int)EntityEnums.UserApprovalStatusEnum.WaitingForApproval;
            //parameters.DetailEntityObjects.Add(new DetailObjectInfo() { EntityName = User.EntityName, FnName = RuleFunctionSEnum.Update, EntitySet = user, AdditionalDataKey="" });
            return true;
        }


        protected override void onAfterGetByID(object entityObj, object typedKeyObject, GetByIDParameters parameters)
        {
            var profileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)typedKeyObject);
            FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "UserProfilePicUrl", entityObj, profileImageUrl);
        }

        protected override void onAfterGetByFilter(System.Collections.IList list, GetByFilterParameters parameters)
        {
            foreach (EntityObjectBase entityObj in list)
            {
                long typedKeyObject = (long)entityObj.GetPrimaryKeyValue();
                var profileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)typedKeyObject);
                FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "UserProfilePicUrl", entityObj, profileImageUrl);
            }
        }

		#endregion

    }
}

