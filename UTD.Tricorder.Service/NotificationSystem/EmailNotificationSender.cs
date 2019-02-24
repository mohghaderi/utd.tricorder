using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Service.NotificationSystem
{
    /// <summary>
    /// Sends email notifications
    /// </summary>
    public class EmailNotificationSender : NotificationSenderBase
    {
        public override void SendNotification(vNotification notificationObj)
        {
            TemplateParams p = GetTemplateParams(notificationObj);

            // ignoring sending emails when receiver doesn't have any email address in our system (causes exception)
            if (string.IsNullOrEmpty(notificationObj.ReceiverUserEmail) == false)
            {
                string fromEmail = null;
                string toEmail = notificationObj.ReceiverUserEmail;
                string subject = p.ProcessTemplate(notificationObj.EmailSubject);
                string body = p.ProcessTemplate(GetEmailMasterTemplate(notificationObj.EmailBodyText));
                bool isBodyHtml = true;

                SendEmailMessage(fromEmail, toEmail, subject, body, isBodyHtml);

                // logging the details
                FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.Notify_Email, UserID = notificationObj.ReceiverUserID, ExtraBigInt = notificationObj.NotificationID });
            }

        }

        private static string _MasterTemplateBody = null;

        /// <summary>
        /// Gets master template and replaces its body with the body obtained from the message
        /// </summary>
        /// <param name="body">message body</param>
        /// <returns></returns>
        private string GetEmailMasterTemplate(string body)
        {
            if (_MasterTemplateBody == null)
                _MasterTemplateBody = NotificationTemplateEN.GetService().GetByIDT((short)EntityEnums.NotificationTemplateEnum.MasterTemplate).EmailBodyText;

            return _MasterTemplateBody.Replace("{Notification.EmailBodyText}", body);
        }

        /// <summary>
        /// Sends the email message.
        /// </summary>
        /// <param name="fromEmail">From email.</param>
        /// <param name="toEmail">To email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> [is body HTML].</param>
        public void SendEmailMessage(string fromEmail, string toEmail, string subject, string body, bool isBodyHtml)
        {
            // sending email
            MailMessage message = new MailMessage();

            if (string.IsNullOrEmpty(fromEmail) == false)
                message.From = new MailAddress(fromEmail);

            message.To.Add(new MailAddress(toEmail));

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isBodyHtml;

            using (SmtpClient client = new SmtpClient())
            {
                //var SmtpUser = new System.Net.NetworkCredential("QOLT1\\smtpuser", "SMTPPassword");
                //client.Credentials = SmtpUser;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(message);
            }
        }

    }
}
