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
	public partial class vSpecialty : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Specialty";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string SpecialtyID = "SpecialtyID";
			public const string SpecialtyTitle = "SpecialtyTitle";
			public const string IsPopular = "IsPopular";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("SpecialtyID");
			_ColumnsList.Add("SpecialtyTitle");
			_ColumnsList.Add("IsPopular");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _specialtyid; 
		private string _specialtytitle; 
		private bool _ispopular; 		
		#endregion

		#region Constructor

		public vSpecialty()
		 //: base()
		{
			_specialtyid = -1; 
			_specialtytitle = null; 
			_ispopular = false; 
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual bool IsPopular
		{
			get
			{ 
				return _ispopular;
			}
			set
			{
				_ispopular = value;
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
            return this.SpecialtyID;
			
        }
		
		#endregion //Public Functions
	}
}
