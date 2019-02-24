using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Website.Base;

namespace UTD.Tricorder.Website.Controllers
{
    public class PayPalController : Controller
    {
        //
        // GET: /PayPal/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cancel(string PaymentID)
        {
            long paymentId = -1;
            if (PaymentID != null)
            {
                string paymentIdString = PaymentID;
                long.TryParse(paymentIdString, out paymentId);
            }
            long? userId = null;
            if (FWUtils.SecurityUtils.IsUserAuthenticated())
                userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();

            // NOTE: it is no longer required because we check payment status right before generating payment url
            // since request is canceled by paypal, it may because of expiration of keys
            // It may also because of completion of the transaction. We need to update the data from its paypal information
            IPaymentService paymentService = (IPaymentService)EntityFactory.GetEntityServiceByName(vPayment.EntityName, "");
            paymentService.SyncPaymentInfoFromPaymentWebsiteByID(paymentId);

            FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.PayPal_CancelURL, UserID = userId, ExtraBigInt = paymentId });

            return UIUtils.GetRedirectResult("Dashboard#/Payment-SentGrid");
        }

        public ActionResult Return(string PaymentID)
        {
            long paymentId = -1;
            if (PaymentID != null)
            {
                string paymentIdString = PaymentID;
                long.TryParse(paymentIdString, out paymentId);
            }
            long? userId = null;
            if (FWUtils.SecurityUtils.IsUserAuthenticated())
                userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();

            FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.PayPal_ReturnURL, UserID = userId, ExtraBigInt = paymentId });

            if (paymentId == -1)
                throw new ImpossibleExecutionException("Paypal return handler PaymentId should not be null");

            IPaymentService paymentService = (IPaymentService)EntityFactory.GetEntityServiceByName(vPayment.EntityName, "");
            paymentService.SyncPaymentInfoFromPaymentWebsiteByID(paymentId);

            return UIUtils.GetRedirectResult("Dashboard#/Payment-SentGrid");
        }




	}
}