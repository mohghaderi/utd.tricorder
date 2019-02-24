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
	public partial class UserDeviceSetting : EntityObjectBase
	{
  #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        [NonSerialized]
        private AdobeAirCapabilities _AdobeAirCapabilities;

        public virtual AdobeAirCapabilities GetAirCapabilities()
        {
            if (_AdobeAirCapabilities == null) // if we didn't have the object we create it
                _AdobeAirCapabilities = new AdobeAirCapabilities(this.CapabilitiesServerString);
            // if the object was created before but it was related to another string, we re-create it
            else if (_AdobeAirCapabilities.IsSame(this.CapabilitiesServerString) == false)
                _AdobeAirCapabilities = new AdobeAirCapabilities(this.CapabilitiesServerString);

            return _AdobeAirCapabilities;
        }

        [NonSerialized]
        private CordovaCapabilities _CordovaCapabilities;

        public virtual CordovaCapabilities GetCordovaCapabilities()
        {
            if (_CordovaCapabilities == null) // if we didn't have the object we create it
                _CordovaCapabilities = new CordovaCapabilities(this.CapabilitiesServerString);
            // if the object was created before but it was related to another string, we re-create it
            else if (_CordovaCapabilities.IsSame(this.CapabilitiesServerString) == false)
                _CordovaCapabilities = new CordovaCapabilities(this.CapabilitiesServerString);

            return _CordovaCapabilities;
        }


        #endregion

		#region Private Members

		private long _userdevicesettingid; 
		private Guid _devicegenerateduuid; 
		private long _userid; 
		private DateTime _insertdate; 
		private string _pushnotificationtoken; 
		private DateTime _pushnotificationtokenlastupdate; 
		private bool _pushnotificationisactive; 
		private byte _mobilepushserverid; 
		private string _devicename; 
		private string _os; 
		private string _manufacturer; 
		private string _version; 
		private string _capabilitiesserverstring; 
		private bool _deviceinuse; 
		private DateTime _updatedate; 
		private byte _userdeviceclientapptypeid; 
		private string _userdeviceclientappversion; 		
		#endregion

		#region Constructor

		public UserDeviceSetting()
		 //: base()
		{
			_userdevicesettingid = -1; 
			_devicegenerateduuid = new Guid(); 
			_userid = -1; 
			_insertdate = DateTime.MinValue; 
			_pushnotificationtoken = null; 
			_pushnotificationtokenlastupdate = DateTime.MinValue; 
			_pushnotificationisactive = false; 
			_mobilepushserverid = new byte(); 
			_devicename = null; 
			_os = null; 
			_manufacturer = null; 
			_version = null; 
			_capabilitiesserverstring = null; 
			_deviceinuse = false; 
			_updatedate = DateTime.MinValue; 
			_userdeviceclientapptypeid = new byte(); 
			_userdeviceclientappversion = null; 
		}

		public UserDeviceSetting(
			long userdevicesettingid, 
			Guid devicegenerateduuid, 
			long userid, 
			DateTime insertdate, 
			DateTime pushnotificationtokenlastupdate, 
			bool pushnotificationisactive, 
			byte mobilepushserverid, 
			string devicename, 
			bool deviceinuse, 
			DateTime updatedate, 
			byte userdeviceclientapptypeid, 
			string userdeviceclientappversion)
			: this()
		{
			_userdevicesettingid = userdevicesettingid;
			_devicegenerateduuid = devicegenerateduuid;
			_userid = userid;
			_insertdate = insertdate;
			_pushnotificationtoken = String.Empty;
			_pushnotificationtokenlastupdate = pushnotificationtokenlastupdate;
			_pushnotificationisactive = pushnotificationisactive;
			_mobilepushserverid = mobilepushserverid;
			_devicename = devicename;
			_os = String.Empty;
			_manufacturer = String.Empty;
			_version = String.Empty;
			_capabilitiesserverstring = String.Empty;
			_deviceinuse = deviceinuse;
			_updatedate = updatedate;
			_userdeviceclientapptypeid = userdeviceclientapptypeid;
			_userdeviceclientappversion = userdeviceclientappversion;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long UserDeviceSettingID
		{
			get
			{ 
				return _userdevicesettingid;
			}
			set
			{
				_userdevicesettingid = value;
			}

		}
			
		public virtual Guid DeviceGeneratedUUID
		{
			get
			{ 
				return _devicegenerateduuid;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for DeviceGeneratedUUID", value, "null");

				_devicegenerateduuid = value;
			}

		}
			
		public virtual long UserID
		{
			get
			{ 
				return _userid;
			}
			set
			{
				_userid = value;
			}

		}
			
		public virtual DateTime InsertDate
		{
			get
			{ 
				return _insertdate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsertDate", value, value.ToString());

				_insertdate = value;	
			}
					
		}
			
		public virtual string PushNotificationToken
		{
			get
			{ 
				return _pushnotificationtoken;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for PushNotificationToken", value, value.ToString());
				
				_pushnotificationtoken = value;
			}
		}
			
		public virtual DateTime PushNotificationTokenLastUpdate
		{
			get
			{ 
				return _pushnotificationtokenlastupdate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for PushNotificationTokenLastUpdate", value, value.ToString());

				_pushnotificationtokenlastupdate = value;	
			}
					
		}
			
		public virtual bool PushNotificationIsActive
		{
			get
			{ 
				return _pushnotificationisactive;
			}
			set
			{
				_pushnotificationisactive = value;
			}

		}
			
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
			
		public virtual string DeviceName
		{
			get
			{ 
				return _devicename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for DeviceName", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for DeviceName", value, value.ToString());
				
				_devicename = value;
			}
		}
			
		public virtual string OS
		{
			get
			{ 
				return _os;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for OS", value, value.ToString());
				
				_os = value;
			}
		}
			
		public virtual string Manufacturer
		{
			get
			{ 
				return _manufacturer;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for Manufacturer", value, value.ToString());
				
				_manufacturer = value;
			}
		}
			
		public virtual string Version
		{
			get
			{ 
				return _version;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for Version", value, value.ToString());
				
				_version = value;
			}
		}
			
		public virtual string CapabilitiesServerString
		{
			get
			{ 
				return _capabilitiesserverstring;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for CapabilitiesServerString", value, value.ToString());
				
				_capabilitiesserverstring = value;
			}
		}
			
		public virtual bool DeviceInUse
		{
			get
			{ 
				return _deviceinuse;
			}
			set
			{
				_deviceinuse = value;
			}

		}
			
		public virtual DateTime UpdateDate
		{
			get
			{ 
				return _updatedate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for UpdateDate", value, value.ToString());

				_updatedate = value;	
			}
					
		}
			
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
			
		public virtual string UserDeviceClientAppVersion
		{
			get
			{ 
				return _userdeviceclientappversion;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UserDeviceClientAppVersion", value, "null");
				
				//if(  value.Length > 10)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserDeviceClientAppVersion", value, value.ToString());
				
				_userdeviceclientappversion = value;
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
            return this.UserDeviceSettingID;
			
        }
		
		#endregion //Public Functions
	}
}
