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
	public partial class Food : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private Guid _foodid;//3

		//private IList<FoodGroupItem> _FoodGroupItemList; 

		private string _foodcode; 
		private string _foodtitle; 
		private double _foodcalorieper100g; 		
		#endregion

		#region Constructor

		public Food()
		 //: base()
		{
			_foodid = new Guid(); 
			//_FoodGroupItemList = new List<FoodGroupItem>(); 
			_foodcode = null; 
			_foodtitle = null; 
			_foodcalorieper100g = new double(); 
		}

		public Food(
			Guid foodid, 
			string foodcode, 
			string foodtitle, 
			double foodcalorieper100g)
			: this()
		{
			_foodid = foodid;
			_foodcode = foodcode;
			_foodtitle = foodtitle;
			_foodcalorieper100g = foodcalorieper100g;
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
            return this.FoodID;
			
        }
		
		#endregion //Public Functions
	}
}
