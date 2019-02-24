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
	public partial class vFitActivity : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "FitActivity";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string FitActivityID = "FitActivityID";
			public const string FitActivityTitle = "FitActivityTitle";
			public const string FitActivityMET = "FitActivityMET";
			public const string FitActivityCategoryID = "FitActivityCategoryID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("FitActivityID");
			_ColumnsList.Add("FitActivityTitle");
			_ColumnsList.Add("FitActivityMET");
			_ColumnsList.Add("FitActivityCategoryID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _fitactivityid; 
		private string _fitactivitytitle; 
		private double _fitactivitymet; 
		private int _fitactivitycategoryid; 		
		#endregion

		#region Constructor

		public vFitActivity()
		 //: base()
		{
			_fitactivityid = -1; 
			_fitactivitytitle = null; 
			_fitactivitymet = new double(); 
			_fitactivitycategoryid = -1; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long FitActivityID
		{
			get
			{ 
				return _fitactivityid;
			}
			set
			{
				_fitactivityid = value;
			}

		}
			
		public virtual string FitActivityTitle
		{
			get
			{ 
				return _fitactivitytitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FitActivityTitle", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for FitActivityTitle", value, value.ToString());
				
				_fitactivitytitle = value;
			}
		}
			
		public virtual double FitActivityMET
		{
			get
			{ 
				return _fitactivitymet;
			}
			set
			{
				_fitactivitymet = value;
			}

		}
			
		public virtual int FitActivityCategoryID
		{
			get
			{ 
				return _fitactivitycategoryid;
			}
			set
			{
				_fitactivitycategoryid = value;
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
            return this.FitActivityID;
			
        }
		
		#endregion //Public Functions
	}
}
