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
	public partial class MobilePushTemplate : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private byte _mobilepushtemplateid;//3

		//private IList<MobilePushNotification> _MobilePushNotificationList; 

		private string _mobilenotificationtypename; 
		private string _title; 
		private string _alerttext; 
		private bool _isonesufficient; 
		private string _soundfilename; 
		private bool? _delaywhileidle; 
		private int? _timetoliveseconds; private byte _mobilepushdeliverytypeid;//0
//private MobilePushDeliveryType _mobilepushdeliverytypeid;//1
		
		#endregion

		#region Constructor

		public MobilePushTemplate()
		 //: base()
		{
			_mobilepushtemplateid = new byte(); 
			//_MobilePushNotificationList = new List<MobilePushNotification>(); 
			_mobilenotificationtypename = null; 
			_title = null; 
			_alerttext = null; 
			_isonesufficient = false; 
			_soundfilename = null; 
			_delaywhileidle = null; 
			_timetoliveseconds = null; 
			_mobilepushdeliverytypeid = new byte(); 
		}

		public MobilePushTemplate(
			byte mobilepushtemplateid, 
			string mobilenotificationtypename, 
			bool isonesufficient, 
			byte mobilepushdeliverytypeid)
			: this()
		{
			_mobilepushtemplateid = mobilepushtemplateid;
			_mobilenotificationtypename = mobilenotificationtypename;
			_title = String.Empty;
			_alerttext = String.Empty;
			_isonesufficient = isonesufficient;
			_soundfilename = String.Empty;
			_delaywhileidle = null;
			_timetoliveseconds = null;
			_mobilepushdeliverytypeid = mobilepushdeliverytypeid;
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

		//public virtual void AddMobilePushNotification(MobilePushNotification obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_MobilePushNotificationList.Add(obj);
		//}
		


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
