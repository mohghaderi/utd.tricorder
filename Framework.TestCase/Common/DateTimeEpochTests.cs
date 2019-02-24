using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.TestCase.Common
{
    [DeploymentItem("_Config\\")]
    [DeploymentItem("Framework\\tzdb\\")]
    [TestClass()]
    public class DateTimeEpochTests
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
        public void ConvertDateToSecondsEpochTest()
        {
            DateTime dateTime = new DateTime(2014, 06, 27, 17, 55, 30);
            int expected = 1403891730;
            int actual = DateTimeEpoch.ConvertDateToSecondsEpoch(dateTime);
            Assert.AreEqual(expected, actual, "Epoch for shoule be equal to " + expected.ToString());
        }

        [TestMethod()]
        public void ConvertSecondsEpochToDateTimeTest()
        {
            int seconds = 1403891730;
            DateTime actual = DateTimeEpoch.ConvertSecondsEpochToDateTime(seconds);
            DateTime expected = new DateTime(2014, 06, 27, 17, 55, 30);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetUtcNowEpochTest()
        {
            DateTime now = DateTime.UtcNow;
            int utcNow = DateTimeEpoch.GetUtcNowEpoch();
            DateTime actual = DateTimeEpoch.ConvertSecondsEpochToDateTime(utcNow);
            Assert.AreEqual(now.Year, actual.Year);
            Assert.AreEqual(now.Month, actual.Month);
            Assert.AreEqual(now.Day, actual.Day);
            Assert.AreEqual(now.Hour, actual.Hour);
            Assert.AreEqual(now.Minute, actual.Minute);
            //Assert.AreEqual(now.Second, actual.Second); // Sometimes it takes more than one second causes test to fail. In addition, TimeZones has nothing to do with seconds
        }

        [TestMethod()]
        public void ConvertUtcTimeToLocalTimeTest()
        {
            int seconds = 1403891730;
            string timeZoneID = "Asia/Tehran";
            DateTime tehranTime = DateTimeEpoch.ConvertUnixEpochToLocalTime(seconds, timeZoneID);
            DateTime expected = new DateTime(2014, 06, 27, 22, 25, 30);
            Assert.AreEqual(expected, tehranTime);
        }


        [TestMethod()]
        public void ConvertUtcTimeToLocalTimeTest2()
        {
            int seconds = 1403891730;
            string timeZoneID = "Europe/London";
            DateTime londonTime = DateTimeEpoch.ConvertUnixEpochToLocalTime(seconds, timeZoneID);
            DateTime expected = new DateTime(2014, 06, 27, 18, 55, 30);
            Assert.AreEqual(expected, londonTime);
        }

        [TestMethod()]
        public void ConvertUtcTimeToLocalTimeTest3()
        {
            int seconds = 1403891730;
            string timeZoneID = "America/Chicago";
            DateTime chicagoTime = DateTimeEpoch.ConvertUnixEpochToLocalTime(seconds, timeZoneID);
            DateTime expected = new DateTime(2014, 06, 27, 12, 55, 30);
            Assert.AreEqual(expected, chicagoTime);
        }

        [TestMethod()]
        public void ConvertUnixSecondsToLocalTimeTest()
        {
            int seconds = 1403891730;
            //string timeZoneID = "America/Chicago";
            int timeZoneID = 381;  //"America/Chicago"
            DateTime chicagoTime = DateTimeEpoch.ConvertUnixEpochToLocalTime(seconds, timeZoneID);
            DateTime expected = new DateTime(2014, 06, 27, 12, 55, 30);
            Assert.AreEqual(expected, chicagoTime);
        }

        [TestMethod()]
        public void ConvertUtcTimeToLocalTimeTest4()
        {
            //string timeZoneID = "America/Chicago";
            DateTime dateTime = new DateTime(2014, 06, 27, 17, 55, 30);
            int timeZoneID = 381;  //"America/Chicago"
            DateTime chicagoTime = DateTimeEpoch.ConvertUtcTimeToLocalTime(dateTime, timeZoneID);
            DateTime expected = new DateTime(2014, 06, 27, 12, 55, 30);
            Assert.AreEqual(expected, chicagoTime);
        }


    }
}
