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
	public partial class vFoodGroupItem : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "FoodGroupItem";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string FoodGroupItemID = "FoodGroupItemID";
			public const string FoodID = "FoodID";
			public const string FoodGroupID = "FoodGroupID";
			public const string ServingAmount = "ServingAmount";
			public const string ServingGrams = "ServingGrams";
			public const string IsGroupSaved = "IsGroupSaved";
			public const string FoodGroupTitle = "FoodGroupTitle";
			public const string FoodServingTypeID = "FoodServingTypeID";
			public const string Calorie = "Calorie";
			public const string Fat = "Fat";
			public const string Carb = "Carb";
			public const string Protein = "Protein";
			public const string FoodTitle = "FoodTitle";
			public const string FoodCaloriePer100g = "FoodCaloriePer100g";
			public const string FoodCode = "FoodCode";
			public const string FoodServingTypeTitle = "FoodServingTypeTitle";
			public const string FoodServingTypeCalorieUnit = "FoodServingTypeCalorieUnit";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("FoodGroupItemID");
			_ColumnsList.Add("FoodID");
			_ColumnsList.Add("FoodGroupID");
			_ColumnsList.Add("ServingAmount");
			_ColumnsList.Add("ServingGrams");
			_ColumnsList.Add("IsGroupSaved");
			_ColumnsList.Add("FoodGroupTitle");
			_ColumnsList.Add("FoodServingTypeID");
			_ColumnsList.Add("Calorie");
			_ColumnsList.Add("Fat");
			_ColumnsList.Add("Carb");
			_ColumnsList.Add("Protein");
			_ColumnsList.Add("FoodTitle");
			_ColumnsList.Add("FoodCaloriePer100g");
			_ColumnsList.Add("FoodCode");
			_ColumnsList.Add("FoodServingTypeTitle");
			_ColumnsList.Add("FoodServingTypeCalorieUnit");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _foodgroupitemid; 
		private Guid _foodid; 
		private long _foodgroupid; 
		private double _servingamount; 
		private double _servinggrams; 
		private bool _isgroupsaved; 
		private string _foodgrouptitle; 
		private int _foodservingtypeid; 
		private double _calorie; 
		private double _fat; 
		private double _carb; 
		private double _protein; 
		private string _foodtitle; 
		private double _foodcalorieper100g; 
		private string _foodcode; 
		private string _foodservingtypetitle; 
		private double _foodservingtypecalorieunit; 		
		#endregion

		#region Constructor

		public vFoodGroupItem()
		 //: base()
		{
			_foodgroupitemid = -1; 
			_foodid = new Guid(); 
			_foodgroupid = -1; 
			_servingamount = new double(); 
			_servinggrams = new double(); 
			_isgroupsaved = false; 
			_foodgrouptitle = null; 
			_foodservingtypeid = -1; 
			_calorie = new double(); 
			_fat = new double(); 
			_carb = new double(); 
			_protein = new double(); 
			_foodtitle = null; 
			_foodcalorieper100g = new double(); 
			_foodcode = null; 
			_foodservingtypetitle = null; 
			_foodservingtypecalorieunit = new double(); 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long FoodGroupItemID
		{
			get
			{ 
				return _foodgroupitemid;
			}
			set
			{
				_foodgroupitemid = value;
			}

		}
			
		public virtual Guid FoodID
		{
			get
			{ 
				return _foodid;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for FoodID", value, "null");

				_foodid = value;
			}

		}
			
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
			
		public virtual double ServingAmount
		{
			get
			{ 
				return _servingamount;
			}
			set
			{
				_servingamount = value;
			}

		}
			
		public virtual double ServingGrams
		{
			get
			{ 
				return _servinggrams;
			}
			set
			{
				_servinggrams = value;
			}

		}
			
		public virtual bool IsGroupSaved
		{
			get
			{ 
				return _isgroupsaved;
			}
			set
			{
				_isgroupsaved = value;
			}

		}
			
		public virtual string FoodGroupTitle
		{
			get
			{ 
				return _foodgrouptitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FoodGroupTitle", value, "null");
				
				//if(  value.Length > 150)
				//	throw new ArgumentOutOfRangeException("Invalid value for FoodGroupTitle", value, value.ToString());
				
				_foodgrouptitle = value;
			}
		}
			
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
			
		public virtual double Calorie
		{
			get
			{ 
				return _calorie;
			}
			set
			{
				_calorie = value;
			}

		}
			
		public virtual double Fat
		{
			get
			{ 
				return _fat;
			}
			set
			{
				_fat = value;
			}

		}
			
		public virtual double Carb
		{
			get
			{ 
				return _carb;
			}
			set
			{
				_carb = value;
			}

		}
			
		public virtual double Protein
		{
			get
			{ 
				return _protein;
			}
			set
			{
				_protein = value;
			}

		}
			
		public virtual string FoodTitle
		{
			get
			{ 
				return _foodtitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FoodTitle", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for FoodTitle", value, value.ToString());
				
				_foodtitle = value;
			}
		}
			
		public virtual double FoodCaloriePer100g
		{
			get
			{ 
				return _foodcalorieper100g;
			}
			set
			{
				_foodcalorieper100g = value;
			}

		}
			
		public virtual string FoodCode
		{
			get
			{ 
				return _foodcode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FoodCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for FoodCode", value, value.ToString());
				
				_foodcode = value;
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
            return this.FoodGroupItemID;
			
        }
		
		#endregion //Public Functions
	}
}
