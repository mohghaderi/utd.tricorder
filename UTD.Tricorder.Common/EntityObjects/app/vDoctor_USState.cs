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
	public partial class vDoctor_USState : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Doctor_USState";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string Doctor_USStateID = "Doctor_USStateID";
			public const string DoctorID = "DoctorID";
			public const string USStateID = "USStateID";
			public const string StateName = "StateName";
			public const string DoctorFirstName = "DoctorFirstName";
			public const string DoctorLastName = "DoctorLastName";
			public const string DoctorNamePrefix = "DoctorNamePrefix";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("Doctor_USStateID");
			_ColumnsList.Add("DoctorID");
			_ColumnsList.Add("USStateID");
			_ColumnsList.Add("StateName");
			_ColumnsList.Add("DoctorFirstName");
			_ColumnsList.Add("DoctorLastName");
			_ColumnsList.Add("DoctorNamePrefix");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _doctor_usstateid; 
		private long _doctorid; 
		private string _usstateid; 
		private string _statename; 
		private string _doctorfirstname; 
		private string _doctorlastname; 
		private string _doctornameprefix; 		
		#endregion

		#region Constructor

		public vDoctor_USState()
		 //: base()
		{
			_doctor_usstateid = -1; 
			_doctorid = -1; 
			_usstateid = null; 
			_statename = null; 
			_doctorfirstname = null; 
			_doctorlastname = null; 
			_doctornameprefix = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long Doctor_USStateID
		{
			get
			{ 
				return _doctor_usstateid;
			}
			set
			{
				_doctor_usstateid = value;
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
			
		public virtual string USStateID
		{
			get
			{ 
				return _usstateid;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for USStateID", value, "null");
				
				//if(  value.Length > 2)
				//	throw new ArgumentOutOfRangeException("Invalid value for USStateID", value, value.ToString());
				
				_usstateid = value;
			}
		}
			
		public virtual string StateName
		{
			get
			{ 
				return _statename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for StateName", value, "null");
				
				//if(  value.Length > 250)
				//	throw new ArgumentOutOfRangeException("Invalid value for StateName", value, value.ToString());
				
				_statename = value;
			}
		}
			
		public virtual string DoctorFirstName
		{
			get
			{ 
				return _doctorfirstname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for DoctorFirstName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorFirstName", value, value.ToString());
				
				_doctorfirstname = value;
			}
		}
			
		public virtual string DoctorLastName
		{
			get
			{ 
				return _doctorlastname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for DoctorLastName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorLastName", value, value.ToString());
				
				_doctorlastname = value;
			}
		}
			
		public virtual string DoctorNamePrefix
		{
			get
			{ 
				return _doctornameprefix;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 4)
				//	throw new ArgumentOutOfRangeException("Invalid value for DoctorNamePrefix", value, value.ToString());
				
				_doctornameprefix = value;
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
            return this.Doctor_USStateID;
			
        }
		
		#endregion //Public Functions
	}
}
