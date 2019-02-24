using System;
using System.Collections.Generic;
using NHibernate.Mapping;
using Newtonsoft.Json;

namespace Framework.Common
{
    /// <summary>
    /// Filter Expression for defining the filters
    /// </summary>
    public class FilterExpression : IFilter , ICloneable
    {

        public FilterExpression()
        {
 
        }


        public FilterExpression(Filter f)
        {
            this.AddFilter(f);
        }

        public FilterExpression(IList<IFilter> filterList)
        {
            _FiltersList = filterList;
        }


        // This is only override method to simplify programming
        /// <summary>
        /// Adds a new filter to filter expression
        /// </summary>
        /// <param name="columnName">column Name</param>
        /// <param name="value">value</param>
        public FilterExpression(string columnName, object value)
        {
            this.AddFilter(columnName, value);
        }

        // This is only override method to simplify programming
        /// <summary>
        /// Adds a new filter to filter expression
        /// </summary>
        /// <param name="columnName">column Name</param>
        /// <param name="value">value</param>
        /// <param name="filterOperator">filter operator</param>
        public FilterExpression(string columnName, object value, FilterOperatorEnum filterOperator)
        {
            this.AddFilter(columnName, value, filterOperator);
        }


        private IList<IFilter> _FiltersList = new List<IFilter>();

        // TODO: This type is really complicated to be deserialized by Json.
        // To do a workaround, I made another type. However, we need to fix this type later
        //[JsonConverter(typeof(InterfaceJsonConvert))] 
        public IList<IFilter> FiltersList
        {
            get { return _FiltersList; }
            //set { _FiltersList = value; }
        }

        /// <summary>
        /// Gets or sets the logical operator.
        /// </summary>
        /// <value>
        /// The logical operator.
        /// </value>
        public FilterLogicalOperatorEnum LogicalOperator { get; set; }


        /// <summary>
        /// Adds the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        public void AddFilter(Filter filter)
        {
            Check.Require(filter != null);

            FiltersList.Add(filter);
        }

        // This is only override method to simplify programming
        /// <summary>
        /// Adds a new filter to filter expression
        /// </summary>
        /// <param name="columnName">column Name</param>
        /// <param name="value">value</param>
        public void AddFilter(string columnName, object value)
        {
            FiltersList.Add(new Filter(columnName, value));
        }

        // This is only override method to simplify programming
        /// <summary>
        /// Adds a new filter to filter expression
        /// </summary>
        /// <param name="columnName">column Name</param>
        /// <param name="value">value</param>
        public void AddFilter(string columnName, object value, FilterOperatorEnum filterOperator)
        {
            FiltersList.Add(new Filter(columnName, value, filterOperator));
        }

        /// <summary>
        /// Adds the filter expression.
        /// </summary>
        /// <param name="filterExp">The filter exp.</param>
        public void AddFilterExpression(FilterExpression filterExp)
        {
            Check.Require(filterExp != null);

            FiltersList.Add(filterExp);
        }


        /// <summary>
        /// Gets the filter string.
        /// </summary>
        /// <param name="values">The values. Pass an empty list for start</param>
        /// <returns></returns>
        public string GetFilterString(ICollection<object> values)
        {
            List<IFilter> filterList = (List<IFilter>) FiltersList;

            if (filterList.Count == 0)
                return "";

            Check.Require(values != null, "Values parameter can not be null, Pass an empty list for start.");

            if (filterList.Count == 1)
                return filterList[0].GetFilterString(values);


            string operatorString = " " + System.Enum.GetName(typeof(FilterLogicalOperatorEnum), this.LogicalOperator) + " ";
            string s = "";
            int numberOfFilters = 0;
            foreach (IFilter filter in filterList)
            {
                string tmp = filter.GetFilterString(values);
                if (string.IsNullOrEmpty(tmp) == false)
                {
                    s += tmp + operatorString;
                    numberOfFilters++;
                }
            }

            if (string.IsNullOrEmpty(s) == false)
            {
                Check.Ensure(numberOfFilters > 0);

                s = s.Remove(s.Length - operatorString.Length);
                if (numberOfFilters > 1)
                    s = "(" + s + ")";
            }

            return s;
        
        }


        /// <summary>
        /// Merges this filterExpression to another one by AND
        /// </summary>
        /// <param name="filterExp2">The filter exp2.</param>
        public void AndMerge(FilterExpression filterExp2)
        {
            //IMPORTANT NOTE: we HAVE TO add empty filters because they are objects and they might change
            //if (filterExp2.FiltersList.Count == 0) 
            //    return; 

            if (this.LogicalOperator == FilterLogicalOperatorEnum.AND)
                this.FiltersList.Add(filterExp2);
            else
            {
                FilterExpression filterExp1 = (FilterExpression)this.Clone();
                // reseting the status of this object
                this.FiltersList.Clear();
                this.LogicalOperator = FilterLogicalOperatorEnum.AND;
                // adding filter expressions
                this.AddFilterExpression(filterExp1);
                this.AddFilterExpression(filterExp2);
            }
        }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            FilterExpression f = new FilterExpression();
            foreach (var filter in this.FiltersList)
                f.FiltersList.Add(filter);
            //f.FiltersList.AddRange(this.FiltersList);
            f.LogicalOperator = this.LogicalOperator;
            return f;
        }

    }
}
