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
	public partial class vVisitPlace : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "VisitPlace";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string VisitPlaceID = "VisitPlaceID";
			public const string VisitPlaceTitle = "VisitPlaceTitle";
			public const string VisitPlaceIcon = "VisitPlaceIcon";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("VisitPlaceID");
			_ColumnsList.Add("VisitPlaceTitle");
			_ColumnsList.Add("VisitPlaceIcon");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private byte _visitplaceid; 
		private string _visitplacetitle; 
		private string _visitplaceicon; 		
		#endregion

		#region Constructor

		public vVisitPlace()
		 //: base()
		{
			_visitplaceid = new byte(); 
			_visitplacetitle = null; 
			_visitplaceicon = null; 
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
