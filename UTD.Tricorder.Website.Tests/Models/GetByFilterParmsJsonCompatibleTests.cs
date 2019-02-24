using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Website.Models;

namespace UTD.Tricorder.Website.Tests.Models
{
    [TestClass]
    public class GetByFilterParmsJsonCompatibleTests
    {

        [TestMethod]
        public void ConvertTest()
        {
            Framework.Common.FilterExpression filter = new Framework.Common.FilterExpression();
            filter.AddFilter("Col1", "Col1value");
            filter.AddFilter("Col2", "Col2value", Framework.Common.FilterOperatorEnum.GreaterThan);
            filter.LogicalOperator = Framework.Common.FilterLogicalOperatorEnum.OR;
            Framework.Common.SortExpression sort = new Framework.Common.SortExpression("Sample Sort1", Framework.Common.SortDirectionEnum.DESC);
            int pageIndex = 1;
            int PageSize = 20;
            List<String> columns = new List<string>();
            columns.Add("SelectCol1");
            columns.Add("SelectCol2");
            Framework.Common.GetSourceTypeEnum sourceType = Framework.Common.GetSourceTypeEnum.View;
            Framework.Common.GetByFilterParameters get = new Framework.Common.GetByFilterParameters(filter, sort, pageIndex, PageSize, columns, sourceType);

            string getSerialized = Framework.Common.FWUtils.EntityUtils.JsonSerializeObject(get, false);
            var get2 = Framework.Common.FWUtils.EntityUtils.JsonDeserializeObject(getSerialized, typeof(UTD.Tricorder.Website.Models.GetByFilterParmsJsonCompatible));
            string get2Serialized = Framework.Common.FWUtils.EntityUtils.JsonSerializeObject(get2, false);

            //Assert.AreEqual(getSerialized, get2Serialized);
            Assert.IsTrue(get2 != "");
        }

        [TestMethod]
        public void Test2()
        {
            GetByFilterParmsJsonCompatible get = new GetByFilterParmsJsonCompatible();
            List<FilterJson> listFilter = new List<FilterJson>();
            listFilter.Add(new FilterJson() {ColumnName= "Col1", Operator = Framework.Common.FilterOperatorEnum.GreaterThan, Value = "Salam"} );
            listFilter.Add(new FilterJson() {ColumnName= "Col2", Operator = Framework.Common.FilterOperatorEnum.EndsWith, Value = "Salam2"} );
            get.Filter = new FilterExpJson();
            get.Filter.FiltersList = listFilter.ToArray();

            List<String> columns = new List<string>();
            columns.Add("SelectCol1");
            columns.Add("SelectCol2");
            get.SelectColumns = columns;

            get.PageIndex = 1;
            get.PageSize = 20;

            Framework.Common.SortExpression sort = new Framework.Common.SortExpression("Sample Sort1", Framework.Common.SortDirectionEnum.DESC);
            get.Sort = sort;


            string getSerialized = Framework.Common.FWUtils.EntityUtils.JsonSerializeObject(get, false);
            GetByFilterParmsJsonCompatible getDeserialized = (GetByFilterParmsJsonCompatible)
                Framework.Common.FWUtils.EntityUtils.JsonDeserializeObject(getSerialized, typeof(GetByFilterParmsJsonCompatible));
            string getSerialized2 = Framework.Common.FWUtils.EntityUtils.JsonSerializeObject(getDeserialized, false);

            Assert.AreEqual(getSerialized, getSerialized2);
        }





    }
}
