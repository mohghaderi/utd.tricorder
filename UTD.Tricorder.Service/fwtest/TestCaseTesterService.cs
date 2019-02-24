using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Service
{
    public class TestCaseTesterService : ServiceBase<TestCaseTester, vTestCaseTester>, ITestCaseTesterService
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public string ServiceFunctionWithoutParameterRetValue()
        {
            return "OK!";
        }

        public void ServiceFunctionWithoutParameter()
        {
            // do nothing
            throw new UserException("OK!");
        }

        public void ServiceFunctionWithOneParameter(string p1)
        {
            // do nothing
            throw new UserException("OK! " + p1);
        }

        public string ServiceFunctionWithOneParameterRetValue(string p1)
        {
            return "OK! " + p1;
        }

        public string ServiceFunctionWithOneComplexParameter(TestCaseTesterComplexP p)
        {
            //Check.Assert(p != null, "Complex parameter can't be null");
            return "OK!";
        }

		#endregion

    }
}

