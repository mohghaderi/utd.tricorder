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
	public partial class vVisitStatus : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "VisitStatus";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string VisitStatusID = "VisitStatusID";
			public const string VisitStatusCode = "VisitStatusCode";
			public const string VisitStatusTitle = "VisitStatusTitle";
			public const string VisitStatusIcon = "VisitStatusIcon";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("VisitStatusID");
			_ColumnsList.Add("VisitStatusCode");
			_ColumnsList.Add("VisitStatusTitle");
			_ColumnsList.Add("VisitStatusIcon");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private int _visitstatusid; 
		private string _visitstatuscode; 
		private string _visitstatustitle; 
		private string _visitstatusicon; 		
		#endregion

		#region Constructor

		public vVisitStatus()
		 //: base()
		{
			_visitstatusid = -1; 
			_visitstatuscode = null; 
			_visitstatustitle = null; 
			_visitstatusicon = null; 
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
