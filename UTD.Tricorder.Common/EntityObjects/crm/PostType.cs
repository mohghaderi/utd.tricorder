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
	public partial class PostType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion //Generator-Safe Area

		#region Private Members
		private byte _posttypeid;//3

		//private IList<Post> _PostList; 

		private string _posttypename; 
		private string _posttypecode; 		
		#endregion

		#region Constructor

		public PostType()
		 //: base()
		{
			_posttypeid = new byte(); 
			//_PostList = new List<Post>(); 
			_posttypename = null; 
			_posttypecode = null; 
		}

		public PostType(
			byte posttypeid, 
			string posttypename, 
			string posttypecode)
			: this()
		{
			_posttypeid = posttypeid;
			_posttypename = posttypename;
			_posttypecode = posttypecode;
		}
		#endregion // End Constructor

		#region Public Properties
			
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
            return this.PostTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
