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
	public partial class vUserInRole : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "UserInRole";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string UserInRoleID = "UserInRoleID";
			public const string UserID = "UserID";
			public const string RoleID = "RoleID";
			public const string InsertUserID = "InsertUserID";
			public const string InsertDate = "InsertDate";
			public const string UpdateUserID = "UpdateUserID";
			public const string UpdateDate = "UpdateDate";
			public const string StartDate = "StartDate";
			public const string EndDate = "EndDate";
			public const string IsActive = "IsActive";
			public const string RoleName = "RoleName";
			public const string RoleCode = "RoleCode";
			public const string MembershipAreaName = "MembershipAreaName";
			public const string MembershipAreaCode = "MembershipAreaCode";
			public const string MembershipAreaID = "MembershipAreaID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("UserInRoleID");
			_ColumnsList.Add("UserID");
			_ColumnsList.Add("RoleID");
			_ColumnsList.Add("InsertUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("UpdateUserID");
			_ColumnsList.Add("UpdateDate");
			_ColumnsList.Add("StartDate");
			_ColumnsList.Add("EndDate");
			_ColumnsList.Add("IsActive");
			_ColumnsList.Add("RoleName");
			_ColumnsList.Add("RoleCode");
			_ColumnsList.Add("MembershipAreaName");
			_ColumnsList.Add("MembershipAreaCode");
			_ColumnsList.Add("MembershipAreaID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _userinroleid; 
		private long _userid; 
		private long _roleid; 
		private long? _insertuserid; 
		private DateTime? _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 
		private DateTime _startdate; 
		private DateTime? _enddate; 
		private bool _isactive; 
		private string _rolename; 
		private string _rolecode; 
		private string _membershipareaname; 
		private string _membershipareacode; 
		private long _membershipareaid; 		
		#endregion

		#region Constructor

		public vUserInRole()
		 //: base()
		{
			_userinroleid = -1; 
			_userid = -1; 
			_roleid = -1; 
			_insertuserid = null; 
			_insertdate = null; 
			_updateuserid = null; 
			_updatedate = null; 
			_startdate = DateTime.MinValue; 
			_enddate = null; 
			_isactive = false; 
			_rolename = null; 
			_rolecode = null; 
			_membershipareaname = null; 
			_membershipareacode = null; 
			_membershipareaid = -1; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long UserInRoleID
		{
			get
			{ 
				return _userinroleid;
			}
			set
			{
				_userinroleid = value;
			}

		}
			
		public virtual long UserID
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
			
		public virtual long RoleID
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
			
		public virtual long? InsertUserID
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
			
		public virtual DateTime? InsertDate
		{
			get
			{ 
				return _insertdate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
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
			
		public virtual DateTime StartDate
		{
			get
			{ 
				return _startdate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for StartDate", value, value.ToString());

				_startdate = value;	
			}
					
		}
			
		public virtual DateTime? EndDate
		{
			get
			{ 
				return _enddate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for EndDate", value, value.ToString());
						
				_enddate = value;	
			}			
					
		}
			
		public virtual bool IsActive
		{
			get
			{ 
				return _isactive;
			}
			set
			{
				_isactive = value;
			}

		}
			
		public virtual string RoleName
		{
			get
			{ 
				return _rolename;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for RoleName", value, value.ToString());
				
				_rolename = value;
			}
		}
			
		public virtual string RoleCode
		{
			get
			{ 
				return _rolecode;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for RoleCode", value, value.ToString());
				
				_rolecode = value;
			}
		}
			
		public virtual string MembershipAreaName
		{
			get
			{ 
				return _membershipareaname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MembershipAreaName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MembershipAreaName", value, value.ToString());
				
				_membershipareaname = value;
			}
		}
			
		public virtual string MembershipAreaCode
		{
			get
			{ 
				return _membershipareacode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MembershipAreaCode", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MembershipAreaCode", value, value.ToString());
				
				_membershipareacode = value;
			}
		}
			
		public virtual long MembershipAreaID
		{
			get
			{ 
				return _membershipareaid;
			}
			set
			{
				_membershipareaid = value;
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
            return this.UserInRoleID;
			
        }
		
		#endregion //Public Functions
	}
}
