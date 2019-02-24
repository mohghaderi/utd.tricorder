using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.SP
{
    public struct NewFeedbackSP
    {
        public string Title { get; set; }
        public string CommentText { get; set; }
        public string ViewAddress { get; set; }
        public byte FeedbackTypeID { get; set; }
        public byte TicketPriorityID { get; set; }
        public byte? HappinessLevel { get; set; }
        public byte TicketSourceTypeID { get; set; }
        public int? SiteID { get; set; }
    }
}
