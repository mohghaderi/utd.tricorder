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
	public partial class vFeedbackType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "FeedbackType";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string FeedbackTypeID = "FeedbackTypeID";
			public const string FeedbackTypeName = "FeedbackTypeName";
			public const string FeedbackTypeCode = "FeedbackTypeCode";
			public const string FeedbackTypeCanBeStarted = "FeedbackTypeCanBeStarted";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("FeedbackTypeID");
			_ColumnsList.Add("FeedbackTypeName");
			_ColumnsList.Add("FeedbackTypeCode");
			_ColumnsList.Add("FeedbackTypeCanBeStarted");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _feedbacktypeid; 
		private string _feedbacktypename; 
		private string _feedbacktypecode; 
		private bool _feedbacktypecanbestarted; 		
		#endregion

		#region Constructor

		public vFeedbackType()
		 //: base()
		{
			_feedbacktypeid = new byte(); 
			_feedbacktypename = null; 
			_feedbacktypecode = null; 
			_feedbacktypecanbestarted = false; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte FeedbackTypeID
		{
			get
			{ 
				return _feedbacktypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FeedbackTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for FeedbackTypeID", value, value.ToString());
				
				_feedbacktypeid = value;
			}

		}
			
		public virtual string FeedbackTypeName
		{
			get
			{ 
				return _feedbacktypename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FeedbackTypeName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for FeedbackTypeName", value, value.ToString());
				
				_feedbacktypename = value;
			}
		}
			
		public virtual string FeedbackTypeCode
		{
			get
			{ 
				return _feedbacktypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for FeedbackTypeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for FeedbackTypeCode", value, value.ToString());
				
				_feedbacktypecode = value;
			}
		}
			
		public virtual bool FeedbackTypeCanBeStarted
		{
			get
			{ 
				return _feedbacktypecanbestarted;
			}
			set
			{
				_feedbacktypecanbestarted = value;
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
            return this.FeedbackTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
