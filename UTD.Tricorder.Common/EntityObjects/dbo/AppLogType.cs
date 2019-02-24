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
	public partial class AppLogType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private short _applogtypeid;//3

		//private IList<AppLog> _AppLogList; 

		private string _applogtypename; 
		private string _applogtypecode; 		
		#endregion

		#region Constructor

		public AppLogType()
		 //: base()
		{
			_applogtypeid = -1; 
			//_AppLogList = new List<AppLog>(); 
			_applogtypename = null; 
			_applogtypecode = null; 
		}

		public AppLogType(
			short applogtypeid, 
			string applogtypename, 
			string applogtypecode)
			: this()
		{
			_applogtypeid = applogtypeid;
			_applogtypename = applogtypename;
			_applogtypecode = applogtypecode;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short AppLogTypeID
		{
			get
			{ 
				return _applogtypeid;
			}
			set
			{
				_applogtypeid = value;
			}

		}
			
		public virtual string AppLogTypeName
		{
			get
			{ 
				return _applogtypename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppLogTypeName", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppLogTypeName", value, value.ToString());
				
				_applogtypename = value;
			}
		}
			
		public virtual string AppLogTypeCode
		{
			get
			{ 
				return _applogtypecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppLogTypeCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppLogTypeCode", value, value.ToString());
				
				_applogtypecode = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddAppLog(AppLog obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_AppLogList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.AppLogTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
