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
	public partial class FoodServingTimeType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private int _foodservingtimetypeid; 
		private string _foodservingtimetypetitle; 		
		#endregion

		#region Constructor

		public FoodServingTimeType()
		 //: base()
		{
			_foodservingtimetypeid = -1; 
			_foodservingtimetypetitle = null; 
		}

		public FoodServingTimeType(
			int foodservingtimetypeid, 
			string foodservingtimetypetitle)
			: this()
		{
			_foodservingtimetypeid = foodservingtimetypeid;
			_foodservingtimetypetitle = foodservingtimetypetitle;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int FoodServingTimeTypeID
		{
			get
			{ 
				return _foodservingtimetypeid;
			}
			set
			{
				_foodservingtimetypeid = value;
			}

		}
			
		public virtual string FoodServingTimeTypeTitle
		{
			get
			{ 
				return _foodservingtimetypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FoodServingTimeTypeTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for FoodServingTimeTypeTitle", value, value.ToString());
				
				_foodservingtimetypetitle = value;
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
            return this.FoodServingTimeTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
