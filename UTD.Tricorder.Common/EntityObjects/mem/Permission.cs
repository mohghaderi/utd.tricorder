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
	public partial class Permission : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion

		#region Private Members

		private long _permissionid; private long? _userid;//0
//private User _userid;//1
private long? _roleid;//0
//private Role _roleid;//1
private long _resourceid;//0
//private Resource _resourceid;//1
private int _permissiontypeid;//0
//private PermissionType _permissiontypeid;//1

		private long _insertuserid; 
		private DateTime _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 		
		#endregion

		#region Constructor

		public Permission()
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
		}

		public Permission(
			long permissionid, 
			long resourceid, 
			int permissiontypeid, 
			long insertuserid, 
			DateTime insertdate)
			: this()
		{
			_permissionid = permissionid;
			_userid = null;
			_roleid = null;
			_resourceid = resourceid;
			_permissiontypeid = permissiontypeid;
			_insertuserid = insertuserid;
			_insertdate = insertdate;
			_updateuserid = null;
			_updatedate = null;
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
