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
	public partial class Doctor_Insurance : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _doctor_insuranceid; private long _doctorid;//0
//private Doctor _doctorid;//1
private long _insuranceplanid;//0
//private InsurancePlan _insuranceplanid;//1
		
		#endregion

		#region Constructor

		public Doctor_Insurance()
		 //: base()
		{
			_doctor_insuranceid = -1; 
			_doctorid = -1; 
			_insuranceplanid = -1; 
		}

		public Doctor_Insurance(
			long doctor_insuranceid, 
			long doctorid, 
			long insuranceplanid)
			: this()
		{
			_doctor_insuranceid = doctor_insuranceid;
			_doctorid = doctorid;
			_insuranceplanid = insuranceplanid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long Doctor_InsuranceID
		{
			get
			{ 
				return _doctor_insuranceid;
			}
			set
			{
				_doctor_insuranceid = value;
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
			
		public virtual long InsurancePlanID
		{
			get
			{ 
				return _insuranceplanid;
			}
			set
			{
				_insuranceplanid = value;
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
            return this.Doctor_InsuranceID;
			
        }
		
		#endregion //Public Functions
	}
}
