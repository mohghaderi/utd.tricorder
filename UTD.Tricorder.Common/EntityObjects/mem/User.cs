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
	public partial class User : EntityObjectBase
	{
  #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        public virtual string UserTitle
        {
            get 
            { 
                return FWUtils.EntityUtils.ConcatStrings(" ", this.NamePrefix, this.FirstName, this.LastName); 
            }
        }

        private string _UserProfilePicUrl;

        public virtual string UserProfilePicUrl
        {
            get
            {
                return _UserProfilePicUrl;
            }
            set
            {
                _UserProfilePicUrl = value;
            }
        }

        #endregion

		#region Private Members
		private long _userid;//3

		//private IList<CallLog> _CallLogList; 

		//private IList<CallLog> _CallLogList; 

		//private IList<DailyActivity> _DailyActivityList; 

		//private IList<Doctor> _DoctorList; 

		//private IList<Doctor_Patient> _Doctor_PatientList; 

		//private IList<PatientInsurance> _PatientInsuranceList; 

		//private IList<Payment> _PaymentList; 

		//private IList<Payment> _PaymentList; 

		//private IList<Person> _PersonList; 

		//private IList<UserPaymentInfo> _UserPaymentInfoList; 

		//private IList<Visit> _VisitList; 

		//private IList<MobilePushNotification> _MobilePushNotificationList; 

		//private IList<MobilePushNotification> _MobilePushNotificationList; 

		//private IList<Notification> _NotificationList; 

		//private IList<Permission> _PermissionList; 

		//private IList<UserInRole> _UserInRoleList; 

		private string _username; 
		private string _firstname; 
		private string _lastname; 
		private byte[] _passwordhash; 
		private byte[] _passwordsalt; 
		private string _email; 
		private string _phonenumber; 
		private int _userapprovalstatusid; 
		private long? _approvaluserid; private long _membershipareaid;//0
//private MembershipArea _membershipareaid;//1

		private long? _insertuserid; 
		private DateTime _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 
		private DateTime? _lastlogindate; 
		private DateTime _lastpasswordchangeddate; 
		private DateTime _laststatuschangedate; 
		private int _failedpasswordattemptcount; 
		private long _defaultroleid; 
		private Guid _emailverificationcode; 
		private int _phoneverificationcode; 
		private bool _isemailverified; 
		private bool _isphoneverified; 
		private string _nameprefix; 
		private string _middlename; 
		private short _primarylanguageid; private short _worldtimezoneid;//0
//private WorldTimeZone _worldtimezoneid;//1

		private long? _referreruserid; 
		private int? _resetpasswordcode; 
		private DateTime? _resetpasswordrequestdate; 
		private bool _isonline; 
		private DateTime? _lastonlinedate; 
		private int _insertsiteid; 		
		#endregion

		#region Constructor

		public User()
		 //: base()
		{
			_userid = -1; 
			//_CallLogList = new List<CallLog>(); 
			//_CallLogList = new List<CallLog>(); 
			//_DailyActivityList = new List<DailyActivity>(); 
			//_DoctorList = new List<Doctor>(); 
			//_Doctor_PatientList = new List<Doctor_Patient>(); 
			//_PatientInsuranceList = new List<PatientInsurance>(); 
			//_PaymentList = new List<Payment>(); 
			//_PaymentList = new List<Payment>(); 
			//_PersonList = new List<Person>(); 
			//_UserPaymentInfoList = new List<UserPaymentInfo>(); 
			//_VisitList = new List<Visit>(); 
			//_MobilePushNotificationList = new List<MobilePushNotification>(); 
			//_MobilePushNotificationList = new List<MobilePushNotification>(); 
			//_NotificationList = new List<Notification>(); 
			//_PermissionList = new List<Permission>(); 
			//_UserInRoleList = new List<UserInRole>(); 
			_username = null; 
			_firstname = null; 
			_lastname = null; 
			_passwordhash = null; 
			_passwordsalt = null; 
			_email = null; 
			_phonenumber = null; 
			_userapprovalstatusid = -1; 
			_approvaluserid = null; 
			_membershipareaid = -1; 
			_insertuserid = null; 
			_insertdate = DateTime.MinValue; 
			_updateuserid = null; 
			_updatedate = null; 
			_lastlogindate = null; 
			_lastpasswordchangeddate = DateTime.MinValue; 
			_laststatuschangedate = DateTime.MinValue; 
			_failedpasswordattemptcount = -1; 
			_defaultroleid = -1; 
			_emailverificationcode = new Guid(); 
			_phoneverificationcode = -1; 
			_isemailverified = false; 
			_isphoneverified = false; 
			_nameprefix = null; 
			_middlename = null; 
			_primarylanguageid = -1; 
			_worldtimezoneid = -1; 
			_referreruserid = null; 
			_resetpasswordcode = null; 
			_resetpasswordrequestdate = null; 
			_isonline = false; 
			_lastonlinedate = null; 
			_insertsiteid = -1; 
		}

		public User(
			long userid, 
			string username, 
			string firstname, 
			string lastname, 
			byte[] passwordhash, 
			byte[] passwordsalt, 
			int userapprovalstatusid, 
			long membershipareaid, 
			DateTime insertdate, 
			DateTime lastpasswordchangeddate, 
			DateTime laststatuschangedate, 
			int failedpasswordattemptcount, 
			long defaultroleid, 
			Guid emailverificationcode, 
			int phoneverificationcode, 
			bool isemailverified, 
			bool isphoneverified, 
			short primarylanguageid, 
			short worldtimezoneid, 
			bool isonline, 
			int insertsiteid)
			: this()
		{
			_userid = userid;
			_username = username;
			_firstname = firstname;
			_lastname = lastname;
			_passwordhash = passwordhash;
			_passwordsalt = passwordsalt;
			_email = String.Empty;
			_phonenumber = String.Empty;
			_userapprovalstatusid = userapprovalstatusid;
			_approvaluserid = null;
			_membershipareaid = membershipareaid;
			_insertuserid = null;
			_insertdate = insertdate;
			_updateuserid = null;
			_updatedate = null;
			_lastlogindate = null;
			_lastpasswordchangeddate = lastpasswordchangeddate;
			_laststatuschangedate = laststatuschangedate;
			_failedpasswordattemptcount = failedpasswordattemptcount;
			_defaultroleid = defaultroleid;
			_emailverificationcode = emailverificationcode;
			_phoneverificationcode = phoneverificationcode;
			_isemailverified = isemailverified;
			_isphoneverified = isphoneverified;
			_nameprefix = String.Empty;
			_middlename = String.Empty;
			_primarylanguageid = primarylanguageid;
			_worldtimezoneid = worldtimezoneid;
			_referreruserid = null;
			_resetpasswordcode = null;
			_resetpasswordrequestdate = null;
			_isonline = isonline;
			_lastonlinedate = null;
			_insertsiteid = insertsiteid;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual string UserName
		{
			get
			{ 
				return _username;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UserName", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserName", value, value.ToString());
				
				_username = value;
			}
		}
			
		public virtual string FirstName
		{
			get
			{ 
				return _firstname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FirstName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for FirstName", value, value.ToString());
				
				_firstname = value;
			}
		}
			
		public virtual string LastName
		{
			get
			{ 
				return _lastname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for LastName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for LastName", value, value.ToString());
				
				_lastname = value;
			}
		}
			
		public virtual byte[] PasswordHash
		{
			get
			{ 
				return _passwordhash;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for PasswordHash", value, "null");

				_passwordhash = value;
			}

		}
			
		public virtual byte[] PasswordSalt
		{
			get
			{ 
				return _passwordsalt;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for PasswordSalt", value, "null");

				_passwordsalt = value;
			}

		}
			
		public virtual string Email
		{
			get
			{ 
				return _email;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for Email", value, value.ToString());
				
				_email = value;
			}
		}
			
		public virtual string PhoneNumber
		{
			get
			{ 
				return _phonenumber;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 18)
				//	throw new ArgumentOutOfRangeException("Invalid value for PhoneNumber", value, value.ToString());
				
				_phonenumber = value;
			}
		}
			
		public virtual int UserApprovalStatusID
		{
			get
			{ 
				return _userapprovalstatusid;
			}
			set
			{
				_userapprovalstatusid = value;
			}

		}
			
		public virtual long? ApprovalUserID
		{
			get
			{ 
				return _approvaluserid;
			}
			set
			{
				_approvaluserid = value;
			}

		}
			
		public virtual long MembershipAreaID
		{
			get
			{ 
				return _membershipareaid;
			}
			set
			{
				_membershipareaid = value;
			}

		}
			
		public virtual long? InsertUserID
		{
			get
			{ 
				return _insertuserid;
			}
			set
			{
				_insertuserid = value;
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
			
		public virtual long? UpdateUserID
		{
			get
			{ 
				return _updateuserid;
			}
			set
			{
				_updateuserid = value;
			}

		}
			
		public virtual DateTime? UpdateDate
		{
			get
			{ 
				return _updatedate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for UpdateDate", value, value.ToString());
						
				_updatedate = value;	
			}			
					
		}
			
		public virtual DateTime? LastLoginDate
		{
			get
			{ 
				return _lastlogindate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for LastLoginDate", value, value.ToString());
						
				_lastlogindate = value;	
			}			
					
		}
			
		public virtual DateTime LastPasswordChangedDate
		{
			get
			{ 
				return _lastpasswordchangeddate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for LastPasswordChangedDate", value, value.ToString());

				_lastpasswordchangeddate = value;	
			}
					
		}
			
		public virtual DateTime LastStatusChangeDate
		{
			get
			{ 
				return _laststatuschangedate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for LastStatusChangeDate", value, value.ToString());

				_laststatuschangedate = value;	
			}
					
		}
			
		public virtual int FailedPasswordAttemptCount
		{
			get
			{ 
				return _failedpasswordattemptcount;
			}
			set
			{
				_failedpasswordattemptcount = value;
			}

		}
			
		public virtual long DefaultRoleID
		{
			get
			{ 
				return _defaultroleid;
			}
			set
			{
				_defaultroleid = value;
			}

		}
			
		public virtual Guid EmailVerificationCode
		{
			get
			{ 
				return _emailverificationcode;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for EmailVerificationCode", value, "null");

				_emailverificationcode = value;
			}

		}
			
		public virtual int PhoneVerificationCode
		{
			get
			{ 
				return _phoneverificationcode;
			}
			set
			{
				_phoneverificationcode = value;
			}

		}
			
		public virtual bool IsEmailVerified
		{
			get
			{ 
				return _isemailverified;
			}
			set
			{
				_isemailverified = value;
			}

		}
			
		public virtual bool IsPhoneVerified
		{
			get
			{ 
				return _isphoneverified;
			}
			set
			{
				_isphoneverified = value;
			}

		}
			
		public virtual string NamePrefix
		{
			get
			{ 
				return _nameprefix;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 4)
				//	throw new ArgumentOutOfRangeException("Invalid value for NamePrefix", value, value.ToString());
				
				_nameprefix = value;
			}
		}
			
		public virtual string MiddleName
		{
			get
			{ 
				return _middlename;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MiddleName", value, value.ToString());
				
				_middlename = value;
			}
		}
			
		public virtual short PrimaryLanguageID
		{
			get
			{ 
				return _primarylanguageid;
			}
			set
			{
				_primarylanguageid = value;
			}

		}
			
		public virtual short WorldTimeZoneID
		{
			get
			{ 
				return _worldtimezoneid;
			}
			set
			{
				_worldtimezoneid = value;
			}

		}
			
		public virtual long? ReferrerUserID
		{
			get
			{ 
				return _referreruserid;
			}
			set
			{
				_referreruserid = value;
			}

		}
			
		public virtual int? ResetPasswordCode
		{
			get
			{ 
				return _resetpasswordcode;
			}
			set
			{
				_resetpasswordcode = value;
			}

		}
			
		public virtual DateTime? ResetPasswordRequestDate
		{
			get
			{ 
				return _resetpasswordrequestdate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for ResetPasswordRequestDate", value, value.ToString());
						
				_resetpasswordrequestdate = value;	
			}			
					
		}
			
		public virtual bool IsOnline
		{
			get
			{ 
				return _isonline;
			}
			set
			{
				_isonline = value;
			}

		}
			
		public virtual DateTime? LastOnlineDate
		{
			get
			{ 
				return _lastonlinedate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for LastOnlineDate", value, value.ToString());
						
				_lastonlinedate = value;	
			}			
					
		}
			
		public virtual int InsertSiteID
		{
			get
			{ 
				return _insertsiteid;
			}
			set
			{
				_insertsiteid = value;
			}

		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddCallLog(CallLog obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_CallLogList.Add(obj);
		//}
		

		//public virtual void AddCallLog(CallLog obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_CallLogList.Add(obj);
		//}
		

		//public virtual void AddDailyActivity(DailyActivity obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_DailyActivityList.Add(obj);
		//}
		

		//public virtual void AddDoctor(Doctor obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_DoctorList.Add(obj);
		//}
		

		//public virtual void AddDoctor_Patient(Doctor_Patient obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Doctor_PatientList.Add(obj);
		//}
		

		//public virtual void AddPatientInsurance(PatientInsurance obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PatientInsuranceList.Add(obj);
		//}
		

		//public virtual void AddPayment(Payment obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PaymentList.Add(obj);
		//}
		

		//public virtual void AddPayment(Payment obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PaymentList.Add(obj);
		//}
		

		//public virtual void AddPerson(Person obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PersonList.Add(obj);
		//}
		

		//public virtual void AddUserPaymentInfo(UserPaymentInfo obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_UserPaymentInfoList.Add(obj);
		//}
		

		//public virtual void AddVisit(Visit obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_VisitList.Add(obj);
		//}
		

		//public virtual void AddMobilePushNotification(MobilePushNotification obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_MobilePushNotificationList.Add(obj);
		//}
		

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
		

		//public virtual void AddPermission(Permission obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PermissionList.Add(obj);
		//}
		

		//public virtual void AddUserInRole(UserInRole obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_UserInRoleList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.UserID;
			
        }
		
		#endregion //Public Functions
	}
}
