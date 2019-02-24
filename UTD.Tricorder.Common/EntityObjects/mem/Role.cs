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
	public partial class Role : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion

		#region Private Members
		private long _roleid;//3

		//private IList<Permission> _PermissionList; 

		//private IList<UserInRole> _UserInRoleList; 

		private string _rolename; 
		private string _rolecode; private long _membershipareaid;//0
//private MembershipArea _membershipareaid;//1

		private long? _insertuserid; 
		private DateTime? _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 		
		#endregion

		#region Constructor

		public Role()
		 //: base()
		{
			_roleid = -1; 
			//_PermissionList = new List<Permission>(); 
			//_UserInRoleList = new List<UserInRole>(); 
			_rolename = null; 
			_rolecode = null; 
			_membershipareaid = -1; 
			_insertuserid = null; 
			_insertdate = null; 
			_updateuserid = null; 
			_updatedate = null; 
		}

		public Role(
			long roleid, 
			long membershipareaid)
			: this()
		{
			_roleid = roleid;
			_rolename = String.Empty;
			_rolecode = String.Empty;
			_membershipareaid = membershipareaid;
			_insertuserid = null;
			_insertdate = null;
			_updateuserid = null;
			_updatedate = null;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddPermission(Permission obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PermissionList.Add(obj);
		//}
		

		//public virtual void AddUserInRole(UserInRole obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_UserInRoleList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.RoleID;
			
        }
		
		#endregion //Public Functions
	}
}
