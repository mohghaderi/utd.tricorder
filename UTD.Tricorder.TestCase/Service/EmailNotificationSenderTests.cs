using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.Service.NotificationSystem;
using UTD.Tricorder.Common.EntityObjects;
namespace UTD.Tricorder.Common.Tests
{
    [TestClass()]
    public class EmailNotificationSenderTests
    {
        // for configuration read:
        // http://www.iis.net/learn/application-frameworks/install-and-configure-php-on-iis/configure-smtp-e-mail-in-iis-7-and-above
        // http://forums.iis.net/t/1157046.aspx

        //NOTE: unsent messages goes to \Inetpub\mailroot\Queue\ folder of the server
        // The problem is usually DNS resolving (it can be checked in Event Viewer under name of app smtpsvc)
        // For gmail fix read: http://social.technet.microsoft.com/Forums/windowsserver/en-US/bc8346f3-80ee-4da8-a646-2889468d7fcc/smtp-error-message-delivery-to-the-host-failed-while-delivering-?forum=winserver8gen


        //[TestMethod()]
        //public void SendEmailMessageSameDomainTest()
        //{
        //    // Test on the same domain
        //    EmailNotificationSender target = new EmailNotificationSender();
        //    string fromEmail = "mohghaderi@qolt1.campus.ad.utdallas.edu";
        //    string toEmail = "mohghaderi@qolt1.campus.ad.utdallas.edu";
        //    string subject = "a test mail subject";
        //    string body = "Body Text. Salam";
        //    bool isBodyHtml = false;

        //    target.SendEmailMessage(fromEmail, toEmail, subject, body, isBodyHtml);
        //}

        //[TestMethod()]
        //public void SendEmailMessageExternalDomainTest()
        //{
        //    // Test on the external domain
        //    EmailNotificationSender target = new EmailNotificationSender();
        //    string fromEmail = "mohghaderi@qolt1.campus.ad.utdallas.edu";
        //    string toEmail = "mohghaderi@gmail.com";
        //    string subject = "a test mail subject";
        //    string body = "Body Text. Salam";
        //    bool isBodyHtml = false;

        //    target.SendEmailMessage(fromEmail, toEmail, subject, body, isBodyHtml);
        //}

        //[TestMethod()]
        //public void SendEmailMessageExternalDomain2Test()
        //{
        //    // Test on the same domain
        //    EmailNotificationSender target = new EmailNotificationSender();
        //    string fromEmail = "mohghaderi@qolt1.campus.ad.utdallas.edu";
        //    string toEmail = "mohghaderi@utdallas.edu";
        //    string subject = "a test mail subject";
        //    string body = "Body Text. Salam";
        //    bool isBodyHtml = false;

        //    target.SendEmailMessage(fromEmail, toEmail, subject, body, isBodyHtml);
        //}

        //[TestMethod()]
        //public void SendEmailMessageHTMLTest()
        //{
        //    EmailNotificationSender target = new EmailNotificationSender();
        //    string fromEmail = "mohghaderi@qolt1.campus.ad.utdallas.edu"; ;
        //    string toEmail = "mohghaderi@utdallas.edu";
        //    string subject = "a test mail subject";
        //    string body = "<html><body><b>Body Text.</b> Salam </body></html>";
        //    bool isBodyHtml = true;

        //    target.SendEmailMessage(fromEmail, toEmail, subject, body, isBodyHtml);
        //}


    }
}
