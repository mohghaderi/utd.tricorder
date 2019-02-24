using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTD.Tricorder.Website.Models
{
    public class FWFormModel
    {
        private string _onBeforeSubmit = "undefined";
        /// <summary>
        /// It calls before submission of the form
        /// </summary>
        public string onBeforeSubmit 
        {
            get { return _onBeforeSubmit; }
            set { _onBeforeSubmit = value; }
        }

        /// <summary>
        /// Title of the form
        /// </summary>
        public string FormTitle
        {
            get; set;
        }

        private string _onAfterSubmit = "undefined";

        /// <summary>
        /// after form submitted
        /// </summary>
        public string onAfterSubmit
        {
            get { return _onAfterSubmit; }
            set { _onAfterSubmit = value; }
        }



    }
}