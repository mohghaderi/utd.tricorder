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
    public class FeedbackService : ServiceBase<Feedback, vFeedback>, IFeedbackService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.


        public void NewFeedback(NewFeedbackSP p)
        {
            if (p.SiteID.HasValue == false)
                p.SiteID = FWUtils.SecurityUtils.GetCurrentSiteID();

            Feedback f = new Feedback()
            {
                Title = p.Title,
                CommentText = p.CommentText,
                ViewAddress = p.ViewAddress,
                FeedbackTypeID = p.FeedbackTypeID,
                VoteCount = 0,
                ChildCount = 0,
                TicketPriorityID = p.TicketPriorityID,
                TicketStatusID = (byte)EntityEnums.TicketStatusID.Open,
                TicketSourceTypeID = p.TicketSourceTypeID,
                HappinessLevel = p.HappinessLevel,
                SiteID = p.SiteID
            };

            Insert(f);

            try
            {
                NotificationSystem.NotificationSenderAgent
                    .emailNotificationSender.SendEmailMessage("\"Xecare feedback\" <feedback@xecare.com>", "mohghaderi@gmail.com", "New feedback - " + p.Title, p.CommentText, false);
            }
            catch (Exception ex)
            {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, null);
            }
        }
		

		#endregion //Generator-Safe Area

    }
}

