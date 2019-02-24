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
	public partial class FoodServingType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _foodservingtypeid;//3

		//private IList<FoodGroupItem> _FoodGroupItemList; 

		private string _foodservingtypetitle; 
		private double _foodservingtypecalorieunit; 		
		#endregion

		#region Constructor

		public FoodServingType()
		 //: base()
		{
			_foodservingtypeid = -1; 
			//_FoodGroupItemList = new List<FoodGroupItem>(); 
			_foodservingtypetitle = null; 
			_foodservingtypecalorieunit = new double(); 
		}

		public FoodServingType(
			int foodservingtypeid, 
			string foodservingtypetitle, 
			double foodservingtypecalorieunit)
			: this()
		{
			_foodservingtypeid = foodservingtypeid;
			_foodservingtypetitle = foodservingtypetitle;
			_foodservingtypecalorieunit = foodservingtypecalorieunit;
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

		//public virtual void AddFoodGroupItem(FoodGroupItem obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_FoodGroupItemList.Add(obj);
		//}
		


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
