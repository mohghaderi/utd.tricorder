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
	public partial class UserDeviceClientAppType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private byte _userdeviceclientapptypeid; 
		private string _userdeviceclientapptypecode; 		
		#endregion

		#region Constructor

		public UserDeviceClientAppType()
		 //: base()
		{
			_userdeviceclientapptypeid = new byte(); 
			_userdeviceclientapptypecode = null; 
		}

		public UserDeviceClientAppType(
			byte userdeviceclientapptypeid, 
			string userdeviceclientapptypecode)
			: this()
		{
			_userdeviceclientapptypeid = userdeviceclientapptypeid;
			_userdeviceclientapptypecode = userdeviceclientapptypecode;
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
