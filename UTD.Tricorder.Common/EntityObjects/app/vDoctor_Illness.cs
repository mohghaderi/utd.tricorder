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
	public partial class vDoctor_Illness : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Doctor_Illness";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string Doctor_IllnessID = "Doctor_IllnessID";
			public const string DoctorID = "DoctorID";
			public const string IllnessID = "IllnessID";
			public const string DefaultPrice = "DefaultPrice";
			public const string IllnessTitle = "IllnessTitle";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("Doctor_IllnessID");
			_ColumnsList.Add("DoctorID");
			_ColumnsList.Add("IllnessID");
			_ColumnsList.Add("DefaultPrice");
			_ColumnsList.Add("IllnessTitle");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _doctor_illnessid; 
		private long _doctorid; 
		private int _illnessid; 
		private decimal _defaultprice; 
		private string _illnesstitle; 		
		#endregion

		#region Constructor

		public vDoctor_Illness()
		 //: base()
		{
			_doctor_illnessid = -1; 
			_doctorid = -1; 
			_illnessid = -1; 
			_defaultprice = -1; 
			_illnesstitle = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long Doctor_IllnessID
		{
			get
			{ 
				return _doctor_illnessid;
			}
			set
			{
				_doctor_illnessid = value;
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
			
		public virtual int IllnessID
		{
			get
			{ 
				return _illnessid;
			}
			set
			{
				_illnessid = value;
			}

		}
			
		public virtual decimal DefaultPrice
		{
			get
			{ 
				return _defaultprice;
			}
			set
			{
				_defaultprice = value;
			}

		}
			
		public virtual string IllnessTitle
		{
			get
			{ 
				return _illnesstitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for IllnessTitle", value, "null");
				
				//if(  value.Length > 350)
				//	throw new ArgumentOutOfRangeException("Invalid value for IllnessTitle", value, value.ToString());
				
				_illnesstitle = value;
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
            return this.Doctor_IllnessID;
			
        }
		
		#endregion //Public Functions
	}
}
