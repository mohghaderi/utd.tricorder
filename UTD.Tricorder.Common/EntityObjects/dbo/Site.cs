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
	public partial class Site : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private int _siteid; 
		private string _sitecode; 
		private string _sitetitle; 
		private string _fileserverdomain; 
		private int? _resetpasswordnewrequestwaitseconds; 
		private int? _resetpasswordcodeexpireseconds; 
		private string _companyaddress; 
		private string _companyphonenumber; private short _defaultlanguageid;//0
//private Language _defaultlanguageid;//1
private string _defaultcountryid;//0
//private Country _defaultcountryid;//1

		private int? _contactuserid; 
		private int? _owneruserid; 
		private int? _insertuserid; 
		private DateTime _insertdate; 		
		#endregion

		#region Constructor

		public Site()
		 //: base()
		{
			_siteid = -1; 
			_sitecode = null; 
			_sitetitle = null; 
			_fileserverdomain = null; 
			_resetpasswordnewrequestwaitseconds = null; 
			_resetpasswordcodeexpireseconds = null; 
			_companyaddress = null; 
			_companyphonenumber = null; 
			_defaultlanguageid = -1; 
			_defaultcountryid = null; 
			_contactuserid = null; 
			_owneruserid = null; 
			_insertuserid = null; 
			_insertdate = DateTime.MinValue; 
		}

		public Site(
			int siteid, 
			string sitecode, 
			string sitetitle, 
			short defaultlanguageid, 
			string defaultcountryid, 
			DateTime insertdate)
			: this()
		{
			_siteid = siteid;
			_sitecode = sitecode;
			_sitetitle = sitetitle;
			_fileserverdomain = String.Empty;
			_resetpasswordnewrequestwaitseconds = null;
			_resetpasswordcodeexpireseconds = null;
			_companyaddress = String.Empty;
			_companyphonenumber = String.Empty;
			_defaultlanguageid = defaultlanguageid;
			_defaultcountryid = defaultcountryid;
			_contactuserid = null;
			_owneruserid = null;
			_insertuserid = null;
			_insertdate = insertdate;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int SiteID
		{
			get
			{ 
				return _siteid;
			}
			set
			{
				_siteid = value;
			}

		}
			
		public virtual string SiteCode
		{
			get
			{ 
				return _sitecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SiteCode", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for SiteCode", value, value.ToString());
				
				_sitecode = value;
			}
		}
			
		public virtual string SiteTitle
		{
			get
			{ 
				return _sitetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SiteTitle", value, "null");
				
				//if(  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for SiteTitle", value, value.ToString());
				
				_sitetitle = value;
			}
		}
			
		public virtual string FileServerDomain
		{
			get
			{ 
				return _fileserverdomain;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for FileServerDomain", value, value.ToString());
				
				_fileserverdomain = value;
			}
		}
			
		public virtual int? ResetPasswordNewRequestWaitSeconds
		{
			get
			{ 
				return _resetpasswordnewrequestwaitseconds;
			}
			set
			{
				_resetpasswordnewrequestwaitseconds = value;
			}

		}
			
		public virtual int? ResetPasswordCodeExpireSeconds
		{
			get
			{ 
				return _resetpasswordcodeexpireseconds;
			}
			set
			{
				_resetpasswordcodeexpireseconds = value;
			}

		}
			
		public virtual string CompanyAddress
		{
			get
			{ 
				return _companyaddress;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for CompanyAddress", value, value.ToString());
				
				_companyaddress = value;
			}
		}
			
		public virtual string CompanyPhoneNumber
		{
			get
			{ 
				return _companyphonenumber;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 18)
				//	throw new ArgumentOutOfRangeException("Invalid value for CompanyPhoneNumber", value, value.ToString());
				
				_companyphonenumber = value;
			}
		}
			
		public virtual short DefaultLanguageID
		{
			get
			{ 
				return _defaultlanguageid;
			}
			set
			{
				_defaultlanguageid = value;
			}

		}
			
		public virtual string DefaultCountryID
		{
			get
			{ 
				return _defaultcountryid;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for DefaultCountryID", value, "null");
				
				//if(  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for DefaultCountryID", value, value.ToString());
				
				_defaultcountryid = value;
			}
		}
			
		public virtual int? ContactUserID
		{
			get
			{ 
				return _contactuserid;
			}
			set
			{
				_contactuserid = value;
			}

		}
			
		public virtual int? OwnerUserID
		{
			get
			{ 
				return _owneruserid;
			}
			set
			{
				_owneruserid = value;
			}

		}
			
		public virtual int? InsertUserID
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.SiteID;
			
        }
		
		#endregion //Public Functions
	}
}
