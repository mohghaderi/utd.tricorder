using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Framework.Common
{    
    
    /// <summary>
    /// Single filter that keeps the column name and operator and value for that operator
    /// </summary>
    public class Filter : IFilter
    {
        public const string ParameterPrefix = ":P";


        private string _ColumnName;
        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        public string ColumnName 
        {
            get { return _ColumnName; }
            // !Should be no Set here. Since these are objects, and sending through layers, change in lower layers or inner functions can affect outside functions
            //set;
        }

        private FilterOperatorEnum _Operator;
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>
        /// The operator.
        /// </value>
        public FilterOperatorEnum Operator 
        {
            get { return _Operator; }
            // !Should be no Set here. Since these are objects, and sending through layers, change in lower layers or inner functions can affect outside functions
            //set; 
        }


        private object _Value;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value
        {
            get { return _Value; }
            // !Should be no Set here. Since these are objects, and sending through layers, change in lower layers or inner functions can affect outside functions
            //set
            //{
            //    // check to make sure that the value type is suitable for the provided operator
            //    CheckValueTypeRegardingTheOperator(value, this.Operator);
            //    _Value = value;
            //}
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Filter" /> class.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="value">The value.</param>
        public Filter(string columnName, object value)
            : this(columnName, value, FilterOperatorEnum.EqualTo)
        {

        }


        ///// <summary>
        ///// Initializes a new instance of the <see cref="Filter" /> class.
        ///// </summary>
        ///// <param name="columnName">Name of the column.</param>
        ///// <param name="value">The value.</param>
        //public Filter(string columnName, FilterOperatorEnum filterOperator)
        //    : this(columnName, null, filterOperator)
        //{

        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="Filter" /> class.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="value">The value.</param>
        /// <param name="filterOperator">The filter operator.</param>
        public Filter(string columnName, object value, FilterOperatorEnum filterOperator)
        {
            Check.Require(string.IsNullOrEmpty(columnName) == false);
            CheckValueTypeRegardingTheOperator(value, filterOperator);

            _ColumnName = columnName;
            _Operator = filterOperator;
            CheckValueTypeRegardingTheOperator(value, this.Operator);
            _Value = value;
        }



        /// <summary>
        /// Gets the filter string.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetFilterString(ICollection<object> values)
        {
            int parameterStartIndex = values.Count;

            string colName = "[" + this.ColumnName + "]";
            string paramName = ParameterPrefix + parameterStartIndex.ToString();
            StringBuilder sb = new StringBuilder();

            switch (this.Operator)
            {
                case FilterOperatorEnum.NoFilter:
                    values.Add(this.Value);
                    break;
                case FilterOperatorEnum.Contains:
                    sb.Append(colName).Append(" like ").Append(paramName);
                    values.Add("%" + this.Value + "%");
                    break;
                case FilterOperatorEnum.DoesNotContain:
                    sb.Append(colName).Append(" not like ").Append(paramName);
                    values.Add("%" + this.Value + "%");
                    break;
                case FilterOperatorEnum.StartsWith:
                    sb.Append(colName).Append(" like ").Append(paramName);
                    values.Add(this.Value + "%");
                    break;
                case FilterOperatorEnum.EndsWith:
                    sb.Append(colName).Append(" like ").Append(paramName);
                    values.Add("%" + this.Value);
                    break;
                case FilterOperatorEnum.EqualTo:
                    sb.Append(colName).Append(" = ").Append(paramName);
                    values.Add(this.Value);
                    break;
                case FilterOperatorEnum.NotEqualTo:
                    sb.Append(colName).Append(" != ").Append(paramName);
                    values.Add(this.Value);
                    break;
                case FilterOperatorEnum.GreaterThan:
                    sb.Append(colName).Append(" > ").Append(paramName);
                    values.Add(this.Value);
                    break;
                case FilterOperatorEnum.LessThan:
                    sb.Append(colName).Append(" < ").Append(paramName);
                    values.Add(this.Value);
                    break;
                case FilterOperatorEnum.GreaterThanOrEqualTo:
                    sb.Append(colName).Append(" >= ").Append(paramName);
                    values.Add(this.Value);
                    break;
                case FilterOperatorEnum.LessThanOrEqualTo:
                    sb.Append(colName).Append(" <= ").Append(paramName);
                    values.Add(this.Value);
                    break;
                case FilterOperatorEnum.IsEmpty:
                    sb.Append(colName).Append(" = '' ");
                    break;
                case FilterOperatorEnum.NotIsEmpty:
                    sb.Append(colName).Append(" != '' ");
                    break;
                case FilterOperatorEnum.IsNull:
                    sb.Append(colName).Append(" is null ");
                    break;
                case FilterOperatorEnum.NotIsNull:
                    sb.Append(colName).Append(" is not null ");
                    break;
                case FilterOperatorEnum.Like:
                    sb.Append(colName).Append(" like ").Append(paramName);

                    values.Add("%" + this.Value + "%");
                    break;
                case FilterOperatorEnum.In:
                    {
                        string inValues = "";
                        if (this.Value is string)
                            inValues = this.Value.ToString();

                        if (this.Value is IEnumerable)
                            inValues = FWUtils.CommaSeperatedUtils.ConverToCommaSeperatedString(((IEnumerable)this.Value), true);

                        Check.Require(string.IsNullOrEmpty(inValues) == false);

                        sb.Append(colName).Append(" in (").Append(inValues).Append(")");
                    }
                    break;
                case FilterOperatorEnum.InSelect:
                    sb.Append(colName).Append(" in (").Append(this.Value.ToString()).Append(")");
                    break;
                default:
                    throw new NotImplementedException();
            }


            return sb.ToString();


        }



        /// <summary>
        /// Checks the value type regarding the operator.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="filterOperator">The filter operator.</param>
        private static void CheckValueTypeRegardingTheOperator(object value, FilterOperatorEnum filterOperator)
        {
            switch (filterOperator)
            {
                case FilterOperatorEnum.NoFilter:
                    break;
                case FilterOperatorEnum.Contains:
                    Check.Require(value is string);
                    break;
                case FilterOperatorEnum.DoesNotContain:
                    Check.Require(value is string);
                    break;
                case FilterOperatorEnum.StartsWith:
                    Check.Require(value is string);
                    break;
                case FilterOperatorEnum.EndsWith:
                    Check.Require(value is string);
                    break;
                case FilterOperatorEnum.EqualTo:
                    Check.Require(value != null);
                    break;
                case FilterOperatorEnum.NotEqualTo:
                    Check.Require(value != null);
                    break;
                case FilterOperatorEnum.GreaterThan:
                    Check.Require(value != null);
                    break;
                case FilterOperatorEnum.LessThan:
                    Check.Require(value != null);
                    break;
                case FilterOperatorEnum.GreaterThanOrEqualTo:
                    Check.Require(value != null);
                    break;
                case FilterOperatorEnum.LessThanOrEqualTo:
                    Check.Require(value != null);
                    break;
                case FilterOperatorEnum.IsEmpty:
                    Check.Require(value == null);
                    break;
                case FilterOperatorEnum.NotIsEmpty:
                    Check.Require(value == null);
                    break;
                case FilterOperatorEnum.IsNull:
                    Check.Require(value == null);
                    break;
                case FilterOperatorEnum.NotIsNull:
                    Check.Require(value == null);
                    break;
                case FilterOperatorEnum.Like:
                    Check.Require(value is string);
                    break;
                case FilterOperatorEnum.In:
                    Check.Require(value is string || value is IEnumerable);
                    break;
                case FilterOperatorEnum.InSelect:
                    Check.Require(value is string);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

    }

}