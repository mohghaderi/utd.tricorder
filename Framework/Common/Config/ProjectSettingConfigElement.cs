using System.Configuration;

namespace Framework.Common.Config
{
    public class ProjectSettingConfigElement : ConfigurationElement
    {
        public ProjectSettingConfigElement() { }

        [ConfigurationProperty("namespacePrefix", DefaultValue = "", IsRequired = true)]
        public string NamespacePrefix
        {
            get { return (string)this["namespacePrefix"]; }
            set { this["namespacePrefix"] = value; }
        }


        [ConfigurationProperty("factoryClassFullName", DefaultValue = "", IsRequired = true)]
        public string FactoryClassFullName
        {
            get { return (string)this["factoryClassFullName"]; }
            set { this["factoryClassFullName"] = value; }
        }

        [ConfigurationProperty("useSchemaWithEntityName", DefaultValue = "false", IsRequired = true)]
        public bool UseSchemaWithEntityName
        {
            get { return (bool)this["useSchemaWithEntityName"]; }
            set { this["useSchemaWithEntityName"] = value; }
        }


        [ConfigurationProperty("serverPrefixDigitsForIDGenerator", DefaultValue = "6", IsRequired = true)]
        public int ServerPrefixDigitsForIDGenerator
        {
            get { return (int)this["serverPrefixDigitsForIDGenerator"]; }
            set 
            {
                Check.Require(value < 6 && value > 2, "serverPrefixDigitsForIDGenerator should be a number between 2 and 6");
                this["serverPrefixDigitsForIDGenerator"] = value; 
            }
        }

        [ConfigurationProperty("projectConfigProviderClassFullName", DefaultValue = "", IsRequired = true)]
        public string ProjectConfigProviderClassFullName
        {
            get { return (string)this["projectConfigProviderClassFullName"]; }
            set { this["projectConfigProviderClassFullName"] = value; }
        }

        [ConfigurationProperty("serverInfoConfigFile", DefaultValue = "_Config\\serverInfo.config", IsRequired = true)]
        public string ServerInfoConfigFile
        {
            get { return (string)this["serverInfoConfigFile"]; }
            set { this["serverInfoConfigFile"] = value; }
        }

        [ConfigurationProperty("emailVerificationUrl", DefaultValue = "", IsRequired = true)]
        public string EmailVerificationUrl
        {
            get { return (string)this["emailVerificationUrl"]; }
            set { this["emailVerificationUrl"] = value; }
        }

        [ConfigurationProperty("phoneNumberVerificationUrl", DefaultValue = "", IsRequired = true)]
        public string PhoneNumberVerificationUrl
        {
            get { return (string)this["phoneNumberVerificationUrl"]; }
            set { this["phoneNumberVerificationUrl"] = value; }
        }

        [ConfigurationProperty("continueQuickRegisterUrl", DefaultValue = "", IsRequired = true)]
        public string ContinueQuickRegisterUrl
        {
            get { return (string)this["continueQuickRegisterUrl"]; }
            set { this["continueQuickRegisterUrl"] = value; }
        }

        [ConfigurationProperty("websiteUrl", DefaultValue = "", IsRequired = true)]
        public string WebsiteUrl
        {
            get { return (string)this["websiteUrl"]; }
            set { this["websiteUrl"] = value; }
        }

        [ConfigurationProperty("title", DefaultValue = "", IsRequired = true)]
        public string Title
        {
            get { return (string)this["title"]; }
            set { this["title"] = value; }
        }


        [ConfigurationProperty("googleApiServerKey", IsRequired = true)]
        public string GoogleApiServerKey
        {
            get { return (string)this["googleApiServerKey"]; }
            set { this["googleApiServerKey"] = value; }
        }

        [ConfigurationProperty("appleCertificatePassword", IsRequired = true)]
        public string AppleCertificatePassword
        {
            get { return (string)this["appleCertificatePassword"]; }
            set { this["appleCertificatePassword"] = value; }
        }

