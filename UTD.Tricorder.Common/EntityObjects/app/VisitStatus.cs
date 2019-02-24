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
	public partial class VisitStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private int _visitstatusid;//3

		//private IList<Visit> _VisitList; 

		private string _visitstatuscode; 
		private string _visitstatustitle; 
		private string _visitstatusicon; 		
		#endregion

		#region Constructor

		public VisitStatus()
		 //: base()
		{
			_visitstatusid = -1; 
			//_VisitList = new List<Visit>(); 
			_visitstatuscode = null; 
			_visitstatustitle = null; 
			_visitstatusicon = null; 
		}

		public VisitStatus(
			int visitstatusid, 
			string visitstatuscode, 
			string visitstatustitle, 
			string visitstatusicon)
			: this()
		{
			_visitstatusid = visitstatusid;
			_visitstatuscode = visitstatuscode;
			_visitstatustitle = visitstatustitle;
			_visitstatusicon = visitstatusicon;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual int VisitStatusID
		{
			get
			{ 
				return _visitstatusid;
			}
			set
			{
				_visitstatusid = value;
			}

		}
			
		public virtual string VisitStatusCode
		{
			get
			{ 
				return _visitstatuscode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitStatusCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitStatusCode", value, value.ToString());
				
				_visitstatuscode = value;
			}
		}
			
		public virtual string VisitStatusTitle
		{
			get
			{ 
				return _visitstatustitle;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitStatusTitle", value, "null");
				
				//if(  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitStatusTitle", value, value.ToString());
				
				_visitstatustitle = value;
			}
		}
			
		public virtual string VisitStatusIcon
		{
			get
			{ 
				return _visitstatusicon;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for VisitStatusIcon", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for VisitStatusIcon", value, value.ToString());
				
				_visitstatusicon = value;
			}
		}
			
				
		#endregion 

		#region Public Functions

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
            return this.VisitStatusID;
			
        }
		
		#endregion //Public Functions
	}
}
