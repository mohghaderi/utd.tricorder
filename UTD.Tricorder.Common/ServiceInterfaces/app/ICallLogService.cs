using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface ICallLogService : IServiceBaseT<CallLog, vCallLog>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        /// <summary>
        /// Sends call notification for the patient based on the visit information
        /// </summary>s
        /// <param name="p">parameters</param>
        CallLogCallPatientResponseSP VisitCallPatient(CallLogVisitCallPatientSP p);

        /// <summary>
        /// Ends a call
        /// </summary>
        /// <param name="CallLogId">The call log identifier.</param>
        void EndCall(CallLogEndCallSP p);



        /// <summary>
        /// Answers a call
        /// </summary>
        /// <param name="CallLogId">The call log identifier.</param>
        void AnswerCall(CallLogAnswerCallSP p);


        /// <summary>
        /// Declines a call
        /// </summary>
        /// <param name="p">Parameters</param>
        void DeclineCall(CallLogDeclineCallSP p);


        /// <summary>
        /// Ends a call
        /// </summary>
        /// <param name="CallLogId">The call log identifier.</param>
        void CancelCall(CallLogCancelCallSP p);

		#endregion
    }
}

