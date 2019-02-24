// adopted from http://www.codeproject.com/Articles/13390/NHibernate-Best-Practices-with-ASP-NET-1-2nd-Ed

using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Web;
using Framework.Common;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;

namespace Framework.DataAccess
{
    /// <summary>
    /// Handles creation and management of sessions and transactions.  It is a singleton because 
    /// building the initial session factory is very expensive. Inspiration for this class came 
    /// from Chapter 8 of Hibernate in Action by Bauer and King.  Although it is a sealed singleton
    /// you can use TypeMock (http://www.typemock.com) for more flexible testing.
    /// </summary>
    public sealed class NHibernateSessionManagerMultiDB
    {
        #region Thread-safe, lazy Singleton

        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static NHibernateSessionManagerMultiDB Instance
        {
            get
            {
                return Nested.NHibernateSessionManager;
            }
        }

        /// <summary>
        /// Private constructor to enforce singleton
        /// </summary>
        private NHibernateSessionManagerMultiDB() { }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            static Nested() { }
            internal static readonly NHibernateSessionManagerMultiDB NHibernateSessionManager =
                new NHibernateSessionManagerMultiDB();
        }

        #endregion

        /// <summary>
        /// This method attempts to find a session factory stored in <see cref="sessionFactories" />
        /// via its name; if it can't be found it creates a new one and adds it the hashtable.
        /// </summary>
        /// <param name="sessionFactoryConfigPath">Path location of the factory config</param>
        private ISessionFactory GetSessionFactoryFor(string contextName)
        {

            Check.Require(string.IsNullOrEmpty(contextName) == false, "contextName cannot be null or empty");
            string sessionFactoryConfigPath = FWUtils.ConfigUtils.GetAppSettings().DatabaseContexts[contextName].SettingsPath;


            Check.Require(!string.IsNullOrEmpty(sessionFactoryConfigPath),
                "sessionFactoryConfigPath may not be null nor empty");

            //  Attempt to retrieve a stored SessionFactory from the hashtable.
            ISessionFactory sessionFactory = (ISessionFactory)sessionFactories[contextName];

            //  Failed to find a matching SessionFactory so make a new one.
            if (sessionFactory == null)
            {
                Check.Require(File.Exists(sessionFactoryConfigPath),
                    "The config file at '" + sessionFactoryConfigPath + "' could not be found");

                Configuration cfg = new Configuration();
                cfg.Configure(sessionFactoryConfigPath);

                //  Now that we have our Configuration object, create a new SessionFactory
                sessionFactory = cfg.BuildSessionFactory();

                if (sessionFactory == null)
                {
                    throw new InvalidOperationException("cfg.BuildSessionFactory() returned null.");
                }

                sessionFactories.Add(contextName, sessionFactory);
            }

            return sessionFactory;
        }

        /// <summary>
        /// Allows you to register an interceptor on a new session.  This may not be called if there is already
        /// an open session attached to the HttpContext.  If you have an interceptor to be used, modify
        /// the HttpModule to call this before calling BeginTransaction().
        /// </summary>
        public void RegisterInterceptorOn(string contextName, IInterceptor interceptor)
        {
            Check.Require(string.IsNullOrEmpty(contextName) == false, "contextName cannot be null or empty");

            ISession session = (ISession)ContextSessions[contextName];

            if (session != null && session.IsOpen)
            {
                throw new CacheException("You cannot register an interceptor once a session has already been opened");
            }

            GetSessionFrom(contextName, interceptor);
        }

        public ISession GetSessionFrom(string contextName)
        {
            return GetSessionFrom(contextName, null);
        }

        /// <summary>
        /// Gets a session with or without an interceptor.  This method is not called directly; instead,
        /// it gets invoked from other public methods.
        /// </summary>
        private ISession GetSessionFrom(string contextName, IInterceptor interceptor)
        {
            ISession session = (ISession)ContextSessions[contextName];

            if (session == null)
            {
                if (interceptor != null)
                {
                    session = GetSessionFactoryFor(contextName).OpenSession(interceptor);
                }
                else
                {
                    session = GetSessionFactoryFor(contextName).OpenSession();
                }

                ContextSessions[contextName] = session;
            }

            Check.Ensure(session != null, "session was null");

            return session;
        }

