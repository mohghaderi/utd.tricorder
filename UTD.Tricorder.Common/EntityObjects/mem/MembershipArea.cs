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
	public partial class MembershipArea : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion

		#region Private Members
		private long _membershipareaid;//3

		//private IList<MembershipArea> _MembershipAreaList; 

		//private IList<Role> _RoleList; 

		//private IList<User> _UserList; 
private long? _parentid;//0
//private MembershipArea _parentid;//1

		private string _membershipareaname; 
		private string _membershipareacode; 		
		#endregion

		#region Constructor

		public MembershipArea()
		 //: base()
		{
			_membershipareaid = -1; 
			//_MembershipAreaList = new List<MembershipArea>(); 
			//_RoleList = new List<Role>(); 
			//_UserList = new List<User>(); 
			_parentid = null; 
			_membershipareaname = null; 
			_membershipareacode = null; 
		}

		public MembershipArea(
			long membershipareaid, 
			string membershipareaname, 
			string membershipareacode)
			: this()
		{
			_membershipareaid = membershipareaid;
			_parentid = null;
			_membershipareaname = membershipareaname;
			_membershipareacode = membershipareacode;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual long? ParentID
		{
			get
			{ 
				return _parentid;
			}
			set
			{
				_parentid = value;
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
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddMembershipArea(MembershipArea obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_MembershipAreaList.Add(obj);
		//}
		

		//public virtual void AddRole(Role obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_RoleList.Add(obj);
		//}
		

		//public virtual void AddUser(User obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_UserList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.MembershipAreaID;
			
        }
		
		#endregion //Public Functions
	}
}
