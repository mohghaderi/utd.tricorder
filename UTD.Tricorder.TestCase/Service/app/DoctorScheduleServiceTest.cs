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
    ///This is a test class for DoctorSchedule
    ///</summary>
    [TestClass()]
    public class DoctorScheduleServiceTest
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

        private IDoctorScheduleService CreateService()
        {
            return DoctorScheduleEN.GetService("");
        }



        [TestMethod()]
        public void InsertTest()
        {
            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);

            var doctorSchedule = DoctorScheduleServiceTest.CreateNewDoctorSchedule();
            var target = DoctorScheduleEN.GetService("");
            target.Insert(doctorSchedule, new InsertParameters());
            // Happy scenario without exception
        }

        [TestMethod]
        public void GetByRangeTest()
        {
            DateTime startDate = new DateTime(2020, 1, 1);
            DateTime endDate = new DateTime(2020, 1, 3);

            var target = DoctorScheduleEN.GetService("");

            var list = target.GetByRange(new DoctorScheduleGetByRangeSP()
                {
                    DoctorID = TestEnums.User.constDoctorID,
                    StartUnixEpoch = DateTimeEpoch.ConvertDateToSecondsEpoch(startDate),
                    EndUnixEpoch = DateTimeEpoch.ConvertDateToSecondsEpoch(endDate)
                })
                ;

            Assert.IsTrue(list.Count > 0); // some items retrieved
        }


        //[TestMethod]
        public void PopulateDatabaseWithRecords()
        {
            int startDate = DateTimeEpoch.ConvertDateToSecondsEpoch(new DateTime(2020, 1, 1));
            int endDate = DateTimeEpoch.ConvertDateToSecondsEpoch(new DateTime(2020, 1, 5));

            PopulateDatabase(startDate, endDate, 100);
        }

        private static void PopulateDatabase(int startDate, int endDate, int numberOfSamples)
        {
            var target = DoctorScheduleEN.GetService("");

            for (int i = 1; i < numberOfSamples; i++)
            {
                var doctorSchedule = DoctorScheduleServiceTest.CreateNewDoctorSchedule();
                int everyFiveMinuteCountInStartDateToEndDate = (endDate - startDate) / 60 / 5;
                int randomNumberInEveryFiveMinuteFromStart = TestUtils.RandomUtils.RandomNumber(0, everyFiveMinuteCountInStartDateToEndDate);
                int randomTime = startDate + (randomNumberInEveryFiveMinuteFromStart * 60 * 5);
                //TestUtils.RandomUtils.RandomNumber(5, 60) * 60; //every minute is 60 seconds  
                doctorSchedule.SlotUnixEpoch = randomTime;
                try
                {
                    target.Insert(doctorSchedule, null);
                }
                catch (BRException)
                {
                    // just don't do anything
                    //i--;
                }
            }
        }

        [TestMethod]
        public void DeleteRange()
        {
            var target = DoctorScheduleEN.GetService("");
            int startDate = DateTimeEpoch.ConvertDateToSecondsEpoch(new DateTime(2020, 1, 6));
            int endDate = startDate + DateTimeEpoch.OneDaySeconds;

            var getTimesP = new DoctorScheduleGetByRangeSP()
                {
                    DoctorID = TestEnums.User.constDoctorID,
                    StartUnixEpoch = startDate,
                    EndUnixEpoch = endDate
                };

            if (target.GetCountByRange(getTimesP) == 0)
            {
                PopulateDatabase(startDate, endDate, 15);
                Assert.IsTrue(target.GetCountByRange(getTimesP) > 0, "PopulateDatabase didn't generate any doctor availablility time slot.");
            }

            target.DeleteRange(new DoctorScheduleDeleteRangeSP()
            {
                DoctorID = TestEnums.User.constDoctorID,
                StartUnixEpoch = startDate,
                EndUnixEpoch = endDate,
            });

            Assert.IsTrue(target.GetCountByRange(getTimesP) == 0, "Delete range didn't all slots in the specified range. Please make sure that there is no visit associated with slots.");
        }


        public static DoctorSchedule CreateNewDoctorSchedule()
        {
            DoctorSchedule doctorSchedule = new DoctorSchedule();
            doctorSchedule.DoctorID = TestEnums.User.constDoctorID;
            doctorSchedule.SlotUnixEpoch = DateTimeEpoch.GetUtcNowEpoch() + 3000;
            doctorSchedule.NumberOfAllowedPatients = 3;
            doctorSchedule.NumberOfRegisteredPatients = 0;
            doctorSchedule.IsDisabled = false;
            doctorSchedule.IsWalkingQueue = false;
            return doctorSchedule;
        }



    }
}