        /// <summary>
        /// Flushes anything left in the session and closes the connection.
        /// </summary>
        public void CloseSessionOn(string contextName)
        {
            ISession session = (ISession)ContextSessions[contextName];

            if (session != null && session.IsOpen)
            {
                session.Flush();
                session.Close();
            }

            ContextSessions.Remove(contextName);
        }

        public ITransaction BeginTransactionOn(string contextName)
        {
            ITransaction transaction = (ITransaction)ContextTransactions[contextName];

            if (transaction == null)
            {
                transaction = GetSessionFrom(contextName).BeginTransaction();
                ContextTransactions.Add(contextName, transaction);
            }

            return transaction;
        }

        public void CommitTransactionOn(string contextName)
        {
            ITransaction transaction = (ITransaction)ContextTransactions[contextName];

            try
            {
                if (HasOpenTransactionOn(contextName))
                {
                    transaction.Commit();
                    ContextTransactions.Remove(contextName);
                }
            }
            catch (HibernateException)
            {
                RollbackTransactionOn(contextName);
                throw;
            }
        }

        public bool HasOpenTransactionOn(string contextName)
        {
            ITransaction transaction = (ITransaction)ContextTransactions[contextName];

            return transaction != null && !transaction.WasCommitted && !transaction.WasRolledBack;
        }

        public void RollbackTransactionOn(string contextName)
        {
            ITransaction transaction = (ITransaction)ContextTransactions[contextName];

            try
            {
                if (HasOpenTransactionOn(contextName))
                {
                    transaction.Rollback();
                }

                ContextTransactions.Remove(contextName);
            }
            finally
            {
                CloseSessionOn(contextName);
            }
        }

        /// <summary>
        /// Since multiple databases may be in use, there may be one transaction per database 
        /// persisted at any one time.  The easiest way to store them is via a hashtable
        /// with the key being tied to session factory.  If within a web context, this uses
        /// <see cref="HttpContext" /> instead of the WinForms specific <see cref="CallContext" />.  
        /// Discussion concerning this found at http://forum.springframework.net/showthread.php?t=572
        /// </summary>
        private Hashtable ContextTransactions
        {
            get
            {
                if (IsInWebContext())
                {
                    if (HttpContext.Current.Items[TRANSACTION_KEY] == null)
                        HttpContext.Current.Items[TRANSACTION_KEY] = new Hashtable();

                    return (Hashtable)HttpContext.Current.Items[TRANSACTION_KEY];
                }
                else
                {
                    if (CallContext.GetData(TRANSACTION_KEY) == null)
                        CallContext.SetData(TRANSACTION_KEY, new Hashtable());

                    return (Hashtable)CallContext.GetData(TRANSACTION_KEY);
                }
            }
        }

        /// <summary>
        /// Since multiple databases may be in use, there may be one session per database 
        /// persisted at any one time.  The easiest way to store them is via a hashtable
        /// with the key being tied to session factory.  If within a web context, this uses
        /// <see cref="HttpContext" /> instead of the WinForms specific <see cref="CallContext" />.  
        /// Discussion concerning this found at http://forum.springframework.net/showthread.php?t=572
        /// </summary>
        private Hashtable ContextSessions
        {
            get
            {
                if (IsInWebContext())
                {
                    if (HttpContext.Current.Items[SESSION_KEY] == null)
                        HttpContext.Current.Items[SESSION_KEY] = new Hashtable();

                    return (Hashtable)HttpContext.Current.Items[SESSION_KEY];
                }
                else
                {
                    if (CallContext.GetData(SESSION_KEY) == null)
                        CallContext.SetData(SESSION_KEY, new Hashtable());

                    return (Hashtable)CallContext.GetData(SESSION_KEY);
                }
            }
        }

        private bool IsInWebContext()
        {
            return HttpContext.Current != null;
        }

        private Hashtable sessionFactories = new Hashtable();
        private const string TRANSACTION_KEY = "CONTEXT_TRANSACTIONS";
        private const string SESSION_KEY = "CONTEXT_SESSIONS";
    }
}
