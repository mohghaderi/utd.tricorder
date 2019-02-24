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
	public partial class vPermission : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Permission";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string PermissionID = "PermissionID";
			public const string UserID = "UserID";
			public const string RoleID = "RoleID";
			public const string ResourceID = "ResourceID";
			public const string PermissionTypeID = "PermissionTypeID";
			public const string InsertUserID = "InsertUserID";
			public const string InsertDate = "InsertDate";
			public const string UpdateUserID = "UpdateUserID";
			public const string UpdateDate = "UpdateDate";
			public const string PermissionTypeTitle = "PermissionTypeTitle";
			public const string PermissionTypeCode = "PermissionTypeCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("PermissionID");
			_ColumnsList.Add("UserID");
			_ColumnsList.Add("RoleID");
			_ColumnsList.Add("ResourceID");
			_ColumnsList.Add("PermissionTypeID");
			_ColumnsList.Add("InsertUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("UpdateUserID");
			_ColumnsList.Add("UpdateDate");
			_ColumnsList.Add("PermissionTypeTitle");
			_ColumnsList.Add("PermissionTypeCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _permissionid; 
		private long? _userid; 
		private long? _roleid; 
		private long _resourceid; 
		private int _permissiontypeid; 
		private long _insertuserid; 
		private DateTime _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 
		private string _permissiontypetitle; 
		private string _permissiontypecode; 		
		#endregion

		#region Constructor

		public vPermission()
		 //: base()
		{
			_permissionid = -1; 
			_userid = null; 
			_roleid = null; 
			_resourceid = -1; 
			_permissiontypeid = -1; 
			_insertuserid = -1; 
			_insertdate = DateTime.MinValue; 
			_updateuserid = null; 
			_updatedate = null; 
			_permissiontypetitle = null; 
			_permissiontypecode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long PermissionID
		{
			get
			{ 
				return _permissionid;
			}
			set
			{
				_permissionid = value;
			}

		}
			
		public virtual long? UserID
		{
			get
			{ 
				return _userid;
			}
			set
			{
				_userid = value;
			}

		}
			
		public virtual long? RoleID
		{
			get
			{ 
				return _roleid;
			}
			set
			{
				_roleid = value;
			}

		}
			
		public virtual long ResourceID
		{
			get
			{ 
				return _resourceid;
			}
			set
			{
				_resourceid = value;
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
			
		public virtual long InsertUserID
		{
			get
			{ 
				return _insertuserid;
			}
			set
			{
				_insertuserid = value;
			}

		}
			
		public virtual DateTime InsertDate
		{
			get
			{ 
				return _insertdate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsertDate", value, value.ToString());

				_insertdate = value;	
			}
					
		}
			
		public virtual long? UpdateUserID
		{
			get
			{ 
				return _updateuserid;
			}
			set
			{
				_updateuserid = value;
			}

		}
			
		public virtual DateTime? UpdateDate
		{
			get
			{ 
				return _updatedate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for UpdateDate", value, value.ToString());
						
				_updatedate = value;	
			}			
					
		}
			
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.PermissionID;
			
        }
		
		#endregion //Public Functions
	}
}
