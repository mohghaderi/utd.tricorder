using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using System.Web;

namespace Framework.Common
{
    /// <summary>
    /// Summary description for AbstractAgent
    /// </summary>
    public abstract class AbstractAgent : IDisposable
    {

        #region Properties

        //protected Timer agentTimer;
        protected BackgroundWorker threadWorker;


        private int _TimerInterval = 1000;

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>
        /// The timer interval.
        /// </value>
        public int TimerInterval
        {
            get { return _TimerInterval; }
            set { _TimerInterval = value; }
        }

        public abstract string AgentTypeName { get; }


        private bool _RecievedStopCommand;

        /// <summary>
        /// Gets a value indicating whether [recieved stop command].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [recieved stop command]; otherwise, <c>false</c>.
        /// </value>
        protected bool RecievedStopCommand
        {
            get { return _RecievedStopCommand; }
        }

        private bool _IsDoingAction = false;

        /// <summary>
        /// Gets a value indicating whether [is doing action].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is doing action]; otherwise, <c>false</c>.
        /// </value>
        public bool IsDoingAction
        {
            get { return _IsDoingAction; }
        }
        #endregion

        #region Constructor Deconstructor

        protected AbstractAgent()
        {
            threadWorker = new BackgroundWorker();
            threadWorker.WorkerSupportsCancellation = true;
            threadWorker.DoWork += new DoWorkEventHandler(threadWorker_DoWork);
            threadWorker.Disposed += new EventHandler(threadWorker_Disposed);
        }

        void threadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Utils.LogAgentData("Agent started", this.AgentTypeName);

            while (true)
            {
                //Utils.LogAgentData("Agent DoAction", this.AgentTypeName);
                _IsDoingAction = true;
                try
                {
                    DoAction(); // first action before timer
                }
                catch (Exception ex)
                {
                    FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, null);
                }
                _IsDoingAction = false;
                System.Threading.Thread.Sleep(this.TimerInterval);
                if (e.Cancel)
                {
                    //Utils.LogAgentData("Thread Canceled", this.AgentTypeName);
                    break;
                }
            }

            //GC.KeepAlive(agentTimer); // to keep timer alive from Garbage Collector

        }

        void threadWorker_Disposed(object sender, EventArgs e)
        {
            //if (agentTimer != null)
            //{
            //    agentTimer.Stop();
            //    agentTimer.Dispose();
            //}
            //Utils.LogAgentData("Agent Thread disposed", this.AgentTypeName);
        }



        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't 
        // own unmanaged resources itself, but leave the other methods
        // exactly as they are. 
        ~AbstractAgent()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }


        // Code Copied from http://msdn.microsoft.com/query/dev12.query?appId=Dev12IDEF1&l=EN-US&k=k(CA1063);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5.1)&rd=true

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (threadWorker != null)
                {
                    threadWorker.Dispose();
                    threadWorker = null;
                }
            }

        }



        #endregion


        /// <summary>
        /// Starts the agent.
        /// </summary>
        public void StartAgent()
        {
            threadWorker.RunWorkerAsync();
        }



        /// <summary>
        /// Stops the agent.
        /// </summary>
        public void StopAgent()
        {
            threadWorker.CancelAsync();
            _RecievedStopCommand = true;
            //agentTimer.Stop();
            //Utils.LogAgentData("Agent Stopped", this.AgentTypeName);
        }


        /// <summary>
        /// Does the action.
        /// </summary>
        public abstract void DoAction();



        


    }

}
