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
	public partial class AppEntity : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private short _appentityid;//3

		//private IList<CallLog> _CallLogList; 

		//private IList<Payment> _PaymentList; 

		//private IList<AppFileType> _AppFileTypeList; 

		private string _appentityname; 
		private string _appentityadk; 		
		#endregion

		#region Constructor

		public AppEntity()
		 //: base()
		{
			_appentityid = -1; 
			//_CallLogList = new List<CallLog>(); 
			//_PaymentList = new List<Payment>(); 
			//_AppFileTypeList = new List<AppFileType>(); 
			_appentityname = null; 
			_appentityadk = null; 
		}

		public AppEntity(
			short appentityid, 
			string appentityname)
			: this()
		{
			_appentityid = appentityid;
			_appentityname = appentityname;
			_appentityadk = String.Empty;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short AppEntityID
		{
			get
			{ 
				return _appentityid;
			}
			set
			{
				_appentityid = value;
			}

		}
			
		public virtual string AppEntityName
		{
			get
			{ 
				return _appentityname;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for AppEntityName", value, "null");
				
				//if(  value.Length > 300)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppEntityName", value, value.ToString());
				
				_appentityname = value;
			}
		}
			
		public virtual string AppEntityADK
		{
			get
			{ 
				return _appentityadk;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for AppEntityADK", value, value.ToString());
				
				_appentityadk = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddCallLog(CallLog obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_CallLogList.Add(obj);
		//}
		

		//public virtual void AddPayment(Payment obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_PaymentList.Add(obj);
		//}
		

		//public virtual void AddAppFileType(AppFileType obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_AppFileTypeList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.AppEntityID;
			
        }
		
		#endregion //Public Functions
	}
}
