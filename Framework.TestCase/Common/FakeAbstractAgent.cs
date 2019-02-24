using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.TestCase.Common
{
    public class FakeAbstractAgent : AbstractAgent
    {

        public override string AgentTypeName
        {
            get { return "FakeAbstractAgent"; }
        }

        public int actionExecutionCount = 0;

        public override void DoAction()
        {
            actionExecutionCount++;
        }
    }
}
