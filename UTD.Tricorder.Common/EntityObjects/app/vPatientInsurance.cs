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
	public partial class vPatientInsurance : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "PatientInsurance";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string PatientInsuranceID = "PatientInsuranceID";
			public const string PatientUserID = "PatientUserID";
			public const string SubscriberName = "SubscriberName";
			public const string InsurancePlanID = "InsurancePlanID";
			public const string GroupNumber = "GroupNumber";
			public const string BenefitIdentifier = "BenefitIdentifier";
			public const string InsuranceCoNumber = "InsuranceCoNumber";
			public const string CoPayAmount = "CoPayAmount";
			public const string IsPrimary = "IsPrimary";
			public const string InsurancePlanTitle = "InsurancePlanTitle";
			public const string InsuranceName = "InsuranceName";
			public const string InsuranceID = "InsuranceID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("PatientInsuranceID");
			_ColumnsList.Add("PatientUserID");
			_ColumnsList.Add("SubscriberName");
			_ColumnsList.Add("InsurancePlanID");
			_ColumnsList.Add("GroupNumber");
			_ColumnsList.Add("BenefitIdentifier");
			_ColumnsList.Add("InsuranceCoNumber");
			_ColumnsList.Add("CoPayAmount");
			_ColumnsList.Add("IsPrimary");
			_ColumnsList.Add("InsurancePlanTitle");
			_ColumnsList.Add("InsuranceName");
			_ColumnsList.Add("InsuranceID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _patientinsuranceid; 
		private long _patientuserid; 
		private string _subscribername; 
		private long _insuranceplanid; 
		private string _groupnumber; 
		private string _benefitidentifier; 
		private string _insuranceconumber; 
		private int _copayamount; 
		private bool _isprimary; 
		private string _insuranceplantitle; 
		private string _insurancename; 
		private long _insuranceid; 		
		#endregion

		#region Constructor

		public vPatientInsurance()
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
			_insuranceplantitle = null; 
			_insurancename = null; 
			_insuranceid = -1; 
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
			
		public virtual string InsuranceName
		{
			get
			{ 
				return _insurancename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for InsuranceName", value, "null");
				
				//if(  value.Length > 150)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsuranceName", value, value.ToString());
				
				_insurancename = value;
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
