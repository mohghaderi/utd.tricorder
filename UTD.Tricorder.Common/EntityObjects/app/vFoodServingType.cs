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
	public partial class vFoodServingType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "FoodServingType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string FoodServingTypeID = "FoodServingTypeID";
			public const string FoodServingTypeTitle = "FoodServingTypeTitle";
			public const string FoodServingTypeCalorieUnit = "FoodServingTypeCalorieUnit";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("FoodServingTypeID");
			_ColumnsList.Add("FoodServingTypeTitle");
			_ColumnsList.Add("FoodServingTypeCalorieUnit");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _foodservingtypeid; 
		private string _foodservingtypetitle; 
		private double _foodservingtypecalorieunit; 		
		#endregion

		#region Constructor

		public vFoodServingType()
		 //: base()
		{
			_foodservingtypeid = -1; 
			_foodservingtypetitle = null; 
			_foodservingtypecalorieunit = new double(); 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int FoodServingTypeID
		{
			get
			{ 
				return _foodservingtypeid;
			}
			set
			{
				_foodservingtypeid = value;
			}

		}
			
		public virtual string FoodServingTypeTitle
		{
			get
			{ 
				return _foodservingtypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FoodServingTypeTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for FoodServingTypeTitle", value, value.ToString());
				
				_foodservingtypetitle = value;
			}
		}
			
		public virtual double FoodServingTypeCalorieUnit
		{
			get
			{ 
				return _foodservingtypecalorieunit;
			}
			set
			{
				_foodservingtypecalorieunit = value;
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
            return this.FoodServingTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
