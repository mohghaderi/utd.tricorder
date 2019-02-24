using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Service
{
    public class SecurityFunctionSEnum
    {
        public static SecurityFunctionSEnum View = new SecurityFunctionSEnum("View");
        public static SecurityFunctionSEnum DDView = new SecurityFunctionSEnum("DDView");
        public static SecurityFunctionSEnum Update = new SecurityFunctionSEnum("Update");
        public static SecurityFunctionSEnum Insert = new SecurityFunctionSEnum("Insert");
        public static SecurityFunctionSEnum Delete = new SecurityFunctionSEnum("Delete");

        private string fnName;

        public SecurityFunctionSEnum(string customFunction)
        {
            fnName = customFunction;
        }


        public string getFnName()
        {
            return fnName;
        }


        public static bool operator ==(SecurityFunctionSEnum e, string s)
        {
            return e.fnName == s;
        }

        public static bool operator !=(SecurityFunctionSEnum e, string s)
        {
            return e.fnName != s;
        }

        public static bool operator ==(SecurityFunctionSEnum e, SecurityFunctionSEnum s)
        {
            return e.fnName == s.fnName;
        }

        public static bool operator !=(SecurityFunctionSEnum e, SecurityFunctionSEnum s)
        {
            return e.fnName != s.fnName;
        }

    }
}
