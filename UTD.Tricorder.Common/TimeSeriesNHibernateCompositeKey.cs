using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTD.Tricorder.Common
{
    [Serializable]
    public class TimeSeriesNHibernateCompositeKey
    {
        //http://www.codeproject.com/Tips/419780/NHibernate-Mappings-for-Composite-Keys-with-Associ

        public virtual int TSDateOffset { get; set; }
        public virtual byte TimeSeriesTypeID { get; set; }
        public virtual long UserID { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            TimeSeriesNHibernateCompositeKey id;
            id = (TimeSeriesNHibernateCompositeKey)obj;
            if (id == null)
                return false;
            if (UserID == id.UserID && TSDateOffset == id.TSDateOffset && TimeSeriesTypeID == id.TimeSeriesTypeID)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (TimeSeriesTypeID + "|" + UserID + "|" + TSDateOffset).GetHashCode();
        }
    }
}
