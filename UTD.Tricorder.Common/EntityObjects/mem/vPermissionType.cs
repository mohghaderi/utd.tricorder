using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Framework.Common;
using Framework.Common.Entity;
using System.Diagnostics.CodeAnalysis;


namespace UTD.Tricorder.Common.EntityObjects

{
	[Serializable]
	[ExcludeFromCodeCoverage]
	public partial class vPermissionType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "PermissionType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string PermissionTypeTitle = "PermissionTypeTitle";
			public const string PermissionTypeCode = "PermissionTypeCode";
			public const string PermissionTypeID = "PermissionTypeID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("PermissionTypeTitle");
			_ColumnsList.Add("PermissionTypeCode");
			_ColumnsList.Add("PermissionTypeID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private string _permissiontypetitle; 
		private string _permissiontypecode; 
		private int _permissiontypeid; 		
		#endregion

		#region Constructor

		public vPermissionType()
		 //: base()
		{
			_permissiontypetitle = null; 
			_permissiontypecode = null; 
			_permissiontypeid = -1; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual string PermissionTypeTitle
		{
			get
			{ 
				return _permissiontypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PermissionTypeTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for PermissionTypeTitle", value, value.ToString());
				
				_permissiontypetitle = value;
			}
		}
			
		public virtual string PermissionTypeCode
		{
			get
			{ 
				return _permissiontypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PermissionTypeCode", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for PermissionTypeCode", value, value.ToString());
				
				_permissiontypecode = value;
			}
		}
			
		public virtual int PermissionTypeID
		{
			get
			{ 
				return _permissiontypeid;
			}
			set
			{
				_permissiontypeid = value;
			}

		}
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.PermissionTypeTitle;
			
        }
		
		#endregion //Public Functions
	}
}
