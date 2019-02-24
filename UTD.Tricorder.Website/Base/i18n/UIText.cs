using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTD.Tricorder.Website
{
    public partial class UIText
    {
        /// <summary>
        /// angularjs locale variable to keep all locale in one memory place
        /// </summary>
        public static List<string> AngularJsLocales;

        /// <summary>
        /// bootstrapValidator locale variable to keep all locale in one memory place
        /// </summary>
        public static List<string> BootStrapValidatorLocales;


        /// <summary>
        /// indicated if we are in rtl language or not
        /// </summary>
        /// <returns></returns>
        public static bool IsRTL()
        {
            return FWUtils.SecurityUtils.GetCultureInfo().TextInfo.IsRightToLeft;
        }

        /// <summary>
        /// gets culture name of the current request in lower case
        /// </summary>
        /// <returns></returns>
        public static string CultureName()
        {
            return FWUtils.SecurityUtils.GetCultureInfo().Name.ToLower();
        }



        public class Base
        {
            public class EntityService
            {
                public class SuccessMsgs
                {
                    public class General
                    {
                        private const string ns = "Web.Base.EntityService.SuccessMsgs.General" + ".";
                        public static i18nText Insert = i18nText.Create(ns + "Insert", "Item added successfully!");
                        public static i18nText Update = i18nText.Create(ns + "Update", "Information updated successfully!");
                        public static i18nText Delete = i18nText.Create(ns + "Delete", "Item deleted successfully!");
                    }

                    public class User
                    {
                        private const string ns = "Web.Base.EntityService.SuccessMsgs.User" + ".";
                        public static i18nText SendEmailVerificationLetter = i18nText.Create(ns + "SendEmailVerificationLetter", "We sent an email to your account. It may take a few seconds to get it. Please open your email, and follow the instructions.");
                        public static i18nText SendPhoneNumberVerification = i18nText.Create(ns + "SendPhoneNumberVerification", "We sent a text message to your phone number. It may take a few seconds to get it. Please open it and follow the instructions.");
                        public static i18nText VerifyEmail = i18nText.Create(ns + "VerifyEmail", "Your email verified successfully.");
                        public static i18nText VerifyPhoneNumber = i18nText.Create(ns + "VerifyPhoneNumber", "Your phone number verified successfully.");
                        
                    }
                }
                
            }
        }

        public class Default
        {
            public class GeneralButtons
            {
                private const string ns = "Web.View.Default.GeneralButtons" + ".";
                public static i18nText LoginButtonText = i18nText.Create(ns + "LoginButtonText", "Login");
                public static i18nText SignupButtonText = i18nText.Create(ns + "SignupButtonText", "Signup");
                public static i18nText CantLoginText = i18nText.Create(ns + "CantLoginText", "Can't login");
                public static i18nText ContinueIncompleteReg = i18nText.Create(ns + "ContinueIncompleteReg", "Continue incomplete reg");
            }

            public class Login
            {
                private const string ns = "Web.View.Default.Login" + ".";
                public static i18nText UserNameLabel = i18nText.Create(ns + "UserNameLabel", "Username");
                public static i18nText PasswordLabel = i18nText.Create(ns + "PasswordLabel", "Password");
            }


        }

        public class Error
        {
            public class Buttons
            {
                private const string ns = "Web.View.Error.Buttons" + ".";
                public static i18nText BackButtonTitle = i18nText.Create(ns + "BackButtonTitle", "Back");
                public static i18nText MainPageButtonTitle = i18nText.Create(ns + "MainPageButtonTitle", "Main Page");
            }

            public class ServerError500
            {
                private const string ns = "Web.View.Error.ServerError500" + ".";
                public static i18nText PageTitle = i18nText.Create(ns + "PageTitle", "Unknown Error");
                public static i18nText PanelTitle = i18nText.Create(ns + "PanelTitle", "Unknown Error");
                public static i18nText ErrorText = i18nText.Create(ns + "ErrorText", "We regret to say that an unknown exception happened in the website. We saved all necessary information, and we will try to fix it as soon as possible. Sorry for any inconvenience.");
            }

            public class NotFound404
            {
                private const string ns = "Web.View.Error.NotFound404" + ".";
                public static i18nText PageTitle = i18nText.Create(ns + "PageTitle", "Page not found");
                public static i18nText PanelTitle = i18nText.Create(ns + "PanelTitle", "Page not found");
                public static i18nText ErrorText = i18nText.Create(ns + "ErrorText", "We regret to say that the requested page is not available on our website. Sorry for any inconvenience.");
            }

            public class AccessDenied403
            {
                private const string ns = "Web.View.Error.AccessDenied403" + ".";
                public static i18nText PageTitle = i18nText.Create(ns + "PageTitle", "Access Denied");
                public static i18nText PanelTitle = i18nText.Create(ns + "PanelTitle", "Access Denied");
                public static i18nText ErrorText = i18nText.Create(ns + "ErrorText", "You don't have enough permission to view this resource.");
            }

            public class GenericHttpError
            {
                private const string ns = "Web.View.Error.GenericHttpError" + ".";
                public static i18nText PageTitle = i18nText.Create(ns + "PageTitle", "Http Error");
                public static i18nText PanelTitle = i18nText.Create(ns + "PanelTitle", "Http Error");
                public static i18nText ErrorText = i18nText.Create(ns + "ErrorText", "We regret to say that an unknown exception happened in the website. We saved all necessary information, and we will try to fix it as soon as possible. Sorry for any inconvenience.");
            }


        }




        public class js
        {
            public class msgs
            {
                public class common
                {
                    private const string ns = "Web.js.msgs.common" + ".";
                    public static i18nText pleasewait = i18nText.Create(ns + "pleasewait", "Please Wait...");
                }

                public class validation
                {
                    private const string ns = "Web.js.msgs.validation" + ".";
                    public static i18nText errortitle = i18nText.Create(ns + "errortitle", "Error");
                    public static i18nText completeformbeforeproceeding = i18nText.Create(ns + "completeformbeforeproceeding", "Please complete the form before proceeding.");
                }

                public class login
                {
                    private const string ns = "Web.js.msgs.login" + ".";
                    public static i18nText welcome = i18nText.Create(ns + "welcome", "Welcome! Please wait...");
                }

                public class user
                {
                    public class signup
                    {
                        private const string ns = "Web.js.msgs.user.signup" + ".";
                        public static i18nText successmessage = i18nText.Create(ns + "successmessage", "Registration successful! Please wait while we redirect you to your panel");
                    }

                    public class searchfromvisitbook
                    {
                        private const string ns = "Web.js.msgs.user.searchfromvisitbook" + ".";
                        public static i18nText selectedItemsListIsEmpty = i18nText.Create(ns + "selectedItemsListIsEmpty", "No one found with the provided information. Please refine your search options first.");
 
                    }
 
                }
            }
        }




    }
}