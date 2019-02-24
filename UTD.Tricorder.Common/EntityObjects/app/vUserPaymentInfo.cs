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
	public partial class vUserPaymentInfo : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "UserPaymentInfo";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string UserPaymentInfoID = "UserPaymentInfoID";
			public const string UserPaymentInfoPayPalEmail = "UserPaymentInfoPayPalEmail";
			public const string Notes = "Notes";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("UserPaymentInfoID");
			_ColumnsList.Add("UserPaymentInfoPayPalEmail");
			_ColumnsList.Add("Notes");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _userpaymentinfoid; 
		private string _userpaymentinfopaypalemail; 
		private string _notes; 		
		#endregion

		#region Constructor

		public vUserPaymentInfo()
		 //: base()
		{
			_userpaymentinfoid = -1; 
			_userpaymentinfopaypalemail = null; 
			_notes = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long UserPaymentInfoID
		{
			get
			{ 
				return _userpaymentinfoid;
			}
			set
			{
				_userpaymentinfoid = value;
			}

		}
			
		public virtual string UserPaymentInfoPayPalEmail
		{
			get
			{ 
				return _userpaymentinfopaypalemail;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 170)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserPaymentInfoPayPalEmail", value, value.ToString());
				
				_userpaymentinfopaypalemail = value;
			}
		}
			
		public virtual string Notes
		{
			get
			{ 
				return _notes;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for Notes", value, value.ToString());
				
				_notes = value;
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
            return this.UserPaymentInfoID;
			
        }
		
		#endregion //Public Functions
	}
}
