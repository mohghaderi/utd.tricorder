using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using UTD.Tricorder.Common.EntityInfos;
using Framework.Common;

namespace UTD.Tricorder.Website.Base
{
    // http://www.asp.net/signalr/overview/guide-to-the-api/hubs-api-guide-server
    // http://www.asp.net/signalr/overview/getting-started/tutorial-server-broadcast-with-signalr

    // DEVELOPER NOTE: Since SignalR execution is different from ASP.NET MVC executions
    // all exceptions need to be handled here in the hub.
    // TODO: Make a general error handler for all Hub exceptions by creating HubBase class


    public class MainHub : Hub
    {

        public MainHub()
        {
      //// Create a Long running task to do an infinite loop which will keep sending the server time
      //      // to the clients every 3 seconds.
      //      var taskTimer = Task.Factory.StartNew(async () =>
      //          {
      //              while(true)
      //              {
      //                  string timeNow = DateTime.Now.ToString();
      ////Sending the server time to all the connected clients on the client method SendServerTime()
      //                  Clients.All.SendServerTime(timeNow);
      //                  //Delaying by 3 seconds.
      //                  await Task.Delay(3000);
      //              }
      //          }, TaskCreationOptions.LongRunning
      //          );
        }

        //public void Hello()
        //{
        //    Clients.All.hello();
        //}

        //public void PhoneRing(long callerId, long callieId)
        //{
        //    Clients.User(callieId.ToString()).PhoneRing(new {CallerID = callerId});
        //}

        //public void Send(long receiverUserID, string fnName, string paramsJSON)
        //{
        //    Clients.User(receiverUserID.ToString()).Send(fnName, paramsJSON);
        //}

        //public void Ack(long mobilePushNotificationID)
        //{
        //    var SignalRPushSender = (UTD.Tricorder.Common.NotificationSystem.ISignalRPushSender)FWUtils.ConfigUtils.GetAppSettings().MobilePush.GetRealTimeNotifyClass();
        //    SignalRPushSender.
        //}


        public override Task OnConnected()
        {
            try
            {
                System.Security.Principal.IPrincipal user = Context.User;
                UserEN.GetService().ChangeIsOnline(Convert.ToInt64(user.Identity.Name), true);
            }
            catch (Exception ex)
            {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, null);
            }

            // Add your own code here.
            // For example: in a chat application, record the association between
            // the current connection ID and user name, and mark the user as online.
            // After the code in this method completes, the client is informed that
            // the connection is established; for example, in a JavaScript client,
            // the start().done callback is executed.
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            try
            {
                if (stopCalled)
                {
                    //Console.WriteLine(String.Format("Client {0} explicitly closed the connection.", Context.ConnectionId));
                }
                else
                {
                    //Console.WriteLine(String.Format("Client {0} timed out .", Context.ConnectionId));
                }

                System.Security.Principal.IPrincipal user = Context.User;
                UserEN.GetService().ChangeIsOnline(Convert.ToInt64(user.Identity.Name), false);

            }
            catch (Exception ex)
            {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, null);
            }

            // Add your own code here.
            // For example: in a chat application, mark the user as offline, 
            // delete the association between the current connection id and user name.
            return base.OnDisconnected(stopCalled);
        }


        public override Task OnReconnected()
        {
            try
            {
                System.Security.Principal.IPrincipal user = Context.User;
                UserEN.GetService().ChangeIsOnline(Convert.ToInt64(user.Identity.Name), true);

                // Add your own code here.
                // For example: in a chat application, you might have marked the
                // user as offline after a period of inactivity; in that case 
                // mark the user as online again.

            }
            catch (Exception ex)
            {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, null);
            }
            return base.OnReconnected();
        }




        // WebRTC Signal Handler
        public void SendSignal(string signal, string targetConnectionId)
        {
            try
            {
                //var callingUser = Users.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);
                //var targetUser = Users.SingleOrDefault(u => u.ConnectionId == targetConnectionId);

                //// Make sure both users are valid
                //if (callingUser == null || targetUser == null)
                //{
                //    return;
                //}

                //// Make sure that the person sending the signal is in a call
                //var userCall = GetUserCall(callingUser.ConnectionId);

                //// ...and that the target is the one they are in a call with
                //if (userCall != null && userCall.Users.Exists(u => u.ConnectionId == targetUser.ConnectionId))
                //{
                //    // These folks are in a call together, let's let em talk WebRTC
                //Clients.Client(targetConnectionId).receiveSignal(callingUser, signal);
                //}
                Clients.Client(targetConnectionId).receiveSignal(Context.ConnectionId, signal);
            }
            catch (Exception ex)
            {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, null);
            }
        }

        public void ServerStartVideoCall(long callLogID)
        {
            try
            {
                // to make sure that call log is valid for video communication
                var callLog = CallLogEN.GetService().GetByIDT(callLogID);

                // if it was receiver, we inform the sender. If it was sender, we inform receiver
                if (Context.Request.User.Identity.Name == callLog.ReceiverUserID.ToString())
                    Clients.User(callLog.SenderUserID.ToString()).clientStartVideoCall(Context.ConnectionId, callLogID);
                else
                    Clients.User(callLog.ReceiverUserID.ToString()).clientStartVideoCall(Context.ConnectionId, callLogID);

            }
            catch (Exception ex)
            {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex,null);
            }
        }


    }
}