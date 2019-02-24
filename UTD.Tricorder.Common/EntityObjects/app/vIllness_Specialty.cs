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
	public partial class vIllness_Specialty : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Illness_Specialty";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string Illness_SpecialtyID = "Illness_SpecialtyID";
			public const string IllnessID = "IllnessID";
			public const string SpecialtyID = "SpecialtyID";
			public const string IllnessTitle = "IllnessTitle";
			public const string SpecialtyTitle = "SpecialtyTitle";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("Illness_SpecialtyID");
			_ColumnsList.Add("IllnessID");
			_ColumnsList.Add("SpecialtyID");
			_ColumnsList.Add("IllnessTitle");
			_ColumnsList.Add("SpecialtyTitle");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _illness_specialtyid; 
		private int _illnessid; 
		private int _specialtyid; 
		private string _illnesstitle; 
		private string _specialtytitle; 		
		#endregion

		#region Constructor

		public vIllness_Specialty()
		 //: base()
		{
			_illness_specialtyid = -1; 
			_illnessid = -1; 
			_specialtyid = -1; 
			_illnesstitle = null; 
			_specialtytitle = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int Illness_SpecialtyID
		{
			get
			{ 
				return _illness_specialtyid;
			}
			set
			{
				_illness_specialtyid = value;
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
            return this.Illness_SpecialtyID;
			
        }
		
		#endregion //Public Functions
	}
}
