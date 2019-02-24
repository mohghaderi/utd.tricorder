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
	public partial class ResourceType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion

		#region Private Members
		private int _resourcetypeid;//3

		//private IList<Resource> _ResourceList; 

		private string _resourcetypetitle; 
		private string _resourcetypecode; 		
		#endregion

		#region Constructor

		public ResourceType()
		 //: base()
		{
			_resourcetypeid = -1; 
			//_ResourceList = new List<Resource>(); 
			_resourcetypetitle = null; 
			_resourcetypecode = null; 
		}

		public ResourceType(
			int resourcetypeid, 
			string resourcetypetitle, 
			string resourcetypecode)
			: this()
		{
			_resourcetypeid = resourcetypeid;
			_resourcetypetitle = resourcetypetitle;
			_resourcetypecode = resourcetypecode;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
			
		public virtual string ResourceTypeTitle
		{
			get
			{ 
				return _resourcetypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ResourceTypeTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for ResourceTypeTitle", value, value.ToString());
				
				_resourcetypetitle = value;
			}
		}
			
		public virtual string ResourceTypeCode
		{
			get
			{ 
				return _resourcetypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for ResourceTypeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for ResourceTypeCode", value, value.ToString());
				
				_resourcetypecode = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

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
            return this.ResourceTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
