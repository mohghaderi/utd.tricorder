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
	public partial class vFood : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Food";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string FoodID = "FoodID";
			public const string FoodCode = "FoodCode";
			public const string FoodTitle = "FoodTitle";
			public const string FoodCaloriePer100g = "FoodCaloriePer100g";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("FoodID");
			_ColumnsList.Add("FoodCode");
			_ColumnsList.Add("FoodTitle");
			_ColumnsList.Add("FoodCaloriePer100g");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private Guid _foodid; 
		private string _foodcode; 
		private string _foodtitle; 
		private double _foodcalorieper100g; 		
		#endregion

		#region Constructor

		public vFood()
		 //: base()
		{
			_foodid = new Guid(); 
			_foodcode = null; 
			_foodtitle = null; 
			_foodcalorieper100g = new double(); 
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.FoodID;
			
        }
		
		#endregion //Public Functions
	}
}
