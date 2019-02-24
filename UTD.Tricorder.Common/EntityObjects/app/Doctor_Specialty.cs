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
	public partial class Doctor_Specialty : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _doctor_specialtyid; private long _doctorid;//0
//private Doctor _doctorid;//1
private int _specialtyid;//0
//private Specialty _specialtyid;//1
		
		#endregion

		#region Constructor

		public Doctor_Specialty()
		 //: base()
		{
			_doctor_specialtyid = -1; 
			_doctorid = -1; 
			_specialtyid = -1; 
		}

		public Doctor_Specialty(
			long doctor_specialtyid, 
			long doctorid, 
			int specialtyid)
			: this()
		{
			_doctor_specialtyid = doctor_specialtyid;
			_doctorid = doctorid;
			_specialtyid = specialtyid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long Doctor_SpecialtyID
		{
			get
			{ 
				return _doctor_specialtyid;
			}
			set
			{
				_doctor_specialtyid = value;
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
			
		public virtual int SpecialtyID
		{
			get
			{ 
				return _specialtyid;
			}
			set
			{
				_specialtyid = value;
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
            return this.Doctor_SpecialtyID;
			
        }
		
		#endregion //Public Functions
	}
}
