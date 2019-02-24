// adopted from http://www.codeproject.com/Articles/13390/NHibernate-Best-Practices-with-ASP-NET-1-2nd-Ed

using System;
using System.Runtime.Remoting.Messaging;
using System.Web;
using Framework.Common;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Xml;

namespace Framework.DataAccess
{
    public class NHibernateSessionContext
    {

        /// <summary>
        /// Initializes the NHibernate session factory upon instantiation.
        /// </summary>
        public NHibernateSessionContext(string contextName)
        {
            InitSessionFactory(contextName);
        }



        /// <summary>
        /// Gets or sets the name of the context.
        /// </summary>
        /// <value>
        /// The name of the context.
        /// </value>
        public string ContextName { get; set; }


        private void InitSessionFactory(string contextName)
        {
            // for single session in web.config usage
            //sessionFactory = new Configuration().Configure().BuildSessionFactory();

            this.ContextName = contextName;
            string configPath = GetConfigFilePath(contextName);

            Configuration cfg = new Configuration();
            cfg.Configure(configPath);

            //  Now that we have our Configuration object, create a new SessionFactory
            try
            {
                sessionFactory = cfg.BuildSessionFactory();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("The server was not found or was not accessible."))
                    throw new DatabaseNotAvailableException("NHibernateSessionContext cannot connect to database. Please make sure that database server is working, ContextName:" + contextName);
                else
                    throw;
            }
            catch (Exception)
            {
                throw;
            }

            if (sessionFactory == null)
            {
                throw new InvalidOperationException("cfg.BuildSessionFactory() returned null.");
            }

        }

        /// <summary>
        /// Gets the configuration file path by context name
        /// </summary>
        /// <param name="contextName">context name</param>
        /// <returns></returns>
        public static string GetConfigFilePath(string contextName)
        {
            Check.Require(string.IsNullOrEmpty(contextName) == false, "contextName cannot be null or empty");

            Check.Require(FWUtils.ConfigUtils.GetAppSettings().DatabaseContexts[contextName] != null,
                "context '" + contextName + "' is not defined in the config file.");

            string sessionFactoryConfigPath = FWUtils.ConfigUtils.GetAppSettings().DatabaseContexts[contextName].SettingsPath;
            Check.Require(!string.IsNullOrEmpty(sessionFactoryConfigPath),
                "sessionFactoryConfigPath may not be null nor empty");

            string configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sessionFactoryConfigPath);

