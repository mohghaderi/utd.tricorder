using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Common.NotificationSystem
{
    public interface ISignalRPushSender
    {
        void Send(MobilePushNotification notification, vMobilePushTemplate template);

        void SendToUser(long recieverUserID, string fnName, string paramsJSON);
    }
}
