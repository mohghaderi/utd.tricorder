using Framework.Common.Security;
using Framework.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Common.Utils
{
    // Developer Note: This class usage is STATIC, No state property


    /// <summary>
    /// Security and membership utilities
    /// </summary>
    public class SecurityUtils
    {
        private IServiceBase _ResourceService;
        private IServiceBase _UserInRoleService;

        public SecurityUtils()
        {
            // Keep constructor empty to prevent FWUtils initialization problem in the case of exception
        }

        private IServiceBase GetResourceService()
        { 
            if (_ResourceService == null)
                _ResourceService = EntityFactory.GetEntityServiceByName("Resource", "");
            return _ResourceService;
        }

        private IServiceBase GetUserInRoleService()
        {
            if (_UserInRoleService == null)
                _UserInRoleService = EntityFactory.GetEntityServiceByName("UserInRole", "");
            return _UserInRoleService;
        }


        public virtual bool IsUserAuthenticated()
        {
            try
            {
                return System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            }
            catch
            {
            }
            return false;
        }

        public virtual string GetCurrentUserIDString()
        {
            try
            {
                return System.Web.HttpContext.Current.User.Identity.Name;
            }
            catch
            {
            }

            return null;
        }

        public virtual long GetCurrentUserIDLong()
        {
            try
            {
                string userId = System.Web.HttpContext.Current.User.Identity.Name;
                if (string.IsNullOrEmpty(userId) == false)
                    return Convert.ToInt64(userId);
            }
            catch
            {
            }

            throw new AuthenticationIsRequiredException();
        }

        /// <summary>
        /// Gets the current user identifier unique identifier.
        /// </summary>
        /// <returns></returns>
        public virtual Guid? GetCurrentUserIDGuid()
        {
            try
            {
                string userId = System.Web.HttpContext.Current.User.Identity.Name;
                if (string.IsNullOrEmpty(userId))
                    return new Guid(userId);
            }
            catch
            {
            }

            return null;
        }

        /// <summary>
        /// Gets current culture info
        /// if it was not available it returns en-US as default culture
        /// </summary>
        /// <returns></returns>
        public CultureInfo GetCultureInfo()
        {
            if (System.Threading.Thread.CurrentThread == null)
                return new CultureInfo("en-US");
            else
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture == null)
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                return System.Threading.Thread.CurrentThread.CurrentCulture;
            }

        }

        /// <summary>
        /// Resources the has access.
        /// </summary>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="throwIfNoAccess">if set to <c>true</c> [throw if no access].</param>
        /// <returns></returns>
        /// <exception cref="UserException"></exception>
        public bool HasAccess(string resourceCode, bool throwIfNoAccess)
        {
            bool hasAccess = true;

            //TODO: Security and Permissions should be added to framework
            //hasAccess = IsUserPermitted();

            if (hasAccess == false && throwIfNoAccess)
                throw new ServiceSecurityException(string.Format(StringMsgs.Exceptions.AccessDenied_, resourceCode));

            return hasAccess;
        }

        /// <summary>
        /// Users the has role.
        /// </summary>
        /// <param name="roleCode">The role code.</param>
        /// <returns></returns>
        public bool HasRole(string roleCode)
        {
            string userId = this.GetCurrentUserIDString();
            if (string.IsNullOrEmpty(userId))
                return false;

            //// TODO: cache roles here
            //var list = _UserInRoleService.GetRolesByUserID(userId);

            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter("UserID", userId));
            filter.AddFilter(new Filter("IsActive", true));
            var gParams = new GetByFilterParameters(filter, new SortExpression(),0, 1000, null, GetSourceTypeEnum.View);
            var list = GetUserInRoleService().GetByFilter(gParams);


            foreach (var item in list)
            {
                string rCode = FWUtils.EntityUtils.GetObjectFieldValueString(item, "RoleCode");
                if (rCode == roleCode)
                    return true;
            }

            return false;
        }


        /// <summary>
        /// Creates a Hash string using SHA256 and base64
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string CreateHashString(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }



        #region Site and Site domain

        /// <summary>
        /// Get running site name from the requested Url
        /// This is not valid when no request object is created and it returns null
        /// </summary>
        /// <returns></returns>
        public string GetDomainName()
        {
            try
            {
                string hostName = System.Web.HttpContext.Current.Request.Url.Host.ToLower();
                return hostName;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Generates a guid by site name
        /// </summary>
        /// <returns></returns>
        public int GetCurrentSiteID()
        {
            int? result = null;
            if (System.Web.HttpContext.Current == null)
                return 0;

            if (System.Web.HttpContext.Current.Request == null) // no current web request, try to get from session
            {
                result = GetLastStoredSiteIDFromSession();
            }

            if (result.HasValue == false)
            {
                // get it from host name and store to session for later access
                string hostName = GetDomainName();
                result = GetSiteIDFromSession(hostName);

                if (result.HasValue == false)
                    result = GetSiteIDFromDatabase(hostName);

                if (result.HasValue)
                    SaveSiteIDToSession(hostName, result.Value);
            }

            if (result.HasValue)
                return result.Value;
            else
                return 0;
        }

        /// <summary>
        /// Gets site id from the database by domain name
        /// </summary>
        /// <param name="hostName">domain name</param>
        /// <returns>site identifier and if not found null</returns>
        public static int? GetSiteIDFromDatabase(string hostName)
        {
            int? result = null;
            string siteCode = GetSiteCode(hostName);

            // if we had a subdomain
            if (string.IsNullOrEmpty(siteCode) == false)
            {
                var siteService = (IFWSiteService)EntityFactory.GetEntityServiceByName("Site", "");
                result = siteService.GetSiteIDBySiteCode(siteCode);
            }
            else
            {
                var siteDomainService = (IFWSiteDomainService)EntityFactory.GetEntityServiceByName("SiteDomain", "");
                result = siteDomainService.GetSiteIDByHostName(hostName);
            }
            return result;
        }


        /// <summary>
        /// Gets site code from domain name
        /// if it was like subdomain.xecare.com, it returns xecare.com
        /// if it was like mydomain.com, then it returns empty string
        /// </summary>
        /// <param name="hostName">domain name</param>
        /// <returns></returns>
        private static string GetSiteCode(string hostName)
        {
            hostName = hostName.ToLower();

            string siteCode = "";
            string mainDomain = FWUtils.ConfigUtils.GetAppSettings().Project.MainDomainName;
            if (hostName.EndsWith(mainDomain) && hostName != mainDomain) // is subdomain of the main domain
            {
                siteCode = hostName.Substring(0, hostName.Length - mainDomain.Length -1);
            }
            return siteCode;
        }

        /// <summary>
        /// Saves retrieved site id to session (for caching purpose)
        /// </summary>
        /// <param name="hostName">domain name</param>
        /// <returns>site identifier and if not found null</returns>
        private static void SaveSiteIDToSession(string hostName, int siteId)
        {
            if (System.Web.HttpContext.Current == null)
                return;

            if (System.Web.HttpContext.Current.Session == null)
                return;

            System.Web.HttpContext.Current.Session["SiteHostName"] = hostName;
            System.Web.HttpContext.Current.Session["SiteID"] = siteId;
        }

        /// <summary>
        /// Gets site identifier if it was stored in the session
        /// it checks that the provided siteId matches the one that stored in the session
        /// if it was not a match then it returns null
        /// </summary>
        /// <param name="hostName">domain name</param>
        /// <returns></returns>
        private static int? GetSiteIDFromSession(string hostName)
        {
            if (string.IsNullOrEmpty(hostName))
                return null;

            if (System.Web.HttpContext.Current == null)
                return null;

            if (System.Web.HttpContext.Current.Session == null)
                return null;

            if (System.Web.HttpContext.Current.Session["SiteHostName"] != hostName)
                return null;

            if (System.Web.HttpContext.Current.Session["SiteID"] != null)
                return Convert.ToInt32(System.Web.HttpContext.Current.Session["SiteID"]);

            return null;
        }

        /// <summary>
        /// Gets last stored site id from the session without checking the domain name
        /// It is only to be used when there is no current request
        /// </summary>
        /// <returns></returns>
        private static int? GetLastStoredSiteIDFromSession()
        {
            if (System.Web.HttpContext.Current == null)
                return null;

            if (System.Web.HttpContext.Current.Session == null)
                return null;

            if (System.Web.HttpContext.Current.Session["SiteID"] != null)
                return Convert.ToInt32(System.Web.HttpContext.Current.Session["SiteID"]);

            return null;
        }

        #endregion



    }
}
