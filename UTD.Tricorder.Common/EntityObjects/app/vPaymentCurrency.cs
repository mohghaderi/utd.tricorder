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
	public partial class vPaymentCurrency : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "PaymentCurrency";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string PaymentCurrencyID = "PaymentCurrencyID";
			public const string PaymentCurrencyCode = "PaymentCurrencyCode";
			public const string PaymentCurrencyName = "PaymentCurrencyName";
			public const string PaymentCurrencySymbol = "PaymentCurrencySymbol";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("PaymentCurrencyID");
			_ColumnsList.Add("PaymentCurrencyCode");
			_ColumnsList.Add("PaymentCurrencyName");
			_ColumnsList.Add("PaymentCurrencySymbol");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private short _paymentcurrencyid; 
		private string _paymentcurrencycode; 
		private string _paymentcurrencyname; 
		private string _paymentcurrencysymbol; 		
		#endregion

		#region Constructor

		public vPaymentCurrency()
		 //: base()
		{
			_paymentcurrencyid = -1; 
			_paymentcurrencycode = null; 
			_paymentcurrencyname = null; 
			_paymentcurrencysymbol = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short PaymentCurrencyID
		{
			get
			{ 
				return _paymentcurrencyid;
			}
			set
			{
				_paymentcurrencyid = value;
			}

		}
			
		public virtual string PaymentCurrencyCode
		{
			get
			{ 
				return _paymentcurrencycode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PaymentCurrencyCode", value, "null");
				
				//if(  value.Length > 3)
				//	throw new ArgumentOutOfRangeException("Invalid value for PaymentCurrencyCode", value, value.ToString());
				
				_paymentcurrencycode = value;
			}
		}
			
		public virtual string PaymentCurrencyName
		{
			get
			{ 
				return _paymentcurrencyname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PaymentCurrencyName", value, "null");
				
				//if(  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for PaymentCurrencyName", value, value.ToString());
				
				_paymentcurrencyname = value;
			}
		}
			
		public virtual string PaymentCurrencySymbol
		{
			get
			{ 
				return _paymentcurrencysymbol;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1)
				//	throw new ArgumentOutOfRangeException("Invalid value for PaymentCurrencySymbol", value, value.ToString());
				
				_paymentcurrencysymbol = value;
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
            return this.PaymentCurrencyID;
			
        }
		
		#endregion //Public Functions
	}
}
