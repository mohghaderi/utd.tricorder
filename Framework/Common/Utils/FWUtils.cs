using System;
using System.Collections;
using System.Configuration;
using System.Text;
using Framework.Common.Config;
using Framework.Common.Exceptions;
using Framework.Common.Utils;
using Framework.Common.Logging;

namespace Framework.Common
{
    /// <summary>
    /// Framework Utility Functions
    /// </summary>
    public static class FWUtils
    {
        private static ConfigUtils _ConfigUtils = new ConfigUtils();
        public static ConfigUtils ConfigUtils { get { return _ConfigUtils; } }

        private static ReflectionUtils _ReflectionUtils = new ReflectionUtils();
        public static ReflectionUtils ReflectionUtils { get { return _ReflectionUtils; } }
        
        private static EntityUtils _EntityUtils = new EntityUtils();
        public static EntityUtils EntityUtils { get { return _EntityUtils; } }
        
        private static DBTypeUtils _DBTypeUtils = new DBTypeUtils();
        public static DBTypeUtils DBTypeUtils { get { return _DBTypeUtils; } }
        
        private static CommaSeperatedUtils _CommaSeperatedUtils = new CommaSeperatedUtils();
        public static CommaSeperatedUtils CommaSeperatedUtils { get { return _CommaSeperatedUtils; } }

        private static WebUIUtils _WebUIUtils = new WebUIUtils();
        public static WebUIUtils WebUIUtils { get { return _WebUIUtils; } }

        private static MiscUtils _MiscUtils = new MiscUtils();
        public static MiscUtils MiscUtils { get { return _MiscUtils; } }

        private static UrlTemplateUtils _UrlTemplateUtils = new UrlTemplateUtils();
        public static UrlTemplateUtils UrlTemplateUtils { get { return _UrlTemplateUtils; } }

        private static SecurityUtils _SecurityUtils = new SecurityUtils();
        public static SecurityUtils SecurityUtils { get { return _SecurityUtils; } }

        private static ExpLogUtils _ExpLogUtils = new ExpLogUtils();
        public static ExpLogUtils ExpLogUtils { get { return _ExpLogUtils; } }

        private static RandomUtils _RandomUtils = new RandomUtils();
        public static RandomUtils RandomUtils { get { return _RandomUtils; } }

        private static EncryptionUtils _EncryptionUtils = new EncryptionUtils();
        public static EncryptionUtils EncryptionUtils { get { return _EncryptionUtils; } }

    }


}
