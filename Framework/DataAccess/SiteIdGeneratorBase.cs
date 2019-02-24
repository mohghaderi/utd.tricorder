using System;
using System.Collections.Generic;
using System.Data;
using Framework.Common;
using NHibernate;
using NHibernate.AdoNet.Util;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Id;
using NHibernate.SqlCommand;
using NHibernate.Type;
using NHibernate.Util;

namespace Framework.DataAccess
{
    public abstract class SiteIdGeneratorBase : TransactionHelper, IConfigurable
    {
        public const string DefaultNHibernateTableParam = "target_table";
        public const string TableParam = "table_name";
        public const string ValueColumnParam = "target_column";


        /// <summary>
        /// Type mapping for the identifier.
        /// </summary>
        public IType IdentifierType { get; private set; }


        /// <summary>
        /// The name of the table in which we store this generator's persistent state.
        /// </summary>
        public string TableName { get; private set; }


        protected SqlString selectQuery;
        protected NHibernate.SqlTypes.SqlType[] selectParameterTypes;

        /// <summary>
        /// The name of the column in which we store our persistent generator value.
        /// </summary>
        public string ValueColumnName { get; private set; }


        public object IDBaseValue { get; protected set; }

        public object IDEndValue { get; protected set; }


        public virtual void Configure(IType type, IDictionary<string, string> parms, Dialect dialect)
        {
            IdentifierType = type;

            TableName = DetermineGeneratorTableName(parms, dialect);
            ValueColumnName = DetermineValueColumnName(parms, dialect);

            BuildSelectQuery(dialect);
            selectParameterTypes = new[] { NHibernate.SqlTypes.SqlTypeFactory.Int64, NHibernate.SqlTypes.SqlTypeFactory.Int64 };

        }



        /// <summary>
        /// Determine the name of the column in which we will store the generator persistent value.
        /// Called during configuration.
        /// </summary>
        protected string DetermineValueColumnName(IDictionary<string, string> parms, Dialect dialect)
        {
            // NHibernate doesn't seem to have anything resembling this ObjectNameNormalizer. Ignore that for now.
            //ObjectNameNormalizer normalizer = ( ObjectNameNormalizer ) params.get( IDENTIFIER_NORMALIZER );
            string name = PropertiesHelper.GetString(ValueColumnParam, parms, "");
            //return dialect.quote( normalizer.normalizeIdentifierQuoting( name ) );

            Check.Ensure(string.IsNullOrEmpty(name) == false, "value_column_name parameter should be set as primaryID for the table in ServerPrefixIdGenerator.");

            return dialect.QuoteForColumnName(name);
        }


        /// <summary>
        ///  Determine the table name to use for the generator values. Called during configuration.
        /// </summary>
        /// <param name="parms">The parameters supplied in the generator config (plus some standard useful extras).</param>
        protected string DetermineGeneratorTableName(IDictionary<string, string> parms, Dialect dialect)
        {
            string name = PropertiesHelper.GetString(TableParam, parms, ""); // try to find the name provided by user
            if (string.IsNullOrEmpty(name)) // if it was not provided, try to get it using default parameters that nhibernate passes to the class.
                name = PropertiesHelper.GetString(DefaultNHibernateTableParam, parms, "");
            bool isGivenNameUnqualified = name.IndexOf('.') < 0;
            if (isGivenNameUnqualified)
            {
                // NHibernate doesn't seem to have anything resembling this ObjectNameNormalizer. Ignore that for now.
                //ObjectNameNormalizer normalizer = ( ObjectNameNormalizer ) params.get( IDENTIFIER_NORMALIZER );
                //name = normalizer.normalizeIdentifierQuoting( name );
                //// if the given name is un-qualified we may neen to qualify it
                //string schemaName = normalizer.normalizeIdentifierQuoting( params.getProperty( SCHEMA ) );
                //string catalogName = normalizer.normalizeIdentifierQuoting( params.getProperty( CATALOG ) );

                string schemaName;
                string catalogName;
                parms.TryGetValue(PersistentIdGeneratorParmsNames.Schema, out schemaName);
                parms.TryGetValue(PersistentIdGeneratorParmsNames.Catalog, out catalogName);
                name = dialect.Qualify(catalogName, schemaName, dialect.QuoteForTableName(name));
                
            }
            else
            {
                string[] s = name.Split('.');
                if (s.Length == 2)
                {
                    name = s[0] + "." + dialect.QuoteForTableName(s[1]);
                }
                // if already qualified there is not much we can do in a portable manner so we pass it
                // through and assume the user has set up the name correctly.
            }

            Check.Ensure(string.IsNullOrEmpty(name) == false, "table_name should be specified as a parameter for ServerPrefixIdGenerator class");

            return name;
        }



        protected void BuildSelectQuery(Dialect dialect)
        {
            const string alias = "tbl";
            SqlStringBuilder selectBuilder = new SqlStringBuilder(100);
            selectBuilder.Add("select ").Add("max(" + StringHelper.Qualify(alias, ValueColumnName) + ")")
                .Add(" from " + TableName + " " + alias + " where ")
                .Add(StringHelper.Qualify(alias, ValueColumnName) + " > ")
                .AddParameter().Add("  ").Add(" and ")           // parameter = nodeSuffixInt64
                .Add(StringHelper.Qualify(alias, ValueColumnName) + " <= ")
                .AddParameter().Add("  ");

            Dictionary<string, LockMode> lockOptions = new Dictionary<string, LockMode>();
            lockOptions[alias] = LockMode.Upgrade;

            Dictionary<string, string[]> updateTargetColumnsMap = new Dictionary<string, string[]>();
            updateTargetColumnsMap[alias] = new[] { ValueColumnName };

            selectQuery = dialect.ApplyLocksToSql(selectBuilder.ToSqlString(), lockOptions, updateTargetColumnsMap);
        }



        public override object DoWorkInCurrentTransaction(ISessionImplementor session, System.Data.IDbConnection conn, System.Data.IDbTransaction transaction)
        {
            Check.Require(this.IDBaseValue != null);
            Check.Require(this.IDEndValue != null);
            Check.Require(Convert.ToInt64(this.IDEndValue) > Convert.ToInt64(this.IDBaseValue));


            object selectedValue;

            IDbCommand selectCmd = session.Factory.ConnectionProvider.Driver.GenerateCommand(CommandType.Text, selectQuery, selectParameterTypes);
            using (selectCmd)
            {
                selectCmd.Connection = conn;
                selectCmd.Transaction = transaction;
                string s = selectCmd.CommandText;

                ((IDataParameter)selectCmd.Parameters[0]).Value = this.IDBaseValue;
                ((IDataParameter)selectCmd.Parameters[1]).Value = this.IDEndValue;

                PersistentIdGeneratorParmsNames.SqlStatementLogger.LogCommand(selectCmd, FormatStyle.Basic);

                selectedValue = selectCmd.ExecuteScalar();
            }

            if (selectedValue == null || selectedValue is System.DBNull)  // if it wasn't found in the database return base id
            {
                return this.IDBaseValue;
            }
            else  // otherwise return the last saved number in the database
            {
                return selectedValue;
            }

        }


    }
}
