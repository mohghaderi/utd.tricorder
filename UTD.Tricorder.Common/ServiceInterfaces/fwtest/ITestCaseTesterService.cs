using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface ITestCaseTesterService : IServiceBaseT<TestCaseTester, vTestCaseTester>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        string ServiceFunctionWithoutParameterRetValue();

        void ServiceFunctionWithoutParameter();

        void ServiceFunctionWithOneParameter(string p1);

        string ServiceFunctionWithOneParameterRetValue(string p1);

        string ServiceFunctionWithOneComplexParameter(TestCaseTesterComplexP p);



		#endregion
    }
}

