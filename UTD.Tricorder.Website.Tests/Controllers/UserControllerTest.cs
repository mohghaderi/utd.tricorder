using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.Website;
using UTD.Tricorder.Website.Controllers;
using UTD.Tricorder.Website.Base;
using UTD.Tricorder.Website.Models;

namespace UTD.Tricorder.Website.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            UserController controller = new UserController();

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
            UserController controller = new UserController();

            // Act
            ServiceActionResult res = controller.GetByID("1");

            // Assert
            Assert.IsNotNull(res.data);
            Assert.IsNull(res.errorMessage);
        }

        [TestMethod]
        public void exec()
        {
            // Arrange
            UserController controller = new UserController();

            FWPostBody body = new FWPostBody("testpatient");
            // Act
            ServiceActionResult res = controller.Exec("ValidateUserNameForInsert", body);

            // Assert
            Assert.IsNotNull(res.errorMessage);
        }

    }
}
