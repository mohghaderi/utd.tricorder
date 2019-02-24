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
	public partial class PaymentMethod : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _paymentmethodid;//3

		//private IList<Payment> _PaymentList; 

		private string _paymentmethodcode; 
		private string _paymentmethodtitle; 		
		#endregion

		#region Constructor

		public PaymentMethod()
		 //: base()
		{
			_paymentmethodid = -1; 
			//_PaymentList = new List<Payment>(); 
			_paymentmethodcode = null; 
			_paymentmethodtitle = null; 
		}

		public PaymentMethod(
			int paymentmethodid, 
			string paymentmethodcode, 
			string paymentmethodtitle)
			: this()
		{
			_paymentmethodid = paymentmethodid;
			_paymentmethodcode = paymentmethodcode;
			_paymentmethodtitle = paymentmethodtitle;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int PaymentMethodID
		{
			get
			{ 
				return _paymentmethodid;
			}
			set
			{
				_paymentmethodid = value;
			}

		}
			
		public virtual string PaymentMethodCode
		{
			get
			{ 
				return _paymentmethodcode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PaymentMethodCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for PaymentMethodCode", value, value.ToString());
				
				_paymentmethodcode = value;
			}
		}
			
		public virtual string PaymentMethodTitle
		{
			get
			{ 
				return _paymentmethodtitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PaymentMethodTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for PaymentMethodTitle", value, value.ToString());
				
				_paymentmethodtitle = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddPayment(Payment obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PaymentList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.PaymentMethodID;
			
        }
		
		#endregion //Public Functions
	}
}
