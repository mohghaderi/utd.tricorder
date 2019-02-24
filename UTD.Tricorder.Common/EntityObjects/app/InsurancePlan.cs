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
	public partial class InsurancePlan : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private long _insuranceplanid;//3

		//private IList<Doctor_Insurance> _Doctor_InsuranceList; 

		//private IList<PatientInsurance> _PatientInsuranceList; 
private long _insuranceid;//0
//private Insurance _insuranceid;//1

		private string _insuranceplantitle; 
		private bool _isdental; 		
		#endregion

		#region Constructor

		public InsurancePlan()
		 //: base()
		{
			_insuranceplanid = -1; 
			//_Doctor_InsuranceList = new List<Doctor_Insurance>(); 
			//_PatientInsuranceList = new List<PatientInsurance>(); 
			_insuranceid = -1; 
			_insuranceplantitle = null; 
			_isdental = false; 
		}

		public InsurancePlan(
			long insuranceplanid, 
			long insuranceid, 
			string insuranceplantitle, 
			bool isdental)
			: this()
		{
			_insuranceplanid = insuranceplanid;
			_insuranceid = insuranceid;
			_insuranceplantitle = insuranceplantitle;
			_isdental = isdental;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual long InsuranceID
		{
			get
			{ 
				return _insuranceid;
			}
			set
			{
				_insuranceid = value;
			}

		}
			
		public virtual string InsurancePlanTitle
		{
			get
			{ 
				return _insuranceplantitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for InsurancePlanTitle", value, "null");
				
				//if(  value.Length > 350)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsurancePlanTitle", value, value.ToString());
				
				_insuranceplantitle = value;
			}
		}
			
		public virtual bool IsDental
		{
			get
			{ 
				return _isdental;
			}
			set
			{
				_isdental = value;
			}

		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddDoctor_Insurance(Doctor_Insurance obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_Doctor_InsuranceList.Add(obj);
		//}
		

		//public virtual void AddPatientInsurance(PatientInsurance obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PatientInsuranceList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.InsurancePlanID;
			
        }
		
		#endregion //Public Functions
	}
}
