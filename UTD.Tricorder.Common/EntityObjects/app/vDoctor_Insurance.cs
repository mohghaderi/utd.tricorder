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
	public partial class vDoctor_Insurance : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Doctor_Insurance";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string Doctor_InsuranceID = "Doctor_InsuranceID";
			public const string DoctorID = "DoctorID";
			public const string InsurancePlanID = "InsurancePlanID";
			public const string InsurancePlanTitle = "InsurancePlanTitle";
			public const string InsuranceName = "InsuranceName";
			public const string InsuranceID = "InsuranceID";
			public const string InsuranceFullName = "InsuranceFullName";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("Doctor_InsuranceID");
			_ColumnsList.Add("DoctorID");
			_ColumnsList.Add("InsurancePlanID");
			_ColumnsList.Add("InsurancePlanTitle");
			_ColumnsList.Add("InsuranceName");
			_ColumnsList.Add("InsuranceID");
			_ColumnsList.Add("InsuranceFullName");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _doctor_insuranceid; 
		private long _doctorid; 
		private long _insuranceplanid; 
		private string _insuranceplantitle; 
		private string _insurancename; 
		private long _insuranceid; 
		private string _insurancefullname; 		
		#endregion

		#region Constructor

		public vDoctor_Insurance()
		 //: base()
		{
			_doctor_insuranceid = -1; 
			_doctorid = -1; 
			_insuranceplanid = -1; 
			_insuranceplantitle = null; 
			_insurancename = null; 
			_insuranceid = -1; 
			_insurancefullname = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long Doctor_InsuranceID
		{
			get
			{ 
				return _doctor_insuranceid;
			}
			set
			{
				_doctor_insuranceid = value;
			}

		}
			
		public virtual long DoctorID
		{
			get
			{ 
				return _doctorid;
			}
			set
			{
				_doctorid = value;
			}

		}
			
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
			
		public virtual string InsuranceFullName
		{
			get
			{ 
				return _insurancefullname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for InsuranceFullName", value, "null");
				
				//if(  value.Length > 503)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsuranceFullName", value, value.ToString());
				
				_insurancefullname = value;
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
            return this.Doctor_InsuranceID;
			
        }
		
		#endregion //Public Functions
	}
}
