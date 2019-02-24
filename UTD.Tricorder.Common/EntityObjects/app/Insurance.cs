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
	public partial class Insurance : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private long _insuranceid;//3

		//private IList<InsurancePlan> _InsurancePlanList; 

		private string _insurancename; 
		private bool _isdental; 
		private bool _haskid; 		
		#endregion

		#region Constructor

		public Insurance()
		 //: base()
		{
			_insuranceid = -1; 
			//_InsurancePlanList = new List<InsurancePlan>(); 
			_insurancename = null; 
			_isdental = false; 
			_haskid = false; 
		}

		public Insurance(
			long insuranceid, 
			string insurancename, 
			bool isdental, 
			bool haskid)
			: this()
		{
			_insuranceid = insuranceid;
			_insurancename = insurancename;
			_isdental = isdental;
			_haskid = haskid;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual bool HasKid
		{
			get
			{ 
				return _haskid;
			}
			set
			{
				_haskid = value;
			}

		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddInsurancePlan(InsurancePlan obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_InsurancePlanList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.InsuranceID;
			
        }
		
		#endregion //Public Functions
	}
}
