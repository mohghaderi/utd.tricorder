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
	public partial class MobilePushDeliveryType : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private byte _mobilepushdeliverytypeid;//3

		//private IList<MobilePushTemplate> _MobilePushTemplateList; 

		private string _mobilepushdeliverytypename; 		
		#endregion

		#region Constructor

		public MobilePushDeliveryType()
		 //: base()
		{
			_mobilepushdeliverytypeid = new byte(); 
			//_MobilePushTemplateList = new List<MobilePushTemplate>(); 
			_mobilepushdeliverytypename = null; 
		}

		public MobilePushDeliveryType(
			byte mobilepushdeliverytypeid, 
			string mobilepushdeliverytypename)
			: this()
		{
			_mobilepushdeliverytypeid = mobilepushdeliverytypeid;
			_mobilepushdeliverytypename = mobilepushdeliverytypename;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte MobilePushDeliveryTypeID
		{
			get
			{ 
				return _mobilepushdeliverytypeid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobilePushDeliveryTypeID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushDeliveryTypeID", value, value.ToString());
				
				_mobilepushdeliverytypeid = value;
			}

		}
			
		public virtual string MobilePushDeliveryTypeName
		{
			get
			{ 
				return _mobilepushdeliverytypename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for MobilePushDeliveryTypeName", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for MobilePushDeliveryTypeName", value, value.ToString());
				
				_mobilepushdeliverytypename = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddMobilePushTemplate(MobilePushTemplate obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_MobilePushTemplateList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.MobilePushDeliveryTypeID;
			
        }
		
		#endregion //Public Functions
	}
}
