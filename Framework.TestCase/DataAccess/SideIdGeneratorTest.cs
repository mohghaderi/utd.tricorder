using Framework.Common;
using Framework.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using Framework.DataAccess;

namespace Framework.TestCase.DataAccess
{
    [TestClass]
    public class SideIdGeneratorTest
    {
        [TestMethod]
        public void LoadServerConfigTest()
        {
            ConfigUtils cf = new ConfigUtils();
        }


        [TestMethod]
        public void SiteIdGeneratorTestInsertTest()
        {
            ISiteIdGeneratorTestService service = (ISiteIdGeneratorTestService) EntityFactory.GetEntityServiceByName(vSiteIdGeneratorTest.EntityName, "");
            SiteIdGeneratorTest obj = CreateNewSiteIdGeneratorEntity();

            service.InsertT(obj, new InsertParameters());

            Assert.IsTrue(obj.SiteIdGeneratorTestID > 0);
            Assert.IsTrue(obj.SiteIdGeneratorTestID > SiteIdUtils.BaseNumberInt64 && obj.SiteIdGeneratorTestID < SiteIdUtils.EndNumberInt64);

        }






        private SiteIdGeneratorTest CreateNewSiteIdGeneratorEntity()
        {
            SiteIdGeneratorTest obj = new SiteIdGeneratorTest();
            //obj.SiteIdGeneratorTestTitle = "TestTitle";
            return obj;
        }


    }
}
