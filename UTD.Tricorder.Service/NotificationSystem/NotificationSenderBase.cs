using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Service.NotificationSystem
{
    public abstract class NotificationSenderBase
    {
        public abstract void SendNotification(vNotification notificationObj);

        /// <summary>
        /// Gets the template parameters.
        /// It makes default parameters + notification parameters available in the object
        /// </summary>
        /// <param name="notificationObj">The notification object.</param>
        /// <returns></returns>
        public TemplateParams GetTemplateParams(vNotification notificationObj)
        {
            var projectSettings = FWUtils.ConfigUtils.GetAppSettings().Project;
            string websiteUrl = projectSettings.WebsiteUrl;
            string appTitle = projectSettings.Title;
            string emailVerificationUrl = projectSettings.GetEmailVerificationCompleteUrl(notificationObj.RecieverUserEmailVerificationCode);
            string phoneNumberVerificationUrl = projectSettings.GetPhoneNumberVerificationCompleteUrl(notificationObj.RecieverUserPhoneVerificationCode);

            TemplateParams p = new TemplateParams().DeserializeFromString(notificationObj.ParametersValues);

            // adding default parameters
            p.AddParameter("App.WebsiteUrl", websiteUrl);
            p.AddParameter("App.Title", appTitle);

            p.AddParameter("ReceiverUser.UserTitle", FWUtils.EntityUtils.ConcatStrings(" ", notificationObj.RecieverUserNamePrefix, notificationObj.ReceiverUserFirstName, notificationObj.ReceiverUserLastName));
            p.AddParameter("ReceiverUser.FirstName", notificationObj.ReceiverUserFirstName);
            p.AddParameter("ReceiverUser.UserName", notificationObj.RecieverUserUserName);
            p.AddParameter("ReceiverUser.Email", notificationObj.ReceiverUserEmail);
            p.AddParameter("ReceiverUser.EmailVerificationCode", notificationObj.RecieverUserEmailVerificationCode.ToString());
            p.AddParameter("ReceiverUser.EmailVerificationUrl", emailVerificationUrl);
            p.AddParameter("ReceiverUser.PhoneVerificationCode", notificationObj.RecieverUserPhoneVerificationCode.ToString());
            p.AddParameter("ReceiverUser.PhoneVerificationUrl", phoneNumberVerificationUrl);

            p.AddParameter("SenderUser.UserTitle", FWUtils.EntityUtils.ConcatStrings(" ", notificationObj.SenderUserNamePrefix, notificationObj.SenderUserFirstName, notificationObj.SenderUserLastName));
            p.AddParameter("SenderUser.FirstName", notificationObj.SenderUserFirstName);
            p.AddParameter("SenderUser.UserName", notificationObj.SenderUserLastName);
            p.AddParameter("SenderUser.Email", notificationObj.SenderUserEmail);
            p.AddParameter("Notification.NotificationID", notificationObj.NotificationID.ToString());
            p.AddParameter("App.CompanyAddress", projectSettings.CompanyAddress);

            return p;
        }
    }
}
