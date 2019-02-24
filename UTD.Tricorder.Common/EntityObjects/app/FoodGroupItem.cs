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
	public partial class FoodGroupItem : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _foodgroupitemid; private Guid _foodid;//0
//private Food _foodid;//1
private long _foodgroupid;//0
//private FoodGroup _foodgroupid;//1

		private double _servingamount; 
		private double _servinggrams; private int _foodservingtypeid;//0
//private FoodServingType _foodservingtypeid;//1

		private double _calorie; 
		private double _fat; 
		private double _carb; 
		private double _protein; 		
		#endregion

		#region Constructor

		public FoodGroupItem()
		 //: base()
		{
			_foodgroupitemid = -1; 
			_foodid = new Guid(); 
			_foodgroupid = -1; 
			_servingamount = new double(); 
			_servinggrams = new double(); 
			_foodservingtypeid = -1; 
			_calorie = new double(); 
			_fat = new double(); 
			_carb = new double(); 
			_protein = new double(); 
		}

		public FoodGroupItem(
			long foodgroupitemid, 
			Guid foodid, 
			long foodgroupid, 
			double servingamount, 
			double servinggrams, 
			int foodservingtypeid, 
			double calorie, 
			double fat, 
			double carb, 
			double protein)
			: this()
		{
			_foodgroupitemid = foodgroupitemid;
			_foodid = foodid;
			_foodgroupid = foodgroupid;
			_servingamount = servingamount;
			_servinggrams = servinggrams;
			_foodservingtypeid = foodservingtypeid;
			_calorie = calorie;
			_fat = fat;
			_carb = carb;
			_protein = protein;
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
