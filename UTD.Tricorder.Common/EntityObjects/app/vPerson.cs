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
	public partial class vPerson : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.
        public virtual string FullName
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


		public const string EntityName = "Person";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string PersonID = "PersonID";
			public const string Birthday = "Birthday";
			public const string GenderTypeID = "GenderTypeID";
			public const string UserName = "UserName";
			public const string USStateID = "USStateID";
			public const string AddressLine1 = "AddressLine1";
			public const string AddressLine2 = "AddressLine2";
			public const string City = "City";
			public const string ZipCode = "ZipCode";
			public const string CountryID = "CountryID";
			public const string StateTitle = "StateTitle";
			public const string NonUSStateTitle = "NonUSStateTitle";
			public const string StateName = "StateName";
			public const string CountryName = "CountryName";
			public const string FirstName = "FirstName";
			public const string LastName = "LastName";
			public const string NamePrefix = "NamePrefix";
			public const string PhoneNumber = "PhoneNumber";
			public const string Email = "Email";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("PersonID");
			_ColumnsList.Add("Birthday");
			_ColumnsList.Add("GenderTypeID");
			_ColumnsList.Add("UserName");
			_ColumnsList.Add("USStateID");
			_ColumnsList.Add("AddressLine1");
			_ColumnsList.Add("AddressLine2");
			_ColumnsList.Add("City");
			_ColumnsList.Add("ZipCode");
			_ColumnsList.Add("CountryID");
			_ColumnsList.Add("StateTitle");
			_ColumnsList.Add("NonUSStateTitle");
			_ColumnsList.Add("StateName");
			_ColumnsList.Add("CountryName");
			_ColumnsList.Add("FirstName");
			_ColumnsList.Add("LastName");
			_ColumnsList.Add("NamePrefix");
			_ColumnsList.Add("PhoneNumber");
			_ColumnsList.Add("Email");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _personid; 
		private DateTime? _birthday; 
		private int? _gendertypeid; 
		private string _username; 
		private string _usstateid; 
		private string _addressline1; 
		private string _addressline2; 
		private string _city; 
		private string _zipcode; 
		private string _countryid; 
		private string _statetitle; 
		private string _nonusstatetitle; 
		private string _statename; 
		private string _countryname; 
		private string _firstname; 
		private string _lastname; 
		private string _nameprefix; 
		private string _phonenumber; 
		private string _email; 		
		#endregion

		#region Constructor

		public vPerson()
		 //: base()
		{
			_personid = -1; 
			_birthday = null; 
			_gendertypeid = null; 
			_username = null; 
			_usstateid = null; 
			_addressline1 = null; 
			_addressline2 = null; 
			_city = null; 
			_zipcode = null; 
			_countryid = null; 
			_statetitle = null; 
			_nonusstatetitle = null; 
			_statename = null; 
			_countryname = null; 
			_firstname = null; 
			_lastname = null; 
			_nameprefix = null; 
			_phonenumber = null; 
			_email = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long PersonID
		{
			get
			{ 
				return _personid;
			}
			set
			{
				_personid = value;
			}

		}
			
		public virtual DateTime? Birthday
		{
			get
			{ 
				return _birthday;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for Birthday", value, value.ToString());
						
				_birthday = value;	
			}			
					
		}
			
		public virtual int? GenderTypeID
		{
			get
			{ 
				return _gendertypeid;
			}
			set
			{
				_gendertypeid = value;
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
			
		public virtual string USStateID
		{
			get
			{ 
				return _usstateid;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for USStateID", value, value.ToString());
				
				_usstateid = value;
			}
		}
			
		public virtual string AddressLine1
		{
			get
			{ 
				return _addressline1;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for AddressLine1", value, value.ToString());
				
				_addressline1 = value;
			}
		}
			
		public virtual string AddressLine2
		{
			get
			{ 
				return _addressline2;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for AddressLine2", value, value.ToString());
				
				_addressline2 = value;
			}
		}
			
		public virtual string City
		{
			get
			{ 
				return _city;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for City", value, value.ToString());
				
				_city = value;
			}
		}
			
		public virtual string ZipCode
		{
			get
			{ 
				return _zipcode;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 15)
				//	throw new ArgumentOutOfRangeException("Invalid value for ZipCode", value, value.ToString());
				
				_zipcode = value;
			}
		}
			
		public virtual string CountryID
		{
			get
			{ 
				return _countryid;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for CountryID", value, value.ToString());
				
				_countryid = value;
			}
		}
			
		public virtual string StateTitle
		{
			get
			{ 
				return _statetitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 250)
				//	throw new ArgumentOutOfRangeException("Invalid value for StateTitle", value, value.ToString());
				
				_statetitle = value;
			}
		}
			
		public virtual string NonUSStateTitle
		{
			get
			{ 
				return _nonusstatetitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for NonUSStateTitle", value, value.ToString());
				
				_nonusstatetitle = value;
			}
		}
			
		public virtual string StateName
		{
			get
			{ 
				return _statename;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 250)
				//	throw new ArgumentOutOfRangeException("Invalid value for StateName", value, value.ToString());
				
				_statename = value;
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.PersonID;
			
        }
		
		#endregion //Public Functions
	}
}
