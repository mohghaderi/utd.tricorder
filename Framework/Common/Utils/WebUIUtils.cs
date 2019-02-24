using Framework.Business;
using Framework.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Framework.Common.Utils
{
    // Developer Note: This class usage is STATIC, No state property

    /// <summary>
    /// Utilities related to Web User Interfaces
    /// </summary>
    public class WebUIUtils
    {
        public delegate void ControlFoundDelegate(Control control);

        /// <summary>
        /// Resolves the client URL.
        /// It changes a relative web url to an absolute one. For example:
        /// ~/FW/Js/common.js  ->  http://localhost:2935/ProjectName/FW/Js/common.js
        /// </summary>
        /// <param name="webPath">The web path.</param>
        /// <returns></returns>
        public string ResolveClientUrl(string webPath)
        {
            try
            {
                return VirtualPathUtility.ToAbsolute(webPath);
            }
            catch (System.Web.HttpException)
            {
                // In the case of execution of test cases, we may get exception
                // The application relative virtual path '~/FW/ExtEdit.aspx?Entity=TestCaseTester&AdditionalDataKey=&MasterRecordID={MasterRecordID}&ParentIDInTree={ParentIDInTree}' 
                // cannot be made absolute, because the path to the application is not known.
                return webPath.Replace("~/", "http://localhost/");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Enumerates the controls recursive.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="retControlsList">The returned controls list.</param>
        public void EnumerateControlsRecursive(Control parent, List<Control> controlsList)
        {
            Check.Require(parent != null);
            Check.Require(controlsList != null);

            foreach (Control child in parent.Controls)
            {
                controlsList.Add(child);
                if (child.Controls.Count > 0)
                    EnumerateControlsRecursive(child, controlsList);
            }
        }


        /// <summary>
        /// Enumerates the controls recursive.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="retControlsList">The returned controls list.</param>
        public void EnumerateControlsRecursiveByDelegate(Control parent, ControlFoundDelegate foundFunction)
        {
            Check.Require(parent != null);
            Check.Require(foundFunction != null);

            foreach (Control child in parent.Controls)
            {
                foundFunction(child);
                if (child.Controls.Count > 0)
                    EnumerateControlsRecursiveByDelegate(child, foundFunction);
            }
        }



        /// <summary>
        /// Gets the ext exception message string.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="handleExp">if set to <c>true</c> [handle exp].</param>
        /// <returns></returns>
        public string GetExtExceptionMessageString(Exception ex, bool handleExp)
        {
            StringBuilder msg = new StringBuilder();
            if (ex is BRException)
            {
                BusinessRuleErrorList errors = ((BRException)ex).RuleErrors;
                foreach (BusinessRuleError err in errors)
                {
                    //msg.Append(err.ColumnTitle).Append(":").Append(err.ErrorDescription).Append("\r\n");
                    msg.Append(err.ErrorDescription).Append("\r\n");
                }

                if (errors.Count == 0)
                    msg.Append(ex.Message);
            }
            else if (ex is UserException)
            {
                msg.Append(ex.Message.ToString());
            }
            else
            {
                if (handleExp)
                {
                    FWUtils.ExpLogUtils.ExceptionHandler.HandleException(ref ex, PolicyName.GlobalPolicy);
                }
                msg = msg.Append(ex.Message);

            }

            return msg.ToString();
        }


        /// <summary>
        /// Determines whether [is local host].
        /// Use Config project IsDebug to do debug tasks
        /// </summary>
        /// <returns></returns>
        public bool IsLocalHost()
        {
            try
            {
                if (System.Web.HttpContext.Current != null)
                {
                    if (System.Web.HttpContext.Current.Request != null)
                    {
                        if (System.Web.HttpContext.Current.Request.Url.AbsoluteUri.Contains("localhost"))
                            return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsAjaxRequest()
        {
            try
            {
                return System.Web.HttpContext.Current.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            }
            catch (Exception)
            {
                return false;
            }
        }


        public string GetRequestIPAddress()
        {
            try
            {
                if (System.Web.HttpContext.Current != null)
                {
                    if (System.Web.HttpContext.Current.Request != null)
                    {
                        return System.Web.HttpContext.Current.Request.UserHostAddress;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetRequestUrl()
        {
            try
            {
                if (System.Web.HttpContext.Current != null)
                {
                    if (System.Web.HttpContext.Current.Request != null)
                    {
                        return System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
                    }
                }
            }
            catch(Exception)
            {
                return null;
            }


            return null;
        }





    }
}
