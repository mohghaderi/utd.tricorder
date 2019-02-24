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
	public partial class vPostType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion //Generator-Safe Area


		public const string EntityName = "PostType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string PostTypeID = "PostTypeID";
			public const string PostTypeName = "PostTypeName";
			public const string PostTypeCode = "PostTypeCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("PostTypeID");
			_ColumnsList.Add("PostTypeName");
			_ColumnsList.Add("PostTypeCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _posttypeid; 
		private string _posttypename; 
		private string _posttypecode; 		
		#endregion

		#region Constructor

		public vPostType()
		 //: base()
		{
			_posttypeid = new byte(); 
			_posttypename = null; 
			_posttypecode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte PostTypeID
		{
			get
			{ 
				return _posttypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PostTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for PostTypeID", value, value.ToString());
				
				_posttypeid = value;
			}

		}
			
		public virtual string PostTypeName
		{
			get
			{ 
				return _posttypename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PostTypeName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for PostTypeName", value, value.ToString());
				
				_posttypename = value;
			}
		}
			
		public virtual string PostTypeCode
		{
			get
			{ 
				return _posttypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PostTypeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for PostTypeCode", value, value.ToString());
				
				_posttypecode = value;
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
            return this.PostTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
