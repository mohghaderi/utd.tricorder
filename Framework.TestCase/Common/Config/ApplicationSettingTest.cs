using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common;

namespace Framework.TestCase.Common.Config
{
    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for ExceptionHandlerTest and is intended
    ///to contain all ExceptionHandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ApplicationSettingTest
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


        /// <summary>
        ///A test for ExceptionHandler Constructor
        ///</summary>
        [TestMethod()]
        public void ApplicationSettingsTest()
        {
            // getting settings without an exception
            var settings = FWUtils.ConfigUtils.GetAppSettings();
        }


        /// <summary>
        ///A test for ExceptionHandler Constructor
        ///</summary>
        [TestMethod()]
        public void PaypalConfigTest()
        {
            var settings = FWUtils.ConfigUtils.GetAppSettings();
            string mainAccount = "PAYPAL_MAIN_ACCOUNT_XXXX";
            string endpoint = "api.sandbox.paypal.com";
            string clientId = "XXXXXXXXXXXXXX";
            string secret = "XXXXXXXXXXXXXX";

            string userName = "XXXXXXXXXXXXXX";
            string password="XXXXXXXXXXXXXX";
            string signature="XXXXXXXXXXXXXX";
            string applicationID="XXXXXXXXXXXXXX";
            
            int connectionTimeout= 12000;
            int requestRetries= 2;

            bool isSandBox = true;

            Assert.AreEqual(mainAccount, settings.Paypal.MainAccount);
            Assert.AreEqual(endpoint, settings.Paypal.Endpoint);
            Assert.AreEqual(clientId, settings.Paypal.ClientID);
            Assert.AreEqual(secret, settings.Paypal.Secret);

            Assert.AreEqual(userName, settings.Paypal.UserName);
            Assert.AreEqual(password, settings.Paypal.password);
            Assert.AreEqual(signature, settings.Paypal.Signature);
            Assert.AreEqual(applicationID, settings.Paypal.ApplicationID);
            Assert.AreEqual(connectionTimeout, settings.Paypal.ConnectionTimeout);
            Assert.AreEqual(requestRetries, settings.Paypal.RequestRetries);

            Assert.AreEqual(isSandBox, settings.Paypal.IsSandBox);
        }

                /// <summary>
        ///A test for ExceptionHandler Constructor
        ///</summary>
        [TestMethod()]
        public void PaypalConfig_GetAcctAndConfigTest()
        {
            var settings = FWUtils.ConfigUtils.GetAppSettings();
            Dictionary<string, string> settingsDic = settings.Paypal.GetAcctAndConfig();

            int expectedCount = 8;

            Assert.AreEqual(expectedCount, settingsDic.Count);

        }

        [TestMethod]
        public void AmazonCloudConfig()
        {
            var settings = FWUtils.ConfigUtils.GetAppSettings().AmazonCloud;
            
            Assert.AreEqual(settings.S3.MainAccount, "mohghaderi");
            Assert.AreEqual(settings.S3.AccessKeyID, "");
            Assert.AreEqual(settings.S3.SecretAccessKey, "");

        }



    }
}
