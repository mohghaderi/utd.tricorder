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
	public partial class VisitPlace : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private byte _visitplaceid;//3

		//private IList<DoctorSchedule> _DoctorScheduleList; 

		//private IList<Visit> _VisitList; 

		private string _visitplacetitle; 
		private string _visitplaceicon; 		
		#endregion

		#region Constructor

		public VisitPlace()
		 //: base()
		{
			_visitplaceid = new byte(); 
			//_DoctorScheduleList = new List<DoctorSchedule>(); 
			//_VisitList = new List<Visit>(); 
			_visitplacetitle = null; 
			_visitplaceicon = null; 
		}

		public VisitPlace(
			byte visitplaceid, 
			string visitplacetitle, 
			string visitplaceicon)
			: this()
		{
			_visitplaceid = visitplaceid;
			_visitplacetitle = visitplacetitle;
			_visitplaceicon = visitplaceicon;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual byte VisitPlaceID
		{
			get
			{ 
				return _visitplaceid;
			}

			set	
			{	
				
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitPlaceID", value, "null");
				
				//if(  value.Length > 0)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitPlaceID", value, value.ToString());
				
				_visitplaceid = value;
			}

		}
			
		public virtual string VisitPlaceTitle
		{
			get
			{ 
				return _visitplacetitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitPlaceTitle", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitPlaceTitle", value, value.ToString());
				
				_visitplacetitle = value;
			}
		}
			
		public virtual string VisitPlaceIcon
		{
			get
			{ 
				return _visitplaceicon;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitPlaceIcon", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitPlaceIcon", value, value.ToString());
				
				_visitplaceicon = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddDoctorSchedule(DoctorSchedule obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_DoctorScheduleList.Add(obj);
		//}
		

		//public virtual void AddVisit(Visit obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_VisitList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.VisitPlaceID;
			
        }
		
		#endregion //Public Functions
	}
}
