using Framework.Common;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UTD.Tricorder.Website.Base.SignalR
{
    public class ErrorHandlingPipelineModule : HubPipelineModule
    {
        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
        {
            FWUtils.ExpLogUtils.ExceptionLogger.LogError(exceptionContext.Error, null);
            base.OnIncomingError(exceptionContext, invokerContext);
        }
    }
}