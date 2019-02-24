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
	public partial class UserInRole : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion

		#region Private Members

		private long _userinroleid; private long _userid;//0
//private User _userid;//1
private long _roleid;//0
//private Role _roleid;//1

		private long? _insertuserid; 
		private DateTime? _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 
		private DateTime _startdate; 
		private DateTime? _enddate; 
		private bool _isactive; 		
		#endregion

		#region Constructor

		public UserInRole()
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
		}

		public UserInRole(
			long userinroleid, 
			long userid, 
			long roleid, 
			DateTime startdate, 
			bool isactive)
			: this()
		{
			_userinroleid = userinroleid;
			_userid = userid;
			_roleid = roleid;
			_insertuserid = null;
			_insertdate = null;
			_updateuserid = null;
			_updatedate = null;
			_startdate = startdate;
			_enddate = null;
			_isactive = isactive;
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
