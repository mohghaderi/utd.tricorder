using Framework.Common.Exceptions;
using Framework.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common.Utils
{
    // Developer Note: This class usage is STATIC, No state property

    /// <summary>
    /// Utilities for doing log and exception handling
    /// </summary>
    public class ExpLogUtils
    {
        
        private static ExceptionLogger _ExceptionLogger = new ExceptionLogger();
        public ExceptionLogger ExceptionLogger { get { return _ExceptionLogger; } }

        private static Logger _Logger = new Logger();
        public Logger Logger { get { return _Logger; } }

        private static ExceptionHandler _ExceptionHandler = new ExceptionHandler();
        public ExceptionHandler ExceptionHandler { get { return _ExceptionHandler; } }

        private static ExceptionTranslator _ExceptionTranslator = new ExceptionTranslator();
        public ExceptionTranslator ExceptionTranslator { get { return _ExceptionTranslator; } }

    }
}
