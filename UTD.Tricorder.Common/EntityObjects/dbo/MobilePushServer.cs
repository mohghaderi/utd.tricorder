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
	public partial class MobilePushServer : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private byte _mobilepushserverid;//3

		//private IList<UserDeviceSetting> _UserDeviceSettingList; 

		private string _mobilepushservername; 
		private string _mobilepushservercode; 		
		#endregion

		#region Constructor

		public MobilePushServer()
		 //: base()
		{
			_mobilepushserverid = new byte(); 
			//_UserDeviceSettingList = new List<UserDeviceSetting>(); 
			_mobilepushservername = null; 
			_mobilepushservercode = null; 
		}

		public MobilePushServer(
			byte mobilepushserverid, 
			string mobilepushservername)
			: this()
		{
			_mobilepushserverid = mobilepushserverid;
			_mobilepushservername = mobilepushservername;
			_mobilepushservercode = String.Empty;
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

		//public virtual void AddUserDeviceSetting(UserDeviceSetting obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_UserDeviceSettingList.Add(obj);
		//}
		


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
