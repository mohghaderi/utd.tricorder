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
	public partial class vNotificationStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "NotificationStatus";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string NotificationStatusTitle = "NotificationStatusTitle";
			public const string NotificationStatusID = "NotificationStatusID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("NotificationStatusTitle");
			_ColumnsList.Add("NotificationStatusID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private string _notificationstatustitle; 
		private byte _notificationstatusid; 		
		#endregion

		#region Constructor

		public vNotificationStatus()
		 //: base()
		{
			_notificationstatustitle = null; 
			_notificationstatusid = new byte(); 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual string NotificationStatusTitle
		{
			get
			{ 
				return _notificationstatustitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for NotificationStatusTitle", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for NotificationStatusTitle", value, value.ToString());
				
				_notificationstatustitle = value;
			}
		}
			
		public virtual byte NotificationStatusID
		{
			get
			{ 
				return _notificationstatusid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for NotificationStatusID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for NotificationStatusID", value, value.ToString());
				
				_notificationstatusid = value;
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
            return this.NotificationStatusTitle;
			
        }
		
		#endregion //Public Functions
	}
}
