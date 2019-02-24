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
	public partial class Payment : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        private string _ReceiverProfilePicUrl;

        public virtual string ReceiverProfilePicUrl
        {
            get
            {
                return _ReceiverProfilePicUrl;
            }
            set
            {
                _ReceiverProfilePicUrl = value;
            }
        }

        private string _SenderProfilePicUrl;

        public virtual string SenderProfilePicUrl
        {
            get
            {
                return _SenderProfilePicUrl;
            }
            set
            {
                _SenderProfilePicUrl = value;
            }
        }

		#endregion

		#region Private Members

		private long _paymentid; private long _senderuserid;//0
//private User _senderuserid;//1
private long _receiveruserid;//0
//private User _receiveruserid;//1
private short _appentityid;//0
//private AppEntity _appentityid;//1

		private long _appentityrecordidvalue; private int _paymentstatusid;//0
//private PaymentStatus _paymentstatusid;//1
private int _paymentmethodid;//0
//private PaymentMethod _paymentmethodid;//1

		private DateTime _createddatetime; 
		private DateTime? _completeddatetime; 
		private string _paykey; 
		private decimal _amount; 
		private decimal _servicechargeamount; 
		private string _description; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 		
		#endregion

		#region Constructor

		public Payment()
		 //: base()
		{
			_paymentid = -1; 
			_senderuserid = -1; 
			_receiveruserid = -1; 
			_appentityid = -1; 
			_appentityrecordidvalue = -1; 
			_paymentstatusid = -1; 
			_paymentmethodid = -1; 
			_createddatetime = DateTime.MinValue; 
			_completeddatetime = null; 
			_paykey = null; 
			_amount = -1; 
			_servicechargeamount = -1; 
			_description = null; 
			_updateuserid = null; 
			_updatedate = null; 
		}

		public Payment(
			long paymentid, 
			long senderuserid, 
			long receiveruserid, 
			short appentityid, 
			long appentityrecordidvalue, 
			int paymentstatusid, 
			int paymentmethodid, 
			DateTime createddatetime, 
			decimal amount, 
			decimal servicechargeamount)
			: this()
		{
			_paymentid = paymentid;
			_senderuserid = senderuserid;
			_receiveruserid = receiveruserid;
			_appentityid = appentityid;
			_appentityrecordidvalue = appentityrecordidvalue;
			_paymentstatusid = paymentstatusid;
			_paymentmethodid = paymentmethodid;
			_createddatetime = createddatetime;
			_completeddatetime = null;
			_paykey = String.Empty;
			_amount = amount;
			_servicechargeamount = servicechargeamount;
			_description = String.Empty;
			_updateuserid = null;
			_updatedate = null;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long PaymentID
		{
			get
			{ 
				return _paymentid;
			}
			set
			{
				_paymentid = value;
			}

		}
			
		public virtual long SenderUserID
		{
			get
			{ 
				return _senderuserid;
			}
			set
			{
				_senderuserid = value;
			}

		}
			
		public virtual long ReceiverUserID
		{
			get
			{ 
				return _receiveruserid;
			}
			set
			{
				_receiveruserid = value;
			}

		}
			
		public virtual short AppEntityID
		{
			get
			{ 
				return _appentityid;
			}
			set
			{
				_appentityid = value;
			}

		}
			
		public virtual long AppEntityRecordIDValue
		{
			get
			{ 
				return _appentityrecordidvalue;
			}
			set
			{
				_appentityrecordidvalue = value;
			}

		}
			
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
			
		public virtual DateTime CreatedDateTime
		{
			get
			{ 
				return _createddatetime;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for CreatedDateTime", value, value.ToString());

				_createddatetime = value;	
			}
					
		}
			
		public virtual DateTime? CompletedDateTime
		{
			get
			{ 
				return _completeddatetime;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for CompletedDateTime", value, value.ToString());
						
				_completeddatetime = value;	
			}			
					
		}
			
		public virtual string PayKey
		{
			get
			{ 
				return _paykey;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for PayKey", value, value.ToString());
				
				_paykey = value;
			}
		}
			
		public virtual decimal Amount
		{
			get
			{ 
				return _amount;
			}
			set
			{
				_amount = value;
			}

		}
			
		public virtual decimal ServiceChargeAmount
		{
			get
			{ 
				return _servicechargeamount;
			}
			set
			{
				_servicechargeamount = value;
			}

		}
			
		public virtual string Description
		{
			get
			{ 
				return _description;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				
				_description = value;
			}
		}
			
		public virtual long? UpdateUserID
		{
			get
			{ 
				return _updateuserid;
			}
			set
			{
				_updateuserid = value;
			}

		}
			
		public virtual DateTime? UpdateDate
		{
			get
			{ 
				return _updatedate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for UpdateDate", value, value.ToString());
						
				_updatedate = value;	
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
            return this.PaymentID;
			
        }
		
		#endregion //Public Functions
	}
}
