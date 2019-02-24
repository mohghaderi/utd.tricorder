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
	public partial class vMobilePushTemplate : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "MobilePushTemplate";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string MobilePushTemplateID = "MobilePushTemplateID";
			public const string MobileNotificationTypeName = "MobileNotificationTypeName";
			public const string Title = "Title";
			public const string AlertText = "AlertText";
			public const string IsOneSufficient = "IsOneSufficient";
			public const string SoundFileName = "SoundFileName";
			public const string DelayWhileIdle = "DelayWhileIdle";
			public const string TimeToLiveSeconds = "TimeToLiveSeconds";
			public const string MobilePushDeliveryTypeID = "MobilePushDeliveryTypeID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("MobilePushTemplateID");
			_ColumnsList.Add("MobileNotificationTypeName");
			_ColumnsList.Add("Title");
			_ColumnsList.Add("AlertText");
			_ColumnsList.Add("IsOneSufficient");
			_ColumnsList.Add("SoundFileName");
			_ColumnsList.Add("DelayWhileIdle");
			_ColumnsList.Add("TimeToLiveSeconds");
			_ColumnsList.Add("MobilePushDeliveryTypeID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _mobilepushtemplateid; 
		private string _mobilenotificationtypename; 
		private string _title; 
		private string _alerttext; 
		private bool _isonesufficient; 
		private string _soundfilename; 
		private bool? _delaywhileidle; 
		private int? _timetoliveseconds; 
		private byte _mobilepushdeliverytypeid; 		
		#endregion

		#region Constructor

		public vMobilePushTemplate()
		 //: base()
		{
			_mobilepushtemplateid = new byte(); 
			_mobilenotificationtypename = null; 
			_title = null; 
			_alerttext = null; 
			_isonesufficient = false; 
			_soundfilename = null; 
			_delaywhileidle = null; 
			_timetoliveseconds = null; 
			_mobilepushdeliverytypeid = new byte(); 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte MobilePushTemplateID
		{
			get
			{ 
				return _mobilepushtemplateid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobilePushTemplateID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushTemplateID", value, value.ToString());
				
				_mobilepushtemplateid = value;
			}

		}
			
		public virtual string MobileNotificationTypeName
		{
			get
			{ 
				return _mobilenotificationtypename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobileNotificationTypeName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobileNotificationTypeName", value, value.ToString());
				
				_mobilenotificationtypename = value;
			}
		}
			
		public virtual string Title
		{
			get
			{ 
				return _title;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
				
				_title = value;
			}
		}
			
		public virtual string AlertText
		{
			get
			{ 
				return _alerttext;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for AlertText", value, value.ToString());
				
				_alerttext = value;
			}
		}
			
		public virtual bool IsOneSufficient
		{
			get
			{ 
				return _isonesufficient;
			}
			set
			{
				_isonesufficient = value;
			}

		}
			
		public virtual string SoundFileName
		{
			get
			{ 
				return _soundfilename;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for SoundFileName", value, value.ToString());
				
				_soundfilename = value;
			}
		}
			
		public virtual bool? DelayWhileIdle
		{
			get
			{ 
				return _delaywhileidle;
			}
			set
			{
				_delaywhileidle = value;
			}

		}
			
		public virtual int? TimeToLiveSeconds
		{
			get
			{ 
				return _timetoliveseconds;
			}
			set
			{
				_timetoliveseconds = value;
			}

		}
			
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.MobilePushTemplateID;
			
        }
		
		#endregion //Public Functions
	}
}
