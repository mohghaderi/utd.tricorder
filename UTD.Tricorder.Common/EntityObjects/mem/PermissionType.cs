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
	public partial class PermissionType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion

		#region Private Members
		private int _permissiontypeid;//3

		//private IList<Permission> _PermissionList; 

		private string _permissiontypetitle; 
		private string _permissiontypecode; 		
		#endregion

		#region Constructor

		public PermissionType()
		 //: base()
		{
			_permissiontypeid = -1; 
			//_PermissionList = new List<Permission>(); 
			_permissiontypetitle = null; 
			_permissiontypecode = null; 
		}

		public PermissionType(
			int permissiontypeid, 
			string permissiontypetitle, 
			string permissiontypecode)
			: this()
		{
			_permissiontypeid = permissiontypeid;
			_permissiontypetitle = permissiontypetitle;
			_permissiontypecode = permissiontypecode;
		}
		#endregion // End Constructor

		#region Public Properties
			
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

		//public virtual void AddPermission(Permission obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PermissionList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.PermissionTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
