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
	public partial class vInsurance : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Insurance";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string InsuranceID = "InsuranceID";
			public const string InsuranceName = "InsuranceName";
			public const string IsDental = "IsDental";
			public const string HasKid = "HasKid";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("InsuranceID");
			_ColumnsList.Add("InsuranceName");
			_ColumnsList.Add("IsDental");
			_ColumnsList.Add("HasKid");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _insuranceid; 
		private string _insurancename; 
		private bool _isdental; 
		private bool _haskid; 		
		#endregion

		#region Constructor

		public vInsurance()
		 //: base()
		{
			_insuranceid = -1; 
			_insurancename = null; 
			_isdental = false; 
			_haskid = false; 
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
