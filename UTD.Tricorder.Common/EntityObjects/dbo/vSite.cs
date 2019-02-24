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
	public partial class vSite : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Site";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string SiteID = "SiteID";
			public const string SiteCode = "SiteCode";
			public const string SiteTitle = "SiteTitle";
			public const string FileServerDomain = "FileServerDomain";
			public const string ResetPasswordNewRequestWaitSeconds = "ResetPasswordNewRequestWaitSeconds";
			public const string ResetPasswordCodeExpireSeconds = "ResetPasswordCodeExpireSeconds";
			public const string CompanyAddress = "CompanyAddress";
			public const string CompanyPhoneNumber = "CompanyPhoneNumber";
			public const string DefaultLanguageID = "DefaultLanguageID";
			public const string DefaultCountryID = "DefaultCountryID";
			public const string ContactUserID = "ContactUserID";
			public const string OwnerUserID = "OwnerUserID";
			public const string InsertUserID = "InsertUserID";
			public const string InsertDate = "InsertDate";
			public const string CountryName = "CountryName";
			public const string CountryTitle = "CountryTitle";
			public const string LanguageName = "LanguageName";
			public const string LanguageCode = "LanguageCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("SiteID");
			_ColumnsList.Add("SiteCode");
			_ColumnsList.Add("SiteTitle");
			_ColumnsList.Add("FileServerDomain");
			_ColumnsList.Add("ResetPasswordNewRequestWaitSeconds");
			_ColumnsList.Add("ResetPasswordCodeExpireSeconds");
			_ColumnsList.Add("CompanyAddress");
			_ColumnsList.Add("CompanyPhoneNumber");
			_ColumnsList.Add("DefaultLanguageID");
			_ColumnsList.Add("DefaultCountryID");
			_ColumnsList.Add("ContactUserID");
			_ColumnsList.Add("OwnerUserID");
			_ColumnsList.Add("InsertUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("CountryName");
			_ColumnsList.Add("CountryTitle");
			_ColumnsList.Add("LanguageName");
			_ColumnsList.Add("LanguageCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _siteid; 
		private string _sitecode; 
		private string _sitetitle; 
		private string _fileserverdomain; 
		private int? _resetpasswordnewrequestwaitseconds; 
		private int? _resetpasswordcodeexpireseconds; 
		private string _companyaddress; 
		private string _companyphonenumber; 
		private short _defaultlanguageid; 
		private string _defaultcountryid; 
		private int? _contactuserid; 
		private int? _owneruserid; 
		private int? _insertuserid; 
		private DateTime _insertdate; 
		private string _countryname; 
		private string _countrytitle; 
		private string _languagename; 
		private string _languagecode; 		
		#endregion

		#region Constructor

		public vSite()
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
			_countryname = null; 
			_countrytitle = null; 
			_languagename = null; 
			_languagecode = null; 
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
			
		public virtual string CountryName
		{
			get
			{ 
				return _countryname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryName", value, value.ToString());
				
				_countryname = value;
			}
		}
			
		public virtual string CountryTitle
		{
			get
			{ 
				return _countrytitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryTitle", value, value.ToString());
				
				_countrytitle = value;
			}
		}
			
		public virtual string LanguageName
		{
			get
			{ 
				return _languagename;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for LanguageName", value, value.ToString());
				
				_languagename = value;
			}
		}
			
		public virtual string LanguageCode
		{
			get
			{ 
				return _languagecode;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for LanguageCode", value, value.ToString());
				
				_languagecode = value;
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
