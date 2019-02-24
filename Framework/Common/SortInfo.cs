using System;

namespace Framework.Common
{
    /// <summary>
    /// Keeps information about sorting columns
    /// </summary>
    public class SortInfo : ICloneable
    {

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
            //set 
            //{
            //    Check.Require(string.IsNullOrEmpty(value) == false);
            //    _ColumnName = value;
            //}
        }


        private SortDirectionEnum _Direction;
        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        public SortDirectionEnum Direction
        {
            get { return _Direction; }
            // !Should be no Set here. Since these are objects, and sending through layers, change in lower layers or inner functions can affect outside functions
            //set;
        }



        /// <summary>
        /// Gets the sort direction string.
        /// </summary>
        /// <returns></returns>
        public string GetSortDirectionString()
        {
            return GetSortDirectionString(this.Direction);
        }


        /// <summary>
        /// Gets the sort direction string.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public static string GetSortDirectionString(SortDirectionEnum st)
        {
            switch (st)
            {
                case SortDirectionEnum.ASC:
                    return "ASC";
                case SortDirectionEnum.DESC:
                    return "DESC";
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortInfo" /> class.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="direction">The direction.</param>
        public SortInfo(string columnName, SortDirectionEnum direction)
        {
            Check.Require(string.IsNullOrEmpty(columnName) == false);

            _ColumnName = columnName;
            _Direction = direction;
        }


        public object Clone()
        {
            return new SortInfo(this.ColumnName, this.Direction);
        }
    }
}
