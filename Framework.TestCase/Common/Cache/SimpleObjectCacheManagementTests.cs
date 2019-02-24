using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common.Cache;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.TestCase.CommonClasses;

namespace Framework.Common.Cache.Tests
{
    [TestClass()]
    public class SimpleObjectCacheManagementTests
    {

        [TestMethod()]
        public void GetOrCreateTest()
        {
            SimpleObjectCacheManagement<ComplexStructure> cache = new SimpleObjectCacheManagement<ComplexStructure>();

            // get and saves an object from cache
            ComplexStructure obj1 = (ComplexStructure)cache.GetOrCreate("K1", (x) => CreateK1(), null);

            // make sure that newly created object is different
            ComplexStructure obj2 = (ComplexStructure)cache.GetOrCreate("K2", (x) => CreateK1(), null);
            Assert.AreNotEqual(obj1, obj2);

            //-----------
            // changes first object values
            obj1.Field1 = "F2";
            obj1.Field2 = Guid.NewGuid();
            obj1.Field3 = DateTime.UtcNow;

            // make sure that the object get from cache is the same object
            ComplexStructure obj3 = (ComplexStructure)cache.GetOrCreate("K1", (x) => CreateK1(), null);
            Assert.AreEqual(obj1, obj3);
        }


        private object CreateK1()
        {
            ComplexStructure k1 = new ComplexStructure();
            k1.Field1 = "F1";
            k1.Field2 = Guid.NewGuid();
            k1.Field3 = DateTime.UtcNow;
            return k1;
        }

    }
}
