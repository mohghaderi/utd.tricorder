using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    public class GetByFilterParameters
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByFilterParameters"/> class.
        /// </summary>
        /// <param name="entityInfo">The entity info.</param>
        /// <param name="filter">The filter.</param>
        public GetByFilterParameters(FilterExpression filter)
            : this(filter, new SortExpression(), 0, -1, null, GetSourceTypeEnum.Table)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByFilterParameters"/> class.
        /// </summary>
        /// <param name="entityInfo">The entity info.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="sort">The sort.</param>
        public GetByFilterParameters(FilterExpression filter, SortExpression sort)
            : this(filter, sort, 0, -1, null, GetSourceTypeEnum.Table)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByFilterParameters"/> class.
        /// </summary>
        /// <param name="entityInfo">The entity info.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        public GetByFilterParameters(FilterExpression filter, SortExpression sort, int pageIndex, int pageSize)
            : this(filter, sort, pageIndex, pageSize, null, GetSourceTypeEnum.Table)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByFilterParameters"/> class.
        /// </summary>
        /// <param name="entityInfo">The entity info.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="selectColumns">The select columns.</param>
        public GetByFilterParameters(FilterExpression filter, SortExpression sort, int pageIndex, int pageSize, ICollection<string> selectColumns, GetSourceTypeEnum sourceType)
        {
            if (filter != null)
                this.Filter = (FilterExpression)filter.Clone();
            else
                this.Filter = new FilterExpression();

            if (sort != null)
                this.Sort = (SortExpression)sort.Clone();
            else
                this.Sort = new SortExpression();

            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.SelectColumns = selectColumns;
            this.SourceType = sourceType;
        }

        // Removed for security purposes
        ///// <summary>
        ///// This is only for Json convertion. It shouldn't be used for other purposes
        ///// </summary>
        //public GetByFilterParameters()
        //{
        //    this.Filter = new FilterExpression();
        //    this.Sort = new SortExpression();
        //    this.PageIndex = 0;
        //    this.PageSize = -1;
        //    this.SelectColumns = null;
        //    this.SourceType = GetSourceTypeEnum.Table;
        //}

        #endregion


        /// <summary>
        /// Gets or sets the select columns.
        /// </summary>
        /// <value>
        /// The select columns.
        /// </value>
        public ICollection<string> SelectColumns { get; set; }


        private FilterExpression _Filter;

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public FilterExpression Filter 
        {
            get { return _Filter; }
            set
            {
                Check.Require(value != null);
                _Filter = value;
            }
        }


        private SortExpression _sort;

        /// <summary>
        /// Gets or sets the sort.
        /// </summary>
        /// <value>
        /// The sort.
        /// </value>
        public SortExpression Sort 
        {
            get 
            {
                return _sort;
            }
            set 
            {
                Check.Require(value != null);
                _sort = value;
            }
        }


        
        private int _PageIndex = 0;

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        public int PageIndex 
        {
            get { return _PageIndex; }
            set 
            {
                Check.Require(value >= 0);
                _PageIndex = value;
            }
        }



        private int _PageSize = -1;

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize 
        {
            get { return _PageSize; }
            set 
            {
                Check.Require(value > 0 || value == -1);
                _PageSize = value; 
            }
        }

        /// <summary>
        /// Gets or sets the type of the get. (Table or view)
        /// </summary>
        /// <value>
        /// The type of the get. (Table or view)
        /// </value>
        public GetSourceTypeEnum SourceType
        {
            get;
            set;
        }


    }
}
