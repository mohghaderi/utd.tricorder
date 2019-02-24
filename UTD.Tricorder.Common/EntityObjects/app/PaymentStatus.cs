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
	public partial class PaymentStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _paymentstatusid;//3

		//private IList<Payment> _PaymentList; 

		private string _paymentstatusname; 
		private string _paymentstatuscode; 
		private string _paymentstatusicon; 		
		#endregion

		#region Constructor

		public PaymentStatus()
		 //: base()
		{
			_paymentstatusid = -1; 
			//_PaymentList = new List<Payment>(); 
			_paymentstatusname = null; 
			_paymentstatuscode = null; 
			_paymentstatusicon = null; 
		}

		public PaymentStatus(
			int paymentstatusid)
			: this()
		{
			_paymentstatusid = paymentstatusid;
			_paymentstatusname = String.Empty;
			_paymentstatuscode = String.Empty;
			_paymentstatusicon = String.Empty;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int PaymentStatusID
		{
			get
			{ 
				return _paymentstatusid;
			}
			set
			{
				_paymentstatusid = value;
			}

		}
			
		public virtual string PaymentStatusName
		{
			get
			{ 
				return _paymentstatusname;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for PaymentStatusName", value, value.ToString());
				
				_paymentstatusname = value;
			}
		}
			
		public virtual string PaymentStatusCode
		{
			get
			{ 
				return _paymentstatuscode;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for PaymentStatusCode", value, value.ToString());
				
				_paymentstatuscode = value;
			}
		}
			
		public virtual string PaymentStatusIcon
		{
			get
			{ 
				return _paymentstatusicon;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for PaymentStatusIcon", value, value.ToString());
				
				_paymentstatusicon = value;
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
            return this.PaymentStatusID;
			
        }
		
		#endregion //Public Functions
	}
}
