using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.BusinessRule
{
    public class UserDeviceSettingBR : BusinessRuleBase<UserDeviceSetting, vUserDeviceSetting>
    {
        #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.


        public void RegisterPushNotificationToken(UserDeviceSetting obj, long userID, string pushToken)
        {
            if (obj == null)
                throw new UserException("Err1: This Device is not registered.");
            else
            {
                // Our current policy is to transfer the device transparently to new user
                // This is when two users are going to use the same device
                // In this case, the person who logins last will be the owner of the device

                //if (obj.UserID != userID)
                //    throw new UserException("Err2: This device belongs to someone else.");

            }
        }

        #endregion

    }
}

