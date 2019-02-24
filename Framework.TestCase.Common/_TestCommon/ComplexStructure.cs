using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.TestCase.CommonClasses
{
    public class ComplexStructure
    {
        public string Field1 { get; set; }
        public Guid Field2 { get; set; }
        public DateTime Field3 { get; set; }

        public string MethodTest()
        {
            string s = "Success!";
            return s;
        }

        public string EchoMethodTest(string s)
        {
            return s;
        }
    }
}
