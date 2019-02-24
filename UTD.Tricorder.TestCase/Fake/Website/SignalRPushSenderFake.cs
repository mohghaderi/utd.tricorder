using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common.NotificationSystem;

namespace UTD.Tricorder.TestCase.Fake.Website
{
    public class SignalRPushSenderFake : ISignalRPushSender
    {

        public void Send(Tricorder.Common.EntityObjects.MobilePushNotification notification, Tricorder.Common.EntityObjects.vMobilePushTemplate template)
        {
            Check.Require(notification != null);
            Check.Require(template != null);
        }

        public void SendToUser(long recieverUserID, string fnName, string paramsJSON)
        {
            return;
        }
    }

}
