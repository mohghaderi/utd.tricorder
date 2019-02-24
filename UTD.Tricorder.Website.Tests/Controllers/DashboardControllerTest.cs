using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UTD.Tricorder.Website.Controllers;

namespace UTD.Tricorder.Website.Tests.Controllers
{
    [TestClass]
    public class DashboardControllerTest
    {
        [TestMethod]
        public void AjaxView()
        {
            DashboardController controller = new DashboardController();
            ContentResult results = controller.AjaxView("DoctorMenu") as ContentResult;

            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Content != null);
        }

        [TestMethod]
        public void AjaxView2()
        {
            DashboardController controller = new DashboardController();
            ContentResult results = controller.AjaxView("Index") as ContentResult;

            Assert.IsTrue(results == null);
        }


        public void AjaxView3()
        {
            DashboardController controller = new DashboardController();
            ContentResult results = controller.AjaxView("_FWTest-PartialTestCase") as ContentResult;

            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Content != null);
        }




    }
}
