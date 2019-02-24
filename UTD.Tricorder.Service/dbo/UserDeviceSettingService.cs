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
    public class UserDeviceSettingService : ServiceBase<UserDeviceSetting, vUserDeviceSetting>, IUserDeviceSettingService
    {
	
	
  #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.



        /// <summary>
        /// Gets data by Device Generated UUID
        /// </summary>
        /// <param name="generatedUUID">Generated UUID</param>
        /// <returns></returns>
        public vUserDeviceSetting GetByDeviceGeneratedUUID(Guid generatedUUID)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vUserDeviceSetting.ColumnNames.DeviceGeneratedUUID, generatedUUID));
            List<vUserDeviceSetting> list = (List<vUserDeviceSetting>)
                GetByFilter(new GetByFilterParameters(filter, new SortExpression(), 0, 1, null , GetSourceTypeEnum.View));
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }


        //public struct RegisterPushNotificationTokenParams
        //{
        //    public Guid generatedUUID { get; set; }
        //    public long userID { get; set; }
        //    public string pushToken { get; set; }
        //}



        ///// <summary>
        ///// Registers push notification token
        ///// </summary>
        ///// <param name="generatedUUID">Generated UUID</param>
        ///// <param name="userID">User ID</param>
        ///// <param name="pushToken">new push token</param>
        //public void UpdatePushNotificationToken(Guid generatedUUID, long userID, string pushToken)
        //{
        //    var obj = GetByDeviceGeneratedUUID(generatedUUID);
        //    UserDeviceSettingBR biz = (UserDeviceSettingBR)this.BusinessLogicObject;
        //    biz.RegisterPushNotificationToken(obj, userID, pushToken);

        //    if (obj.PushNotificationToken != pushToken) // if it was the same token, don't update anything
        //    {
        //        obj.PushNotificationToken = pushToken;
        //        obj.PushNotificationTokenLastUpdate = DateTime.UtcNow;
        //        obj.UserID = userID; // Transparently transfer a device from one user to another

        //        Update(obj, new UpdateParameters());
        //    }
        //}

        /// <summary>
        /// Registers a new device for a user
        /// </summary>
        /// <param name="generatedUUID">device generated UUID</param>
        /// <param name="userID">user identifier</param>
        /// <param name="capabilitiesServerString">capabilities Server String</param>
        /// <param name="pushToken">push Token</param>
        public void RegisterDevice(UserDeviceSettingRegisterDeviceSP p)
        {
            var dev = GetRegisteredDevice(p.UserID, p.GeneratedUUID, p.PushToken);
            if (dev != null) // if this device was registered before
            {
                if (dev.UserID != p.UserID) // if it was not the same user, just transfer the user; later we may change this policy for security concerns
                {
                    dev.UserID = p.UserID;
                }
                
                if (dev.DeviceGeneratedUUID != p.GeneratedUUID)
                    dev.DeviceGeneratedUUID = p.GeneratedUUID;

                dev.CapabilitiesServerString = p.CapabilitiesServerString;
                if (string.IsNullOrEmpty(p.PushToken) == false)
                    if (dev.PushNotificationToken != p.PushToken)
                    {
                        dev.PushNotificationToken = p.PushToken;
                        dev.PushNotificationTokenLastUpdate = DateTime.UtcNow;
                    }

                dev.UserDeviceClientAppTypeID = p.UserDeviceClientAppTypeID;
                dev.UserDeviceClientAppVersion = p.UserDeviceClientAppVersion;

                dev.UpdateDate = DateTime.UtcNow;

                Update(dev, new UpdateParameters());
            }
            else // if it was not registered before, just insert a new one
            {
                UserDeviceSetting obj = new UserDeviceSetting();
                obj.UserID = p.UserID;
                obj.InsertDate = DateTime.UtcNow;
                obj.DeviceGeneratedUUID = p.GeneratedUUID;

                // push notification
                obj.PushNotificationToken = p.PushToken;
                obj.PushNotificationTokenLastUpdate = DateTime.UtcNow;

                obj.UserDeviceClientAppTypeID = p.UserDeviceClientAppTypeID;
                obj.UserDeviceClientAppVersion = p.UserDeviceClientAppVersion;

                SetCapabilities(obj, p.CapabilitiesServerString);

                // detecting mobile push server id
                if (obj.Version.ToLower().StartsWith("and") ||
                    obj.OS.ToLower().Contains("android"))
                    obj.MobilePushServerID = (byte)EntityEnums.MobilePushServerEnum.Google_GCM;
                else if (obj.OS.ToLower().IndexOf("iphone") > -1 ||
                    obj.OS.ToLower().IndexOf("ipad") > -1)
                {
                    obj.MobilePushServerID = (byte)EntityEnums.MobilePushServerEnum.Apple_APNS;
                }
                else
                    obj.MobilePushServerID = (byte)EntityEnums.MobilePushServerEnum.Unknown;

                if (obj.MobilePushServerID != (byte)EntityEnums.MobilePushServerEnum.Unknown)
                    obj.PushNotificationIsActive = true;

                obj.UpdateDate = DateTime.UtcNow;

                Insert(obj, new InsertParameters());
            }

        }

        private static void SetCapabilities(UserDeviceSetting obj, string capabilitiesString)
        {
            obj.CapabilitiesServerString = capabilitiesString;
            if (obj.UserDeviceClientAppTypeID == (byte)EntityEnums.UserDeviceClientAppTypeEnum.Cordova)
            {
                var cordovaCapabilities = obj.GetCordovaCapabilities();
                obj.Manufacturer = cordovaCapabilities.model;
                obj.Version = cordovaCapabilities.osversion;
                obj.OS = cordovaCapabilities.platform;
                obj.DeviceName = cordovaCapabilities.model;
            }
            else
            {
                var airCapabilities = obj.GetAirCapabilities();
                obj.Manufacturer = airCapabilities.manufacturer;
                obj.Version = airCapabilities.version;
                obj.OS = airCapabilities.os;
                obj.DeviceName = airCapabilities.manufacturer;
            }
        }


        /// <summary>
        /// Gets registered device with the provided information
        /// if the device was not available then it returns null
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="generatedUUID">generated uuid</param>
        /// <param name="pushToken">token</param>
        /// <returns></returns>
        private vUserDeviceSetting GetRegisteredDevice(long userId, Guid generatedUUID, string pushToken)
        {
            // gets all devices of one user
            var userDevicesList = GetByUserID(userId);
            foreach (var device in userDevicesList)
            {
                if (device.DeviceGeneratedUUID == generatedUUID)
                    return device;
                if (device.PushNotificationToken == pushToken)
                    return device;
            }
            return null;
        }

        /// <summary>
        /// Get the list of device settings by UserID
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <returns></returns>
        public List<vUserDeviceSetting> GetByUserID(long userId)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vUserDeviceSetting.ColumnNames.UserID, userId));

            List<vUserDeviceSetting> list = (List<vUserDeviceSetting>)
                GetByFilter(new GetByFilterParameters(filter, new SortExpression(), 0, 1000, null, GetSourceTypeEnum.View));

            return list;
        }

        /// <summary>
        /// Sends push sanity to the current user
        /// </summary>
        public List<vUserDeviceSetting> SendPushSanity(SendPushSanitySP p)
        {
            List<vUserDeviceSetting> results = new List<vUserDeviceSetting>();

            var list = GetByUserID(p.UserID);
            foreach(var item in list)
            {
                if (item.PushNotificationIsActive == true)
                    results.Add(MobilePushNotificationEN.GetService().TestPushSanity(item.DeviceGeneratedUUID));
            }
            return results;
        }

        #endregion

    }
}

