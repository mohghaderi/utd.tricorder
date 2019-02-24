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
using UTD.Tricorder.Service;

namespace UTD.Tricorder.TestCase.Service.dbo
{
    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for AppFile
    ///</summary>
    [TestClass()]
    public class AppFileServiceTest
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

        private IAppFileService CreateService()
        {
            return AppFileEN.GetService("");
        }



        [TestMethod()]
        public void InsertTest()
        {
            TestUtils.Security.SetCurrentUser(TestEnums.User.constDoctorID);

            var AppFile = AppFileServiceTest.CreateNewAppFile();
            var target = AppFileEN.GetService("");
            target.Insert(AppFile, new InsertParameters());
            // Happy scenario without exception
        }

        [TestMethod]
        public void GetFileKeyTest()
        {
            var AppFile = AppFileServiceTest.CreateNewAppFile();
            AppFileService target = (AppFileService) AppFileEN.GetService("");
            string recordId = "123123";
            string virtualPathTemplate = "userfiles/u{userid}/visitattach/{recordid}/{filename}";
            string selectedfileName = "myfile.zip";
            long userId = 100000001;
            string expected = "userfiles/u100000001/visitattach/123123/myfile.zip";
            string actual = target.GetFileKeyByPathTemplate(virtualPathTemplate, selectedfileName, userId, recordId);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFileKey2Test()
        {
            AppFileService target = (AppFileService)AppFileEN.GetService("");
            string recordId = "123123";
            string virtualPathTemplate = "userfiles/u{userid}/visitattach/{recordid}/image.jpg";
            string selectedfileName = "filename.jpg";
            long userId = 100000001;
            string expected = "userfiles/u100000001/visitattach/123123/image.jpg";
            string actual = target.GetFileKeyByPathTemplate(virtualPathTemplate, selectedfileName, userId, recordId);

            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void AmazonUploadRequestTest()
        {
            TestUtils.Security.SetCurrentUser(TestEnums.User.constPatientUserID);

            var target = AppFileEN.GetService("");
            AppFileAmazonUploadRequestSP p = new AppFileAmazonUploadRequestSP() {
                 FileName = "images.jpg"
                 , AppEntityRecordIDValue = (long) TestEnums.User.constPatientUserID
                 , AppFileTypeID = (int) EntityEnums.AppEntityFileTypeEnum.Test_Picture_Upload
            };
            var result = target.AmazonUploadRequest(p);

            string expectedKey = "systemtest/testfile.jpg";
            //string expectedPolicyString = ""; (it can variate and has time added by 10 hours so, it's hard to have an exact policy)

            Assert.IsTrue(result.AppFileID > 0);
            Assert.AreEqual(result.Key, expectedKey);
            //Assert.AreEqual(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(result.PolicyBase64)), expectedPolicyString);
            string actualPolicyText = System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(result.PolicyBase64));
            Assert.IsTrue(string.IsNullOrEmpty(actualPolicyText) == false, "policy text base 64 can't be null or empty.");
            Assert.IsTrue(FWUtils.EntityUtils.JsonIsValidThenDeserialize(actualPolicyText) != null, "policy string should be a valid json object");
            Assert.IsTrue(string.IsNullOrEmpty(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(result.SignatureBase64))) == false, "signature base 64 can't be null or empty.");
        }

        [TestMethod]
        public void GetS3SignedUrlAccessTest()
        {
            // https://console.aws.amazon.com/s3/home?region=us-west-2#

            // test generates a url for downloading a file from S3
            // it downloads the file and checks the length to be more than 0
            AppFileService target = (AppFileService)AppFileEN.GetService("");
            string key = "systemtest/testwebprivatedownload.jpg";
            var url = target.GetS3SignedUrlAccess(key, 5);

            using (System.Net.WebClient w = new System.Net.WebClient())
            {
                byte[] data = w.DownloadData(url);
                Assert.IsTrue(data.Length > 0);
            }
        }

