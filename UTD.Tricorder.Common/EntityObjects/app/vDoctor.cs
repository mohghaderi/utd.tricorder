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
	public partial class vDoctor : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        public virtual string DoctorFullName
        {
            get
            {
                return FWUtils.EntityUtils.ConcatStrings(" ", this.NamePrefix, this.FirstName, this.LastName);
            }
        }

        private string _DoctorProfilePicUrl;

        public virtual string DoctorProfilePicUrl
        {
            get
            {
                return _DoctorProfilePicUrl;
            }
            set
            {
                _DoctorProfilePicUrl = value;
            }
        }

		#endregion


		public const string EntityName = "Doctor";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string DoctorID = "DoctorID";
			public const string ProfessionalStatement = "ProfessionalStatement";
			public const string RegistrationNumber = "RegistrationNumber";
			public const string DefaultVisitPrice = "DefaultVisitPrice";
			public const string ClinicAddress = "ClinicAddress";
			public const string FirstName = "FirstName";
			public const string LastName = "LastName";
			public const string NamePrefix = "NamePrefix";
			public const string Degrees = "Degrees";
			public const string BoardCertificationYear = "BoardCertificationYear";
			public const string LicenseNumbers = "LicenseNumbers";
			public const string MedicalSchool = "MedicalSchool";
			public const string ResidencyPlace = "ResidencyPlace";
			public const string HospitalPrivileges = "HospitalPrivileges";
			public const string HasRevokedLicense = "HasRevokedLicense";
			public const string FederalDEAInformation = "FederalDEAInformation";
			public const string HasMilitaryExperience = "HasMilitaryExperience";
			public const string ClinicPhoneNumber = "ClinicPhoneNumber";
			public const string ClinicPhoneNumberSearchable = "ClinicPhoneNumberSearchable";
			public const string SpecialtiesList = "SpecialtiesList";
			public const string InsuranceFullNamesList = "InsuranceFullNamesList";
			public const string USStatesList = "USStatesList";
			public const string LanguagesList = "LanguagesList";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("DoctorID");
			_ColumnsList.Add("ProfessionalStatement");
			_ColumnsList.Add("RegistrationNumber");
			_ColumnsList.Add("DefaultVisitPrice");
			_ColumnsList.Add("ClinicAddress");
			_ColumnsList.Add("FirstName");
			_ColumnsList.Add("LastName");
			_ColumnsList.Add("NamePrefix");
			_ColumnsList.Add("Degrees");
			_ColumnsList.Add("BoardCertificationYear");
			_ColumnsList.Add("LicenseNumbers");
			_ColumnsList.Add("MedicalSchool");
			_ColumnsList.Add("ResidencyPlace");
			_ColumnsList.Add("HospitalPrivileges");
			_ColumnsList.Add("HasRevokedLicense");
			_ColumnsList.Add("FederalDEAInformation");
			_ColumnsList.Add("HasMilitaryExperience");
			_ColumnsList.Add("ClinicPhoneNumber");
			_ColumnsList.Add("ClinicPhoneNumberSearchable");
			_ColumnsList.Add("SpecialtiesList");
			_ColumnsList.Add("InsuranceFullNamesList");
			_ColumnsList.Add("USStatesList");
			_ColumnsList.Add("LanguagesList");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _doctorid; 
		private string _professionalstatement; 
		private string _registrationnumber; 
		private decimal _defaultvisitprice; 
		private string _clinicaddress; 
		private string _firstname; 
		private string _lastname; 
		private string _nameprefix; 
		private string _degrees; 
		private short _boardcertificationyear; 
		private string _licensenumbers; 
		private string _medicalschool; 
		private string _residencyplace; 
		private bool _hospitalprivileges; 
		private bool _hasrevokedlicense; 
		private string _federaldeainformation; 
		private bool _hasmilitaryexperience; 
		private string _clinicphonenumber; 
		private string _clinicphonenumbersearchable; 
		private string _specialtieslist; 
		private string _insurancefullnameslist; 
		private string _usstateslist; 
		private string _languageslist; 		
		#endregion

		#region Constructor

		public vDoctor()
		 //: base()
		{
			_doctorid = -1; 
			_professionalstatement = null; 
			_registrationnumber = null; 
			_defaultvisitprice = -1; 
			_clinicaddress = null; 
			_firstname = null; 
			_lastname = null; 
			_nameprefix = null; 
			_degrees = null; 
			_boardcertificationyear = -1; 
			_licensenumbers = null; 
			_medicalschool = null; 
			_residencyplace = null; 
			_hospitalprivileges = false; 
			_hasrevokedlicense = false; 
			_federaldeainformation = null; 
			_hasmilitaryexperience = false; 
			_clinicphonenumber = null; 
			_clinicphonenumbersearchable = null; 
			_specialtieslist = null; 
			_insurancefullnameslist = null; 
			_usstateslist = null; 
			_languageslist = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long DoctorID
		{
			get
			{ 
				return _doctorid;
			}
			set
			{
				_doctorid = value;
			}

		}
			
		public virtual string ProfessionalStatement
		{
			get
			{ 
				return _professionalstatement;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ProfessionalStatement", value, "null");
				
				//if(  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for ProfessionalStatement", value, value.ToString());
				
				_professionalstatement = value;
			}
		}
			
		public virtual string RegistrationNumber
		{
			get
			{ 
				return _registrationnumber;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for RegistrationNumber", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for RegistrationNumber", value, value.ToString());
				
				_registrationnumber = value;
			}
		}
			
		public virtual decimal DefaultVisitPrice
		{
			get
			{ 
				return _defaultvisitprice;
			}
			set
			{
				_defaultvisitprice = value;
			}

		}
			
		public virtual string ClinicAddress
		{
			get
			{ 
				return _clinicaddress;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2048)
				//	throw new ArgumentOutOfRangeException("Invalid value for ClinicAddress", value, value.ToString());
				
				_clinicaddress = value;
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
			
		public virtual string Degrees
		{
			get
			{ 
				return _degrees;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for Degrees", value, "null");
				
				//if(  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for Degrees", value, value.ToString());
				
				_degrees = value;
			}
		}
			
		public virtual short BoardCertificationYear
		{
			get
			{ 
				return _boardcertificationyear;
			}
			set
			{
				_boardcertificationyear = value;
			}

		}
			
		public virtual string LicenseNumbers
		{
			get
			{ 
				return _licensenumbers;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for LicenseNumbers", value, "null");
				
				//if(  value.Length > 500)
				//	throw new ArgumentOutOfRangeException("Invalid value for LicenseNumbers", value, value.ToString());
				
				_licensenumbers = value;
			}
		}
			
		public virtual string MedicalSchool
		{
			get
			{ 
				return _medicalschool;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MedicalSchool", value, "null");
				
				//if(  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for MedicalSchool", value, value.ToString());
				
				_medicalschool = value;
			}
		}
			
		public virtual string ResidencyPlace
		{
			get
			{ 
				return _residencyplace;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ResidencyPlace", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ResidencyPlace", value, value.ToString());
				
				_residencyplace = value;
			}
		}
			
		public virtual bool HospitalPrivileges
		{
			get
			{ 
				return _hospitalprivileges;
			}
			set
			{
				_hospitalprivileges = value;
			}

		}
			
		public virtual bool HasRevokedLicense
		{
			get
			{ 
				return _hasrevokedlicense;
			}
			set
			{
				_hasrevokedlicense = value;
			}

		}
			
		public virtual string FederalDEAInformation
		{
			get
			{ 
				return _federaldeainformation;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2000)
				//	throw new ArgumentOutOfRangeException("Invalid value for FederalDEAInformation", value, value.ToString());
				
				_federaldeainformation = value;
			}
		}
			
		public virtual bool HasMilitaryExperience
		{
			get
			{ 
				return _hasmilitaryexperience;
			}
			set
			{
				_hasmilitaryexperience = value;
			}

		}
			
		public virtual string ClinicPhoneNumber
		{
			get
			{ 
				return _clinicphonenumber;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 42)
				//	throw new ArgumentOutOfRangeException("Invalid value for ClinicPhoneNumber", value, value.ToString());
				
				_clinicphonenumber = value;
			}
		}
			
		public virtual string ClinicPhoneNumberSearchable
		{
			get
			{ 
				return _clinicphonenumbersearchable;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 42)
				//	throw new ArgumentOutOfRangeException("Invalid value for ClinicPhoneNumberSearchable", value, value.ToString());
				
				_clinicphonenumbersearchable = value;
			}
		}
			
		public virtual string SpecialtiesList
		{
			get
			{ 
				return _specialtieslist;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for SpecialtiesList", value, value.ToString());
				
				_specialtieslist = value;
			}
		}
			
		public virtual string InsuranceFullNamesList
		{
			get
			{ 
				return _insurancefullnameslist;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsuranceFullNamesList", value, value.ToString());
				
				_insurancefullnameslist = value;
			}
		}
			
		public virtual string USStatesList
		{
			get
			{ 
				return _usstateslist;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for USStatesList", value, value.ToString());
				
				_usstateslist = value;
			}
		}
			
		public virtual string LanguagesList
		{
			get
			{ 
				return _languageslist;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for LanguagesList", value, value.ToString());
				
				_languageslist = value;
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
            return this.DoctorID;
			
        }
		
		#endregion //Public Functions
	}
}
