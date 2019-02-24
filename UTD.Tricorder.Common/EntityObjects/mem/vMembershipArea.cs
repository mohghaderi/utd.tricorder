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
	public partial class vMembershipArea : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "MembershipArea";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string MembershipAreaID = "MembershipAreaID";
			public const string ParentID = "ParentID";
			public const string MembershipAreaCode = "MembershipAreaCode";
			public const string MembershipAreaName = "MembershipAreaName";
			public const string ParentMembershipAreaName = "ParentMembershipAreaName";
			public const string ParentMembershipAreaCode = "ParentMembershipAreaCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("MembershipAreaID");
			_ColumnsList.Add("ParentID");
			_ColumnsList.Add("MembershipAreaCode");
			_ColumnsList.Add("MembershipAreaName");
			_ColumnsList.Add("ParentMembershipAreaName");
			_ColumnsList.Add("ParentMembershipAreaCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _membershipareaid; 
		private long? _parentid; 
		private string _membershipareacode; 
		private string _membershipareaname; 
		private string _parentmembershipareaname; 
		private string _parentmembershipareacode; 		
		#endregion

		#region Constructor

		public vMembershipArea()
		 //: base()
		{
			_membershipareaid = -1; 
			_parentid = null; 
			_membershipareacode = null; 
			_membershipareaname = null; 
			_parentmembershipareaname = null; 
			_parentmembershipareacode = null; 
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
			
		public virtual string ParentMembershipAreaName
		{
			get
			{ 
				return _parentmembershipareaname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ParentMembershipAreaName", value, value.ToString());
				
				_parentmembershipareaname = value;
			}
		}
			
		public virtual string ParentMembershipAreaCode
		{
			get
			{ 
				return _parentmembershipareacode;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ParentMembershipAreaCode", value, value.ToString());
				
				_parentmembershipareacode = value;
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
            return this.MembershipAreaID;
			
        }
		
		#endregion //Public Functions
	}
}