        [ConfigurationProperty("videoServiceHost", IsRequired = true)]
        public string VideoServiceHost
        {
            get { return (string)this["videoServiceHost"]; }
            set { this["videoServiceHost"] = value; }
        }

        [ConfigurationProperty("videoMeetingName", IsRequired = true)]
        public string VideoMeetingName
        {
            get { return (string)this["videoMeetingName"]; }
            set { this["videoMeetingName"] = value; }
        }

        [ConfigurationProperty("videoDefaultConnectionType", IsRequired = true)]
        public string VideoDefaultConnectionType
        {
            get { return (string)this["videoDefaultConnectionType"]; }
            set { this["videoDefaultConnectionType"] = value; }
        }

        [ConfigurationProperty("isDebug", DefaultValue = "false", IsRequired = true)]
        public bool IsDebug
        {
            get { return (bool)this["isDebug"]; }
            set { this["isDebug"] = value; }
        }


        /// <summary>
        /// Wait time to request new reset password code
        /// </summary>
        [ConfigurationProperty("resetPasswordNewRequestWaitSeconds", DefaultValue = "60", IsRequired = true)]
        public int ResetPasswordNewRequestWaitSeconds
        {
            get { return (int)this["resetPasswordNewRequestWaitSeconds"]; }
            set
            {
                this["resetPasswordNewRequestWaitSeconds"] = value;
            }
        }

        [ConfigurationProperty("resetPasswordCodeExpireSeconds", DefaultValue = "600", IsRequired = true)]
        public int ResetPasswordCodeExpireSeconds
        {
            get { return (int)this["resetPasswordCodeExpireSeconds"]; }
            set
            {
                this["resetPasswordCodeExpireSeconds"] = value;
            }
        }

        [ConfigurationProperty("resetPasswordUrl", DefaultValue = "", IsRequired = true)]
        public string ResetPasswordUrl
        {
            get { return (string)this["resetPasswordUrl"]; }
            set { this["resetPasswordUrl"] = value; }
        }

        [ConfigurationProperty("companyAddress", DefaultValue = "", IsRequired = false)]
        public string CompanyAddress
        {
            get { return (string)this["companyAddress"]; }
            set { this["companyAddress"] = value; }
        }

        [ConfigurationProperty("mainDomainName", DefaultValue = "", IsRequired = true)]
        public string MainDomainName
        {
            get { return (string)this["mainDomainName"]; }
            set { this["mainDomainName"] = value.ToLower(); }
        }


        /// <summary>
        /// Gets the email verification complete URL.
        /// </summary>
        /// <param name="emailVerificationCode">The email verification code.</param>
        /// <returns></returns>
        public string GetEmailVerificationCompleteUrl(System.Guid emailVerificationCode)
        {
            return this.WebsiteUrl + string.Format(this.EmailVerificationUrl, emailVerificationCode.ToString());
        }

        /// <summary>
        /// Gets the PhoneNumber verification complete URL.
        /// </summary>
        /// <param name="PhoneNumberVerificationCode">The PhoneNumber verification code.</param>
        /// <returns></returns>
        public string GetPhoneNumberVerificationCompleteUrl(int PhoneNumberVerificationCode)
        {
            return this.WebsiteUrl + string.Format(this.PhoneNumberVerificationUrl, PhoneNumberVerificationCode.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="verificationCode"></param>
        /// <returns></returns>
        public string GetContinueQuickRegisterUrl(long userId, int verificationCode)
        {
            return this.WebsiteUrl + string.Format(this.PhoneNumberVerificationUrl, userId.ToString(), verificationCode.ToString());
        }

        /// <summary>
        /// makes and creates a url for reseting a password
        /// </summary>
        /// <param name="emailOrPhoneNumber"></param>
        /// <param name="resetCode"></param>
        /// <returns></returns>
        public string GetResetPasswordUrl(string emailOrPhoneNumber, int resetCode)
        {
            string encodedEmailOrPhone = System.Web.HttpUtility.UrlEncode(emailOrPhoneNumber);
            return string.Format(this.ResetPasswordUrl, resetCode, encodedEmailOrPhone);
        }
        

    }
}
