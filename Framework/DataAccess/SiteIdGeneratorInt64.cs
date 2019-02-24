using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Id;
using NHibernate.Type;

namespace Framework.DataAccess
{

    public class SiteIdGeneratorInt64 : SiteIdGeneratorBase, IIdentifierGenerator
    {
        // This class is copy & paste of ServerPrefixInt32IdGenerator, just replace 32 to 64

        private Int64 LastNumber = -1;


        public SiteIdGeneratorInt64()
        {
            SiteIdUtils.ComputeValuesOnce();
            this.IDBaseValue = SiteIdUtils.BaseNumberInt64;
            this.IDEndValue = SiteIdUtils.EndNumberInt64;
        }


        public override void Configure(IType type, IDictionary<string, string> parms, Dialect dialect)
        {
            base.Configure(type, parms, dialect);
            selectParameterTypes = new[] { NHibernate.SqlTypes.SqlTypeFactory.Int64, NHibernate.SqlTypes.SqlTypeFactory.Int64 };
        }



        [MethodImpl(MethodImplOptions.Synchronized)]
        public Object Generate(ISessionImplementor session, Object obj)
        {
            if (LastNumber == -1)
            {
                // gets max number saved in database
                LastNumber = Convert.ToInt64(DoWorkInNewTransaction(session));
            }

            LastNumber++;
            if (LastNumber > (Int64)this.IDEndValue)
                throw new Exception("Cannot allocate a siteID due to insufficient number of available IDs in table :" + TableName);

            return LastNumber;
        }

    }
}
