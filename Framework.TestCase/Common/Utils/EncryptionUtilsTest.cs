using Framework.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Framework.Common;
using Framework.TestCase.CommonClasses;
using System.Security.Cryptography;
using System.Text;

namespace Framework.TestCase.Common.Utils
{


    /// <summary>
    ///This is a test class for EncryptionUtilsTest and is intended
    ///to contain all EncryptionUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EncryptionUtilsTest
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
        ///A test for EncryptionUtils Constructor
        ///</summary>
        [TestMethod()]
        public void EncryptionUtilsConstructorTest()
        {
            EncryptionUtils target = new EncryptionUtils();
        }


        /// <summary>
        ///A test for ConvertStringKeyToBytes
        ///</summary>
        [TestMethod()]
        public void ConvertStringKeyToBytesTest1()
        {
            string key = "64C6B83A-0EFF-4122-A15A-507D4765FC9A";
            byte[] keyBytes = EncryptionUtils.ConvertStringKeyToBytes(key);
            StringBuilder sb = new StringBuilder();
            sb.Append("byte[] keyBytes = {");
            for (int i = 0; i < keyBytes.Length; i++)
            {
                sb.Append(keyBytes[i]);
                if (i != keyBytes.Length - 1)
                    sb.Append(", ");
            }
            sb.Append("}");
            string actual = sb.ToString();
            string expected = "byte[] keyBytes = {95, 8, 90, 86, 202, 165, 217, 248, 62, 130, 210, 231, 66, 233, 34, 176, 134, 213, 7, 151, 11, 74, 47, 133, 215, 172, 14, 244, 29, 157, 157, 1}";
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for EncryptString, DecryptString for small UTF-8 string
        ///</summary>
        [TestMethod()]
        public void EncryptAndDecryptStringTest1()
        {
            EncryptionUtils target = new EncryptionUtils();
            string myData = "This is a random data با کد های یونیکد &^%$#@!";
            string key = "64C6B83A-0EFF-4122-A15A-507D4765FC9A";

            try
            {
                string encrypted = target.EncryptString(myData, key);
                Assert.AreNotEqual(encrypted, myData);
                string decrypted = target.DecryptString(encrypted, key);
                Assert.AreEqual(decrypted, myData);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }



        /// <summary>
        ///A test for EncryptString, DecryptString for big strings that needs more than one chunk
        ///</summary>
        [TestMethod()]
        public void EncryptAndDecryptBigStringTest1()
        {
            EncryptionUtils target = new EncryptionUtils();
            string myData = "This is a random data با کد های یونیکد &^%$#@!";
            myData += myData + myData + myData + myData + myData + myData; //making big string for more than one block encryption and decryption

            string key = "64C6B83A-0EFF-4122-A15A-507D4765FC9A";

            try
            {
                string encrypted = target.EncryptString(myData, key);
                Assert.AreNotEqual(encrypted, myData);
                string decrypted = target.DecryptString(encrypted, key);
                Assert.AreEqual(decrypted, myData);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        /// <summary>
        ///A test for EncryptString, DecryptString with wrong key that show make an exception
        ///</summary>
        [TestMethod()]
        public void EncryptAndDecryptStringWrongKeyTest1()
        {
            EncryptionUtils target = new EncryptionUtils();
            string myData = "This is a random data با کد های یونیکد &^%$#@!";
            string key = "64C6B83A-0EFF-4122-A15A-507D4765FC9A";
            string wrongKey = "64C6B83A";

            string encrypted = target.EncryptString(myData, key);

            try
            {
                string decrypted = target.DecryptString(encrypted, wrongKey);
                if (decrypted == myData)
                    Assert.Fail();
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                Assert.IsTrue(ex.Message.Contains("Padding is invalid and cannot be removed."));
                return;
            }
            Assert.Fail();
        }



        /// <summary>
        ///A test for Encrypt, Decrypt
        ///</summary>
        [TestMethod()]
        public void EncryptAndDecryptTest1()
        {
            EncryptionUtils target = new EncryptionUtils();

            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            string data = "This is a random data با کد های یونیکد &^%$#@!";
            byte[] myData = sha256.ComputeHash(Encoding.Unicode.GetBytes(data));
            string key = "64C6B83A-0EFF-4122-A15A-507D4765FC9A";

            try
            {
                byte[] encrypted = target.Encrypt(myData, key);
                Assert.AreNotEqual(encrypted, myData);
                byte[] decrypted = target.Decrypt(encrypted, key);
                Assert.AreEqual(Convert.ToBase64String(decrypted), Convert.ToBase64String(myData));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }




    }
}
