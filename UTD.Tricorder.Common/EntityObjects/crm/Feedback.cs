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
	public partial class Feedback : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private long _feedbackid;//3

		//private IList<Feedback> _FeedbackList; 
private long? _parentfeedbackid;//0
//private Feedback _parentfeedbackid;//1

		private string _title; 
		private string _commenttext; 
		private string _viewaddress; 
		private long? _insertuserid; 
		private DateTime _insertdate; private byte _feedbacktypeid;//0
//private FeedbackType _feedbacktypeid;//1

		private short _votecount; 
		private short _childcount; private byte _ticketpriorityid;//0
//private TicketPriority _ticketpriorityid;//1
private byte _ticketstatusid;//0
//private TicketStatus _ticketstatusid;//1

		private byte _ticketsourcetypeid; private int? _relatedticketgroupid;//0
//private TicketGroup _relatedticketgroupid;//1

		private long? _ticketassigneduserid; 
		private string _internalcompanycomment; 
		private byte? _happinesslevel; 
		private int? _siteid; 
		private short _insertlanguageid; 		
		#endregion

		#region Constructor

		public Feedback()
		 //: base()
		{
			_feedbackid = -1; 
			//_FeedbackList = new List<Feedback>(); 
			_parentfeedbackid = null; 
			_title = null; 
			_commenttext = null; 
			_viewaddress = null; 
			_insertuserid = null; 
			_insertdate = DateTime.MinValue; 
			_feedbacktypeid = new byte(); 
			_votecount = -1; 
			_childcount = -1; 
			_ticketpriorityid = new byte(); 
			_ticketstatusid = new byte(); 
			_ticketsourcetypeid = new byte(); 
			_relatedticketgroupid = null; 
			_ticketassigneduserid = null; 
			_internalcompanycomment = null; 
			_happinesslevel = null; 
			_siteid = null; 
			_insertlanguageid = -1; 
		}

		public Feedback(
			long feedbackid, 
			string commenttext, 
			DateTime insertdate, 
			byte feedbacktypeid, 
			short votecount, 
			short childcount, 
			byte ticketpriorityid, 
			byte ticketstatusid, 
			byte ticketsourcetypeid, 
			short insertlanguageid)
			: this()
		{
			_feedbackid = feedbackid;
			_parentfeedbackid = null;
			_title = String.Empty;
			_commenttext = commenttext;
			_viewaddress = String.Empty;
			_insertuserid = null;
			_insertdate = insertdate;
			_feedbacktypeid = feedbacktypeid;
			_votecount = votecount;
			_childcount = childcount;
			_ticketpriorityid = ticketpriorityid;
			_ticketstatusid = ticketstatusid;
			_ticketsourcetypeid = ticketsourcetypeid;
			_relatedticketgroupid = null;
			_ticketassigneduserid = null;
			_internalcompanycomment = String.Empty;
			_happinesslevel = null;
			_siteid = null;
			_insertlanguageid = insertlanguageid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long FeedbackID
		{
			get
			{ 
				return _feedbackid;
			}
			set
			{
				_feedbackid = value;
			}

		}
			
		public virtual long? ParentFeedbackID
		{
			get
			{ 
				return _parentfeedbackid;
			}
			set
			{
				_parentfeedbackid = value;
			}

		}
			
		public virtual string Title
		{
			get
			{ 
				return _title;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
				
				_title = value;
			}
		}
			
		public virtual string CommentText
		{
			get
			{ 
				return _commenttext;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for CommentText", value, "null");
				
				//if(  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for CommentText", value, value.ToString());
				
				_commenttext = value;
			}
		}
			
		public virtual string ViewAddress
		{
			get
			{ 
				return _viewaddress;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for ViewAddress", value, value.ToString());
				
				_viewaddress = value;
			}
		}
			
		public virtual long? InsertUserID
		{
			get
			{ 
				return _insertuserid;
			}
			set
			{
				_insertuserid = value;
			}

		}
			
		public virtual DateTime InsertDate
		{
			get
			{ 
				return _insertdate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsertDate", value, value.ToString());

				_insertdate = value;	
			}
					
		}
			
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
			
		public virtual short VoteCount
		{
			get
			{ 
				return _votecount;
			}
			set
			{
				_votecount = value;
			}

		}
			
		public virtual short ChildCount
		{
			get
			{ 
				return _childcount;
			}
			set
			{
				_childcount = value;
			}

		}
			
		public virtual byte TicketPriorityID
		{
			get
			{ 
				return _ticketpriorityid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketPriorityID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketPriorityID", value, value.ToString());
				
				_ticketpriorityid = value;
			}

		}
			
		public virtual byte TicketStatusID
		{
			get
			{ 
				return _ticketstatusid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketStatusID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketStatusID", value, value.ToString());
				
				_ticketstatusid = value;
			}

		}
			
		public virtual byte TicketSourceTypeID
		{
			get
			{ 
				return _ticketsourcetypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketSourceTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketSourceTypeID", value, value.ToString());
				
				_ticketsourcetypeid = value;
			}

		}
			
		public virtual int? RelatedTicketGroupID
		{
			get
			{ 
				return _relatedticketgroupid;
			}
			set
			{
				_relatedticketgroupid = value;
			}

		}
			
		public virtual long? TicketAssignedUserID
		{
			get
			{ 
				return _ticketassigneduserid;
			}
			set
			{
				_ticketassigneduserid = value;
			}

		}
			
		public virtual string InternalCompanyComment
		{
			get
			{ 
				return _internalcompanycomment;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for InternalCompanyComment", value, value.ToString());
				
				_internalcompanycomment = value;
			}
		}
			
		public virtual byte? HappinessLevel
		{
			get
			{ 
				return _happinesslevel;
			}
			set
			{
				_happinesslevel = value;
			}

		}
			
		public virtual int? SiteID
		{
			get
			{ 
				return _siteid;
			}
			set
			{
				_siteid = value;
			}

		}
			
		public virtual short InsertLanguageID
		{
			get
			{ 
				return _insertlanguageid;
			}
			set
			{
				_insertlanguageid = value;
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
            return this.FeedbackID;
			
        }
		
		#endregion //Public Functions
	}
}
