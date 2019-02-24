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
	public partial class Notification : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public virtual void SetParametersValues(TemplateParams p)
        {
            if (p != null)
                this._parametersvalues = p.SerializeToString();
        }
		

		#endregion

		#region Private Members

		private long _notificationid; 
		private DateTime _insertdate; 
		private DateTime? _emailsenddate; 
		private DateTime? _smssenddate; private long? _senderuserid;//0
//private User _senderuserid;//1

		private long _receiveruserid; private short _notificationtemplateid;//0
//private NotificationTemplate _notificationtemplateid;//1

		private string _parametersvalues; private byte _smsnotificationstatusid;//0
//private NotificationStatus _smsnotificationstatusid;//1
private byte _emailnotificationstatusid;//0
//private NotificationStatus _emailnotificationstatusid;//1

		private string _notificationerrormessage; 
		private bool _issms; 
		private bool _isemail; 
		private bool _iswebmessage; 
		private bool _ismobilepushmessage; 
		private string _gotourl; private byte _mobilepushnotificationstatusid;//0
//private NotificationStatus _mobilepushnotificationstatusid;//1
		
		#endregion

		#region Constructor

		public Notification()
		 //: base()
		{
			_notificationid = -1; 
			_insertdate = DateTime.MinValue; 
			_emailsenddate = null; 
			_smssenddate = null; 
			_senderuserid = null; 
			_receiveruserid = -1; 
			_notificationtemplateid = -1; 
			_parametersvalues = null; 
			_smsnotificationstatusid = new byte(); 
			_emailnotificationstatusid = new byte(); 
			_notificationerrormessage = null; 
			_issms = false; 
			_isemail = false; 
			_iswebmessage = false; 
			_ismobilepushmessage = false; 
			_gotourl = null; 
			_mobilepushnotificationstatusid = new byte(); 
		}

		public Notification(
			long notificationid, 
			DateTime insertdate, 
			long receiveruserid, 
			short notificationtemplateid, 
			byte smsnotificationstatusid, 
			byte emailnotificationstatusid, 
			bool issms, 
			bool isemail, 
			bool iswebmessage, 
			bool ismobilepushmessage, 
			byte mobilepushnotificationstatusid)
			: this()
		{
			_notificationid = notificationid;
			_insertdate = insertdate;
			_emailsenddate = null;
			_smssenddate = null;
			_senderuserid = null;
			_receiveruserid = receiveruserid;
			_notificationtemplateid = notificationtemplateid;
			_parametersvalues = String.Empty;
			_smsnotificationstatusid = smsnotificationstatusid;
			_emailnotificationstatusid = emailnotificationstatusid;
			_notificationerrormessage = String.Empty;
			_issms = issms;
			_isemail = isemail;
			_iswebmessage = iswebmessage;
			_ismobilepushmessage = ismobilepushmessage;
			_gotourl = String.Empty;
			_mobilepushnotificationstatusid = mobilepushnotificationstatusid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long NotificationID
		{
			get
			{ 
				return _notificationid;
			}
			set
			{
				_notificationid = value;
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
			
		public virtual DateTime? EmailSendDate
		{
			get
			{ 
				return _emailsenddate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for EmailSendDate", value, value.ToString());
						
				_emailsenddate = value;	
			}			
					
		}
			
		public virtual DateTime? SMSSendDate
		{
			get
			{ 
				return _smssenddate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for SMSSendDate", value, value.ToString());
						
				_smssenddate = value;	
			}			
					
		}
			
		public virtual long? SenderUserID
		{
			get
			{ 
				return _senderuserid;
			}
			set
			{
				_senderuserid = value;
			}

		}
			
		public virtual long ReceiverUserID
		{
			get
			{ 
				return _receiveruserid;
			}
			set
			{
				_receiveruserid = value;
			}

		}
			
		public virtual short NotificationTemplateID
		{
			get
			{ 
				return _notificationtemplateid;
			}
			set
			{
				_notificationtemplateid = value;
			}

		}
			
		public virtual string ParametersValues
		{
			get
			{ 
				return _parametersvalues;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for ParametersValues", value, value.ToString());
				
				_parametersvalues = value;
			}
		}
			
		public virtual byte SMSNotificationStatusID
		{
			get
			{ 
				return _smsnotificationstatusid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SMSNotificationStatusID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for SMSNotificationStatusID", value, value.ToString());
				
				_smsnotificationstatusid = value;
			}

		}
			
		public virtual byte EmailNotificationStatusID
		{
			get
			{ 
				return _emailnotificationstatusid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for EmailNotificationStatusID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for EmailNotificationStatusID", value, value.ToString());
				
				_emailnotificationstatusid = value;
			}

		}
			
		public virtual string NotificationErrorMessage
		{
			get
			{ 
				return _notificationerrormessage;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for NotificationErrorMessage", value, value.ToString());
				
				_notificationerrormessage = value;
			}
		}
			
		public virtual bool IsSMS
		{
			get
			{ 
				return _issms;
			}
			set
			{
				_issms = value;
			}

		}
			
		public virtual bool IsEmail
		{
			get
			{ 
				return _isemail;
			}
			set
			{
				_isemail = value;
			}

		}
			
		public virtual bool IsWebMessage
		{
			get
			{ 
				return _iswebmessage;
			}
			set
			{
				_iswebmessage = value;
			}

		}
			
		public virtual bool IsMobilePushMessage
		{
			get
			{ 
				return _ismobilepushmessage;
			}
			set
			{
				_ismobilepushmessage = value;
			}

		}
			
		public virtual string GotoURL
		{
			get
			{ 
				return _gotourl;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2048)
				//	throw new ArgumentOutOfRangeException("Invalid value for GotoURL", value, value.ToString());
				
				_gotourl = value;
			}
		}
			
		public virtual byte MobilePushNotificationStatusID
		{
			get
			{ 
				return _mobilepushnotificationstatusid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobilePushNotificationStatusID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushNotificationStatusID", value, value.ToString());
				
				_mobilepushnotificationstatusid = value;
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
            return this.NotificationID;
			
        }
		
		#endregion //Public Functions
	}
}
