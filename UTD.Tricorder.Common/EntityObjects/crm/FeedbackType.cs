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
	public partial class FeedbackType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private byte _feedbacktypeid;//3

		//private IList<Feedback> _FeedbackList; 

		private string _feedbacktypename; 
		private string _feedbacktypecode; 
		private bool _feedbacktypecanbestarted; 		
		#endregion

		#region Constructor

		public FeedbackType()
		 //: base()
		{
			_feedbacktypeid = new byte(); 
			//_FeedbackList = new List<Feedback>(); 
			_feedbacktypename = null; 
			_feedbacktypecode = null; 
			_feedbacktypecanbestarted = false; 
		}

		public FeedbackType(
			byte feedbacktypeid, 
			string feedbacktypename, 
			string feedbacktypecode, 
			bool feedbacktypecanbestarted)
			: this()
		{
			_feedbacktypeid = feedbacktypeid;
			_feedbacktypename = feedbacktypename;
			_feedbacktypecode = feedbacktypecode;
			_feedbacktypecanbestarted = feedbacktypecanbestarted;
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

		//public virtual void AddFeedback(Feedback obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_FeedbackList.Add(obj);
		//}
		


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
