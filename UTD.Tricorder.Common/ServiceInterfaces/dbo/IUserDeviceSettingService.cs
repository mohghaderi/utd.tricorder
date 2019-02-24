using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IUserDeviceSettingService : IServiceBaseT<UserDeviceSetting, vUserDeviceSetting>
    {
        #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.
        
        /// <summary>
        /// Gets data by Device Generated UUID
        /// </summary>
        /// <param name="uuid">uuid</param>
        /// <returns></returns>
        vUserDeviceSetting GetByDeviceGeneratedUUID(Guid uuid);


        // This function is removed to make the device registration simpler for now
        // If we wanted to have an advanced device registration later
        // because of security concerns, we will switch back to this design
        ///// <summary>
        ///// Registers push notification token
        ///// </summary>
        ///// <param name="generatedUUID">Generated UUID</param>
        ///// <param name="userID">User ID</param>
        ///// <param name="pushToken">new push token</param>
        //void UpdatePushNotificationToken(Guid generatedUUID, long userID, string pushToken);




        /// <summary>
        /// Registers a new device for a user
        /// </summary>
        /// <param name="generatedUUID">device generated UUID</param>
        /// <param name="userID">user identifier</param>
        /// <param name="capabilitiesServerString">capabilities Server String</param>
        /// <param name="pushToken">push Token</param>
        void RegisterDevice(UserDeviceSettingRegisterDeviceSP p);



        /// <summary>
        /// Get the list of device settings by UserID
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <returns></returns>
        List<vUserDeviceSetting> GetByUserID(long userId);

        // removed because we have no usage for sending to one device only

        ///// <summary>
        ///// Sends a notification to the user's device
        ///// </summary>
        ///// <param name="userId">user identifier</param>
        ///// <param name="messageBody">Message body. Simple string message that user will see it. For example "Hello World!"</param>
        ///// <param name="sound">Sound file like Sound.caf</param>
        ///// <param name="timeToLiveSeconds">
        ///// from 0 to 2,419,200 seconds (GCM)
        /////  For infinite TTL set it as null
        /////  GCM keeps messages for only four weeks.
        /////  
        ///// For instant delivery use 0 because
        ///// GCM will never throttle messages with a time_to_live value of 0 seconds. In other words, GCM will guarantee best effort for messages that must be delivered "now or never."
        ///// Read more here: http://developer.android.com/google/gcm/adv.html#ttl
        ///// </param>
        ///// <param name="collapseKeyIfAny">
        ///// One is sufficient when message is collapsible. For example, for each new mail received
        ///// we don't need to inform user one by one. One 'new message' notificaion is enought so, 
        ///// IsOneSufficient = true. But for doctor rington, it can't be collapsible; So, IsOneSufficient=false there.
        ///// </param>
        ///// <param name="delayWhileIdle">
        ///// If the device was not available should it delay the delivery or not.
        ///// For example for mobile rington DelayWhileIdle should be false
        ///// For default value use null
        ///// </param>
        //bool PushNotificationToDevice(vUserDeviceSetting deviceSettings, string messageBody, string sound, int? timeToLiveSeconds, string collapseKeyIfAny, bool? delayWhileIdle);


        List<vUserDeviceSetting> SendPushSanity(SendPushSanitySP p);

        #endregion
    }
}

