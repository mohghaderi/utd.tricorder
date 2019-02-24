using Framework.Common;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.NotificationSystem;

namespace UTD.Tricorder.Website.Base
{
    public class SignalRPushSender  : ISignalRPushSender
    {
        IHubContext context = null;

        public SignalRPushSender()
        {
            // getting main hub context to communicate with client
            context = GlobalHost.ConnectionManager.GetHubContext<MainHub>();
        }


        public void Send(MobilePushNotification notification, vMobilePushTemplate template)
        {
            Check.Require(notification != null);
            Check.Require(template != null);

            if (notification.ReceiverUserID.HasValue)
            {
                if (template.MobilePushDeliveryTypeID == (byte)EntityEnums.MobilePushDeliveryType.WebAndMobile
                    || template.MobilePushDeliveryTypeID == (byte)EntityEnums.MobilePushDeliveryType.WebOnly)

                    SendToUser(notification.ReceiverUserID.Value, template.MobileNotificationTypeName, notification.ParamsJSON);
                else
                    throw new NotImplementedException();
                //    SendNeedAckToUser(notification.ReceiverUserID.Value, template.MobileNotificationTypeName, notification.ParamsJSON, notification.MobilePushNotificationID);
            }
            else
                throw new NotImplementedException();
        }


        public void SendToUser(long recieverUserID, string fnName, string paramsJSON)
        {
            context.Clients.User(recieverUserID.ToString()).Send(fnName, paramsJSON);
        }

        //public void SendNeedAckToUser(long recieverUserID, string fnName, string paramsJSON, long mobilePushNotificationId)
        //{
        //    context.Clients.User(recieverUserID.ToString()).SendNeedAck(fnName, paramsJSON, );
        //}
    }
}