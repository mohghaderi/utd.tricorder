using System;

namespace Framework.Common
{

    /// <summary>
    /// Entity Columns Information
    /// </summary>
    public class ColumnInfo
    {

        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        public string Name
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>
        /// The caption.
        /// </value>
        public string Caption
        {
            get;
            set;
        }


        /// <summary>
        /// Gets the data type dot net.
        /// </summary>
        /// <value>
        /// The data type dot net.
        /// </value>
        public Type DataTypeDotNet
        {
            get;
            set;
        }

        ///// <summary>
        ///// Gets the type of the data.
        ///// </summary>
        ///// <value>
        ///// The type of the data.
        ///// </value>
        //public DBDataType DataType
        //{
        //    get;
        //    set;
        //}



        /// <summary>
        /// Gets a value indicating whether this instance is editable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is editable; otherwise, <c>false</c>.
        /// </value>
        public bool IsUpdatable
        {
            get;
            set;
        }


        /// <summary>
        /// Gets a value indicating whether this instance is insertable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is insertable; otherwise, <c>false</c>.
        /// </value>
        public bool IsInsertable
        {
            get;
            set;
        }


        /// <summary>
        /// Gets a value indicating whether this instance is foreign key.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is foreign key; otherwise, <c>false</c>.
        /// </value>
        public bool IsForeignKey
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the name of the foreign entity.
        /// </summary>
        /// <value>
        /// The name of the foreign entity.
        /// </value>
        public string ForeignEntityName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the foreign entity additional data key.
        /// </summary>
        /// <value>
        /// The foreign entity additional data key.
        /// </value>
        public string ForeignEntityAdditionalDataKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the foreign entity map column.
        /// For example, when DepID column in Person Entity will be mapped to DepartmentID in Department Entity:
        /// Name=Person.ColumnNames.DepID, IsForeignKey=true, ForeignEntityName=Department.EntityName, ForeignEntityMapColumnName=Department.ColumnNames.DepartmentID
        /// </summary>
        /// <value>
        /// The name of the foreign entity map column.
        /// </value>
        public string ForeignEntityMapColumnName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is primary key.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is primary key; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrimaryKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is client column.
        /// This column will be rendered to the store even though it is not available in grid
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is client column; otherwise, <c>false</c>.
        /// </value>
        public bool IsClientColumn
        {
            get;
            set;
        }


        /// <summary>
        /// Gets the max length value.
        /// This is only for string and byte[]
        /// </summary>
        /// <value>
        /// The max length value.
        /// </value>
        public int ValidationMaxLength
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum length of the edit.
        /// This is only for string and byte[]
        /// </summary>
        /// <value>
        /// The minimum length of the edit.
        /// </value>
        public int ValidationMinLength
        {
            get;
            set;
        }



        /// <summary>
        /// Gets or sets a value indicating whether [validation is nullable].
        /// </summary>
        /// <value>
        /// <c>true</c> if [validation is nullable]; otherwise, <c>false</c>.
        /// </value>
        public bool ValidationIsNullable
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the validation minimum value.
        /// </summary>
        /// <value>
        /// The validation minimum value.
        /// </value>
        public object ValidationMinValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the validation maximum value.
        /// </summary>
        /// <value>
        /// The validation maximum value.
        /// </value>
        public object ValidationMaxValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [validation is unique].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [validation is unique]; otherwise, <c>false</c>.
        /// </value>
        public bool ValidationNoDuplicate
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the size of the column.
        /// </summary>
        /// <value>
        /// The size of the column.
        /// </value>
        public int GridColumnSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ColumnInfo" /> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool GridVisible
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the grid text align.
        /// </summary>
        /// <value>
        /// The grid text align.
        /// </value>
        public TextAlignEnum GridTextAlign { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether [grid allow filter].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [grid allow filter]; otherwise, <c>false</c>.
        /// </value>
        public bool GridAllowFilter { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether [grid is auto expand].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [grid is auto expand]; otherwise, <c>false</c>.
        /// </value>
        public bool GridIsAutoExpand { get; set; }



        /// <summary>
        /// Gets or sets a value indicating whether [grid is inplace editable].
        /// </summary>
        /// <value>
        /// <c>true</c> if [grid is inplace editable]; otherwise, <c>false</c>.
        /// </value>
        public bool GridIsInplaceEditable { get; set; }



        /// <summary>
        /// Gets or sets a value indicating whether [pick list visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pick list visible]; otherwise, <c>false</c>.
        /// </value>
        public bool PickListVisible { get; set; }



        /// <summary>
        /// Gets or sets the editor control.
        /// </summary>
        /// <value>
        /// The editor control.
        /// </value>
        public EditorControlTypes EditorControl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [edit form is read only].
        /// </summary>
        /// <value>
        /// <c>true</c> if [edit form is read only]; otherwise, <c>false</c>.
        /// </value>
        public bool EditFormIsReadOnly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [edit form is hidden].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [edit form is hidden]; otherwise, <c>false</c>.
        /// </value>
        public bool EditFormIsHidden
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets a value indicating whether [drop down use custom load].
        /// </summary>
        /// <value>
        /// <c>true</c> if [drop down use custom load]; otherwise, <c>false</c>.
        /// </value>
        public bool DropDownUseCustomLoad
        {
            get;
            set;
        }

        ///// <summary>
        ///// Gets the editor settings1.
        ///// </summary>
        ///// <value>
        ///// The editor settings1.
        ///// </value>
        //public string EditorSettings1
        //{
        //    get;
        //    set;
        //}


        ///// <summary>
        ///// Gets the editor settings2.
        ///// </summary>
        ///// <value>
        ///// The editor settings2.
        ///// </value>
        //public string EditorSettings2
        //{
        //    get;
        //    set;
        //}


        ///// <summary>
        ///// Gets the editor settings3.
        ///// </summary>
        ///// <value>
        ///// The editor settings3.
        ///// </value>
        //public string EditorSettings3
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// Gets or sets the index of the form layout region.
        ///// </summary>
        ///// <value>
        ///// The index of the form layout region.
        ///// </value>
        //public string FormLayoutRegionIndex
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// Gets or sets the index of the form layout field.
        ///// </summary>
        ///// <value>
        ///// The index of the form layout field.
        ///// </value>
        //public int FormLayoutFieldIndex
        //{
        //    get;
        //    set;
        //}




        ///// <summary>
        ///// Gets or sets a value indicating whether this instance is custom field.
        ///// </summary>
        ///// <value>
        ///// <c>true</c> if this instance is custom field; otherwise, <c>false</c>.
        ///// </value>
        //public bool IsCustomField
        //{
        //    get;
        //    set;
        //}





        ///// <summary>
        ///// Gets a value indicating whether this instance is localizable.
        ///// </summary>
        ///// <value>
        ///// <c>true</c> if this instance is localizable; otherwise, <c>false</c>.
        ///// </value>
        //public bool IsLocalizable
        //{
        //    get;
        //    set;
        //}



        ///// <summary>
        ///// Gets a value indicating whether this instance is numeric field.
        ///// </summary>
        ///// <value>
        ///// <c>true</c> if this instance is numeric field; otherwise, <c>false</c>.
        ///// </value>
        //public bool IsNumericField
        //{
        //    get
        //    {
        //        return (DataType == DBDataType.Float || DataType == DBDataType.Int32 || DataType == DBDataType.Int64 || DataType == DBDataType.Double);
        //    }
        //}

    }


}
