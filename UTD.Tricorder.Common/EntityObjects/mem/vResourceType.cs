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
	public partial class vResourceType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "ResourceType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string ResourceTypeID = "ResourceTypeID";
			public const string ResourceTypeTitle = "ResourceTypeTitle";
			public const string ResourceTypeCode = "ResourceTypeCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("ResourceTypeID");
			_ColumnsList.Add("ResourceTypeTitle");
			_ColumnsList.Add("ResourceTypeCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _resourcetypeid; 
		private string _resourcetypetitle; 
		private string _resourcetypecode; 		
		#endregion

		#region Constructor

		public vResourceType()
		 //: base()
		{
			_resourcetypeid = -1; 
			_resourcetypetitle = null; 
			_resourcetypecode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int ResourceTypeID
		{
			get
			{ 
				return _resourcetypeid;
			}
			set
			{
				_resourcetypeid = value;
			}

		}
			
		public virtual string ResourceTypeTitle
		{
			get
			{ 
				return _resourcetypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ResourceTypeTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ResourceTypeTitle", value, value.ToString());
				
				_resourcetypetitle = value;
			}
		}
			
		public virtual string ResourceTypeCode
		{
			get
			{ 
				return _resourcetypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ResourceTypeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for ResourceTypeCode", value, value.ToString());
				
				_resourcetypecode = value;
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
            return this.ResourceTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
