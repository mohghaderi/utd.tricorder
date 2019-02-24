using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IMobilePushNotificationService : IServiceBaseT<MobilePushNotification, vMobilePushNotification>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        /// <summary>
        /// Sends a test message from the push server to test if the device receives the message or not.
        /// </summary>
        /// <param name="generatedUUID">device generated UUID</param>
        vUserDeviceSetting TestPushSanity(Guid generatedUUID);

        /// <summary>
        /// Sends a notification to the user's device
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <param name="message">Message</param>
        /// <returns>Number of delivered messages</returns>
        int PushNotification(long userId, UTD.Tricorder.Common.NotificationSystem.MobileNotificationMessage message);



		#endregion
    }
}

