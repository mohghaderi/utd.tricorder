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
	public partial class FitActivityCategory : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _fitactivitycategoryid;//3

		//private IList<FitActivity> _FitActivityList; 

		private string _fitactivitycategorytitle; 		
		#endregion

		#region Constructor

		public FitActivityCategory()
		 //: base()
		{
			_fitactivitycategoryid = -1; 
			//_FitActivityList = new List<FitActivity>(); 
			_fitactivitycategorytitle = null; 
		}

		public FitActivityCategory(
			int fitactivitycategoryid, 
			string fitactivitycategorytitle)
			: this()
		{
			_fitactivitycategoryid = fitactivitycategoryid;
			_fitactivitycategorytitle = fitactivitycategorytitle;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int FitActivityCategoryID
		{
			get
			{ 
				return _fitactivitycategoryid;
			}
			set
			{
				_fitactivitycategoryid = value;
			}

		}
			
		public virtual string FitActivityCategoryTitle
		{
			get
			{ 
				return _fitactivitycategorytitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FitActivityCategoryTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for FitActivityCategoryTitle", value, value.ToString());
				
				_fitactivitycategorytitle = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddFitActivity(FitActivity obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_FitActivityList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.FitActivityCategoryID;
			
        }
		
		#endregion //Public Functions
	}
}
