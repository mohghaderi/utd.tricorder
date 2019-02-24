using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Common
{
    /// <summary>
    /// Keeps information about sort columns and the sort direction
    /// </summary>
    public class SortExpression : ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SortExpression" /> class.
        /// </summary>
        public SortExpression()
        {
 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortExpression" /> class.
        /// It adds one sort column with ASC direction
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        public SortExpression(string columnName)
        {
            AddSort(new SortInfo(columnName, SortDirectionEnum.ASC));
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="SortExpression" /> class.
        /// It adds one sort column with ASC direction
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        public SortExpression(string columnName, SortDirectionEnum sortDirection)
        {
            AddSort(new SortInfo(columnName, sortDirection));
        }


        private List<SortInfo> _SortInfoList = new List<SortInfo>();

        /// <summary>
        /// Gets the sort info list.
        /// </summary>
        /// <value>
        /// The sort info list.
        /// </value>
        public ICollection<SortInfo> SortInfoList
        {
            get { return _SortInfoList; }        
        }

        /// <summary>
        /// Adds the sort.
        /// </summary>
        /// <param name="sort">The sort.</param>
        public SortExpression AddSort(SortInfo sort)
        {
            Check.Require(sort != null);
            SortInfoList.Add(sort);
            return this;
        }

        public SortExpression AddSort(string columnName)
        {
            SortInfoList.Add(new SortInfo(columnName, SortDirectionEnum.ASC));
            return this;
        }

        /// <summary>
        /// Adds the sort.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        public SortExpression AddSort(string columnName, SortDirectionEnum sortDirection)
        {
            SortInfoList.Add(new SortInfo(columnName, sortDirection));
            return this;
        }


        /// <summary>
        /// Gets the sort expression string.
        /// </summary>
        /// <returns></returns>
        public string GetSortExpressionString()
        {
            if (this.SortInfoList == null || this.SortInfoList.Count == 0)
                return "";


            StringBuilder sb = new StringBuilder();

            foreach (SortInfo obj in this.SortInfoList)
                sb.Append(obj.ColumnName).Append(" ").Append(obj.GetSortDirectionString()).Append(",");

            if (sb.Length > 0)
                sb = sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }




        public object Clone()
        {
            SortExpression sort = new SortExpression();
            foreach (SortInfo s in this.SortInfoList)
                sort.SortInfoList.Add((SortInfo) s.Clone());
            return sort;
        }

    }

}