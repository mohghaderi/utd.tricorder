using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.TestCase.Common
{
    /// <summary>
    ///This is a test class for PaymentServiceTest and is intended
    ///to contain all PaymentServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AbstractAgentTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }



        /// <summary>
        ///A test for CreatePaymentForVisit
        ///It should create one record for one visit
        ///</summary>
        [TestMethod()]
        public void DoActionTest()
        {
            FakeAbstractAgent agent = new FakeAbstractAgent();
            agent.TimerInterval = 100;
            agent.StartAgent();
            System.Threading.Thread.Sleep(1000);
            agent.StopAgent();
            // I am not sure if we should get exactly 10 on all machines
            Assert.IsTrue(agent.actionExecutionCount == 10);
            agent.Dispose();
        }


    }
}
