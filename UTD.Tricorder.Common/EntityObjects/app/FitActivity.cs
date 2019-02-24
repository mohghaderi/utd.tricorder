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
	public partial class FitActivity : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _fitactivityid; 
		private string _fitactivitytitle; 
		private double _fitactivitymet; private int _fitactivitycategoryid;//0
//private FitActivityCategory _fitactivitycategoryid;//1
		
		#endregion

		#region Constructor

		public FitActivity()
		 //: base()
		{
			_fitactivityid = -1; 
			_fitactivitytitle = null; 
			_fitactivitymet = new double(); 
			_fitactivitycategoryid = -1; 
		}

		public FitActivity(
			long fitactivityid, 
			string fitactivitytitle, 
			double fitactivitymet, 
			int fitactivitycategoryid)
			: this()
		{
			_fitactivityid = fitactivityid;
			_fitactivitytitle = fitactivitytitle;
			_fitactivitymet = fitactivitymet;
			_fitactivitycategoryid = fitactivitycategoryid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long FitActivityID
		{
			get
			{ 
				return _fitactivityid;
			}
			set
			{
				_fitactivityid = value;
			}

		}
			
		public virtual string FitActivityTitle
		{
			get
			{ 
				return _fitactivitytitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FitActivityTitle", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for FitActivityTitle", value, value.ToString());
				
				_fitactivitytitle = value;
			}
		}
			
		public virtual double FitActivityMET
		{
			get
			{ 
				return _fitactivitymet;
			}
			set
			{
				_fitactivitymet = value;
			}

		}
			
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.FitActivityID;
			
        }
		
		#endregion //Public Functions
	}
}
