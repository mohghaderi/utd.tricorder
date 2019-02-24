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
	public partial class vInsurancePlan : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "InsurancePlan";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string InsurancePlanID = "InsurancePlanID";
			public const string InsuranceID = "InsuranceID";
			public const string InsurancePlanTitle = "InsurancePlanTitle";
			public const string IsDental = "IsDental";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("InsurancePlanID");
			_ColumnsList.Add("InsuranceID");
			_ColumnsList.Add("InsurancePlanTitle");
			_ColumnsList.Add("IsDental");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _insuranceplanid; 
		private long _insuranceid; 
		private string _insuranceplantitle; 
		private bool _isdental; 		
		#endregion

		#region Constructor

		public vInsurancePlan()
		 //: base()
		{
			_insuranceplanid = -1; 
			_insuranceid = -1; 
			_insuranceplantitle = null; 
			_isdental = false; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long InsurancePlanID
		{
			get
			{ 
				return _insuranceplanid;
			}
			set
			{
				_insuranceplanid = value;
			}

		}
			
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
			
		public virtual string InsurancePlanTitle
		{
			get
			{ 
				return _insuranceplantitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for InsurancePlanTitle", value, "null");
				
				//if(  value.Length > 350)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsurancePlanTitle", value, value.ToString());
				
				_insuranceplantitle = value;
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.InsurancePlanID;
			
        }
		
		#endregion //Public Functions
	}
}
