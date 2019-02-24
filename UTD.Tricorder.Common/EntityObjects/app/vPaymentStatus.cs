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
	public partial class vPaymentStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "PaymentStatus";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string PaymentStatusID = "PaymentStatusID";
			public const string PaymentStatusName = "PaymentStatusName";
			public const string PaymentStatusCode = "PaymentStatusCode";
			public const string PaymentStatusIcon = "PaymentStatusIcon";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("PaymentStatusID");
			_ColumnsList.Add("PaymentStatusName");
			_ColumnsList.Add("PaymentStatusCode");
			_ColumnsList.Add("PaymentStatusIcon");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _paymentstatusid; 
		private string _paymentstatusname; 
		private string _paymentstatuscode; 
		private string _paymentstatusicon; 		
		#endregion

		#region Constructor

		public vPaymentStatus()
		 //: base()
		{
			_paymentstatusid = -1; 
			_paymentstatusname = null; 
			_paymentstatuscode = null; 
			_paymentstatusicon = null; 
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
