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
	public partial class vDoctor_Specialty : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Doctor_Specialty";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string Doctor_SpecialtyID = "Doctor_SpecialtyID";
			public const string DoctorID = "DoctorID";
			public const string SpecialtyID = "SpecialtyID";
			public const string SpecialtyTitle = "SpecialtyTitle";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("Doctor_SpecialtyID");
			_ColumnsList.Add("DoctorID");
			_ColumnsList.Add("SpecialtyID");
			_ColumnsList.Add("SpecialtyTitle");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _doctor_specialtyid; 
		private long _doctorid; 
		private int _specialtyid; 
		private string _specialtytitle; 		
		#endregion

		#region Constructor

		public vDoctor_Specialty()
		 //: base()
		{
			_doctor_specialtyid = -1; 
			_doctorid = -1; 
			_specialtyid = -1; 
			_specialtytitle = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long Doctor_SpecialtyID
		{
			get
			{ 
				return _doctor_specialtyid;
			}
			set
			{
				_doctor_specialtyid = value;
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
			
		public virtual int SpecialtyID
		{
			get
			{ 
				return _specialtyid;
			}
			set
			{
				_specialtyid = value;
			}

		}
			
		public virtual string SpecialtyTitle
		{
			get
			{ 
				return _specialtytitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for SpecialtyTitle", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for SpecialtyTitle", value, value.ToString());
				
				_specialtytitle = value;
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
            return this.Doctor_SpecialtyID;
			
        }
		
		#endregion //Public Functions
	}
}
