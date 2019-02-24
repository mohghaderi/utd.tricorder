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
	public partial class vTicketGroup : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "TicketGroup";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string TicketGroupID = "TicketGroupID";
			public const string TicketGroupName = "TicketGroupName";
			public const string SiteID = "SiteID";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("TicketGroupID");
			_ColumnsList.Add("TicketGroupName");
			_ColumnsList.Add("SiteID");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _ticketgroupid; 
		private string _ticketgroupname; 
		private Guid? _siteid; 		
		#endregion

		#region Constructor

		public vTicketGroup()
		 //: base()
		{
			_ticketgroupid = -1; 
			_ticketgroupname = null; 
			_siteid = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int TicketGroupID
		{
			get
			{ 
				return _ticketgroupid;
			}
			set
			{
				_ticketgroupid = value;
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
			
		public virtual Guid? SiteID
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.TicketGroupID;
			
        }
		
		#endregion //Public Functions
	}
}
