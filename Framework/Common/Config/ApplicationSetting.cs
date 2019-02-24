using System.Configuration;

namespace Framework.Common.Config
{
    /// <summary>
    /// Keeps Application settings
    /// </summary>
    public class ApplicationSetting : ConfigurationSection //, IXmlSerializable
    {

        public ApplicationSetting()
        {
        }

        /// <summary>
        /// Gets or sets the exceptionHandling.
        /// </summary>
        /// <value>
        /// The exceptionHandling.
        /// </value>
        [ConfigurationProperty("exceptionHandling")]
        public ExceptionSettingConfigElement ExceptionHandling
        {
            get { return (ExceptionSettingConfigElement)this["exceptionHandling"]; }
            set { this["exceptionHandling"] = value; }
        }


        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        /// <value>
        /// The log.
        /// </value>
        [ConfigurationProperty("log")]
        public LogSettingConfigElement Log
        {
            get { return (LogSettingConfigElement)this["log"]; }
            set { this["log"] = value; }
        }


        /// <summary>
        /// Gets or sets the security.
        /// </summary>
        /// <value>
        /// The security.
        /// </value>
        [ConfigurationProperty("security")]
        public SecuritySettingConfigElement Security
        {
            get { return (SecuritySettingConfigElement)this["security"]; }
            set { this["security"] = value; }
        }



        [ConfigurationProperty("localization")]
        public LocalizationSettingConfigElement Localization
        {
            get { return (LocalizationSettingConfigElement)this["localization"]; }
            set { this["localization"] = value; }
        }



        [ConfigurationProperty("project")]
        public ProjectSettingConfigElement Project
        {
            get { return (ProjectSettingConfigElement)this["project"]; }
            set { this["project"] = value; }
        }



        [ConfigurationProperty("databaseContexts", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DatabaseContextsCollection), AddItemName = "context",
            ClearItemsName = "clearFactories")]
        public DatabaseContextsCollection DatabaseContexts
        {
            get
            {
                return (DatabaseContextsCollection)base["databaseContexts"];
            }
        }



        [ConfigurationProperty("paypal")]
        public PaypalConfigElements Paypal
        {
            get { return (PaypalConfigElements)this["paypal"]; }
            set { this["paypal"] = value; }
        }

        [ConfigurationProperty("twilio")]
        public TwilioConfigElement Twilio
        {
            get { return (TwilioConfigElement)this["twilio"]; }
            set { this["twilio"] = value; }
        }


        [ConfigurationProperty("amazonCloud")]
        public AmazonCloudConfigElement AmazonCloud
        {
            get { return (AmazonCloudConfigElement)this["amazonCloud"]; }
            set { this["amazonCloud"] = value; }
        }

        /// <summary>
        /// Gets or sets the mobile push settings.
        /// </summary>
        /// <value>
        /// The mobile push settings.
        /// </value>
        [ConfigurationProperty("mobilePush")]
        public MobilePushConfigElement MobilePush
        {
            get { return (MobilePushConfigElement)this["mobilePush"]; }
            set { this["mobilePush"] = value; }
        }


    }



}

