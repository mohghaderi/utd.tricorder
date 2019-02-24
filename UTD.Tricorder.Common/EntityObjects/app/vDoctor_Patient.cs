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
	public partial class vDoctor_Patient : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Doctor complate name
        /// </summary>
        public virtual string DoctorFullName
        {
            get 
            {
                return FWUtils.EntityUtils.ConcatStrings(" ", this.DoctorNamePrefix, this.DoctorFirstName, this.DoctorLastName);
            }
        }

        /// <summary>
        /// Patient full name
        /// </summary>
        public virtual string PatientFullName
        {
            get
            {
                return FWUtils.EntityUtils.ConcatStrings(" ", this.PatientNamePrefix, this.PatientFirstName, this.PatientLastName);
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

        private string _PatientProfilePicUrl;

        public virtual string PatientProfilePicUrl
        {
            get
            {
                return _PatientProfilePicUrl;
            }
            set
            {
                _PatientProfilePicUrl = value;
            }
        }

		#endregion


		public const string EntityName = "Doctor_Patient";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string Doctor_PatientID = "Doctor_PatientID";
			public const string DoctorID = "DoctorID";
			public const string PatientUserID = "PatientUserID";
			public const string DoctorFirstName = "DoctorFirstName";
			public const string DoctorLastName = "DoctorLastName";
			public const string DoctorNamePrefix = "DoctorNamePrefix";
			public const string PatientFirstName = "PatientFirstName";
			public const string PatientLastName = "PatientLastName";
			public const string PatientNamePrefix = "PatientNamePrefix";
			public const string PatientPhoneNumber = "PatientPhoneNumber";
			public const string ClinicPhoneNumber = "ClinicPhoneNumber";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("Doctor_PatientID");
			_ColumnsList.Add("DoctorID");
			_ColumnsList.Add("PatientUserID");
			_ColumnsList.Add("DoctorFirstName");
			_ColumnsList.Add("DoctorLastName");
			_ColumnsList.Add("DoctorNamePrefix");
			_ColumnsList.Add("PatientFirstName");
			_ColumnsList.Add("PatientLastName");
			_ColumnsList.Add("PatientNamePrefix");
			_ColumnsList.Add("PatientPhoneNumber");
			_ColumnsList.Add("ClinicPhoneNumber");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _doctor_patientid; 
		private long _doctorid; 
		private long _patientuserid; 
		private string _doctorfirstname; 
		private string _doctorlastname; 
		private string _doctornameprefix; 
		private string _patientfirstname; 
		private string _patientlastname; 
		private string _patientnameprefix; 
		private string _patientphonenumber; 
		private string _clinicphonenumber; 		
		#endregion

		#region Constructor

		public vDoctor_Patient()
		 //: base()
		{
			_doctor_patientid = -1; 
			_doctorid = -1; 
			_patientuserid = -1; 
			_doctorfirstname = null; 
			_doctorlastname = null; 
			_doctornameprefix = null; 
			_patientfirstname = null; 
			_patientlastname = null; 
			_patientnameprefix = null; 
			_patientphonenumber = null; 
			_clinicphonenumber = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long Doctor_PatientID
		{
			get
			{ 
				return _doctor_patientid;
			}
			set
			{
				_doctor_patientid = value;
			}

		}
			
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
			
		public virtual long PatientUserID
		{
			get
			{ 
				return _patientuserid;
			}
			set
			{
				_patientuserid = value;
			}

		}
			
		public virtual string DoctorFirstName
		{
			get
			{ 
				return _doctorfirstname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for DoctorFirstName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorFirstName", value, value.ToString());
				
				_doctorfirstname = value;
			}
		}
			
		public virtual string DoctorLastName
		{
			get
			{ 
				return _doctorlastname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for DoctorLastName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorLastName", value, value.ToString());
				
				_doctorlastname = value;
			}
		}
			
		public virtual string DoctorNamePrefix
		{
			get
			{ 
				return _doctornameprefix;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 4)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorNamePrefix", value, value.ToString());
				
				_doctornameprefix = value;
			}
		}
			
		public virtual string PatientFirstName
		{
			get
			{ 
				return _patientfirstname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PatientFirstName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for PatientFirstName", value, value.ToString());
				
				_patientfirstname = value;
			}
		}
			
		public virtual string PatientLastName
		{
			get
			{ 
				return _patientlastname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PatientLastName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for PatientLastName", value, value.ToString());
				
				_patientlastname = value;
			}
		}
			
		public virtual string PatientNamePrefix
		{
			get
			{ 
				return _patientnameprefix;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 4)
				//	throw new ArgumentOutOfRangeException("Invalid value for PatientNamePrefix", value, value.ToString());
				
				_patientnameprefix = value;
			}
		}
			
		public virtual string PatientPhoneNumber
		{
			get
			{ 
				return _patientphonenumber;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 18)
				//	throw new ArgumentOutOfRangeException("Invalid value for PatientPhoneNumber", value, value.ToString());
				
				_patientphonenumber = value;
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.Doctor_PatientID;
			
        }
		
		#endregion //Public Functions
	}
}
