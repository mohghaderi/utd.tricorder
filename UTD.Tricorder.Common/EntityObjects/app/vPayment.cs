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
	public partial class vPayment : EntityObjectBase
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


		public const string EntityName = "Payment";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string PaymentID = "PaymentID";
			public const string SenderUserID = "SenderUserID";
			public const string ReceiverUserID = "ReceiverUserID";
			public const string AppEntityID = "AppEntityID";
			public const string AppEntityRecordIDValue = "AppEntityRecordIDValue";
			public const string PaymentStatusID = "PaymentStatusID";
			public const string CreatedDateTime = "CreatedDateTime";
			public const string CompletedDateTime = "CompletedDateTime";
			public const string Amount = "Amount";
			public const string Description = "Description";
			public const string ServiceChargeAmount = "ServiceChargeAmount";
			public const string PaymentMethodID = "PaymentMethodID";
			public const string PayKey = "PayKey";
			public const string ReceiverFirstName = "ReceiverFirstName";
			public const string ReceiverLastName = "ReceiverLastName";
			public const string SenderFirstName = "SenderFirstName";
			public const string SenderLastName = "SenderLastName";
			public const string AppEntityName = "AppEntityName";
			public const string AppEntityADK = "AppEntityADK";
			public const string UpdateUserID = "UpdateUserID";
			public const string UpdateDate = "UpdateDate";
			public const string PaymentStatusIcon = "PaymentStatusIcon";
			public const string PaymentStatusName = "PaymentStatusName";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("PaymentID");
			_ColumnsList.Add("SenderUserID");
			_ColumnsList.Add("ReceiverUserID");
			_ColumnsList.Add("AppEntityID");
			_ColumnsList.Add("AppEntityRecordIDValue");
			_ColumnsList.Add("PaymentStatusID");
			_ColumnsList.Add("CreatedDateTime");
			_ColumnsList.Add("CompletedDateTime");
			_ColumnsList.Add("Amount");
			_ColumnsList.Add("Description");
			_ColumnsList.Add("ServiceChargeAmount");
			_ColumnsList.Add("PaymentMethodID");
			_ColumnsList.Add("PayKey");
			_ColumnsList.Add("ReceiverFirstName");
			_ColumnsList.Add("ReceiverLastName");
			_ColumnsList.Add("SenderFirstName");
			_ColumnsList.Add("SenderLastName");
			_ColumnsList.Add("AppEntityName");
			_ColumnsList.Add("AppEntityADK");
			_ColumnsList.Add("UpdateUserID");
			_ColumnsList.Add("UpdateDate");
			_ColumnsList.Add("PaymentStatusIcon");
			_ColumnsList.Add("PaymentStatusName");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _paymentid; 
		private long _senderuserid; 
		private long _receiveruserid; 
		private short _appentityid; 
		private long _appentityrecordidvalue; 
		private int _paymentstatusid; 
		private DateTime _createddatetime; 
		private DateTime? _completeddatetime; 
		private decimal _amount; 
		private string _description; 
		private decimal _servicechargeamount; 
		private int _paymentmethodid; 
		private string _paykey; 
		private string _receiverfirstname; 
		private string _receiverlastname; 
		private string _senderfirstname; 
		private string _senderlastname; 
		private string _appentityname; 
		private string _appentityadk; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 
		private string _paymentstatusicon; 
		private string _paymentstatusname; 		
		#endregion

		#region Constructor

		public vPayment()
		 //: base()
		{
			_paymentid = -1; 
			_senderuserid = -1; 
			_receiveruserid = -1; 
			_appentityid = -1; 
			_appentityrecordidvalue = -1; 
			_paymentstatusid = -1; 
			_createddatetime = DateTime.MinValue; 
			_completeddatetime = null; 
			_amount = -1; 
			_description = null; 
			_servicechargeamount = -1; 
			_paymentmethodid = -1; 
			_paykey = null; 
			_receiverfirstname = null; 
			_receiverlastname = null; 
			_senderfirstname = null; 
			_senderlastname = null; 
			_appentityname = null; 
			_appentityadk = null; 
			_updateuserid = null; 
			_updatedate = null; 
			_paymentstatusicon = null; 
			_paymentstatusname = null; 
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
			
		public virtual string ReceiverFirstName
		{
			get
			{ 
				return _receiverfirstname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ReceiverFirstName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ReceiverFirstName", value, value.ToString());
				
				_receiverfirstname = value;
			}
		}
			
		public virtual string ReceiverLastName
		{
			get
			{ 
				return _receiverlastname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ReceiverLastName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ReceiverLastName", value, value.ToString());
				
				_receiverlastname = value;
			}
		}
			
		public virtual string SenderFirstName
		{
			get
			{ 
				return _senderfirstname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SenderFirstName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderFirstName", value, value.ToString());
				
				_senderfirstname = value;
			}
		}
			
		public virtual string SenderLastName
		{
			get
			{ 
				return _senderlastname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SenderLastName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for SenderLastName", value, value.ToString());
				
				_senderlastname = value;
			}
		}
			
		public virtual string AppEntityName
		{
			get
			{ 
				return _appentityname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppEntityName", value, "null");
				
				//if(  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppEntityName", value, value.ToString());
				
				_appentityname = value;
			}
		}
			
		public virtual string AppEntityADK
		{
			get
			{ 
				return _appentityadk;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppEntityADK", value, value.ToString());
				
				_appentityadk = value;
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
