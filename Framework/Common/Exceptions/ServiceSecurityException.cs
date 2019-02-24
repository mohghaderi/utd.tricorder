using Framework.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    [Serializable]
    public class ServiceSecurityException : UserException
    {
        public ServiceSecurityException()
            : base(StringMsgs.Exceptions.AccessDenied)
        {
 
        }


        public ServiceSecurityException(string message)
            :base(message)
        { 

        }



    }
}
