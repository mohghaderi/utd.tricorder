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
	public partial class vPost : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion //Generator-Safe Area


		public const string EntityName = "Post";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string PostID = "PostID";
			public const string ParentPostID = "ParentPostID";
			public const string Title = "Title";
			public const string CommentText = "CommentText";
			public const string ViewAddress = "ViewAddress";
			public const string InsertUserID = "InsertUserID";
			public const string InsertDate = "InsertDate";
			public const string PostTypeID = "PostTypeID";
			public const string SiteID = "SiteID";
			public const string VoteCount = "VoteCount";
			public const string ChildCount = "ChildCount";
			public const string TicketPriorityID = "TicketPriorityID";
			public const string TicketStatusID = "TicketStatusID";
			public const string TicketSourceTypeID = "TicketSourceTypeID";
			public const string RelatedTicketGroupID = "RelatedTicketGroupID";
			public const string TicketAssignedUserID = "TicketAssignedUserID";
			public const string InternalCompanyComment = "InternalCompanyComment";
			public const string HappinessLevel = "HappinessLevel";
			public const string TicketStatusTitle = "TicketStatusTitle";
			public const string TicketStatusCode = "TicketStatusCode";
			public const string TicketPriorityTitle = "TicketPriorityTitle";
			public const string TicketPriorityCode = "TicketPriorityCode";
			public const string TicketSourceTypeTitle = "TicketSourceTypeTitle";
			public const string TicketSourceTypeCode = "TicketSourceTypeCode";
			public const string TicketGroupName = "TicketGroupName";
			public const string PostTypeName = "PostTypeName";
			public const string PostTypeCode = "PostTypeCode";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("PostID");
			_ColumnsList.Add("ParentPostID");
			_ColumnsList.Add("Title");
			_ColumnsList.Add("CommentText");
			_ColumnsList.Add("ViewAddress");
			_ColumnsList.Add("InsertUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("PostTypeID");
			_ColumnsList.Add("SiteID");
			_ColumnsList.Add("VoteCount");
			_ColumnsList.Add("ChildCount");
			_ColumnsList.Add("TicketPriorityID");
			_ColumnsList.Add("TicketStatusID");
			_ColumnsList.Add("TicketSourceTypeID");
			_ColumnsList.Add("RelatedTicketGroupID");
			_ColumnsList.Add("TicketAssignedUserID");
			_ColumnsList.Add("InternalCompanyComment");
			_ColumnsList.Add("HappinessLevel");
			_ColumnsList.Add("TicketStatusTitle");
			_ColumnsList.Add("TicketStatusCode");
			_ColumnsList.Add("TicketPriorityTitle");
			_ColumnsList.Add("TicketPriorityCode");
			_ColumnsList.Add("TicketSourceTypeTitle");
			_ColumnsList.Add("TicketSourceTypeCode");
			_ColumnsList.Add("TicketGroupName");
			_ColumnsList.Add("PostTypeName");
			_ColumnsList.Add("PostTypeCode");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _postid; 
		private long? _parentpostid; 
		private string _title; 
		private string _commenttext; 
		private string _viewaddress; 
		private long? _insertuserid; 
		private DateTime _insertdate; 
		private byte _posttypeid; 
		private Guid _siteid; 
		private short _votecount; 
		private short _childcount; 
		private byte _ticketpriorityid; 
		private byte _ticketstatusid; 
		private byte _ticketsourcetypeid; 
		private int? _relatedticketgroupid; 
		private long? _ticketassigneduserid; 
		private string _internalcompanycomment; 
		private byte? _happinesslevel; 
		private string _ticketstatustitle; 
		private string _ticketstatuscode; 
		private string _ticketprioritytitle; 
		private string _ticketprioritycode; 
		private string _ticketsourcetypetitle; 
		private string _ticketsourcetypecode; 
		private string _ticketgroupname; 
		private string _posttypename; 
		private string _posttypecode; 		
		#endregion

		#region Constructor

		public vPost()
		 //: base()
		{
			_postid = -1; 
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
			_ticketstatustitle = null; 
			_ticketstatuscode = null; 
			_ticketprioritytitle = null; 
			_ticketprioritycode = null; 
			_ticketsourcetypetitle = null; 
			_ticketsourcetypecode = null; 
			_ticketgroupname = null; 
			_posttypename = null; 
			_posttypecode = null; 
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
			
		public virtual string TicketStatusTitle
		{
			get
			{ 
				return _ticketstatustitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketStatusTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketStatusTitle", value, value.ToString());
				
				_ticketstatustitle = value;
			}
		}
			
		public virtual string TicketStatusCode
		{
			get
			{ 
				return _ticketstatuscode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketStatusCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketStatusCode", value, value.ToString());
				
				_ticketstatuscode = value;
			}
		}
			
		public virtual string TicketPriorityTitle
		{
			get
			{ 
				return _ticketprioritytitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketPriorityTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketPriorityTitle", value, value.ToString());
				
				_ticketprioritytitle = value;
			}
		}
			
		public virtual string TicketPriorityCode
		{
			get
			{ 
				return _ticketprioritycode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketPriorityCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketPriorityCode", value, value.ToString());
				
				_ticketprioritycode = value;
			}
		}
			
		public virtual string TicketSourceTypeTitle
		{
			get
			{ 
				return _ticketsourcetypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketSourceTypeTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketSourceTypeTitle", value, value.ToString());
				
				_ticketsourcetypetitle = value;
			}
		}
			
		public virtual string TicketSourceTypeCode
		{
			get
			{ 
				return _ticketsourcetypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketSourceTypeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketSourceTypeCode", value, value.ToString());
				
				_ticketsourcetypecode = value;
			}
		}
			
		public virtual string TicketGroupName
		{
			get
			{ 
				return _ticketgroupname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TicketGroupName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for TicketGroupName", value, value.ToString());
				
				_ticketgroupname = value;
			}
		}
			
		public virtual string PostTypeName
		{
			get
			{ 
				return _posttypename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PostTypeName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for PostTypeName", value, value.ToString());
				
				_posttypename = value;
			}
		}
			
		public virtual string PostTypeCode
		{
			get
			{ 
				return _posttypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for PostTypeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for PostTypeCode", value, value.ToString());
				
				_posttypecode = value;
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
            return this.PostID;
			
        }
		
		#endregion //Public Functions
	}
}
