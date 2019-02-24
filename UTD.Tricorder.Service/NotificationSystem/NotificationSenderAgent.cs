using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Service.NotificationSystem
{

    /// <summary>
    /// Notification sender reads the queue from database and selects the appropriate
    /// sender and send it to the media
    /// </summary>
    public class NotificationSenderAgent : AbstractAgent
    {

        public static EmailNotificationSender emailNotificationSender = new EmailNotificationSender();
        public static SMSNotificationSender smsNotificationSender = new SMSNotificationSender();
        public static MobilePushMessageNotificationSender mobilePushMessageSender = new MobilePushMessageNotificationSender();


        public override string AgentTypeName
        {
            get { return "NotificationSender"; }
        }

        public override void DoAction()
        {
            try
            {
                // Reads the list and sends the notification
                List<vNotification> notificationList = GetPendingNotificationList();
                foreach (vNotification notification in notificationList)
                {
                    SendNotification(notification);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Gets the pending notification list.
        /// </summary>
        /// <returns></returns>
        public static List<vNotification> GetPendingNotificationList()
        {
            INotificationService service = (INotificationService)EntityFactory.GetEntityServiceByName(
                vNotification.EntityName, "");

            FilterExpression filterEmail = new FilterExpression();
            filterEmail.AddFilter(new Filter(vNotification.ColumnNames.EmailNotificationStatusID, (int)EntityEnums.NotificationStatusEnum.Pending));
            filterEmail.AddFilter(new Filter(vNotification.ColumnNames.IsEmail, true));
            filterEmail.AddFilter(new Filter(vNotification.ColumnNames.ReceiverUserEmail, null, FilterOperatorEnum.NotIsNull));

            FilterExpression filterSMS = new FilterExpression();
            filterSMS.AddFilter(new Filter(vNotification.ColumnNames.SMSNotificationStatusID, (int)EntityEnums.NotificationStatusEnum.Pending));
            filterSMS.AddFilter(new Filter(vNotification.ColumnNames.IsSMS, true));
            filterSMS.AddFilter(new Filter(vNotification.ColumnNames.ReceiverUserPhoneNumber, null, FilterOperatorEnum.NotIsNull));

            FilterExpression filter = new FilterExpression();
            filter.AddFilterExpression(filterEmail);
            filter.AddFilterExpression(filterSMS);
            filter.LogicalOperator = FilterLogicalOperatorEnum.OR;

            SortExpression sort = new SortExpression(vNotification.ColumnNames.InsertDate, SortDirectionEnum.ASC);

            int numberOfNotifies = 100;
            List<vNotification> notificationList = (List<vNotification>)
                service.GetByFilter(new GetByFilterParameters(filter, sort, 0, numberOfNotifies, null, GetSourceTypeEnum.View));
            return notificationList;
        }

        /// <summary>
        /// Sends the notification
        /// </summary>
        /// <param name="notification">The notification.</param>
        public static void SendNotification(vNotification notification)
        {
            //TODO: This design is not scalable for Mobile Push system
            //send email notification
            string errorMessage = null;
            if (notification.IsEmail)
            {
                try
                {
                    emailNotificationSender.SendNotification(notification);
                    notification.EmailNotificationStatusID = (int)EntityEnums.NotificationStatusEnum.Sent;
                    notification.EmailSendDate = DateTime.UtcNow;
                }
                catch (Exception ex)
                {
                    FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, "EMail, NotificationID:" + notification.NotificationID);
                    errorMessage = ex.Message;
                }
            }

            // send SMS notification
            if (notification.IsSMS)
            {
                try
                {
                    smsNotificationSender.SendNotification(notification);
                    notification.SMSNotificationStatusID = (int)EntityEnums.NotificationStatusEnum.Sent;
                    notification.SMSSendDate = DateTime.UtcNow;
                }
                catch (Exception ex)
                {
                    FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, "SMS, NotificationID:" + notification.NotificationID);
                    errorMessage = ex.Message;
                }
            }

            //send mobile push notify
            if (notification.IsMobilePushMessage)
            {
                try
                {
                    mobilePushMessageSender.SendNotification(notification);
                }
                catch (Exception ex)
                {
                    FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, "MobilePush, NotificationID:" + notification.NotificationID);
                    errorMessage = ex.Message;
                }

            }

            notification.NotificationErrorMessage = errorMessage;

            UpdateNotificationStatus(notification);
        }

        /// <summary>
        /// Updates the notification status.
        /// </summary>
        /// <param name="notification">The notification.</param>
        public static void UpdateNotificationStatus(vNotification notification)
        {
            INotificationService service = (INotificationService)EntityFactory.GetEntityServiceByName(
                 vNotification.EntityName, "");

            Notification n = (Notification)service.GetByID(notification.NotificationID, new GetByIDParameters());

            n.SMSNotificationStatusID = notification.SMSNotificationStatusID;
            n.EmailNotificationStatusID = notification.EmailNotificationStatusID;
            n.NotificationErrorMessage = notification.NotificationErrorMessage;
            n.EmailSendDate = notification.EmailSendDate;
            n.SMSSendDate = notification.SMSSendDate;

            service.Update(n, new UpdateParameters());
        }


    }
}
