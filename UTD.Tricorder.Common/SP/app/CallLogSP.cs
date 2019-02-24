using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.SP
{
    /// <summary>
    /// Doctor calls patient for a visit
    /// </summary>
    public struct CallLogVisitCallPatientSP
    {
        public long VisitID;
    }

    /// <summary>
    /// Response parameters for visit call
    /// </summary>
    public struct CallLogCallPatientResponseSP
    {
        public long CallLogID;
        public string RecieverUserProfilePictureUrl;
        public long ReceiverUserID;
        public string ReceiverFullName;

        public string RecieverProfilePictureUrl { get; set; }

        public string RecieverProfilePicUrl { get; set; }

        public string ReceiverProfilePicUrl { get; set; }
    }


    /// <summary>
    /// Ends a call
    /// </summary>
    public struct CallLogEndCallSP
    {
        public long CallLogID;
    }

    /// <summary>
    /// Canel call parameters
    /// </summary>
    public struct CallLogCancelCallSP
    {
        public long CallLogID;
    }


    /// <summary>
    /// answers a call
    /// </summary>
    public struct CallLogAnswerCallSP
    {
        public long CallLogID;
    }

    /// <summary>
    /// Declines a call
    /// </summary>
    public struct CallLogDeclineCallSP
    {
        public long CallLogID;
    }



}
