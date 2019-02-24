using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Id;
using NHibernate.Type;

namespace Framework.DataAccess
{

    public class SiteIdGeneratorInt32 : SiteIdGeneratorBase, IIdentifierGenerator
    {

        private Int32 LastNumber = -1;


        public SiteIdGeneratorInt32()
        {
            SiteIdUtils.ComputeValuesOnce();
            this.IDBaseValue = SiteIdUtils.BaseNumberInt32;
            this.IDEndValue = SiteIdUtils.EndNumberInt32;
        }


        public override void Configure(IType type, IDictionary<string, string> parms, Dialect dialect)
        {
            base.Configure(type, parms, dialect);
            selectParameterTypes = new[] { NHibernate.SqlTypes.SqlTypeFactory.Int32, NHibernate.SqlTypes.SqlTypeFactory.Int32 };
        }



        [MethodImpl(MethodImplOptions.Synchronized)]
        public Object Generate(ISessionImplementor session, Object obj)
        {
            if (LastNumber == -1)
            {
                // gets max number saved in database
                LastNumber = Convert.ToInt32(DoWorkInNewTransaction(session));
            }

            LastNumber++;
            if (LastNumber > (Int32)this.IDEndValue)
                throw new Exception("Cannot allocate a new siteID due to insufficient number of available IDs in table :" + TableName);

            return LastNumber;
        }

    }



}
