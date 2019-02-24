using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IFeedbackService : IServiceBaseT<Feedback, vFeedback>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        void NewFeedback(NewFeedbackSP p);

		#endregion //Generator-Safe Area
    }
}

