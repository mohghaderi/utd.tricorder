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
	public partial class vDailyActivityChart : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "DailyActivityChart";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string RowID = "RowID";
			public const string UserID = "UserID";
			public const string DateUnix = "DateUnix";
			public const string CalorieSum = "CalorieSum";
			public const string FatSum = "FatSum";
			public const string CarbSum = "CarbSum";
			public const string ProteinSum = "ProteinSum";
			public const string CalorieBurn = "CalorieBurn";
			public const string CalorieTaken = "CalorieTaken";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("RowID");
			_ColumnsList.Add("UserID");
			_ColumnsList.Add("DateUnix");
			_ColumnsList.Add("CalorieSum");
			_ColumnsList.Add("FatSum");
			_ColumnsList.Add("CarbSum");
			_ColumnsList.Add("ProteinSum");
			_ColumnsList.Add("CalorieBurn");
			_ColumnsList.Add("CalorieTaken");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long? _rowid; 
		private long _userid; 
		private int? _dateunix; 
		private double? _caloriesum; 
		private double? _fatsum; 
		private double? _carbsum; 
		private double? _proteinsum; 
		private double? _calorieburn; 
		private double? _calorietaken; 		
		#endregion

		#region Constructor

		public vDailyActivityChart()
		 //: base()
		{
			_rowid = null; 
			_userid = -1; 
			_dateunix = null; 
			_caloriesum = null; 
			_fatsum = null; 
			_carbsum = null; 
			_proteinsum = null; 
			_calorieburn = null; 
			_calorietaken = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long? RowID
		{
			get
			{ 
				return _rowid;
			}
			set
			{
				_rowid = value;
			}

		}
			
		public virtual long UserID
		{
			get
			{ 
				return _userid;
			}
			set
			{
				_userid = value;
			}

		}
			
		public virtual int? DateUnix
		{
			get
			{ 
				return _dateunix;
			}
			set
			{
				_dateunix = value;
			}

		}
			
		public virtual double? CalorieSum
		{
			get
			{ 
				return _caloriesum;
			}
			set
			{
				_caloriesum = value;
			}

		}
			
		public virtual double? FatSum
		{
			get
			{ 
				return _fatsum;
			}
			set
			{
				_fatsum = value;
			}

		}
			
		public virtual double? CarbSum
		{
			get
			{ 
				return _carbsum;
			}
			set
			{
				_carbsum = value;
			}

		}
			
		public virtual double? ProteinSum
		{
			get
			{ 
				return _proteinsum;
			}
			set
			{
				_proteinsum = value;
			}

		}
			
		public virtual double? CalorieBurn
		{
			get
			{ 
				return _calorieburn;
			}
			set
			{
				_calorieburn = value;
			}

		}
			
		public virtual double? CalorieTaken
		{
			get
			{ 
				return _calorietaken;
			}
			set
			{
				_calorietaken = value;
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
            return this.RowID;
			
        }
		
		#endregion //Public Functions
	}
}
