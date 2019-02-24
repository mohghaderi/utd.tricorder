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
	public partial class UserPaymentInfo : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private long _userpaymentinfoid;//3

		//private IList<UserPaymentInfo> _UserPaymentInfoList; 

		private string _userpaymentinfopaypalemail; 
		private string _notes; 		
		#endregion

		#region Constructor

		public UserPaymentInfo()
		 //: base()
		{
			_userpaymentinfoid = -1; 
			//_UserPaymentInfoList = new List<UserPaymentInfo>(); 
			_userpaymentinfopaypalemail = null; 
			_notes = null; 
		}

		public UserPaymentInfo(
			long userpaymentinfoid)
			: this()
		{
			_userpaymentinfoid = userpaymentinfoid;
			_userpaymentinfopaypalemail = String.Empty;
			_notes = String.Empty;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long UserPaymentInfoID
		{
			get
			{ 
				return _userpaymentinfoid;
			}
			set
			{
				_userpaymentinfoid = value;
			}

		}
			
		public virtual string UserPaymentInfoPayPalEmail
		{
			get
			{ 
				return _userpaymentinfopaypalemail;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 170)
				//	throw new ArgumentOutOfRangeException("Invalid value for UserPaymentInfoPayPalEmail", value, value.ToString());
				
				_userpaymentinfopaypalemail = value;
			}
		}
			
		public virtual string Notes
		{
			get
			{ 
				return _notes;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1000)
				//	throw new ArgumentOutOfRangeException("Invalid value for Notes", value, value.ToString());
				
				_notes = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddUserPaymentInfo(UserPaymentInfo obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_UserPaymentInfoList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.UserPaymentInfoID;
			
        }
		
		#endregion //Public Functions
	}
}
