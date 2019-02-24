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
	public partial class SiteIdGeneratorTest : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion

		#region Private Members

		private long _siteidgeneratortestid; 
		private string _siteidgeneratortesttitle; 
		private int? _newintid; 		
		#endregion

		#region Constructor

		public SiteIdGeneratorTest()
		 //: base()
		{
			_siteidgeneratortestid = -1; 
			_siteidgeneratortesttitle = null; 
			_newintid = null; 
		}

		public SiteIdGeneratorTest(
			long siteidgeneratortestid)
			: this()
		{
			_siteidgeneratortestid = siteidgeneratortestid;
			_siteidgeneratortesttitle = String.Empty;
			_newintid = null;
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
			
		public virtual int? NewIntID
		{
			get
			{ 
				return _newintid;
			}
			set
			{
				_newintid = value;
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
