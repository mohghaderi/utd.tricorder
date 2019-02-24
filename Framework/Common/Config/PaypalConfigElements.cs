using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Config
{
    public class PaypalConfigElements : ConfigurationElement
    {
        public PaypalConfigElements() { }

        // for both classic and rest api
        [ConfigurationProperty("mainAccount", DefaultValue = "", IsRequired = true)]
        public string MainAccount
        {
            get { return (string)this["mainAccount"]; }
            set { this["mainAccount"] = value; }
        }

        // for both restful and classic Api
        [ConfigurationProperty("endpoint", DefaultValue = "", IsRequired = true)]
        public string Endpoint
        {
            get { return (string)this["endpoint"]; }
            set { this["endpoint"] = value; }
        }


        // this is only for restful Api (get in paypal developer webside)
        [ConfigurationProperty("clientID", DefaultValue = "", IsRequired = true)]
        public string ClientID
        {
            get { return (string)this["clientID"]; }
            set { this["clientID"] = value; }
        }


        // This is only for restful api
        [ConfigurationProperty("secret", DefaultValue = "", IsRequired = true)]
        public string Secret
        {
            get { return (string)this["secret"]; }
            set { this["secret"] = value; }
        }

        //  ----------------- Classic Api settings --------------------


        // this is only for classic api
        [ConfigurationProperty("applicationID", DefaultValue = "", IsRequired = true)]
        public string ApplicationID
        {
            get { return (string)this["applicationID"]; }
            set { this["applicationID"] = value; }
        }


        // this is only for classic api
        [ConfigurationProperty("userName", DefaultValue = "", IsRequired = true)]
        public string UserName
        {
            get { return (string)this["userName"]; }
            set { this["userName"] = value; }
        }

        // this is only for classic api
        [ConfigurationProperty("password", DefaultValue = "", IsRequired = true)]
        public string password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }


        // this is only for classic api
        [ConfigurationProperty("signature", DefaultValue = "", IsRequired = true)]
        public string Signature
        {
            get { return (string)this["signature"]; }
            set { this["signature"] = value; }
        }



        // ------------------- Connection Settings  ---------------------


        [ConfigurationProperty("connectionTimeout", DefaultValue = "5000", IsRequired = true)]
        public int ConnectionTimeout
        {
            get { return (int)this["connectionTimeout"]; }
            set { this["connectionTimeout"] = value; }
        }


        [ConfigurationProperty("requestRetries", DefaultValue = "2", IsRequired = true)]
        public int RequestRetries
        {
            get { return (int)this["requestRetries"]; }
            set { this["requestRetries"] = value; }
        }



        // This is only for restful api
        [ConfigurationProperty("isSandBox", DefaultValue = "true", IsRequired = true)]
        public bool IsSandBox
        {
            get { return (bool)this["isSandBox"]; }
            set { this["isSandBox"] = value; }
        }


        [ConfigurationProperty("senderRedirectUrl", DefaultValue = "", IsRequired = true)]
        public string senderRedirectUrl
        {
            get { return (string)this["senderRedirectUrl"]; }
            set { this["senderRedirectUrl"] = value; }
        }

        [ConfigurationProperty("senderRedirectMobileUrl", DefaultValue = "", IsRequired = true)]
        public string SenderRedirectMobileUrl
        {
            get { return (string)this["senderRedirectMobileUrl"]; }
            set { this["senderRedirectMobileUrl"] = value; }
        }

        [ConfigurationProperty("cancelPage", DefaultValue = "", IsRequired = true)]
        public string CancelPage
        {
            get { return (string)this["cancelPage"]; }
            set { this["cancelPage"] = value; }
        }

        [ConfigurationProperty("returnPage", DefaultValue = "", IsRequired = true)]
        public string ReturnPage
        {
            get { return (string)this["returnPage"]; }
            set { this["returnPage"] = value; }
        }

        [ConfigurationProperty("webRootUrl", DefaultValue = "", IsRequired = true)]
        public string WebRootUrl
        {
            get { return (string)this["webRootUrl"]; }
            set { this["webRootUrl"] = value; }
        }



        private Dictionary<string, string> configMapWithAccount;

        // Creates a configuration map containing credentials and other required configuration parameters
        public Dictionary<string, string> GetAcctAndConfig()
        {
            if (configMapWithAccount != null)
                return configMapWithAccount;

            configMapWithAccount = GetConfig();

            // Signature Credential
            configMapWithAccount.Add("account1.apiUsername", this.UserName);
            configMapWithAccount.Add("account1.apiPassword", this.password);
            configMapWithAccount.Add("account1.apiSignature", this.Signature);
            configMapWithAccount.Add("account1.applicationId", this.ApplicationID);

            // Sandbox Email Address
            configMapWithAccount.Add("sandboxEmailAddress", this.MainAccount);

            return configMapWithAccount;
        }

        // Creates a configuration map containing mode and other required configuration parameters
        public Dictionary<string, string> GetConfig()
        {
            Dictionary<string, string> configMap = new Dictionary<string, string>();

            if (this.IsSandBox)
            {
                configMap.Add("mode", "sandbox");
            }
            else
            {
                configMap.Add("mode", "live");
            }

            // These values are defaulted in SDK. If you want to override default values, uncomment it and add your value.
            configMap.Add("connectionTimeout", this.ConnectionTimeout.ToString());
            configMap.Add("requestRetries", this.RequestRetries.ToString());

            return configMap;
        }

        #region Url Calculations

        
        
        #endregion


        /// <summary>
        /// Gets the sender redirect URL pay key.
        /// </summary>
        /// <param name="payKey">The pay key</param>
        /// <returns></returns>
        public string GetSenderRedirectUrlPayKey(string payKey, bool isMobile)
        {
            if (isMobile)
                return this.SenderRedirectMobileUrl + payKey;
            else
                return this.senderRedirectUrl + payKey;
        }

        /// <summary>
        /// Gets the cancel URL payment identifier.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns></returns>
        public string GetCancelUrlPaymentID(long paymentId)
        {
            string websiteUrl = FWUtils.ConfigUtils.GetAppSettings().Project.WebsiteUrl;
            return websiteUrl + this.WebRootUrl + this.CancelPage + "?paymentId=" + paymentId.ToString();
        }

        /// <summary>
        /// Gets the return URL by payment identifier.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns></returns>
        public string GetReturnUrlByPaymentID(long paymentId)
        {
            string websiteUrl = FWUtils.ConfigUtils.GetAppSettings().Project.WebsiteUrl;
            return websiteUrl + this.WebRootUrl + this.ReturnPage + "?paymentId=" + paymentId.ToString();
        }

        /// <summary>
        /// Gets the ipn notification URL.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns></returns>
        /// <exception cref="ImpossibleExecutionException">This url should be less than 1024 characters. Check web.config file for applicationsettings.paypal.webRootUrl:  + ipnUrl</exception>
        public string GetIpnNotificationUrl(long paymentId)
        {
            string websiteUrl = FWUtils.ConfigUtils.GetAppSettings().Project.WebsiteUrl;
            string ipnUrl = websiteUrl + this.WebRootUrl + "ipnNotification.ashx?paymentId=" + paymentId.ToString();
            if (ipnUrl.Length >= 1024)
                throw new ImpossibleExecutionException("This url should be less than 1024 characters. Check web.config file for applicationsettings.paypal.webRootUrl: " + ipnUrl);
            return ipnUrl;
        }


    }
}
