using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace UTD.Tricorder.Website.Helpers
{
    public static class SiteUI
    {
        public const string constSitesPath = "~/Sites/";

        /// <summary>
        /// Returns ~ path of the file based on the site
        /// This is for server usage like Layouts,...
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetViewPath(string filePath)
        {
            string tenantName = GetTenant();
            string path = GetTenantViewFilePath(tenantName, filePath);
            return path;
        }

        /// <summary>
        /// return url of the file based on the site and user culture
        /// This is for client usage like images css,...
        /// </summary>
        /// <param name="filePath">path of the file can stat with !</param>
        /// <returns></returns>
        public static string FileUrl(string filePath)
        {
            // TODO: we can add amazon and other file servers later when supported
            return VirtualPathUtility.ToAbsolute(filePath);
        }

        private static string GetTenantViewFilePath(string tenantName, string filePath)
        {
            if (string.IsNullOrEmpty(tenantName))
                return filePath; 
            
            Check.Require(filePath.StartsWith("~/"));

            // TODO: Check security that request from one site can't load other sites
            if (filePath.StartsWith(constSitesPath)) // we don't override sites
                return filePath;

            string tenantPath = GetTenantRoot(tenantName) + filePath.Substring(2);
            //if (tenantPath.EndsWith(".cshtml") == false)
            //    tenantPath = tenantPath + ".cshtml";

            //if physical file was overritten then return it from tenant otherwise return from old path
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(tenantPath)))
                return tenantPath;
            else
                return filePath;
        }

        public static string GetTenantRoot(string tenantName)
        {
            if (string.IsNullOrEmpty(tenantName) == false)
                return constSitesPath + tenantName + "/";
            return "~/";
        }



        private static Dictionary<string, string> _TenantDomains;

        private static Dictionary<string, string> GetTenantDomains()
        {
            // http://stackoverflow.com/questions/4709014/using-custom-domains-with-iis-express
            //

            // to do it locally use C:\Windows\System32\drivers\etc\hosts file and add following lines:
            //127.0.0.1	xecarelocal.com
            //127.0.0.1	cometcare.xecarelocal.com
            //127.0.0.1	hamad.xecarelocal.com
            //127.0.0.1	petcare.xecarelocal.com

            // then open iis configuration: C:\Users\moh\Documents\IISExpress\config\applicationhost.config
            // find the website there and edit configurations like this:

            // <bindings>
			//		<binding protocol="http" bindingInformation="*:9343:localhost" />
			//		<binding protocol="http" bindingInformation="*:9343:*" />					
            //        <binding protocol="https" bindingInformation="*:44300:localhost" />
			//		<binding protocol="https" bindingInformation="*:44300:*" />
            //    </bindings>
            
            // open command prompt in administrator mode, and give permission to other domain names
            // netsh http add urlacl url=http://*:9343/ user=Everyone
            // netsh http add urlacl url=http://localhost:9343/ user=Everyone
            // This gives permissions for both localhost and *. 

            // no access the website by url: http://cometcare.xecarelocal.com:9343/
            // you should see cometcare home page instead of xecare home page :)
            // done!

            if (_TenantDomains == null)
            {
                _TenantDomains = new Dictionary<string, string>();
                _TenantDomains.Add("cometcare.xecarelocallocal.com", "cometcare");
                _TenantDomains.Add("cometcare.xecarelocal.com", "cometcare");

                _TenantDomains.Add("hamad.xecarelocallocal.com", "hamad");
                _TenantDomains.Add("hamad.xecarelocal.com", "hamad");

                _TenantDomains.Add("utsw.xecarelocallocal.com", "utsw");
                _TenantDomains.Add("utsw.xecarelocal.com", "utsw");
            }
            return _TenantDomains;
        }

        public static string GetTenant()
        {
            try
            {
                Dictionary<string, string> domains = GetTenantDomains();


                string hostName = HttpContext.Current.Request.Url.Host.ToLower();
                if (domains.ContainsKey(hostName))
                    return domains[hostName];

                return null; // if we didn't find the right domain, then the main domain
            }
            catch (Exception)
            {
                return null;
            }
        }


    }



}