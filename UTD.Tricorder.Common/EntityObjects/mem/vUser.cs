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
	public partial class vUser : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public virtual string UserFullName
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


		public const string EntityName = "User";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string UserID = "UserID";
			public const string UserName = "UserName";
			public const string FirstName = "FirstName";
			public const string LastName = "LastName";
			public const string PasswordHash = "PasswordHash";
			public const string PasswordSalt = "PasswordSalt";
			public const string Email = "Email";
			public const string PhoneNumber = "PhoneNumber";
			public const string UserApprovalStatusID = "UserApprovalStatusID";
			public const string ApprovalUserID = "ApprovalUserID";
			public const string MembershipAreaID = "MembershipAreaID";
			public const string InsertUserID = "InsertUserID";
			public const string InsertDate = "InsertDate";
			public const string UpdateUserID = "UpdateUserID";
			public const string UpdateDate = "UpdateDate";
			public const string LastLoginDate = "LastLoginDate";
			public const string LastPasswordChangedDate = "LastPasswordChangedDate";
			public const string LastStatusChangeDate = "LastStatusChangeDate";
			public const string FailedPasswordAttemptCount = "FailedPasswordAttemptCount";
			public const string MembershipAreaName = "MembershipAreaName";
			public const string MembershipAreaCode = "MembershipAreaCode";
			public const string DefaultRoleID = "DefaultRoleID";
			public const string RoleName = "RoleName";
			public const string RoleCode = "RoleCode";
			public const string UserApprovalStatusTitle = "UserApprovalStatusTitle";
			public const string UserApprovalStatusCode = "UserApprovalStatusCode";
			public const string EmailVerificationCode = "EmailVerificationCode";
			public const string PhoneVerificationCode = "PhoneVerificationCode";
			public const string IsEmailVerified = "IsEmailVerified";
			public const string IsPhoneVerified = "IsPhoneVerified";
			public const string NamePrefix = "NamePrefix";
			public const string PrimaryLanguageID = "PrimaryLanguageID";
			public const string MiddleName = "MiddleName";
			public const string WorldTimeZoneTitle = "WorldTimeZoneTitle";
			public const string WorldTimeZoneIANAName = "WorldTimeZoneIANAName";
			public const string WorldTimeZoneID = "WorldTimeZoneID";
			public const string ReferrerUserID = "ReferrerUserID";
			public const string ResetPasswordCode = "ResetPasswordCode";
			public const string ResetPasswordRequestDate = "ResetPasswordRequestDate";
			public const string IsOnline = "IsOnline";
			public const string LastOnlineDate = "LastOnlineDate";
			public const string InsertSiteID = "InsertSiteID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("UserID");
			_ColumnsList.Add("UserName");
			_ColumnsList.Add("FirstName");
			_ColumnsList.Add("LastName");
			_ColumnsList.Add("PasswordHash");
			_ColumnsList.Add("PasswordSalt");
			_ColumnsList.Add("Email");
			_ColumnsList.Add("PhoneNumber");
			_ColumnsList.Add("UserApprovalStatusID");
			_ColumnsList.Add("ApprovalUserID");
			_ColumnsList.Add("MembershipAreaID");
			_ColumnsList.Add("InsertUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("UpdateUserID");
			_ColumnsList.Add("UpdateDate");
			_ColumnsList.Add("LastLoginDate");
			_ColumnsList.Add("LastPasswordChangedDate");
			_ColumnsList.Add("LastStatusChangeDate");
			_ColumnsList.Add("FailedPasswordAttemptCount");
			_ColumnsList.Add("MembershipAreaName");
			_ColumnsList.Add("MembershipAreaCode");
			_ColumnsList.Add("DefaultRoleID");
			_ColumnsList.Add("RoleName");
			_ColumnsList.Add("RoleCode");
			_ColumnsList.Add("UserApprovalStatusTitle");
			_ColumnsList.Add("UserApprovalStatusCode");
			_ColumnsList.Add("EmailVerificationCode");
			_ColumnsList.Add("PhoneVerificationCode");
			_ColumnsList.Add("IsEmailVerified");
			_ColumnsList.Add("IsPhoneVerified");
			_ColumnsList.Add("NamePrefix");
			_ColumnsList.Add("PrimaryLanguageID");
			_ColumnsList.Add("MiddleName");
			_ColumnsList.Add("WorldTimeZoneTitle");
			_ColumnsList.Add("WorldTimeZoneIANAName");
			_ColumnsList.Add("WorldTimeZoneID");
			_ColumnsList.Add("ReferrerUserID");
			_ColumnsList.Add("ResetPasswordCode");
			_ColumnsList.Add("ResetPasswordRequestDate");
			_ColumnsList.Add("IsOnline");
			_ColumnsList.Add("LastOnlineDate");
			_ColumnsList.Add("InsertSiteID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _userid; 
		private string _username; 
		private string _firstname; 
		private string _lastname; 
		private byte[] _passwordhash; 
		private byte[] _passwordsalt; 
		private string _email; 
		private string _phonenumber; 
		private int _userapprovalstatusid; 
		private long? _approvaluserid; 
		private long _membershipareaid; 
		private long? _insertuserid; 
		private DateTime _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 
		private DateTime? _lastlogindate; 
		private DateTime _lastpasswordchangeddate; 
		private DateTime _laststatuschangedate; 
		private int _failedpasswordattemptcount; 
		private string _membershipareaname; 
		private string _membershipareacode; 
		private long _defaultroleid; 
		private string _rolename; 
		private string _rolecode; 
		private string _userapprovalstatustitle; 
		private string _userapprovalstatuscode; 
		private Guid _emailverificationcode; 
		private int _phoneverificationcode; 
		private bool _isemailverified; 
		private bool _isphoneverified; 
		private string _nameprefix; 
		private short _primarylanguageid; 
		private string _middlename; 
		private string _worldtimezonetitle; 
		private string _worldtimezoneiananame; 
		private short _worldtimezoneid; 
		private long? _referreruserid; 
		private int? _resetpasswordcode; 
		private DateTime? _resetpasswordrequestdate; 
		private bool _isonline; 
		private DateTime? _lastonlinedate; 
		private int _insertsiteid; 		
		#endregion

		#region Constructor

		public vUser()
		 //: base()
		{
			_userid = -1; 
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
			_membershipareaname = null; 
			_membershipareacode = null; 
			_defaultroleid = -1; 
			_rolename = null; 
			_rolecode = null; 
			_userapprovalstatustitle = null; 
			_userapprovalstatuscode = null; 
			_emailverificationcode = new Guid(); 
			_phoneverificationcode = -1; 
			_isemailverified = false; 
			_isphoneverified = false; 
			_nameprefix = null; 
			_primarylanguageid = -1; 
			_middlename = null; 
			_worldtimezonetitle = null; 
			_worldtimezoneiananame = null; 
			_worldtimezoneid = -1; 
			_referreruserid = null; 
			_resetpasswordcode = null; 
			_resetpasswordrequestdate = null; 
			_isonline = false; 
			_lastonlinedate = null; 
			_insertsiteid = -1; 
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
			
		public virtual string MembershipAreaName
		{
			get
			{ 
				return _membershipareaname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MembershipAreaName", value, value.ToString());
				
				_membershipareaname = value;
			}
		}
			
		public virtual string MembershipAreaCode
		{
			get
			{ 
				return _membershipareacode;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for MembershipAreaCode", value, value.ToString());
				
				_membershipareacode = value;
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
			
		public virtual string RoleName
		{
			get
			{ 
				return _rolename;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for RoleName", value, value.ToString());
				
				_rolename = value;
			}
		}
			
		public virtual string RoleCode
		{
			get
			{ 
				return _rolecode;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for RoleCode", value, value.ToString());
				
				_rolecode = value;
			}
		}
			
		public virtual string UserApprovalStatusTitle
		{
			get
			{ 
				return _userapprovalstatustitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UserApprovalStatusTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserApprovalStatusTitle", value, value.ToString());
				
				_userapprovalstatustitle = value;
			}
		}
			
		public virtual string UserApprovalStatusCode
		{
			get
			{ 
				return _userapprovalstatuscode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for UserApprovalStatusCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserApprovalStatusCode", value, value.ToString());
				
				_userapprovalstatuscode = value;
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
			
		public virtual string WorldTimeZoneTitle
		{
			get
			{ 
				return _worldtimezonetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for WorldTimeZoneTitle", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for WorldTimeZoneTitle", value, value.ToString());
				
				_worldtimezonetitle = value;
			}
		}
			
		public virtual string WorldTimeZoneIANAName
		{
			get
			{ 
				return _worldtimezoneiananame;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for WorldTimeZoneIANAName", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for WorldTimeZoneIANAName", value, value.ToString());
				
				_worldtimezoneiananame = value;
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
