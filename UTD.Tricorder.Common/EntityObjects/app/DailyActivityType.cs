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
	public partial class DailyActivityType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _dailyactivitytypeid;//3

		//private IList<DailyActivity> _DailyActivityList; 

		private string _dailyactivitytypetitle; 
		private bool _hassumduration; 		
		#endregion

		#region Constructor

		public DailyActivityType()
		 //: base()
		{
			_dailyactivitytypeid = -1; 
			//_DailyActivityList = new List<DailyActivity>(); 
			_dailyactivitytypetitle = null; 
			_hassumduration = false; 
		}

		public DailyActivityType(
			int dailyactivitytypeid, 
			string dailyactivitytypetitle, 
			bool hassumduration)
			: this()
		{
			_dailyactivitytypeid = dailyactivitytypeid;
			_dailyactivitytypetitle = dailyactivitytypetitle;
			_hassumduration = hassumduration;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int DailyActivityTypeID
		{
			get
			{ 
				return _dailyactivitytypeid;
			}
			set
			{
				_dailyactivitytypeid = value;
			}

		}
			
		public virtual string DailyActivityTypeTitle
		{
			get
			{ 
				return _dailyactivitytypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for DailyActivityTypeTitle", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for DailyActivityTypeTitle", value, value.ToString());
				
				_dailyactivitytypetitle = value;
			}
		}
			
		public virtual bool HasSumDuration
		{
			get
			{ 
				return _hassumduration;
			}
			set
			{
				_hassumduration = value;
			}

		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddDailyActivity(DailyActivity obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_DailyActivityList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.DailyActivityTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
