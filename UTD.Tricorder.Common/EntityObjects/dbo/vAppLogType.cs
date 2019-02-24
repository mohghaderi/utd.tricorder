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
	public partial class vAppLogType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "AppLogType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string AppLogTypeID = "AppLogTypeID";
			public const string AppLogTypeName = "AppLogTypeName";
			public const string AppLogTypeCode = "AppLogTypeCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("AppLogTypeID");
			_ColumnsList.Add("AppLogTypeName");
			_ColumnsList.Add("AppLogTypeCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private short _applogtypeid; 
		private string _applogtypename; 
		private string _applogtypecode; 		
		#endregion

		#region Constructor

		public vAppLogType()
		 //: base()
		{
			_applogtypeid = -1; 
			_applogtypename = null; 
			_applogtypecode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short AppLogTypeID
		{
			get
			{ 
				return _applogtypeid;
			}
			set
			{
				_applogtypeid = value;
			}

		}
			
		public virtual string AppLogTypeName
		{
			get
			{ 
				return _applogtypename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppLogTypeName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppLogTypeName", value, value.ToString());
				
				_applogtypename = value;
			}
		}
			
		public virtual string AppLogTypeCode
		{
			get
			{ 
				return _applogtypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppLogTypeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppLogTypeCode", value, value.ToString());
				
				_applogtypecode = value;
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
            return this.AppLogTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
