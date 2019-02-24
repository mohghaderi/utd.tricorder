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
	public partial class vFoodGroup : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "FoodGroup";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string FoodGroupID = "FoodGroupID";
			public const string UserID = "UserID";
			public const string FoodGroupTitle = "FoodGroupTitle";
			public const string FoodServingTimeTypeID = "FoodServingTimeTypeID";
			public const string IsGroupSaved = "IsGroupSaved";
			public const string FoodServingTimeTypeTitle = "FoodServingTimeTypeTitle";
			public const string RecordDateTimeUserLocal = "RecordDateTimeUserLocal";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("FoodGroupID");
			_ColumnsList.Add("UserID");
			_ColumnsList.Add("FoodGroupTitle");
			_ColumnsList.Add("FoodServingTimeTypeID");
			_ColumnsList.Add("IsGroupSaved");
			_ColumnsList.Add("FoodServingTimeTypeTitle");
			_ColumnsList.Add("RecordDateTimeUserLocal");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _foodgroupid; 
		private long _userid; 
		private string _foodgrouptitle; 
		private byte _foodservingtimetypeid; 
		private bool _isgroupsaved; 
		private string _foodservingtimetypetitle; 
		private DateTime _recorddatetimeuserlocal; 		
		#endregion

		#region Constructor

		public vFoodGroup()
		 //: base()
		{
			_foodgroupid = -1; 
			_userid = -1; 
			_foodgrouptitle = null; 
			_foodservingtimetypeid = new byte(); 
			_isgroupsaved = false; 
			_foodservingtimetypetitle = null; 
			_recorddatetimeuserlocal = DateTime.MinValue; 
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual long UserID
		{
			get
			{ 
				return _userid;
			}
			set
			{
				_userid = value;
			}

		}
			
		public virtual string FoodGroupTitle
		{
			get
			{ 
				return _foodgrouptitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 250)
				//	throw new ArgumentOutOfRangeException("Invalid value for FoodGroupTitle", value, value.ToString());
				
				_foodgrouptitle = value;
			}
		}
			
		public virtual byte FoodServingTimeTypeID
		{
			get
			{ 
				return _foodservingtimetypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FoodServingTimeTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for FoodServingTimeTypeID", value, value.ToString());
				
				_foodservingtimetypeid = value;
			}

		}
			
		public virtual bool IsGroupSaved
		{
			get
			{ 
				return _isgroupsaved;
			}
			set
			{
				_isgroupsaved = value;
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
			
		public virtual DateTime RecordDateTimeUserLocal
		{
			get
			{ 
				return _recorddatetimeuserlocal;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for RecordDateTimeUserLocal", value, value.ToString());

				_recorddatetimeuserlocal = value;	
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
            return this.FoodGroupID;
			
        }
		
		#endregion //Public Functions
	}
}
