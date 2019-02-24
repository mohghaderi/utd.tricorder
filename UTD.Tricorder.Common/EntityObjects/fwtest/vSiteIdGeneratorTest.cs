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
	public partial class vSiteIdGeneratorTest : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion


		public const string EntityName = "SiteIdGeneratorTest";

		#region ColumnNames Class

		public static class ColumnNames
		{
			public const string SiteIdGeneratorTestID = "SiteIdGeneratorTestID";
			public const string SiteIdGeneratorTestTitle = "SiteIdGeneratorTestTitle";
		}


		private static List<String> _ColumnsList;

		public static List<String> GetColumnNamesList()
		{
			if (_ColumnsList != null)
				return _ColumnsList;
			
			_ColumnsList = new List<string>();
			_ColumnsList.Add("SiteIdGeneratorTestID");
			_ColumnsList.Add("SiteIdGeneratorTestTitle");

			return _ColumnsList;
		}

		#endregion // end columnNames class 

		#region Private Members

		private long _siteidgeneratortestid; 
		private string _siteidgeneratortesttitle; 		
		#endregion

		#region Constructor

		public vSiteIdGeneratorTest()
		 //: base()
		{
			_siteidgeneratortestid = -1; 
			_siteidgeneratortesttitle = null; 
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long SiteIdGeneratorTestID
		{
			get
			{ 
				return _siteidgeneratortestid;
			}
			set
			{
				_siteidgeneratortestid = value;
			}

		}
			
		public virtual string SiteIdGeneratorTestTitle
		{
			get
			{ 
				return _siteidgeneratortesttitle;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 100)
				//	throw new ArgumentOutOfRangeException("Invalid value for SiteIdGeneratorTestTitle", value, value.ToString());
				
				_siteidgeneratortesttitle = value;
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
            return this.SiteIdGeneratorTestID;
			
        }
		
		#endregion //Public Functions
	}
}
