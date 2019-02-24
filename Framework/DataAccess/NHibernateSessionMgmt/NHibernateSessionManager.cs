// adopted from http://www.codeproject.com/Articles/13390/NHibernate-Best-Practices-with-ASP-NET-1-2nd-Ed

using System;
using System.Collections.Generic;
using Framework.Common;

namespace Framework.DataAccess
{
    /// <summary>
    /// Handles creation and management of sessions and transactions.  It is a singleton because 
    /// building the initial session factory is very expensive. Inspiration for this class came 
    /// from Chapter 8 of Hibernate in Action by Bauer and King.  Although it is a sealed singleton
    /// you can use TypeMock (http://www.typemock.com) for more flexible testing.
    /// </summary>
    public sealed class NHibernateSessionManager
    {
        #region Thread-safe, lazy Singleton

        /// <summary>
        /// This is a thread-safe, lazy singleton.  See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static NHibernateSessionManager Instance
        {
            get
            {
                return Nested.NHibernateSessionManager;
            }
        }

        /// <summary>
        /// Initializes the NHibernate session factory upon instantiation.
        /// </summary>
        private NHibernateSessionManager()
        {
            
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            static Nested() { }
            internal static readonly NHibernateSessionManager NHibernateSessionManager =
                new NHibernateSessionManager();
        }

        #endregion


        /// <summary>
        /// List of the created contexts. Since this class is created using singleton, this will not slow down the usage of the program.
        /// </summary>
        private Dictionary<string, NHibernateSessionContext> _ContextList = new Dictionary<string, NHibernateSessionContext>();

        private static object lockObject = new object();

        /// <summary>
        /// Gets the name of the context by.
        /// </summary>
        /// <param name="contextName">Name of the context.</param>
        /// <returns></returns>
        public NHibernateSessionContext GetContextByName(string contextName)
        {
            Check.Require(string.IsNullOrEmpty(contextName) == false, "contextName cannot be null or empty");

            NHibernateSessionContext context = null;

            lock (lockObject)
            {
                if (_ContextList.ContainsKey(contextName))
                    context = (NHibernateSessionContext)_ContextList[contextName];
                else
                {
                    context = new NHibernateSessionContext(contextName);
                    _ContextList.Add(contextName, context);
                }
            }

            Check.Ensure(context != null);

            return context;
        }

        /// <summary>
        /// commits all transactions in all contexts
        /// If some failure happened, it can't roll back
        /// </summary>
        public void CommitAllContexts()
        {
            List<Exception> exceptionsThatHappened = new List<Exception>();

            foreach (var context in _ContextList)
            {
                try
                {
                    context.Value.CommitTransaction();
                }
                catch (Exception ex)
                {
                    exceptionsThatHappened.Add(ex);
                }
            }

            if (exceptionsThatHappened.Count > 0)
                throw new Exception("Commit failed.");

        }


    }
}
