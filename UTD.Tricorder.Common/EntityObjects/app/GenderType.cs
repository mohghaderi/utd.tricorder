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
	public partial class GenderType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion

		#region Private Members
		private int _gendertypeid;//3

		//private IList<Person> _PersonList; 

		private string _gendertypetitle; 
		private string _gendertypecode; 		
		#endregion

		#region Constructor

		public GenderType()
		 //: base()
		{
			_gendertypeid = -1; 
			//_PersonList = new List<Person>(); 
			_gendertypetitle = null; 
			_gendertypecode = null; 
		}

		public GenderType(
			int gendertypeid, 
			string gendertypetitle, 
			string gendertypecode)
			: this()
		{
			_gendertypeid = gendertypeid;
			_gendertypetitle = gendertypetitle;
			_gendertypecode = gendertypecode;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int GenderTypeID
		{
			get
			{ 
				return _gendertypeid;
			}
			set
			{
				_gendertypeid = value;
			}

		}
			
		public virtual string GenderTypeTitle
		{
			get
			{ 
				return _gendertypetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for GenderTypeTitle", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for GenderTypeTitle", value, value.ToString());
				
				_gendertypetitle = value;
			}
		}
			
		public virtual string GenderTypeCode
		{
			get
			{ 
				return _gendertypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for GenderTypeCode", value, "null");
				
				//if(  value.Length > 10)
				//	throw new ArgumentOutOfRangeException("Invalid value for GenderTypeCode", value, value.ToString());
				
				_gendertypecode = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddPerson(Person obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PersonList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.GenderTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
