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
	public partial class PatientInsurance : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _patientinsuranceid; private long _patientuserid;//0
//private User _patientuserid;//1

		private string _subscribername; private long _insuranceplanid;//0
//private InsurancePlan _insuranceplanid;//1

		private string _groupnumber; 
		private string _benefitidentifier; 
		private string _insuranceconumber; 
		private int _copayamount; 
		private bool _isprimary; 		
		#endregion

		#region Constructor

		public PatientInsurance()
		 //: base()
		{
			_patientinsuranceid = -1; 
			_patientuserid = -1; 
			_subscribername = null; 
			_insuranceplanid = -1; 
			_groupnumber = null; 
			_benefitidentifier = null; 
			_insuranceconumber = null; 
			_copayamount = -1; 
			_isprimary = false; 
		}

		public PatientInsurance(
			long patientinsuranceid, 
			long patientuserid, 
			string subscribername, 
			long insuranceplanid, 
			string groupnumber, 
			string benefitidentifier, 
			string insuranceconumber, 
			int copayamount, 
			bool isprimary)
			: this()
		{
			_patientinsuranceid = patientinsuranceid;
			_patientuserid = patientuserid;
			_subscribername = subscribername;
			_insuranceplanid = insuranceplanid;
			_groupnumber = groupnumber;
			_benefitidentifier = benefitidentifier;
			_insuranceconumber = insuranceconumber;
			_copayamount = copayamount;
			_isprimary = isprimary;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long PatientInsuranceID
		{
			get
			{ 
				return _patientinsuranceid;
			}
			set
			{
				_patientinsuranceid = value;
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
			
		public virtual string SubscriberName
		{
			get
			{ 
				return _subscribername;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SubscriberName", value, "null");
				
				//if(  value.Length > 250)
				//	throw new ArgumentOutOfRangeException("Invalid value for SubscriberName", value, value.ToString());
				
				_subscribername = value;
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
			
		public virtual string GroupNumber
		{
			get
			{ 
				return _groupnumber;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for GroupNumber", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for GroupNumber", value, value.ToString());
				
				_groupnumber = value;
			}
		}
			
		public virtual string BenefitIdentifier
		{
			get
			{ 
				return _benefitidentifier;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for BenefitIdentifier", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for BenefitIdentifier", value, value.ToString());
				
				_benefitidentifier = value;
			}
		}
			
		public virtual string InsuranceCoNumber
		{
			get
			{ 
				return _insuranceconumber;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for InsuranceCoNumber", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsuranceCoNumber", value, value.ToString());
				
				_insuranceconumber = value;
			}
		}
			
		public virtual int CoPayAmount
		{
			get
			{ 
				return _copayamount;
			}
			set
			{
				_copayamount = value;
			}

		}
			
		public virtual bool IsPrimary
		{
			get
			{ 
				return _isprimary;
			}
			set
			{
				_isprimary = value;
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
            return this.PatientInsuranceID;
			
        }
		
		#endregion //Public Functions
	}
}
