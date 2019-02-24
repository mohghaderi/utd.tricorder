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
	public partial class vFoodServingTimeType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "FoodServingTimeType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string FoodServingTimeTypeID = "FoodServingTimeTypeID";
			public const string FoodServingTimeTypeTitle = "FoodServingTimeTypeTitle";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("FoodServingTimeTypeID");
			_ColumnsList.Add("FoodServingTimeTypeTitle");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _foodservingtimetypeid; 
		private string _foodservingtimetypetitle; 		
		#endregion

		#region Constructor

		public vFoodServingTimeType()
		 //: base()
		{
			_foodservingtimetypeid = -1; 
			_foodservingtimetypetitle = null; 
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