            Check.Require(System.IO.File.Exists(configPath),
                    "The config file at '" + configPath + "' could not be found");
            return configPath;
        }

        /// <summary>
        /// Gets connection string from 
        /// </summary>
        /// <returns></returns>
        public static string GetNHibernateConnectionString(string contextName)
        {
            string nhibernateConfigFile = NHibernateSessionContext.GetConfigFilePath(contextName);
            XmlDocument doc = new XmlDocument();
            doc.Load(nhibernateConfigFile);
            var properties = doc.GetElementsByTagName("session-factory")[0].ChildNodes;
            for (int i = 0; i < properties.Count; i++)
            {
                if (properties[i].Attributes["name"].Value == "connection.connection_string")
                    return properties[i].InnerText.Trim();
            }

            return null;
        }

        /// <summary>
        /// Allows you to register an interceptor on a new session.  This may not be called if there is already
        /// an open session attached to the HttpContext.  If you have an interceptor to be used, modify
        /// the HttpModule to call this before calling BeginTransaction().
        /// </summary>
        public void RegisterInterceptor(IInterceptor interceptor)
        {
            ISession session = ContextSession;

            if (session != null && session.IsOpen)
            {
                throw new CacheException("You cannot register an interceptor once a session has already been opened");
            }

            GetSession(interceptor);
        }

        public ISession GetSession()
        {
            return GetSession(null);
        }

        /// <summary>
        /// Gets a session with or without an interceptor.  This method is not called directly; instead,
        /// it gets invoked from other public methods.
        /// </summary>
        private ISession GetSession(IInterceptor interceptor)
        {
            ISession session = ContextSession;

            if (session == null)
            {
                if (interceptor != null)
                {
                    session = sessionFactory.OpenSession(interceptor);
                }
                else
                {
                    session = sessionFactory.OpenSession();
                }

                ContextSession = session;
            }

            Check.Ensure(session != null, "session was null");

            return session;
        }

        /// <summary>
        /// Flushes anything left in the session and closes the connection.
        /// </summary>
        public void CloseSession()
        {
            ISession session = ContextSession;

            if (session != null && session.IsOpen)
            {
                //session.Flush(); when session exception happened, flushing causes the same exception to happen again.
                session.Close();
            }

            ContextSession = null;
        }

        public void BeginTransaction()
        {
            ITransaction transaction = ContextTransaction;

            if (transaction == null)
            {
                transaction = GetSession().BeginTransaction();
                ContextTransaction = transaction;
            }
        }

        public void CommitTransaction()
        {
            ITransaction transaction = ContextTransaction;

            try
            {
                if (HasOpenTransaction())
                {
                    transaction.Commit();
                    ContextTransaction = null;
                }
            }
            catch (HibernateException)
            {
                RollbackTransaction();
                throw;
            }
        }

        public bool HasOpenTransaction()
        {
            ITransaction transaction = ContextTransaction;

            return transaction != null && !transaction.WasCommitted && !transaction.WasRolledBack;
        }

        public void RollbackTransaction()
        {
            ITransaction transaction = ContextTransaction;

            try
            {
                if (HasOpenTransaction())
                {
                    transaction.Rollback();
                }

                ContextTransaction = null;
            }
            finally
            {
                CloseSession();
            }
        }

        /// <summary>
        /// If within a web context, this uses <see cref="HttpContext" /> instead of the WinForms 
        /// specific <see cref="CallContext" />.  Discussion concerning this found at 
        /// http://forum.springframework.net/showthread.php?t=572.
        /// </summary>
        private ITransaction ContextTransaction
        {
            get
            {
                if (IsInWebContext())
                {
                    return (ITransaction)HttpContext.Current.Items[this.ContextName + "_" + TRANSACTION_KEY];
                }
                else
                {
                    return (ITransaction)CallContext.GetData(this.ContextName + "_" + TRANSACTION_KEY);
                }
            }
            set
            {
                if (IsInWebContext())
                {
                    HttpContext.Current.Items[this.ContextName + "_" + TRANSACTION_KEY] = value;
                }
                else
                {
                    CallContext.SetData(this.ContextName + "_" + TRANSACTION_KEY, value);
                }
            }
        }

        /// <summary>
        /// If within a web context, this uses <see cref="HttpContext" /> instead of the WinForms 
        /// specific <see cref="CallContext" />.  Discussion concerning this found at 
        /// http://forum.springframework.net/showthread.php?t=572.
        /// </summary>
        private ISession ContextSession
        {
            get
            {
                if (IsInWebContext())
                {
                    return (ISession)HttpContext.Current.Items[this.ContextName + "_" + SESSION_KEY];
                }
                else
                {
                    return (ISession)CallContext.GetData(this.ContextName + "_" + SESSION_KEY);
                }
            }
            set
            {
                if (IsInWebContext())
                {
                    HttpContext.Current.Items[this.ContextName + "_" + SESSION_KEY] = value;
                }
                else
                {
                    CallContext.SetData(this.ContextName + "_" + SESSION_KEY, value);
                }
            }
        }

        private bool IsInWebContext()
        {
            return HttpContext.Current != null;
        }

        private const string TRANSACTION_KEY = "CONTEXT_TRANSACTION";
        private const string SESSION_KEY = "CONTEXT_SESSION";
        private ISessionFactory sessionFactory;
    }
}
