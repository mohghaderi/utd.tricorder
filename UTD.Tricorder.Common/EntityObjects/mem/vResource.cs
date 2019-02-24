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
	public partial class vResource : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "Resource";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string ResourceID = "ResourceID";
			public const string ParentID = "ParentID";
			public const string ResourceTitle = "ResourceTitle";
			public const string ResourceCode = "ResourceCode";
			public const string InsertUsertID = "InsertUsertID";
			public const string InsertDate = "InsertDate";
			public const string UpdateUserID = "UpdateUserID";
			public const string UpdateDate = "UpdateDate";
			public const string ResourceTypeID = "ResourceTypeID";
			public const string Url = "Url";
			public const string RankOrder = "RankOrder";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("ResourceID");
			_ColumnsList.Add("ParentID");
			_ColumnsList.Add("ResourceTitle");
			_ColumnsList.Add("ResourceCode");
			_ColumnsList.Add("InsertUsertID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("UpdateUserID");
			_ColumnsList.Add("UpdateDate");
			_ColumnsList.Add("ResourceTypeID");
			_ColumnsList.Add("Url");
			_ColumnsList.Add("RankOrder");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _resourceid; 
		private long? _parentid; 
		private string _resourcetitle; 
		private string _resourcecode; 
		private long _insertusertid; 
		private DateTime _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 
		private int _resourcetypeid; 
		private string _url; 
		private int _rankorder; 		
		#endregion

		#region Constructor

		public vResource()
		 //: base()
		{
			_resourceid = -1; 
			_parentid = null; 
			_resourcetitle = null; 
			_resourcecode = null; 
			_insertusertid = -1; 
			_insertdate = DateTime.MinValue; 
			_updateuserid = null; 
			_updatedate = null; 
			_resourcetypeid = -1; 
			_url = null; 
			_rankorder = -1; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long ResourceID
		{
			get
			{ 
				return _resourceid;
			}
			set
			{
				_resourceid = value;
			}

		}
			
		public virtual long? ParentID
		{
			get
			{ 
				return _parentid;
			}
			set
			{
				_parentid = value;
			}

		}
			
		public virtual string ResourceTitle
		{
			get
			{ 
				return _resourcetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ResourceTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ResourceTitle", value, value.ToString());
				
				_resourcetitle = value;
			}
		}
			
		public virtual string ResourceCode
		{
			get
			{ 
				return _resourcecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ResourceCode", value, "null");
				
				//if(  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for ResourceCode", value, value.ToString());
				
				_resourcecode = value;
			}
		}
			
		public virtual long InsertUsertID
		{
			get
			{ 
				return _insertusertid;
			}
			set
			{
				_insertusertid = value;
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
			
		public virtual long? UpdateUserID
		{
			get
			{ 
				return _updateuserid;
			}
			set
			{
				_updateuserid = value;
			}

		}
			
		public virtual DateTime? UpdateDate
		{
			get
			{ 
				return _updatedate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for UpdateDate", value, value.ToString());
						
				_updatedate = value;	
			}			
					
		}
			
		public virtual int ResourceTypeID
		{
			get
			{ 
				return _resourcetypeid;
			}
			set
			{
				_resourcetypeid = value;
			}

		}
			
		public virtual string Url
		{
			get
			{ 
				return _url;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 2048)
				//	throw new ArgumentOutOfRangeException("Invalid value for Url", value, value.ToString());
				
				_url = value;
			}
		}
			
		public virtual int RankOrder
		{
			get
			{ 
				return _rankorder;
			}
			set
			{
				_rankorder = value;
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
            return this.ResourceID;
			
        }
		
		#endregion //Public Functions
	}
}
