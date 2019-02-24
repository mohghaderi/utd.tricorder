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
	public partial class vFoodGroupSum : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion //Generator-Safe Area


		public const string EntityName = "FoodGroupSum";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string FoodGroupID = "FoodGroupID";
			public const string CalorieSum = "CalorieSum";
			public const string FatSum = "FatSum";
			public const string CarbSum = "CarbSum";
			public const string ProteinSum = "ProteinSum";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("FoodGroupID");
			_ColumnsList.Add("CalorieSum");
			_ColumnsList.Add("FatSum");
			_ColumnsList.Add("CarbSum");
			_ColumnsList.Add("ProteinSum");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _foodgroupid; 
		private double? _caloriesum; 
		private double? _fatsum; 
		private double? _carbsum; 
		private double? _proteinsum; 		
		#endregion

		#region Constructor

		public vFoodGroupSum()
		 //: base()
		{
			_foodgroupid = -1; 
			_caloriesum = null; 
			_fatsum = null; 
			_carbsum = null; 
			_proteinsum = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long FoodGroupID
		{
			get
			{ 
				return _foodgroupid;
			}
			set
			{
				_foodgroupid = value;
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.FoodGroupID;
			
        }
		
		#endregion //Public Functions
	}
}
