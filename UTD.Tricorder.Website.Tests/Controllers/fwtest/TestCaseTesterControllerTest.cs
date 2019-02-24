using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.Website;
using UTD.Tricorder.Website.Controllers;
using UTD.Tricorder.Website.Base;
using UTD.Tricorder.Common.SP;
using Framework.Common;
using UTD.Tricorder.Website.Models;

namespace UTD.Tricorder.Website.Tests.Controllers
{
    [DeploymentItem("_Config\\")]
    [TestClass]
    public class TestCaseTesterControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            TestCaseTesterController controller = new TestCaseTesterController();

            // Act
            ServiceActionResult res = controller.Get(null);

            // Assert
            Assert.IsNotNull(res.data);
            Assert.IsNull(res.errorMessage);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            TestCaseTesterController controller = new TestCaseTesterController();

            // Act
            ServiceActionResult res = controller.GetByID("5D4A773E-2FF0-4BC0-8167-A2460135BBBF");

            // Assert
            Assert.IsNotNull(res.data);
            Assert.IsNull(res.errorMessage);
        }

        [TestMethod]
        public void exec_ServiceFunctionWithoutParameterRetValue()
        {
            // Arrange
            TestCaseTesterController controller = new TestCaseTesterController();

            // Act
            ServiceActionResult res = controller.Exec("ServiceFunctionWithoutParameterRetValue", null);

            // Assert
            Assert.AreEqual("OK!", res.data);
        }

        [TestMethod]
        public void exec_ServiceFunctionWithoutParameter()
        {
            // Arrange
            TestCaseTesterController controller = new TestCaseTesterController();

            // Act
            ServiceActionResult res = controller.Exec("ServiceFunctionWithoutParameter", null);

            // Assert
            Assert.AreEqual("OK!", res.errorMessage);
        }



        [TestMethod]
        public void exec_ServiceFunctionWithOneParameter()
        {
            // Arrange
            TestCaseTesterController controller = new TestCaseTesterController();

            FWPostBody body = new FWPostBody("paramValue");
            // Act
            ServiceActionResult res = controller.Exec("ServiceFunctionWithOneParameter", body);

            // Assert
            Assert.AreEqual("OK! paramValue", res.errorMessage);
        }


        [TestMethod]
        public void exec_ServiceFunctionWithOneParameterRetValue()
        {
            // Arrange
            TestCaseTesterController controller = new TestCaseTesterController();

            FWPostBody body = new FWPostBody("paramValue");
            // Act
            ServiceActionResult res = controller.Exec("ServiceFunctionWithOneParameterRetValue", body);

            // Assert
            Assert.AreEqual("OK! paramValue", res.data);
        }


        [TestMethod]
        public void exec_ServiceFunctionWithOneComplexParameter()
        {
            // Arrange
            TestCaseTesterController controller = new TestCaseTesterController();

            TestCaseTesterComplexP p = new TestCaseTesterComplexP();
            //p.MFieldbytearray50
            p.MFielddatetime = new DateTime(2013,1,1);
            p.MFielddecimal = 1000000;
            p.MFielddouble = Double.MaxValue;
            p.MFieldfloat = float.MaxValue;
            p.MFieldint16 = Int16.MaxValue;
            p.MFieldint32 = Int32.MaxValue;
            p.MFieldint64 = Int64.MaxValue;
            p.MFieldntext = "Some Text";
            p.MFieldstring = "Some String";

            string jSonData = FWUtils.EntityUtils.JsonSerializeObject(p);

            FWPostBody body = new FWPostBody(jSonData);
            // Act
            ServiceActionResult res = controller.Exec("ServiceFunctionWithOneComplexParameter", body);

            // Assert
            Assert.AreEqual("OK!", res.data);
        }

    }
}
