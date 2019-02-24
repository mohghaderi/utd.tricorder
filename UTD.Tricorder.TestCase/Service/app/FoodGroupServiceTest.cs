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
    ///This is a test class for FoodGroup
    ///</summary>
    [TestClass()]
    public class FoodGroupServiceTest
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

        private IFoodGroupService CreateService()
        {
            return FoodGroupEN.GetService("");
        }

        [TestMethod]
        public void GetUnsavedFoodGroupTest()
        {
            var target = FoodGroupEN.GetService("");
            var p = new FoodGroup_GetUnsavedFoodGroupSP
            {
                FoodServingTimeTypeID = (int)EntityEnums.FoodServingTimeTypeEnum.Other,
                UserID = TestEnums.User.constPatientUserID
            };

            var first = target.GetUnsavedFoodGroup(p);
            var firstId = first.FoodGroupID;
            target.Delete(first, null);

            var second = target.GetUnsavedFoodGroup(p);

            Assert.IsTrue(firstId != second.FoodGroupID);
        }

        [TestMethod]
        public void OnBeforeUpdateTest()
        {
            var target = FoodGroupEN.GetService("");
            var p = new FoodGroup_GetUnsavedFoodGroupSP
            {
                FoodServingTimeTypeID = (int)EntityEnums.FoodServingTimeTypeEnum.Other,
                UserID = TestEnums.User.constPatientUserID
            };
            var obj = target.GetUnsavedFoodGroup(p);

            // clearing previous results
            var dp = new DailyActivity_GetByTypeAndExternalEntityAndUserSP()
            {
                UserID = TestEnums.User.constPatientUserID,
                DailyActivityTypeID = (int)EntityEnums.DailyActivityTypeEnum.Eating,
                ExternalEntityID = obj.FoodGroupID
            };
            var list = DailyActivityEN.GetService().GetByTypeAndExternalEntityAndUser(dp);
            if (list.Count > 0)
                DailyActivityEN.GetService().Delete(list[0], null);

            
            // test update
            obj.RecordDateTimeUserLocal = DateTime.Now;

            //var foodgroupitem1 = new FoodGroupItem
            //{
            //    FoodGroupID = obj.FoodGroupID,
            //    Calorie = 0,
            //    Carb = 0,
            //    Protein = 0,
            //    Fat = 0,
            //    FoodID = new Guid("176B0637-65E9-409E-829C-0001D06B5626"),
            //    FoodServingTypeID = 0,
            //    ServingAmount = 100,
            //    ServingGrams = 50
            //};
            //FoodGroupItemEN.GetService().Insert(foodgroupitem1, null);

            target.Update(obj, null);
            
            // check if daily activity is created successfully
            list = DailyActivityEN.GetService().GetByTypeAndExternalEntityAndUser(dp);
            Assert.IsTrue(obj.IsGroupSaved == true, "group should be saved after update");
            Assert.IsTrue(list.Count == 1, "DailyActivity has not been created after update");
        }

        [TestMethod]
        public void OnAfterUpdateTest()
        {
            var target = FoodGroupEN.GetService("");
            var p = new FoodGroup_GetUnsavedFoodGroupSP
            {
                FoodServingTimeTypeID = (int)EntityEnums.FoodServingTimeTypeEnum.Other,
                UserID = TestEnums.User.constPatientUserID
            };
            var obj = target.GetUnsavedFoodGroup(p);

            
            var foodgroupitem1 = new FoodGroupItem {
                 FoodGroupID = obj.FoodGroupID,
                 Calorie = 100,
                 Carb = 200,
                 Protein = 300,
                 Fat = 400,
                 FoodID = new Guid("176B0637-65E9-409E-829C-0001D06B5626"),
                 FoodServingTypeID = 0,
                 ServingAmount = 100,
                 ServingGrams = 50
            };

            var foodgroupitem2 = new FoodGroupItem
            {
                FoodGroupID = obj.FoodGroupID,
                Calorie = 100,
                Carb = 200,
                Protein = 300,
                Fat = 400,
                FoodID = new Guid("176B0637-65E9-409E-829C-0001D06B5626"),
                FoodServingTypeID = 0,
                ServingAmount = 100,
                ServingGrams = 50
            };

            FoodGroupItemEN.GetService().Insert(foodgroupitem1, null);
            FoodGroupItemEN.GetService().Insert(foodgroupitem2, null);

            // updating foodgroup to save information in the database
            obj.RecordDateTimeUserLocal = DateTime.Now;
            target.Update(obj, null);

            // Checking sum values be updated in Daily Activity entity
            var dp = new DailyActivity_GetByTypeAndExternalEntityAndUserSP()
            {
                UserID = TestEnums.User.constPatientUserID,
                DailyActivityTypeID = (int)EntityEnums.DailyActivityTypeEnum.Eating,
                ExternalEntityID = obj.FoodGroupID
            };
            var list = DailyActivityEN.GetService().GetByTypeAndExternalEntityAndUser(dp);
            Assert.IsTrue(list.Count > 0, "Daily Activity should exists.");
            var dailyActivity = list[0];
            Assert.AreEqual(dailyActivity.Carb, foodgroupitem1.Carb + foodgroupitem2.Carb);
            Assert.AreEqual(dailyActivity.Protein, foodgroupitem1.Protein + foodgroupitem2.Protein);
            Assert.AreEqual(dailyActivity.Fat, foodgroupitem1.Fat + foodgroupitem2.Fat);
            Assert.AreEqual(dailyActivity.Calorie, foodgroupitem1.Calorie + foodgroupitem2.Calorie);

            // Note: This part is another test case, but I put it here to avoid writing the whole test again
            // Check updates of a FoodGroupItem to propagate to daily activity
            foodgroupitem1.Calorie = foodgroupitem1.Calorie * 2;
            foodgroupitem1.Fat = foodgroupitem1.Fat * 2;
            foodgroupitem1.Protein = foodgroupitem1.Protein * 2;
            foodgroupitem1.Carb = foodgroupitem1.Carb * 2;
            FoodGroupItemEN.GetService().Update(foodgroupitem1, null);

            
            list = DailyActivityEN.GetService().GetByTypeAndExternalEntityAndUser(dp);
            Assert.IsTrue(list.Count > 0, "Daily Activity should exists.");
            dailyActivity = list[0];
            Assert.AreEqual(dailyActivity.Carb, foodgroupitem1.Carb + foodgroupitem2.Carb);
            Assert.AreEqual(dailyActivity.Protein, foodgroupitem1.Protein + foodgroupitem2.Protein);
            Assert.AreEqual(dailyActivity.Fat, foodgroupitem1.Fat + foodgroupitem2.Fat);
            Assert.AreEqual(dailyActivity.Calorie, foodgroupitem1.Calorie + foodgroupitem2.Calorie);
        }



    }
}
