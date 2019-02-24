using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTD.Tricorder.Website.Models
{
    public class FilterJson
    {
        public string ColumnName { get; set; }
        public object Value { get; set; }
        public FilterLogicalOperatorEnum? LogicalOperator { get; set; }
        public FilterOperatorEnum? Operator { get; set; }
    }


    public class FilterExpJson
    {
        public FilterLogicalOperatorEnum? LogicalOperator { get; set; }
        public FilterJson[] FiltersList { get; set; }
    }


    public class GetByFilterParmsJsonCompatible
    {
        /// <summary>
        /// Gets or sets the select columns.
        /// </summary>
        /// <value>
        /// The select columns.
        /// </value>
        public List<string> SelectColumns { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public SortExpression Sort { get; set;}

        public FilterExpJson Filter { get; set; }

        public GetSourceTypeEnum SourceType
        {
            get;
            set;
        }


        /// <summary>
        /// Converts the class to the GetByFilter class used in Framework
        /// </summary>
        /// <returns>GetByFilter parameters</returns>
        public GetByFilterParameters ConvertToGetByFilterParameters(EntityInfoBase entity)
        {
            // logic is like this: The deserializer deserialize JSON on this object
            // we need to read from this.PropertyName and create new GetByFilterObject
            FilterExpression filterFinal = new FilterExpression();
            if (this.Filter != null)
            {
                if (this.Filter.LogicalOperator.HasValue == false) // default value for logical operator
                    this.Filter.LogicalOperator = FilterLogicalOperatorEnum.AND;

                filterFinal.LogicalOperator = this.Filter.LogicalOperator.Value;
                if (this.Filter.FiltersList != null)
                {
                    foreach (var item in this.Filter.FiltersList)
                    {
                        //TODO: It doesn't support advanced filter by now. 
                        // Add advanced filter later

                        if (item.LogicalOperator.HasValue)
                        {
                            throw new NotImplementedException("Nested filters are not supported by now");
                            //    FilterExpression f2 = new FilterExpression();
                            //    f2.AddFilter()
                        }

                        if (item.Operator.HasValue == false) // default value for filter operator
                            item.Operator = FilterOperatorEnum.EqualTo;

                        // some security check for column names
                        if (entity.EntityColumns.ContainsKey(item.ColumnName))
                        {
                            // type casting for columns
                            if (item.Value is string)
                                item.Value = FWUtils.EntityUtils.ConvertStringToObject((string)item.Value, entity.EntityColumns[item.ColumnName].DataTypeDotNet);
                        }
                        else
                            throw new Exception("Filter column name : " + item.ColumnName + " is not exists in the entity: " + entity.EntityName);


                        filterFinal.AddFilter(new Filter(item.ColumnName, item.Value, item.Operator.Value));
                    }
                }
            }

            // Check sort experssion columns
            if (this.Sort != null)
            {
                foreach(var item in this.Sort.SortInfoList)
                    if (entity.EntityColumns.ContainsKey(item.ColumnName)== false)
                        throw new Exception("Sort column name : " + item.ColumnName + " is not exists in the entity: " + entity.EntityName);
            }

            // fix page size
            // if the page size is greater than 100, then we need to decrease it.
            if (this.PageSize > 100)
                this.PageSize = 100;

            if (this.PageSize == 0)
                this.PageSize = -1;

            GetByFilterParameters getByFilter = new GetByFilterParameters(filterFinal, this.Sort, this.PageIndex, this.PageSize, this.SelectColumns, this.SourceType);
            return getByFilter;
        }
    

    }
}