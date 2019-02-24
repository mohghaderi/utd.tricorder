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
	public partial class NotificationStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private byte _notificationstatusid;//3

		//private IList<MobilePushNotification> _MobilePushNotificationList; 

		//private IList<Notification> _NotificationList; 

		//private IList<Notification> _NotificationList; 

		//private IList<Notification> _NotificationList; 

		private string _notificationstatustitle; 		
		#endregion

		#region Constructor

		public NotificationStatus()
		 //: base()
		{
			_notificationstatusid = new byte(); 
			//_MobilePushNotificationList = new List<MobilePushNotification>(); 
			//_NotificationList = new List<Notification>(); 
			//_NotificationList = new List<Notification>(); 
			//_NotificationList = new List<Notification>(); 
			_notificationstatustitle = null; 
		}

		public NotificationStatus(
			byte notificationstatusid, 
			string notificationstatustitle)
			: this()
		{
			_notificationstatusid = notificationstatusid;
			_notificationstatustitle = notificationstatustitle;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
		

		//public virtual void AddNotification(Notification obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_NotificationList.Add(obj);
		//}
		

		//public virtual void AddNotification(Notification obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_NotificationList.Add(obj);
		//}
		

		//public virtual void AddNotification(Notification obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_NotificationList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.NotificationStatusID;
			
        }
		
		#endregion //Public Functions
	}
}
