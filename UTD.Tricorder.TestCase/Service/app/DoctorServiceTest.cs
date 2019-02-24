using Framework.Common;
using Framework.TestCase.CommonClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.TestCase.Service.app
{
    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for Doctor
    ///</summary>
    [TestClass()]
    public class DoctorServiceTest
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

        private IDoctorService CreateService()
        {
            return DoctorEN.GetService("");
        }

        [TestMethod]
        public void SearchByClinicPhoneNumber()
        {
            DoctorSearchByClinicPhoneNumberSP p = new DoctorSearchByClinicPhoneNumberSP();
            p.PhoneNumber = "888-222-3445";

            var target = DoctorEN.GetService("");
            IList<vDoctor> list = target.SearchByClinicPhoneNumber(p);

            Assert.AreEqual(1, list.Count, "SearchByClinicPhoneNumber should find only one doctor");
            Assert.AreEqual(list[0].DoctorID, TestEnums.User.constDoctorID, "SearchByClinicPhoneNumber should find TestEnums.User.constDoctorID doctor");
        }


        [TestMethod]
        public void SearchByClinicPhoneNumber2()
        {
            DoctorSearchByClinicPhoneNumberSP p = new DoctorSearchByClinicPhoneNumberSP();
            p.PhoneNumber = "888222";

            var target = DoctorEN.GetService("");
            IList<vDoctor> list = target.SearchByClinicPhoneNumber(p);

            Assert.IsTrue(list.Count >= 1, "888222 should find several items in phone number");
        }


        [TestMethod]
        public void SearchByClinicPhoneNumber3()
        {
            DoctorSearchByClinicPhoneNumberSP p = new DoctorSearchByClinicPhoneNumberSP();
            // invalid number shouldn't have any results
            p.PhoneNumber = "AnInvalidNumber";

            var target = DoctorEN.GetService("");
            IList<vDoctor> list = target.SearchByClinicPhoneNumber(p);

            Assert.IsTrue(list.Count == 0, "anInvalidNumber should not have any results");
        }



    }
}
