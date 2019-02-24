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
	public partial class Resource : EntityObjectBase
	{
		#region Generator-Safe Area

        private IList<Resource> _childs;
		//Please write your properties and functions here. This part will not be replaced.
        [XmlIgnore]
        public virtual IList<Resource> Childs 
        {
            get
            {
                if (_childs == null)
                    _childs = new List<Resource>();
                return _childs;
            }
        } 

		#endregion

		#region Private Members
		private long _resourceid;//3

		//private IList<Permission> _PermissionList; 

		//private IList<Resource> _ResourceList; 
private long? _parentid;//0
//private Resource _parentid;//1

		private string _resourcetitle; 
		private string _resourcecode; 
		private long _insertusertid; 
		private DateTime _insertdate; 
		private long? _updateuserid; 
		private DateTime? _updatedate; private int _resourcetypeid;//0
//private ResourceType _resourcetypeid;//1

		private string _url; 
		private int _rankorder; 		
		#endregion

		#region Constructor

		public Resource()
		 //: base()
		{
			_resourceid = -1; 
			//_PermissionList = new List<Permission>(); 
			//_ResourceList = new List<Resource>(); 
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

		public Resource(
			long resourceid, 
			string resourcetitle, 
			string resourcecode, 
			long insertusertid, 
			DateTime insertdate, 
			int resourcetypeid, 
			int rankorder)
			: this()
		{
			_resourceid = resourceid;
			_parentid = null;
			_resourcetitle = resourcetitle;
			_resourcecode = resourcecode;
			_insertusertid = insertusertid;
			_insertdate = insertdate;
			_updateuserid = null;
			_updatedate = null;
			_resourcetypeid = resourcetypeid;
			_url = String.Empty;
			_rankorder = rankorder;
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

		//public virtual void AddPermission(Permission obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PermissionList.Add(obj);
		//}
		

		//public virtual void AddResource(Resource obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_ResourceList.Add(obj);
		//}
		


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
