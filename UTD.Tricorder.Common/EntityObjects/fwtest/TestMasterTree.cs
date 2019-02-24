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
	public partial class TestMasterTree : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

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

		public TestMasterTree()
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

		public TestMasterTree(
			long testmastertreeid, 
			string testmastertreecode, 
			string testmastertreetitle)
			: this()
		{
			_testmastertreeid = testmastertreeid;
			_testmastertreecode = testmastertreecode;
			_testmastertreetitle = testmastertreetitle;
			_parentid = String.Empty;
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
