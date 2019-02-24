using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Website.Base;
using UTD.Tricorder.Website.Helpers;

namespace UTD.Tricorder.Website.Controllers
{
    public class DefaultController : ViewControllerBase
    {

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "Tricorder";
            return ShowRelatedView();
        }


        [AllowAnonymous]
        public ActionResult Home()
        {
            ViewBag.Title = "Home Page";

            return ShowRelatedView();
        }

        [RequiresSSL]
        [AllowAnonymous]
        public ActionResult Login()
        {
            //FormsAuthentication.SignOut();

            ViewBag.Title = "Login";
            return ShowRelatedView();
        }

        [Authorize]
        public ActionResult RefreshToken()
        {
            return ShowRelatedView();
        }

        [RequiresSSL]
        [AllowAnonymous]
        public ActionResult Signup()
        {
            ViewBag.Title = "Signup";

            return ShowRelatedView();
        }


        [AllowAnonymous]
        public ActionResult View1()
        {
            ViewBag.Title = "View1";

            return ShowRelatedView();
        }

        [NoCacheAttribute]
        [AllowAnonymous]
        public ActionResult DoFormAuth()
        {
            string userId = FWUtils.SecurityUtils.GetCurrentUserIDString();
            if (string.IsNullOrEmpty(userId) == false)
            {
                FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.User_Login, UserID = Convert.ToInt64(userId) });

                FormsAuthentication.SetAuthCookie(userId, true);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
        }

        [NoCacheAttribute]
        [AllowAnonymous]
        public ActionResult Signout()
        {
            FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.User_Logout });

            FormsAuthentication.SignOut();
            return UIUtils.GetRedirectResult("Default/Login");
        }

        [AllowAnonymous]
        /// <summary>
        /// Email verification page
        /// </summary>
        /// <returns></returns>
        public ActionResult VerifyEmail()
        {
            return ShowRelatedView();
        }

        [AllowAnonymous]
        /// <summary>
        /// Phone Number verification page
        /// </summary>
        /// <returns></returns>
        public ActionResult VerifyPhoneNumber()
        {
            return ShowRelatedView();
        }

        [AllowAnonymous]
        /// <summary>
        /// continuing quick registeration
        /// </summary>
        /// <returns></returns>
        public ActionResult ContinueQReg()
        {
            return ShowRelatedView();
        }

        [AllowAnonymous]
        /// <summary>
        /// Terms and conditions page
        /// </summary>
        /// <returns></returns>
        public ActionResult Terms()
        {
            return ShowRelatedView();
        }

        [AllowAnonymous]
        /// <summary>
        /// Terms and conditions page
        /// </summary>
        /// <returns></returns>
        public ActionResult PrivacyPolicy()
        {
            return ShowRelatedView();
        }

        [AllowAnonymous]
        /// <summary>
        /// I Can't login page
        /// </summary>
        /// <returns></returns>
        public ActionResult ICantLogin()
        {
            return ShowRelatedView();
        }

        [AllowAnonymous]
        public ActionResult PhoneRing()
        {
            return ShowRelatedView(); 
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return ShowRelatedView();
        }

        [AllowAnonymous]
        public ActionResult MobileApp()
        {
            if (FWUtils.SecurityUtils.IsUserAuthenticated())
                return UIUtils.GetRedirectResult("Dashboard");
            else
                return UIUtils.GetRedirectResult("Default/Login");
        }


        private ActionResult ShowRelatedView()
        {
            string viewPath = Convert.ToString(HttpContext.Request.RequestContext.RouteData.Values["Action"]);
            

            if (Request.IsAjaxRequest())
                return PartialView();
            else
                return View();
        }

    }
}
