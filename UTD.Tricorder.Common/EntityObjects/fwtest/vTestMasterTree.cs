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
	public partial class vTestMasterTree : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "TestMasterTree";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string TestMasterTreeID = "TestMasterTreeID";
			public const string TestMasterTreeCode = "TestMasterTreeCode";
			public const string TestMasterTreeTitle = "TestMasterTreeTitle";
			public const string ParentID = "ParentID";
			public const string InsertUserID = "InsertUserID";
			public const string InsertDate = "InsertDate";
			public const string UpdateUserID = "UpdateUserID";
			public const string UpdateDate = "UpdateDate";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("TestMasterTreeID");
			_ColumnsList.Add("TestMasterTreeCode");
			_ColumnsList.Add("TestMasterTreeTitle");
			_ColumnsList.Add("ParentID");
			_ColumnsList.Add("InsertUserID");
			_ColumnsList.Add("InsertDate");
			_ColumnsList.Add("UpdateUserID");
			_ColumnsList.Add("UpdateDate");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _testmastertreeid; 
		private string _testmastertreecode; 
		private string _testmastertreetitle; 
		private string _parentid; 
		private long? _insertuserid; 
		private DateTime? _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; 		
		#endregion

		#region Constructor

		public vTestMasterTree()
		 //: base()
		{
			_testmastertreeid = -1; 
			_testmastertreecode = null; 
			_testmastertreetitle = null; 
			_parentid = null; 
			_insertuserid = null; 
			_insertdate = null; 
			_updateuserid = null; 
			_updatedate = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long TestMasterTreeID
		{
			get
			{ 
				return _testmastertreeid;
			}
			set
			{
				_testmastertreeid = value;
			}

		}
			
		public virtual string TestMasterTreeCode
		{
			get
			{ 
				return _testmastertreecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TestMasterTreeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for TestMasterTreeCode", value, value.ToString());
				
				_testmastertreecode = value;
			}
		}
			
		public virtual string TestMasterTreeTitle
		{
			get
			{ 
				return _testmastertreetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TestMasterTreeTitle", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for TestMasterTreeTitle", value, value.ToString());
				
				_testmastertreetitle = value;
			}
		}
			
		public virtual string ParentID
		{
			get
			{ 
				return _parentid;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 10)
				//	throw new ArgumentOutOfRangeException("Invalid value for ParentID", value, value.ToString());
				
				_parentid = value;
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
			
		public virtual DateTime? InsertDate
		{
			get
			{ 
				return _insertdate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
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
			
				
		#endregion 

		#region Public Functions


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.TestMasterTreeID;
			
        }
		
		#endregion //Public Functions
	}
}
