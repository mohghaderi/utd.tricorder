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
	public partial class vUserDeviceClientAppType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "UserDeviceClientAppType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string UserDeviceClientAppTypeID = "UserDeviceClientAppTypeID";
			public const string UserDeviceClientAppTypeCode = "UserDeviceClientAppTypeCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("UserDeviceClientAppTypeID");
			_ColumnsList.Add("UserDeviceClientAppTypeCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _userdeviceclientapptypeid; 
		private string _userdeviceclientapptypecode; 		
		#endregion

		#region Constructor

		public vUserDeviceClientAppType()
		 //: base()
		{
			_userdeviceclientapptypeid = new byte(); 
			_userdeviceclientapptypecode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte UserDeviceClientAppTypeID
		{
			get
			{ 
				return _userdeviceclientapptypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UserDeviceClientAppTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserDeviceClientAppTypeID", value, value.ToString());
				
				_userdeviceclientapptypeid = value;
			}

		}
			
		public virtual string UserDeviceClientAppTypeCode
		{
			get
			{ 
				return _userdeviceclientapptypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UserDeviceClientAppTypeCode", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserDeviceClientAppTypeCode", value, value.ToString());
				
				_userdeviceclientapptypecode = value;
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
            return this.UserDeviceClientAppTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
