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
	public partial class Language : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members
		private short _languageid;//3

		//private IList<Site> _SiteList; 

		private string _languagecode; 
		private string _languagename; 
		private short _superlanguageid; 		
		#endregion

		#region Constructor

		public Language()
		 //: base()
		{
			_languageid = -1; 
			//_SiteList = new List<Site>(); 
			_languagecode = null; 
			_languagename = null; 
			_superlanguageid = -1; 
		}

		public Language(
			short languageid, 
			string languagecode, 
			string languagename, 
			short superlanguageid)
			: this()
		{
			_languageid = languageid;
			_languagecode = languagecode;
			_languagename = languagename;
			_superlanguageid = superlanguageid;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual short LanguageID
		{
			get
			{ 
				return _languageid;
			}
			set
			{
				_languageid = value;
			}

		}
			
		public virtual string LanguageCode
		{
			get
			{ 
				return _languagecode;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for LanguageCode", value, "null");
				
				//if(  value.Length > 50)
				//	throw new ArgumentOutOfRangeException("Invalid value for LanguageCode", value, value.ToString());
				
				_languagecode = value;
			}
		}
			
		public virtual string LanguageName
		{
			get
			{ 
				return _languagename;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for LanguageName", value, "null");
				
				//if(  value.Length > 200)
				//	throw new ArgumentOutOfRangeException("Invalid value for LanguageName", value, value.ToString());
				
				_languagename = value;
			}
		}
			
		public virtual short SuperLanguageID
		{
			get
			{ 
				return _superlanguageid;
			}
			set
			{
				_superlanguageid = value;
			}

		}
			
				
		#endregion 

		#region Public Functions

		//public virtual void AddSite(Site obj)
		//{
		//	#region Check if null
		//	if (obj == null)
		//		throw new ArgumentNullException("obj", "El parametro no puede ser nulo");
		//	#endregion
		//	_SiteList.Add(obj);
		//}
		


        /// <summary>
        /// Gets the value of the primary key
        /// </summary>
        /// <returns></returns>
        public override object GetPrimaryKeyValue()
        {
            return this.LanguageID;
			
        }
		
		#endregion //Public Functions
	}
}
