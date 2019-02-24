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
	public partial class vDailyActivityType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "DailyActivityType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string DailyActivityTypeID = "DailyActivityTypeID";
			public const string DailyActivityTypeTitle = "DailyActivityTypeTitle";
			public const string HasSumDuration = "HasSumDuration";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("DailyActivityTypeID");
			_ColumnsList.Add("DailyActivityTypeTitle");
			_ColumnsList.Add("HasSumDuration");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _dailyactivitytypeid; 
		private string _dailyactivitytypetitle; 
		private bool _hassumduration; 		
		#endregion

		#region Constructor

		public vDailyActivityType()
		 //: base()
		{
			_dailyactivitytypeid = -1; 
			_dailyactivitytypetitle = null; 
			_hassumduration = false; 
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
