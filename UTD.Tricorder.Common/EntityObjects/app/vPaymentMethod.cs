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
	public partial class vPaymentMethod : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "PaymentMethod";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string PaymentMethodID = "PaymentMethodID";
			public const string PaymentMethodCode = "PaymentMethodCode";
			public const string PaymentMethodTitle = "PaymentMethodTitle";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("PaymentMethodID");
			_ColumnsList.Add("PaymentMethodCode");
			_ColumnsList.Add("PaymentMethodTitle");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _paymentmethodid; 
		private string _paymentmethodcode; 
		private string _paymentmethodtitle; 		
		#endregion

		#region Constructor

		public vPaymentMethod()
		 //: base()
		{
			_paymentmethodid = -1; 
			_paymentmethodcode = null; 
			_paymentmethodtitle = null; 
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
