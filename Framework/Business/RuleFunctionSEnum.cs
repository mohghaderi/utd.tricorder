using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    /// <summary>
    /// Class to wrap rule functions. This helps to make less string checking errors
    /// </summary>
    public class RuleFunctionSEnum
    {
        public static RuleFunctionSEnum Update = new RuleFunctionSEnum("Update");
        public static RuleFunctionSEnum Insert = new RuleFunctionSEnum("Insert");
        public static RuleFunctionSEnum Delete = new RuleFunctionSEnum("Delete");

        private string fnName;

        public RuleFunctionSEnum(string customFunction)
        {
            fnName = customFunction;
        }


        public string getFnName()
        {
            return fnName;
        }


        public static bool operator ==(RuleFunctionSEnum e, string s)
        {
            return e.fnName == s;
        }

        public static bool operator !=(RuleFunctionSEnum e, string s)
        {
            return e.fnName != s;
        }

        public static bool operator ==(RuleFunctionSEnum e, RuleFunctionSEnum s)
        {
            return e.fnName == s.fnName;
        }

        public static bool operator !=(RuleFunctionSEnum e, RuleFunctionSEnum s)
        {
            return e.fnName != s.fnName;
        }

    }




}
