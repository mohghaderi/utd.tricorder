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
	public partial class vMobilePushDeliveryType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "MobilePushDeliveryType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string MobilePushDeliveryTypeID = "MobilePushDeliveryTypeID";
			public const string MobilePushDeliveryTypeName = "MobilePushDeliveryTypeName";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("MobilePushDeliveryTypeID");
			_ColumnsList.Add("MobilePushDeliveryTypeName");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _mobilepushdeliverytypeid; 
		private string _mobilepushdeliverytypename; 		
		#endregion

		#region Constructor

		public vMobilePushDeliveryType()
		 //: base()
		{
			_mobilepushdeliverytypeid = new byte(); 
			_mobilepushdeliverytypename = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte MobilePushDeliveryTypeID
		{
			get
			{ 
				return _mobilepushdeliverytypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobilePushDeliveryTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushDeliveryTypeID", value, value.ToString());
				
				_mobilepushdeliverytypeid = value;
			}

		}
			
		public virtual string MobilePushDeliveryTypeName
		{
			get
			{ 
				return _mobilepushdeliverytypename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobilePushDeliveryTypeName", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushDeliveryTypeName", value, value.ToString());
				
				_mobilepushdeliverytypename = value;
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
            return this.MobilePushDeliveryTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
