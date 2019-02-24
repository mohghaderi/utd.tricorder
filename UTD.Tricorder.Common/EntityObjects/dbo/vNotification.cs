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
	public partial class vNotification : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Notification";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string NotificationID = "NotificationID";
			public const string InsertDate = "InsertDate";
			public const string SenderUserID = "SenderUserID";
			public const string ReceiverUserID = "ReceiverUserID";
			public const string ParametersValues = "ParametersValues";
			public const string NotificationErrorMessage = "NotificationErrorMessage";
			public const string NotificationTemplateID = "NotificationTemplateID";
			public const string IsSMS = "IsSMS";
			public const string IsEmail = "IsEmail";
			public const string IsWebMessage = "IsWebMessage";
			public const string IsMobilePushMessage = "IsMobilePushMessage";
			public const string SMSBody = "SMSBody";
			public const string EmailSubject = "EmailSubject";
			public const string EmailBodyHTML = "EmailBodyHTML";
			public const string ShortWebBody = "ShortWebBody";
			public const string EmailBodyText = "EmailBodyText";
			public const string GotoURL = "GotoURL";
			public const string ReceiverUserFirstName = "ReceiverUserFirstName";
			public const string ReceiverUserLastName = "ReceiverUserLastName";
			public const string ReceiverUserEmail = "ReceiverUserEmail";
			public const string ReceiverUserPhoneNumber = "ReceiverUserPhoneNumber";
			public const string RecieverUserUserName = "RecieverUserUserName";
			public const string SenderUserFirstName = "SenderUserFirstName";
			public const string SenderUserLastName = "SenderUserLastName";
			public const string SenderUserEmail = "SenderUserEmail";
			public const string SenderUserPhoneNumber = "SenderUserPhoneNumber";
			public const string SenderUserUserName = "SenderUserUserName";
			public const string SMSNotificationStatusID = "SMSNotificationStatusID";
			public const string EmailNotificationStatusID = "EmailNotificationStatusID";
			public const string EmailSendDate = "EmailSendDate";
			public const string SMSSendDate = "SMSSendDate";
			public const string RecieverUserNamePrefix = "RecieverUserNamePrefix";
			public const string SenderUserNamePrefix = "SenderUserNamePrefix";
			public const string RecieverUserWorldTimeZoneID = "RecieverUserWorldTimeZoneID";
			public const string RecieverUserEmailVerificationCode = "RecieverUserEmailVerificationCode";
			public const string RecieverUserPhoneVerificationCode = "RecieverUserPhoneVerificationCode";
			public const string MobilePushType = "MobilePushType";
			public const string MobilePushParamsJSON = "MobilePushParamsJSON";
			public const string MobilePushAlert = "MobilePushAlert";
			public const string MobilePushTitle = "MobilePushTitle";
			public const string MobilePushSound = "MobilePushSound";
			public const string TimeToLiveSeconds = "TimeToLiveSeconds";
			public const string MobilePushNotificationStatusID = "MobilePushNotificationStatusID";
			public const string TemplateDotNetFullClassName = "TemplateDotNetFullClassName";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("NotificationID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("SenderUserID");
			_ColumnsList.Add("ReceiverUserID");
			_ColumnsList.Add("ParametersValues");
			_ColumnsList.Add("NotificationErrorMessage");
			_ColumnsList.Add("NotificationTemplateID");
			_ColumnsList.Add("IsSMS");
			_ColumnsList.Add("IsEmail");
			_ColumnsList.Add("IsWebMessage");
			_ColumnsList.Add("IsMobilePushMessage");
			_ColumnsList.Add("SMSBody");
			_ColumnsList.Add("EmailSubject");
			_ColumnsList.Add("EmailBodyHTML");
			_ColumnsList.Add("ShortWebBody");
			_ColumnsList.Add("EmailBodyText");
			_ColumnsList.Add("GotoURL");
			_ColumnsList.Add("ReceiverUserFirstName");
			_ColumnsList.Add("ReceiverUserLastName");
			_ColumnsList.Add("ReceiverUserEmail");
			_ColumnsList.Add("ReceiverUserPhoneNumber");
			_ColumnsList.Add("RecieverUserUserName");
			_ColumnsList.Add("SenderUserFirstName");
			_ColumnsList.Add("SenderUserLastName");
			_ColumnsList.Add("SenderUserEmail");
			_ColumnsList.Add("SenderUserPhoneNumber");
			_ColumnsList.Add("SenderUserUserName");
			_ColumnsList.Add("SMSNotificationStatusID");
			_ColumnsList.Add("EmailNotificationStatusID");
			_ColumnsList.Add("EmailSendDate");
			_ColumnsList.Add("SMSSendDate");
			_ColumnsList.Add("RecieverUserNamePrefix");
			_ColumnsList.Add("SenderUserNamePrefix");
			_ColumnsList.Add("RecieverUserWorldTimeZoneID");
			_ColumnsList.Add("RecieverUserEmailVerificationCode");
			_ColumnsList.Add("RecieverUserPhoneVerificationCode");
			_ColumnsList.Add("MobilePushType");
			_ColumnsList.Add("MobilePushParamsJSON");
			_ColumnsList.Add("MobilePushAlert");
			_ColumnsList.Add("MobilePushTitle");
			_ColumnsList.Add("MobilePushSound");
			_ColumnsList.Add("TimeToLiveSeconds");
			_ColumnsList.Add("MobilePushNotificationStatusID");
			_ColumnsList.Add("TemplateDotNetFullClassName");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _notificationid; 
		private DateTime _insertdate; 
		private long? _senderuserid; 
		private long _receiveruserid; 
		private string _parametersvalues; 
		private string _notificationerrormessage; 
		private short _notificationtemplateid; 
		private bool _issms; 
		private bool _isemail; 
		private bool _iswebmessage; 
		private bool _ismobilepushmessage; 
		private string _smsbody; 
		private string _emailsubject; 
		private string _emailbodyhtml; 
		private string _shortwebbody; 
		private string _emailbodytext; 
		private string _gotourl; 
		private string _receiveruserfirstname; 
		private string _receiveruserlastname; 
		private string _receiveruseremail; 
		private string _receiveruserphonenumber; 
		private string _recieveruserusername; 
		private string _senderuserfirstname; 
		private string _senderuserlastname; 
		private string _senderuseremail; 
		private string _senderuserphonenumber; 
		private string _senderuserusername; 
		private byte _smsnotificationstatusid; 
		private byte _emailnotificationstatusid; 
		private DateTime? _emailsenddate; 
		private DateTime? _smssenddate; 
		private string _recieverusernameprefix; 
		private string _senderusernameprefix; 
		private short _recieveruserworldtimezoneid; 
		private Guid _recieveruseremailverificationcode; 
		private int _recieveruserphoneverificationcode; 
		private string _mobilepushtype; 
		private string _mobilepushparamsjson; 
		private string _mobilepushalert; 
		private string _mobilepushtitle; 
		private string _mobilepushsound; 
		private int? _timetoliveseconds; 
		private byte _mobilepushnotificationstatusid; 
		private string _templatedotnetfullclassname; 		
		#endregion

		#region Constructor

		public vNotification()
		 //: base()
		{
			_notificationid = -1; 
			_insertdate = DateTime.MinValue; 
			_senderuserid = null; 
			_receiveruserid = -1; 
			_parametersvalues = null; 
			_notificationerrormessage = null; 
			_notificationtemplateid = -1; 
			_issms = false; 
			_isemail = false; 
			_iswebmessage = false; 
			_ismobilepushmessage = false; 
			_smsbody = null; 
			_emailsubject = null; 
			_emailbodyhtml = null; 
			_shortwebbody = null; 
			_emailbodytext = null; 
			_gotourl = null; 
			_receiveruserfirstname = null; 
			_receiveruserlastname = null; 
			_receiveruseremail = null; 
			_receiveruserphonenumber = null; 
			_recieveruserusername = null; 
			_senderuserfirstname = null; 
			_senderuserlastname = null; 
			_senderuseremail = null; 
			_senderuserphonenumber = null; 
			_senderuserusername = null; 
			_smsnotificationstatusid = new byte(); 
			_emailnotificationstatusid = new byte(); 
			_emailsenddate = null; 
			_smssenddate = null; 
			_recieverusernameprefix = null; 
			_senderusernameprefix = null; 
			_recieveruserworldtimezoneid = -1; 
			_recieveruseremailverificationcode = new Guid(); 
			_recieveruserphoneverificationcode = -1; 
			_mobilepushtype = null; 
			_mobilepushparamsjson = null; 
			_mobilepushalert = null; 
			_mobilepushtitle = null; 
			_mobilepushsound = null; 
			_timetoliveseconds = null; 
			_mobilepushnotificationstatusid = new byte(); 
			_templatedotnetfullclassname = null; 
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
			
		public virtual string SMSBody
		{
			get
			{ 
				return _smsbody;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 500)
				//	throw new ArgumentOutOfRangeException("Invalid value for SMSBody", value, value.ToString());
				
				_smsbody = value;
			}
		}
			
		public virtual string EmailSubject
		{
			get
			{ 
				return _emailsubject;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for EmailSubject", value, value.ToString());
				
				_emailsubject = value;
			}
		}
			
		public virtual string EmailBodyHTML
		{
			get
			{ 
				return _emailbodyhtml;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for EmailBodyHTML", value, value.ToString());
				
				_emailbodyhtml = value;
			}
		}
			
		public virtual string ShortWebBody
		{
			get
			{ 
				return _shortwebbody;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for ShortWebBody", value, value.ToString());
				
				_shortwebbody = value;
			}
		}
			
		public virtual string EmailBodyText
		{
			get
			{ 
				return _emailbodytext;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for EmailBodyText", value, value.ToString());
				
				_emailbodytext = value;
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
			
		public virtual string ReceiverUserFirstName
		{
			get
			{ 
				return _receiveruserfirstname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ReceiverUserFirstName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ReceiverUserFirstName", value, value.ToString());
				
				_receiveruserfirstname = value;
			}
		}
			
		public virtual string ReceiverUserLastName
		{
			get
			{ 
				return _receiveruserlastname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ReceiverUserLastName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ReceiverUserLastName", value, value.ToString());
				
				_receiveruserlastname = value;
			}
		}
			
		public virtual string ReceiverUserEmail
		{
			get
			{ 
				return _receiveruseremail;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ReceiverUserEmail", value, value.ToString());
				
				_receiveruseremail = value;
			}
		}
			
		public virtual string ReceiverUserPhoneNumber
		{
			get
			{ 
				return _receiveruserphonenumber;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 18)
				//	throw new ArgumentOutOfRangeException("Invalid value for ReceiverUserPhoneNumber", value, value.ToString());
				
				_receiveruserphonenumber = value;
			}
		}
			
		public virtual string RecieverUserUserName
		{
			get
			{ 
				return _recieveruserusername;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for RecieverUserUserName", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for RecieverUserUserName", value, value.ToString());
				
				_recieveruserusername = value;
			}
		}
			
		public virtual string SenderUserFirstName
		{
			get
			{ 
				return _senderuserfirstname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderUserFirstName", value, value.ToString());
				
				_senderuserfirstname = value;
			}
		}
			
		public virtual string SenderUserLastName
		{
			get
			{ 
				return _senderuserlastname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderUserLastName", value, value.ToString());
				
				_senderuserlastname = value;
			}
		}
			
		public virtual string SenderUserEmail
		{
			get
			{ 
				return _senderuseremail;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderUserEmail", value, value.ToString());
				
				_senderuseremail = value;
			}
		}
			
		public virtual string SenderUserPhoneNumber
		{
			get
			{ 
				return _senderuserphonenumber;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 18)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderUserPhoneNumber", value, value.ToString());
				
				_senderuserphonenumber = value;
			}
		}
			
		public virtual string SenderUserUserName
		{
			get
			{ 
				return _senderuserusername;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderUserUserName", value, value.ToString());
				
				_senderuserusername = value;
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
			
		public virtual string RecieverUserNamePrefix
		{
			get
			{ 
				return _recieverusernameprefix;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 4)
				//	throw new ArgumentOutOfRangeException("Invalid value for RecieverUserNamePrefix", value, value.ToString());
				
				_recieverusernameprefix = value;
			}
		}
			
		public virtual string SenderUserNamePrefix
		{
			get
			{ 
				return _senderusernameprefix;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 4)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderUserNamePrefix", value, value.ToString());
				
				_senderusernameprefix = value;
			}
		}
			
		public virtual short RecieverUserWorldTimeZoneID
		{
			get
			{ 
				return _recieveruserworldtimezoneid;
			}
			set
			{
				_recieveruserworldtimezoneid = value;
			}

		}
			
		public virtual Guid RecieverUserEmailVerificationCode
		{
			get
			{ 
				return _recieveruseremailverificationcode;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for RecieverUserEmailVerificationCode", value, "null");

				_recieveruseremailverificationcode = value;
			}

		}
			
		public virtual int RecieverUserPhoneVerificationCode
		{
			get
			{ 
				return _recieveruserphoneverificationcode;
			}
			set
			{
				_recieveruserphoneverificationcode = value;
			}

		}
			
		public virtual string MobilePushType
		{
			get
			{ 
				return _mobilepushtype;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushType", value, value.ToString());
				
				_mobilepushtype = value;
			}
		}
			
		public virtual string MobilePushParamsJSON
		{
			get
			{ 
				return _mobilepushparamsjson;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 500)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushParamsJSON", value, value.ToString());
				
				_mobilepushparamsjson = value;
			}
		}
			
		public virtual string MobilePushAlert
		{
			get
			{ 
				return _mobilepushalert;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushAlert", value, value.ToString());
				
				_mobilepushalert = value;
			}
		}
			
		public virtual string MobilePushTitle
		{
			get
			{ 
				return _mobilepushtitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushTitle", value, value.ToString());
				
				_mobilepushtitle = value;
			}
		}
			
		public virtual string MobilePushSound
		{
			get
			{ 
				return _mobilepushsound;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushSound", value, value.ToString());
				
				_mobilepushsound = value;
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
			
		public virtual string TemplateDotNetFullClassName
		{
			get
			{ 
				return _templatedotnetfullclassname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for TemplateDotNetFullClassName", value, value.ToString());
				
				_templatedotnetfullclassname = value;
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
