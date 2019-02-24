using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UTD.Tricorder.Website.Base
{
    /// <summary>
    /// results for each service action. It sends data to the client
    /// </summary>
    public class ServiceActionResult : ActionResult
    {
        private static i18nText _DefaultSuccessMessage = i18nText.Create("Web.Base.ServiceActionResult.DefaultSuccessMessage", "Information saved successfully!");

        /// <summary>
        /// Error message to show to the user
        /// </summary>
        public string errorMessage { get; set; }
        /// <summary>
        /// data that can be send back to the client for further process like get data
        /// or the entity after update
        /// </summary>
        public object data { get; set; }

        // read : http://www.codeproject.com/Articles/533932/Custom-ASP-NET-MVC-ActionResults

        /// <summary>
        /// Message for suceessful action (like the information saved sucessfully)
        /// </summary>
        public string message { get; set; }


        /// <summary>
        /// constructor for success result with returned data
        /// </summary>
        /// <param name="data">data</param>
        public ServiceActionResult(object data)
        {
            this.data = data;
            this.errorMessage = null;
        }

        /// <summary>
        /// constructor for simple error result
        /// </summary>
        /// <param name="errorMsg">error message</param>
        public ServiceActionResult(object data, string errorMsg)
        {
            this.data = data;
            this.errorMessage = errorMsg;
        }

        /// <summary>
        /// constructor to simple success result
        /// </summary>
        public ServiceActionResult()
        {
            this.message = _DefaultSuccessMessage;
            this.errorMessage = null;
        }


        /// <summary>
        /// executes the action to the client
        /// Now, it just uses a simple json execution
        /// </summary>
        /// <param name="context">the context</param>
        public override void ExecuteResult(ControllerContext context)
        {
            JsonResult jResult = new JsonResult();
            jResult.Data = this;
            jResult.ExecuteResult(context);
        }

        public static ServiceActionResult CreateSuccess(string sucessString)
        {
            ServiceActionResult a = new ServiceActionResult();
            if (string.IsNullOrEmpty(sucessString) == false)
                a.message = sucessString;
            return a;
        }



    }
}