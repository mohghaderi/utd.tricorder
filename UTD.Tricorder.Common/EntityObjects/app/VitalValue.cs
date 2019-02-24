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
	public partial class VitalValue : EntityObjectBase
	{
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

		#endregion

		#region Private Members

		private long _vitalvalueid; private long _personid;//0
//private Person _personid;//1

		private double _datavalue; 
		private DateTime _recorddatetime; private int _vitaltypeid;//0
//private VitalType _vitaltypeid;//1

		private bool _ismanualentry; 
		private string _comment; 		
		#endregion

		#region Constructor

		public VitalValue()
		 //: base()
		{
			_vitalvalueid = -1; 
			_personid = -1; 
			_datavalue = new double(); 
			_recorddatetime = DateTime.MinValue; 
			_vitaltypeid = -1; 
			_ismanualentry = false; 
			_comment = null; 
		}

		public VitalValue(
			long vitalvalueid, 
			long personid, 
			double datavalue, 
			DateTime recorddatetime, 
			int vitaltypeid, 
			bool ismanualentry)
			: this()
		{
			_vitalvalueid = vitalvalueid;
			_personid = personid;
			_datavalue = datavalue;
			_recorddatetime = recorddatetime;
			_vitaltypeid = vitaltypeid;
			_ismanualentry = ismanualentry;
			_comment = String.Empty;
		}
		#endregion // End Constructor

		#region Public Properties
			
		public virtual long VitalValueID
		{
			get
			{ 
				return _vitalvalueid;
			}
			set
			{
				_vitalvalueid = value;
			}

		}
			
		public virtual long PersonID
		{
			get
			{ 
				return _personid;
			}
			set
			{
				_personid = value;
			}

		}
			
		public virtual double DataValue
		{
			get
			{ 
				return _datavalue;
			}
			set
			{
				_datavalue = value;
			}

		}
			
		public virtual DateTime RecordDateTime
		{
			get
			{ 
				return _recorddatetime;
			}

			set	
			{
				//if (value < FWConsts.MinDateTime || value > FWConsts.MaxDateTime)
				//	throw new ArgumentOutOfRangeException("Invalid value for RecordDateTime", value, value.ToString());

				_recorddatetime = value;	
			}
					
		}
			
		public virtual int VitalTypeID
		{
			get
			{ 
				return _vitaltypeid;
			}
			set
			{
				_vitaltypeid = value;
			}

		}
			
		public virtual bool IsManualEntry
		{
			get
			{ 
				return _ismanualentry;
			}
			set
			{
				_ismanualentry = value;
			}

		}
			
		public virtual string Comment
		{
			get
			{ 
				return _comment;
			}

			set	
			{	
				//if(  value != null &&  value.Length > 1073741823)
				//	throw new ArgumentOutOfRangeException("Invalid value for Comment", value, value.ToString());
				
				_comment = value;
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
            return this.VitalValueID;
			
        }
		
		#endregion //Public Functions
	}
}
