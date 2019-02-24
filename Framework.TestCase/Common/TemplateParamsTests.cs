using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Framework.TestCase.Common
{
    [TestClass()]
    public class TemplateParamsTests
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void TestParamsParametersConstructorTest()
        {
            string p1 = "P1";
            string p1Value = "p1Value";
            string p2 = "P2";
            string p2Value = "p2Value";

            TemplateParams target = new TemplateParams(p1, p1Value, p2, p2Value);

            Assert.AreEqual(2, target.ParametersValues.Count);
            Assert.AreEqual(p1Value, target.ParametersValues["P1"]);
            Assert.AreEqual(p2Value, target.ParametersValues["P2"]);
        }

        [TestMethod()]
        public void TestParamsSerializedConstructorTest()
        {
            TemplateParams testParams = getTestParams();
            string serializedString = testParams.SerializeToString();

            TemplateParams target = TemplateParams.FromSerializedString(serializedString);

            Assert.AreEqual(testParams.ParametersValues.Count, target.ParametersValues.Count);
            foreach (var item in testParams.ParametersValues)
            {
                Assert.AreEqual(item.Value, testParams.ParametersValues[item.Key]);
            }
        }


        [TestMethod()]
        public void AddParameterTest()
        {
            TemplateParams p = new TemplateParams();
            string paramName = "p1";
            string paramValue = "P1Value";

            p.AddParameter(paramName, paramValue);
            Assert.AreEqual(1, p.ParametersValues.Count);
            Assert.AreEqual(p.ParametersValues[paramName], paramValue);
        }




        [TestMethod()]
        public void SerializeToStringTest()
        {
            TemplateParams target = getTestParams();

            string actual = target.SerializeToString();
            //string expected = "{\"p1\":\"P1Value\",\"Parameter2\":\"{Test ParameterValue}\",\"P3\":\"This is a value\",\"Today\":\"2014/06/24\"}";
            // order of parameters may change in serialization. we can't check the string. So as far as it's a long string that should be enough
            // more testing will be done in DeserializeFromStringTest
            Assert.IsTrue(actual.Length > 50);
        }

        [TestMethod()]
        public void DeserializeFromStringTest()
        {
            TemplateParams testParams = getTestParams();
            string serializedString = testParams.SerializeToString();

            TemplateParams target = new TemplateParams();
            target.DeserializeFromString(serializedString);

            Assert.AreEqual(testParams.ParametersValues.Count, target.ParametersValues.Count);
            foreach (var item in testParams.ParametersValues) {
                Assert.AreEqual(item.Value, testParams.ParametersValues[item.Key]);
            }
        }

        [TestMethod()]
        public void DeserializeFromStringNullTest()
        {
            string serializedString = null;
            TemplateParams target = new TemplateParams();
            target.AddParameter("OldParameter", "OldValue");
            target.DeserializeFromString(serializedString);

            Assert.AreEqual(0, target.ParametersValues.Count);
        }


        [TestMethod()]
        public void ProcessTemplateTest()
        {
            TemplateParams target = getTestParams();
            string templateText = "This is a template {p1}. There are some parameters here {Parameter2}, but we shouldn't replace {P3} with P3. We will do date formatting later. Today is {Today}. {Not availbale parameter} shoudn't cause exception. {PNull} replacement with no exception";
            string actual = target.ProcessTemplate(templateText);
            string expected = "This is a template P1Value. There are some parameters here {P2}, but we shouldn't replace P 3 value with P3. We will do date formatting later. Today is 2014/06/24. {Not availbale parameter} shoudn't cause exception.  replacement with no exception";

            Assert.AreEqual(expected, actual);
        }

        public void ProcessTemplateTest2()
        {
            // null template should return a null value
            TemplateParams target = getTestParams();
            string templateText = null;
            string actual = target.ProcessTemplate(templateText);
            string expected = null;

            Assert.AreEqual(expected, actual);
        }


        private TemplateParams getTestParams()
        {
            TemplateParams p = new TemplateParams();
            string paramName = "p1";
            string paramValue = "P1Value";

            p.AddParameter(paramName, paramValue);
            p.AddParameter("Today", "2014/06/24");
            p.AddParameter("Parameter2", "{P2}");
            p.AddParameter("P3", "P 3 value");
            p.AddParameter("PNull", null); // null value parameter
            // TODO: later add {P2} and make sure that P2 doesn't replace again. It doesn't matter at this time.
            // add more parameters for testing. Date Formatting should be added later.
            return p;
        }


    }
}
