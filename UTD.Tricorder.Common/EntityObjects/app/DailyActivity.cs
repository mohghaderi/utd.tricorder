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
	public partial class DailyActivity : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private Guid _dailyactivityid; private long _userid;//0
//private User _userid;//1

		private DateTime _recorddatetimeuserlocal; private int _dailyactivitytypeid;//0
//private DailyActivityType _dailyactivitytypeid;//1

		private string _dailyactivitytitle; 
		private bool _ismanualentry; 
		private int _durationseconds; 
		private long? _externalentityid; 
		private double _calorie; 
		private double _fat; 
		private double _carb; 
		private double _protein; 
		private string _comment; 		
		#endregion

		#region Constructor

		public DailyActivity()
		 //: base()
		{
			_dailyactivityid = new Guid(); 
			_userid = -1; 
			_recorddatetimeuserlocal = DateTime.MinValue; 
			_dailyactivitytypeid = -1; 
			_dailyactivitytitle = null; 
			_ismanualentry = false; 
			_durationseconds = -1; 
			_externalentityid = null; 
			_calorie = new double(); 
			_fat = new double(); 
			_carb = new double(); 
			_protein = new double(); 
			_comment = null; 
		}

		public DailyActivity(
			Guid dailyactivityid, 
			long userid, 
			DateTime recorddatetimeuserlocal, 
			int dailyactivitytypeid, 
			bool ismanualentry, 
			int durationseconds, 
			double calorie, 
			double fat, 
			double carb, 
			double protein)
			: this()
		{
			_dailyactivityid = dailyactivityid;
			_userid = userid;
			_recorddatetimeuserlocal = recorddatetimeuserlocal;
			_dailyactivitytypeid = dailyactivitytypeid;
			_dailyactivitytitle = String.Empty;
			_ismanualentry = ismanualentry;
			_durationseconds = durationseconds;
			_externalentityid = null;
			_calorie = calorie;
			_fat = fat;
			_carb = carb;
			_protein = protein;
			_comment = String.Empty;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual Guid DailyActivityID
		{
			get
			{ 
				return _dailyactivityid;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for DailyActivityID", value, "null");

				_dailyactivityid = value;
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
			
		public virtual string DailyActivityTitle
		{
			get
			{ 
				return _dailyactivitytitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 500)
				//	throw new ArgumentOutOfRangeException("Invalid value for DailyActivityTitle", value, value.ToString());
				
				_dailyactivitytitle = value;
			}
		}
			
		public virtual bool IsManualEntry
		{
			get
			{ 
				return _ismanualentry;
			}
			set
			{
				_ismanualentry = value;
			}

		}
			
		public virtual int DurationSeconds
		{
			get
			{ 
				return _durationseconds;
			}
			set
			{
				_durationseconds = value;
			}

		}
			
		public virtual long? ExternalEntityID
		{
			get
			{ 
				return _externalentityid;
			}
			set
			{
				_externalentityid = value;
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
			
		public virtual string Comment
		{
			get
			{ 
				return _comment;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for Comment", value, value.ToString());
				
				_comment = value;
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
            return this.DailyActivityID;
			
        }
		
		#endregion //Public Functions
	}
}
