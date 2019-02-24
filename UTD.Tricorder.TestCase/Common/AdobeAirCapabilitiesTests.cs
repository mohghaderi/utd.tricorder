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
    public class AdobeAirCapabilitiesTests
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
        ///A test for AdobeAirCapabilitiesTests Constructor
        ///</summary>
        [TestMethod()]
        public void AdobeAirCapabilitiesTestsConstructorNullTest()
        {
            string airCapabilities = null;
            AdobeAirCapabilities target = new AdobeAirCapabilities(airCapabilities);
            Assert.AreEqual(true, target.IsNull);
        }

        /// <summary>
        ///A test for AdobeAirCapabilitiesTests Constructor
        ///</summary>
        [TestMethod()]
        public void AdobeAirCapabilitiesTestsConstructorTest()
        {
            string airCapabilities = "A=t&SA=t&SV=t&EV=t&MP3=t&AE=t&VE=t&ACC=t&PR=t&SP=t&" + 
                "SB=t&DEB=t&V=WIN%209%2C0%2C0%2C0&M=Adobe%20Windows&" + 
                "R=1600x1200&DP=72&COL=color&AR=1.2&OS=Windows%20XP&" + 
                "L=en&PT=External&AVD=t&LFD=t&WD=t&IME=t&DD=t&" +
                "DDP=t&DTS=t&DTE=t&DTH=t&DTM=t" +
                "&TLS=t&ML=100";
            AdobeAirCapabilities target = new AdobeAirCapabilities(airCapabilities);

            Assert.AreEqual(false, target.IsNull, "target.IsNull should be false");
            Assert.AreEqual(true, target.avHardwareDisable, "target.avHardwareDisable should be true");
            Assert.AreEqual(true, target.hasAccessibility, "target.hasAccessibility should be true");
            Assert.AreEqual(true, target.hasAudio, "target.hasAudio should be true");
            Assert.AreEqual(true, target.hasAudioEncoder, "target.hasAudioEncoder should be true");
            Assert.AreEqual(true, target.hasEmbeddedVideo, "target.hasEmbeddedVideo should be true");
            Assert.AreEqual(true, target.hasIME, "target.hasIME should be true");
            Assert.AreEqual(true, target.hasMP3, "target.hasMP3 should be true");
            Assert.AreEqual(true, target.hasPrinting, "target.hasPrinting should be true");
            Assert.AreEqual(true, target.hasScreenBroadcast, "target.hasScreenBroadcast should be true");
            Assert.AreEqual(true, target.hasScreenPlayback, "target.hasScreenPlayback should be true");
            Assert.AreEqual(true, target.hasStreamingAudio, "target.hasStreamingAudio should be true");
            Assert.AreEqual(true, target.hasStreamingVideo, "target.hasStreamingVideo should be true");
            Assert.AreEqual(true, target.hasTLS, "target.hasTLS should be true");
            Assert.AreEqual(true, target.hasVideoEncoder, "target.hasVideoEncoder should be true");
            Assert.AreEqual(true, target.isDebugger, "target.isDebugger should be true");
            Assert.AreEqual("en", target.language, "target.language should be 'en'");

            Assert.AreEqual(true, target.localFileReadDisable, "target.localFileReadDisable should be true");
            Assert.AreEqual("Adobe Windows", target.manufacturer, "target.manufacturer should be 'Adobe Windows'");
            Assert.AreEqual("100", target.maxLevelIDC, "target.maxLevelIDC should be 100");
            Assert.AreEqual("Windows XP", target.os, "target.os should be 'Windows XP'");
            //float pixelAspectRatioExpected = 1.2f;
            //Assert.AreEqual(pixelAspectRatioExpected, target.pixelAspectRatio, "target.pixelAspectRatio should be 1.2");
            Assert.AreEqual("External", target.playerType, "target.playerType should be 'External'");
            Assert.AreEqual("color", target.screenColor, "target.screenColor should be 'color'");
            Assert.AreEqual(72, target.screenDPI, "target.screenDPI should be 72");
            Assert.AreEqual(1600, target.screenResolutionX, "target.screenResolutionX should be 1600");
            Assert.AreEqual(1200, target.screenResolutionY, "target.screenResolutionY should be 1200");
            Assert.AreEqual("WIN 9,0,0,0", target.version, "target.version should be 'WIN 9,0,0,0'");
            Assert.AreEqual(true, target.supportsDolbyDigitalAudio, "target.supportsDolbyDigitalAudio should be true");
            Assert.AreEqual(true, target.supportsDolbyDigitalPlusAudio, "target.supportsDolbyDigitalPlusAudio should be true");
            Assert.AreEqual(true, target.supportsDTSAudio, "target.supportsDTSAudio should be true");
            Assert.AreEqual(true, target.supportsDTSExpressAudio, "target.supportsDTSExpressAudio should be true");
            Assert.AreEqual(true, target.supportsDTS_HDHighResolutionAudio, "target.supportsDTS_HDHighResolutionAudio should be true");
            Assert.AreEqual(true, target.supportsDTS_HDMasterAudio, "target.supportsDTS_HDMasterAudio should be true");
        }

        ///// <summary>
        /////A test for AdobeAirCapabilitiesTests Constructor
        /////</summary>
        //[TestMethod()]
        //public void AdobeAirCapabilitiesTestsConstructorNullTest()
        //{
        //    string invalidString = "invalidString";
        //}

    }
}
