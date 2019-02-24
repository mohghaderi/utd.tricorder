using System.Globalization;
using Framework.Common.Config;
using System;

namespace Framework.Common
{

    /// <summary>
    /// Keeps additional configuration for project
    /// TODO: This class should be removed completely. It has a bad design pattern
    /// </summary>
    public abstract class ConfigurationBase
    {

        public int FailedPasswordCountAllowed
        {
            get { return 5; }
        }



        private static ConfigurationBase _DefaultInstance;

        /// <summary>
        /// Gets the default instance of the project configuration
        /// </summary>
        /// <value>
        /// The default instance.
        /// </value>
        public static ConfigurationBase DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null)
                {
                    ApplicationSetting appSetting = FWUtils.ConfigUtils.GetAppSettings();
                    _DefaultInstance = (ConfigurationBase)FWUtils.ReflectionUtils.CreateInstance(appSetting.Project.ProjectConfigProviderClassFullName);
                }
                return _DefaultInstance;
            }
        }




    }
}
