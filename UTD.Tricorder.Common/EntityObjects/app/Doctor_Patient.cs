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
	public partial class Doctor_Patient : EntityObjectBase
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

		#region Private Members

		private long _doctor_patientid; private long _doctorid;//0
//private Doctor _doctorid;//1
private long _patientuserid;//0
//private User _patientuserid;//1
		
		#endregion

		#region Constructor

		public Doctor_Patient()
		 //: base()
		{
			_doctor_patientid = -1; 
			_doctorid = -1; 
			_patientuserid = -1; 
		}

		public Doctor_Patient(
			long doctor_patientid, 
			long doctorid, 
			long patientuserid)
			: this()
		{
			_doctor_patientid = doctor_patientid;
			_doctorid = doctorid;
			_patientuserid = patientuserid;
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
