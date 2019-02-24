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
	public partial class Doctor : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

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

		#region Private Members
		private long _doctorid;//3

		//private IList<Doctor_Illness> _Doctor_IllnessList; 

		//private IList<Doctor_Insurance> _Doctor_InsuranceList; 

		//private IList<Doctor_Patient> _Doctor_PatientList; 

		//private IList<Doctor_Specialty> _Doctor_SpecialtyList; 

		//private IList<Doctor_USState> _Doctor_USStateList; 

		//private IList<DoctorSchedule> _DoctorScheduleList; 

		//private IList<Doctor> _DoctorList; 

		private string _degrees; 
		private string _professionalstatement; 
		private string _registrationnumber; 
		private string _licensenumbers; 
		private decimal _defaultvisitprice; 
		private string _clinicaddress; 
		private short _boardcertificationyear; 
		private string _medicalschool; 
		private string _residencyplace; 
		private bool _hospitalprivileges; 
		private bool _hasrevokedlicense; 
		private string _federaldeainformation; 
		private bool _hasmilitaryexperience; 
		private string _clinicphonenumber; 
		private string _clinicphonenumbersearchable; 		
		#endregion

		#region Constructor

		public Doctor()
		 //: base()
		{
			_doctorid = -1; 
			//_Doctor_IllnessList = new List<Doctor_Illness>(); 
			//_Doctor_InsuranceList = new List<Doctor_Insurance>(); 
			//_Doctor_PatientList = new List<Doctor_Patient>(); 
			//_Doctor_SpecialtyList = new List<Doctor_Specialty>(); 
			//_Doctor_USStateList = new List<Doctor_USState>(); 
			//_DoctorScheduleList = new List<DoctorSchedule>(); 
			//_DoctorList = new List<Doctor>(); 
			_degrees = null; 
			_professionalstatement = null; 
			_registrationnumber = null; 
			_licensenumbers = null; 
			_defaultvisitprice = -1; 
			_clinicaddress = null; 
			_boardcertificationyear = -1; 
			_medicalschool = null; 
			_residencyplace = null; 
			_hospitalprivileges = false; 
			_hasrevokedlicense = false; 
			_federaldeainformation = null; 
			_hasmilitaryexperience = false; 
			_clinicphonenumber = null; 
			_clinicphonenumbersearchable = null; 
		}

		public Doctor(
			long doctorid, 
			string degrees, 
			string professionalstatement, 
			string registrationnumber, 
			string licensenumbers, 
			decimal defaultvisitprice, 
			short boardcertificationyear, 
			string medicalschool, 
			string residencyplace, 
			bool hospitalprivileges, 
			bool hasrevokedlicense, 
			bool hasmilitaryexperience)
			: this()
		{
			_doctorid = doctorid;
			_degrees = degrees;
			_professionalstatement = professionalstatement;
			_registrationnumber = registrationnumber;
			_licensenumbers = licensenumbers;
			_defaultvisitprice = defaultvisitprice;
			_clinicaddress = String.Empty;
			_boardcertificationyear = boardcertificationyear;
			_medicalschool = medicalschool;
			_residencyplace = residencyplace;
			_hospitalprivileges = hospitalprivileges;
			_hasrevokedlicense = hasrevokedlicense;
			_federaldeainformation = String.Empty;
			_hasmilitaryexperience = hasmilitaryexperience;
			_clinicphonenumber = String.Empty;
			_clinicphonenumbersearchable = String.Empty;
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
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddDoctor_Illness(Doctor_Illness obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Doctor_IllnessList.Add(obj);
		//}
		

		//public virtual void AddDoctor_Insurance(Doctor_Insurance obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Doctor_InsuranceList.Add(obj);
		//}
		

		//public virtual void AddDoctor_Patient(Doctor_Patient obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Doctor_PatientList.Add(obj);
		//}
		

		//public virtual void AddDoctor_Specialty(Doctor_Specialty obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Doctor_SpecialtyList.Add(obj);
		//}
		

		//public virtual void AddDoctor_USState(Doctor_USState obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Doctor_USStateList.Add(obj);
		//}
		

		//public virtual void AddDoctorSchedule(DoctorSchedule obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_DoctorScheduleList.Add(obj);
		//}
		

		//public virtual void AddDoctor(Doctor obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_DoctorList.Add(obj);
		//}
		


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