        [TestMethod]
        public void UploadFileToS3_GetS3SignedUrl_Delete_IntegrationTest()
        {
            // https://console.aws.amazon.com/s3/home?region=us-west-2#

            AppFileService target = (AppFileService)AppFileEN.GetService("");
            string key = "systemtest/testintegrationfile2.jpg";

            // test deleting existing file
            try 
	        {
                target.DeleteFromS3(key);
            }
	        catch (Exception)
	        {
	        }

            byte[] testbytes = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            target.UploadFileToS3(key, testbytes, "image/jpg", Guid.NewGuid());

            var url = target.GetS3SignedUrlAccess(key, 5);
            using (System.Net.WebClient w = new System.Net.WebClient())
            {
                byte[] data = w.DownloadData(url);
                Assert.IsTrue(data.Length > 0);
            }

            target.DeleteFromS3(key);
        }


        [TestMethod]
        public void FileExistsS3_Test()
        {
            AppFileService target = (AppFileService)AppFileEN.GetService("");
            string key = "systemtest/testwebprivatedownload.jpg";
            bool expected = true;
            bool actual = target.FileExistsS3(key);
            Assert.AreEqual(expected, actual, "file " + key + "should exist on Amazon S3 bucket.");
        }

        [TestMethod]
        public void FileExistsS3_Test2()
        {
            AppFileService target = (AppFileService)AppFileEN.GetService("");
            string key = "systemtest/randomfilename123123123.jpg";
            bool expected = false;
            bool actual = target.FileExistsS3(key);
            Assert.AreEqual(expected, actual, "file " + key + "should not exists on Amazon S3 bucket.");
        }

        [TestMethod]
        public void UploadToS3Completed_Test()
        {
            // this test inserts a new file into the database and updates its status
            // by completing it
            string fileName = "testfile.jpg";
            AppFileService target = (AppFileService)AppFileEN.GetService("");
            var appFile = target.InsertNewFile(fileName, (int) EntityEnums.AppEntityFileTypeEnum.Test_Picture_Upload, TestEnums.User.constPatientUserID);
            Assert.AreEqual(appFile.AppFileUploadStatusID, (short) EntityEnums.AppEntityFileUploadStatus.Incomplete);
            string fileKey = "systemtest/testfile.jpg";
            target.DeleteFromS3(fileKey); // clearning test

            byte[] bytes = {0,1,2,3,4};
            target.UploadFileToS3(fileKey, bytes, "image/jpg", Guid.NewGuid());
            target.UploadToS3Completed(new AppFileUploadToS3CompletedSP(){ AppFileID = appFile.AppFileID });
            
            var actualfile = target.GetByIDT(appFile.AppFileID);
            short newStatus = actualfile.AppFileUploadStatusID;
            try // Cleaning test data
            {
                target.DeleteFromS3(fileKey);
                target.Delete(actualfile);
            }
            catch (Exception)
            {
            }
            Assert.AreEqual(newStatus, (short)EntityEnums.AppEntityFileUploadStatus.Completed);
        }

        // AWS references shouldn't be in public method returns. 
        // Methods are public for test purposes only
        //[TestMethod]
        //public void S3GetObjectMetaData_Test()
        //{
        //    AppFileService target = (AppFileService)AppFileEN.GetService("");
        //    string key = "systemtest/testwebprivatedownload.jpg";
        //    bool expected = true;
        //    var actual = target.S3GetObjectMetaData(key);
        //    Assert.AreEqual(expected, );
        //}



        public static AppFile CreateNewAppFile()
        {
            AppFile appFile = new AppFile();
            appFile.AppFileTypeID = (int)EntityEnums.AppEntityFileTypeEnum.Test_Picture_Upload;
            appFile.AppEntityRecordIDValue = TestEnums.User.constPatientUserID;
            appFile.InsertUserID = TestEnums.User.constPatientUserID;
            appFile.InsertDate = DateTime.UtcNow;
            appFile.AppFileUploadStatusID = (short)EntityEnums.AppEntityFileUploadStatus.Incomplete;
            appFile.FileUUID = Guid.NewGuid();
            return appFile;
        }



    }
}
