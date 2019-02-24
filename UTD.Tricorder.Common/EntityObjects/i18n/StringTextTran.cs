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
	public partial class StringTextTran : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		

		#endregion

		#region Private Members

		private long _stringtexttranid; 
		private Guid _stringtextid; 
		private string _tranvalue; 
		private short _languageid; 
		private bool _isaccepted; 
		private long _insertuserid; 
		private DateTime _insertdate; 
		private long? _accepteduserid; 
		private DateTime? _accepteddate; 		
		#endregion

		#region Constructor

		public StringTextTran()
		 //: base()
		{
			_stringtexttranid = -1; 
			_stringtextid = new Guid(); 
			_tranvalue = null; 
			_languageid = -1; 
			_isaccepted = false; 
			_insertuserid = -1; 
			_insertdate = DateTime.MinValue; 
			_accepteduserid = null; 
			_accepteddate = null; 
		}

		public StringTextTran(
			long stringtexttranid, 
			Guid stringtextid, 
			string tranvalue, 
			short languageid, 
			bool isaccepted, 
			long insertuserid, 
			DateTime insertdate)
			: this()
		{
			_stringtexttranid = stringtexttranid;
			_stringtextid = stringtextid;
			_tranvalue = tranvalue;
			_languageid = languageid;
			_isaccepted = isaccepted;
			_insertuserid = insertuserid;
			_insertdate = insertdate;
			_accepteduserid = null;
			_accepteddate = null;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long StringTextTranID
		{
			get
			{ 
				return _stringtexttranid;
			}
			set
			{
				_stringtexttranid = value;
			}

		}
			
		public virtual Guid StringTextID
		{
			get
			{ 
				return _stringtextid;
			}
			set
			{
//				if( value == null )
//					throw new ArgumentOutOfRangeException("Null value not allowed for StringTextID", value, "null");

				_stringtextid = value;
			}

		}
			
		public virtual string TranValue
		{
			get
			{ 
				return _tranvalue;
			}

			set	
			{	
				//if( value == null )
				//	throw new ArgumentOutOfRangeException("Null value not allowed for TranValue", value, "null");
				
				//if(  value.Length > 500)
				//	throw new ArgumentOutOfRangeException("Invalid value for TranValue", value, value.ToString());
				
				_tranvalue = value;
			}
		}
			
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
			
		public virtual bool IsAccepted
		{
			get
			{ 
				return _isaccepted;
			}
			set
			{
				_isaccepted = value;
			}

		}
			
		public virtual long InsertUserID
		{
			get
			{ 
				return _insertuserid;
			}
			set
			{
				_insertuserid = value;
			}

		}
			
		public virtual DateTime InsertDate
		{
			get
			{ 
				return _insertdate;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for InsertDate", value, value.ToString());

				_insertdate = value;	
			}
					
		}
			
		public virtual long? AcceptedUserID
		{
			get
			{ 
				return _accepteduserid;
			}
			set
			{
				_accepteduserid = value;
			}

		}
			
		public virtual DateTime? AcceptedDate
		{
			get
			{ 
				return _accepteddate;
			}

			set	
			{
				//if (value.HasValue && (value.Value < FWConsts.MinDateTime || value.Value > FWConsts.MaxDateTime))
				//	throw new ArgumentOutOfRangeException("Invalid value for AcceptedDate", value, value.ToString());
						
				_accepteddate = value;	
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
            return this.StringTextTranID;
			
        }
		
		#endregion //Public Functions
	}
}
