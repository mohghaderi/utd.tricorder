using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    public class DetailObjectInfo
    {
        public string EntityName { get; set; }

        private string _AdditionalDataKey = "";
        public string AdditionalDataKey 
        { 
            get { return _AdditionalDataKey; } 
            set { _AdditionalDataKey = value; } 
        }
        public RuleFunctionSEnum FnName { get; set; }
        public EntityObjectBase EntitySet { get; set; }
        public string FKColumnNameForAutoSet { get; set; }
    }
}
