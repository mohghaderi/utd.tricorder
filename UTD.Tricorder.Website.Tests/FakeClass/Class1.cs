using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Service;

namespace UTD.Tricorder.Website.Tests.FakeClass
{
    [TestClass]
    public class Class1
    {
        [TestMethod()]
        public void TestMethod()
        {
            // Visual studio build removes all unused assemblies by default
            // it is a bug that was active and no solution
            // This line makes a reference to the service layer
            // causes visual studio to complile Service dll with test files
            UserService service = new UserService();
        }

    }
}
