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
	public partial class vMobilePushServer : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "MobilePushServer";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string MobilePushServerID = "MobilePushServerID";
			public const string MobilePushServerName = "MobilePushServerName";
			public const string MobilePushServerCode = "MobilePushServerCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("MobilePushServerID");
			_ColumnsList.Add("MobilePushServerName");
			_ColumnsList.Add("MobilePushServerCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _mobilepushserverid; 
		private string _mobilepushservername; 
		private string _mobilepushservercode; 		
		#endregion

		#region Constructor

		public vMobilePushServer()
		 //: base()
		{
			_mobilepushserverid = new byte(); 
			_mobilepushservername = null; 
			_mobilepushservercode = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte MobilePushServerID
		{
			get
			{ 
				return _mobilepushserverid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobilePushServerID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushServerID", value, value.ToString());
				
				_mobilepushserverid = value;
			}

		}
			
		public virtual string MobilePushServerName
		{
			get
			{ 
				return _mobilepushservername;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobilePushServerName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushServerName", value, value.ToString());
				
				_mobilepushservername = value;
			}
		}
			
		public virtual string MobilePushServerCode
		{
			get
			{ 
				return _mobilepushservercode;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 20)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushServerCode", value, value.ToString());
				
				_mobilepushservercode = value;
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
            return this.MobilePushServerID;
			
        }
		
		#endregion //Public Functions
	}
}
