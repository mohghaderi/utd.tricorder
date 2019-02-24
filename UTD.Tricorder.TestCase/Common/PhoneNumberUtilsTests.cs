using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common;

namespace UTD.Tricorder.TestCase.Common
{
    /// <summary>
    ///This is a test class for AdobeAirCapabilitiesTests and is intended
    ///to contain all AdobeAirCapabilities Unit Tests
    ///</summary>
    [TestClass()]
    public class PhoneNumberUtilsTests
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod]
        public void MakeSearchablePhoneNumber()
        {
            string[] phoneNumbers = {null, "", "1-238-0453.5554", "1111", "778-JAAJ-777"};
            string[] expecteds = { null, null, "123804535554", "1111", "778jaaj777" };

            for (int i = 0; i < phoneNumbers.Length; i++ )
            {
                string phoneNumber = phoneNumbers[i];
                string expected = expecteds[i];
                string actual = PhoneNumberUtils.MakeSearchablePhoneNumber(phoneNumber);
                Assert.AreEqual(expected, actual, string.Format("Phone number {0} is not formatted correct. Actual: {1}", phoneNumber, actual));
            }

        }



    }
}
