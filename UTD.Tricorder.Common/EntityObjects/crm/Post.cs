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
	public partial class Post : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion //Generator-Safe Area

		#region Private Members
		private long _postid;//3

		//private IList<Post> _PostList; 
private long? _parentpostid;//0
//private Post _parentpostid;//1

		private string _title; 
		private string _commenttext; 
		private string _viewaddress; 
		private long? _insertuserid; 
		private DateTime _insertdate; private byte _posttypeid;//0
//private PostType _posttypeid;//1

		private Guid _siteid; 
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
		#endregion

		#region Constructor

		public Post()
		 //: base()
		{
			_postid = -1; 
			//_PostList = new List<Post>(); 
			_parentpostid = null; 
			_title = null; 
			_commenttext = null; 
			_viewaddress = null; 
			_insertuserid = null; 
			_insertdate = DateTime.MinValue; 
			_posttypeid = new byte(); 
			_siteid = new Guid(); 
			_votecount = -1; 
			_childcount = -1; 
			_ticketpriorityid = new byte(); 
			_ticketstatusid = new byte(); 
			_ticketsourcetypeid = new byte(); 
			_relatedticketgroupid = null; 
			_ticketassigneduserid = null; 
			_internalcompanycomment = null; 
			_happinesslevel = null; 
		}

		public Post(
			long postid, 
			string title, 
			string commenttext, 
			DateTime insertdate, 
			byte posttypeid, 
			Guid siteid, 
			short votecount, 
			short childcount, 
			byte ticketpriorityid, 
			byte ticketstatusid, 
			byte ticketsourcetypeid)
			: this()
		{
			_postid = postid;
			_parentpostid = null;
			_title = title;
			_commenttext = commenttext;
			_viewaddress = String.Empty;
			_insertuserid = null;
			_insertdate = insertdate;
			_posttypeid = posttypeid;
			_siteid = siteid;
			_votecount = votecount;
			_childcount = childcount;
			_ticketpriorityid = ticketpriorityid;
			_ticketstatusid = ticketstatusid;
			_ticketsourcetypeid = ticketsourcetypeid;
			_relatedticketgroupid = null;
			_ticketassigneduserid = null;
			_internalcompanycomment = String.Empty;
			_happinesslevel = null;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long PostID
		{
			get
			{ 
				return _postid;
			}
			set
			{
				_postid = value;
			}

		}
			
		public virtual long? ParentPostID
		{
			get
			{ 
				return _parentpostid;
			}
			set
			{
				_parentpostid = value;
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
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for Title", value, "null");
				
				//if(  value.Length > 200)
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
			
		public virtual byte PostTypeID
		{
			get
			{ 
				return _posttypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PostTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for PostTypeID", value, value.ToString());
				
				_posttypeid = value;
			}

		}
			
		public virtual Guid SiteID
		{
			get
			{ 
				return _siteid;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for SiteID", value, "null");

				_siteid = value;
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
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddPost(Post obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PostList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.PostID;
			
        }
		
		#endregion //Public Functions
	}
}
