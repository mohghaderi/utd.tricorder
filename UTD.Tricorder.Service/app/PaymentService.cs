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
    public class PaymentService : ServiceBase<Payment, vPayment>, IPaymentService
    {
	
	
  #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        // Doctor selected a visit record, then CreatePaymentForVisit
        // Patient gets a notification to pay the amount
        // Patient selected payment method like Paypal (it uses UpdatePayPalKey to get Key from the bank)
        // Patient pays the money for the payment and 
        // 

        /// <summary>
        /// Precondition: 
        /// Have Visit record in database with PaymentStatusID = NotStarted 
        /// Steps:
        /// 1- Select a visit record (visitID) and enter amount and description required
        /// 2- CreatePaymentForVisit (PaymentStatusID = PendingWithoutPayKey)
        /// 3- UpdatePayPalKey (payment records in database PaymentStatusID = PendingWithPayKey)
        /// 4- PaymentReceived (PaymentStatusID = Done)
        /// </summary>
        public Payment CreatePaymentForVisit(PaymentCreatePaymentForVisitSP p)
        {
            PaymentBR biz = (PaymentBR)this.BusinessLogicObject;

            IVisitService visitService = (IVisitService)EntityFactory.GetEntityServiceByName(vVisit.EntityName, "");
            vVisit visit = (vVisit) visitService.GetByID(p.VisitID, new GetByIDParameters(GetSourceTypeEnum.View));
            Visit visitForUpdate = (Visit)visitService.GetByID(p.VisitID, new GetByIDParameters());

            biz.CreatePaymentForVisit(visit);


            Payment paymentForDoctor = new Payment();
            paymentForDoctor.SenderUserID = visit.PatientUserID;
            paymentForDoctor.ReceiverUserID = visit.DoctorID;
            paymentForDoctor.AppEntityID = (int) EntityEnums.PaymentEntityEnum.Visit;
            paymentForDoctor.PaymentStatusID = (int)EntityEnums.PaymentStatusEnum.PendingWithoutPayKey;
            paymentForDoctor.AppEntityRecordIDValue = visit.VisitID;
            paymentForDoctor.CreatedDateTime = DateTime.UtcNow;
            paymentForDoctor.CompletedDateTime = null;
            paymentForDoctor.PayKey = "";
            paymentForDoctor.Amount = p.Amount;
            paymentForDoctor.ServiceChargeAmount = p.ServiceChargeAmount;
            paymentForDoctor.PaymentMethodID = (int) EntityEnums.PaymentMethodEnum.Undefined;
            paymentForDoctor.Description = null;

            InsertParameters insertParameters = new InsertParameters();

            //visitForUpdate.PaymentStatusID = (int)EntityEnums.PaymentStatusEnum.PendingWithoutPayKey;
            DetailObjectInfo visitDetail = new DetailObjectInfo()
            {
                EntitySet = visitForUpdate,
                EntityName = vVisit.EntityName,
                AdditionalDataKey = "",
                FnName = RuleFunctionSEnum.Update,
                FKColumnNameForAutoSet = ""
            };
            insertParameters.DetailEntityObjects.Add(visitDetail);


            // At this time, we just have one record for each visit.
            // We don't keep data for each receiver. So, it simplifies the problem.
            // ServiceChargeAmount is to show how much the user paid to us

            //Payment paymentForProvider = new Payment();
            //paymentForProvider.SenderUserID = visit.PatientUserID;
            //paymentForProvider.ReceiverUserID = visit.DoctorUserID;
            //paymentForProvider.PaymentEntityID = (int)EntityEnums.PaymentEntityEnum.Visit;
            //paymentForProvider.RelatedEntityRecordID = visit.VisitID;
            //paymentForProvider.CreatedDateTime = DateTime.UtcNow;
            //paymentForProvider.CompletedDateTime = null;
            //paymentForProvider.PayKey = "";
            //paymentForProvider.Amount = amount;
            //paymentForProvider.Description = null;

            //DetailObjectInfo companyPayment = new DetailObjectInfo() { 
            //    EntitySet = paymentForProvider, 
            //    EntityName = Payment.EntityName, 
            //    AdditionalDataKey = this.AdditionalDataKey, 
            //    FnName = RuleFunctionSEnum.Insert, 
            //    FKColumnNameForAutoSet = "" };

            //insertParameters.DetailEntityObjects.Add(companyPayment);


            Insert(paymentForDoctor, insertParameters);
            return paymentForDoctor;
        }


        /// <summary>
        /// Gets PayKey from PayPal and updates in the database
        /// </summary>
        /// <param name="paymentId">Payment indentifier</param>
        public Payment UpdatePayPalKey(long paymentId)
        {
            vPayment payment = (vPayment)GetByID(paymentId, new GetByIDParameters(GetSourceTypeEnum.View));

            IUserPaymentInfoService service =
                (IUserPaymentInfoService)EntityFactory.GetEntityServiceByName(vUserPaymentInfo.EntityName, "");
            
            UserPaymentInfo senderPaymentInfo = (UserPaymentInfo) service.GetByID(payment.SenderUserID, new GetByIDParameters());
            UserPaymentInfo receiverPaymentInfo = (UserPaymentInfo) service.GetByID(payment.ReceiverUserID, new GetByIDParameters());

            // Checking the business rules first
            PaymentBR biz = (PaymentBR)this.BusinessLogicObject;
            biz.UpdatePayKey(payment, senderPaymentInfo, receiverPaymentInfo);

            VisitParallelPaymentParameters p = new VisitParallelPaymentParameters();
            p.paymentId = paymentId;
            p.receiver1amount = payment.Amount - payment.ServiceChargeAmount;
            p.receiver2amount = payment.ServiceChargeAmount;
            p.receiver1email = receiverPaymentInfo.UserPaymentInfoPayPalEmail;
            p.receiver2email = FWUtils.ConfigUtils.GetAppSettings().Paypal.MainAccount;

            // DEVELOPER NOTE: PayPal Embedded Payment has a bug; it returns an error Payment can't be completed. This feature is currently unavailable.
            // In order to fix the bug, sender email should not be specified. In addition, not specifying sender email allows Guest Payment (without having a PayPal account)
            // Read more here: http://stackoverflow.com/questions/12666184/embedded-payments-and-this-function-is-temporarily-unavailable-error
            //p.senderEmail = senderPaymentInfo.UserPaymentInfoPayPalEmail;

            PayPalService payPal = new PayPalService();
            string payKey = payPal.GetPayKey(p);

            // logging the details
            long? userId = null;
            if (FWUtils.SecurityUtils.IsUserAuthenticated())
                userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            string logString = "" + p.senderEmail + "\t" + p.receiver1email + "\t" + p.receiver1amount + "\t" + p.receiver2amount;
            FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.PayPal_UpdatePayKey, UserID = userId, ExtraBigInt = paymentId, ExtraString1 = payKey, ExtraString2 = logString });

            return UpdatePaykeyInDatabase(payment.PaymentID, payKey);
        }


        /// <summary>
        /// Updates the paykey in database.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <param name="payKey">The pay key.</param>
        private Payment UpdatePaykeyInDatabase(long paymentId, string payKey)
        {
            Payment payment = (Payment)GetByID(paymentId, new GetByIDParameters());
            PaymentBR biz = (PaymentBR)this.BusinessLogicObject;

            // Checking if PayKey is valid (it is not duplicated or it has the defined format)
            biz.UpdatePaykeyInDatabase(payKey);

            payment.PayKey = payKey;
            payment.PaymentStatusID = (int)EntityEnums.PaymentStatusEnum.PendingWithPayKey;

            base.Update(payment, new UpdateParameters());
            return payment;
        }


        ///// <summary>
        ///// Updates the payment information and mark it as done
        ///// </summary>
        ///// <param name="payKey">PayKey of the received payment</param>
        ///// <returns></returns>
        //private Payment CompletePaymentInDatabaseByPayKey(string payKey)
        //{
        //    PaymentBR biz = (PaymentBR)this.BusinessLogicObject;

        //    FilterExpression filter = new FilterExpression(new Filter(Payment.ColumnNames.PayKey, payKey));
        //    filter.AddFilter(new Filter(Payment.ColumnNames.PaymentStatusID, (int)EntityEnums.PaymentStatusEnum.PendingWithPayKey));
        //    List<Payment> paymentsList = (List<Payment>) GetByFilter(new GetByFilterParameters(this.Entity, filter, new SortExpression(),0, 1000, null, GetSourceTypeEnum.Table));
            
        //    biz.PaymentReceived(paymentsList, payKey);// checking business rules

        //    return CompletePaymentInDatabase(paymentsList[0]);

        //    //UpdateParameters updateParameters = new UpdateParameters();
            
        //    //for(int i = 0; i < paymentsList.Count; i++)
        //    //{
        //    //    var payment = paymentsList[i];

        //    //    payment.PaymentStatusID = (int) EntityEnums.PaymentStatusEnum.Done;
        //    //    payment.CompletedDateTime = DateTime.UtcNow;

        //    //    if (i != 0) // the other object should be changed separately to come to the transaction
        //    //    {
        //    //        parameters.DetailEntityObjects.Add(new DetailObjectInfo()
        //    //        {
        //    //            EntityName = Payment.EntityName,
        //    //            AdditionalDataKey = "",
        //    //            EntitySet = payment,
        //    //            FKColumnNameForAutoSet = "",
        //    //            FnName = RuleFunctionSEnum.Update
        //    //        });
        //    //    }
        //    //}

        //    //Update(paymentsList[0], updateParameters);
        //    //return paymentsList[0];
        //}

        private Payment CompletePaymentInDatabase(Payment payment)
        {
            UpdateParameters updateParameters = new UpdateParameters();

            payment.PaymentStatusID = (int)EntityEnums.PaymentStatusEnum.Done;
            payment.CompletedDateTime = DateTime.UtcNow;

            Update(payment, updateParameters);
            return payment;
        }

        /// <summary>
        /// Updates the payment status if completed.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns>if it completed then the payment object</returns>
        public Payment CompletePayment(long paymentId)
        {
            Payment payment = (Payment)GetByID(paymentId, new GetByIDParameters());
            PayPalService paypalService = new PayPalService();
            var executionStatus = paypalService.GetPaymentExecutionStatus(payment.PayKey);
            if (executionStatus == PaypalApi.PaymentExecStatusSEnum.COMPLETED)
            {
                // logging the details
                long? userId = null;
                if (FWUtils.SecurityUtils.IsUserAuthenticated())
                    userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
                FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.PayPal_CompletePayment, UserID = userId, ExtraBigInt = paymentId });

                return CompletePaymentInDatabase(payment);
            }
            throw new BRException(BusinessErrorStrings.Payment.PaymentIsNotCompletedInPayPal);
        }

        /// <summary>
        /// Refunds the payment.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        public void RefundPayment(long paymentId)
        {
            PaymentBR biz = (PaymentBR)this.BusinessLogicObject;
            vPayment payment = (vPayment)GetByID(paymentId, new GetByIDParameters(GetSourceTypeEnum.View));

            IUserPaymentInfoService paymentInfoService =
                (IUserPaymentInfoService)EntityFactory.GetEntityServiceByName(vUserPaymentInfo.EntityName, "");
            
            UserPaymentInfo receiverPaymentInfo = (UserPaymentInfo) paymentInfoService.GetByID(payment.ReceiverUserID, new GetByIDParameters());
            biz.RefundPayment(payment, receiverPaymentInfo);

            PayPalService paypalService = new PayPalService();
            var executionStatus = paypalService.GetPaymentExecutionStatus(payment.PayKey);

            if (executionStatus == PaypalApi.PaymentExecStatusSEnum.COMPLETED) {
                // logging the details
                long? userId = null;
                if (FWUtils.SecurityUtils.IsUserAuthenticated())
                    userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
                FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.PayPal_Refund, UserID = userId, ExtraBigInt = paymentId });

                RefundParameters p = new RefundParameters();
                p.payKey = payment.PayKey;
                p.receiver1amount = payment.Amount - payment.ServiceChargeAmount;
                p.receiver2amount = payment.ServiceChargeAmount;
                p.receiver1email = receiverPaymentInfo.UserPaymentInfoPayPalEmail;
                p.receiver2email = FWUtils.ConfigUtils.GetAppSettings().Paypal.MainAccount;

                paypalService.RefundPayment(p);
                UpdateStatusPaymentInDatabase(paymentId, EntityEnums.PaymentStatusEnum.Refunded, true);
            }
        }


        protected override void onAfterGetByFilter(System.Collections.IList list, GetByFilterParameters parameters)
        {
            foreach (EntityObjectBase entityObj in list)
            {
                long senderId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vCallLog.ColumnNames.SenderUserID);
                var senderProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)senderId);
                FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "SenderProfilePicUrl", entityObj, senderProfileImageUrl);

                long receiverId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vCallLog.ColumnNames.ReceiverUserID);
                var receiverProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)receiverId);
                FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "ReceiverProfilePicUrl", entityObj, receiverProfileImageUrl);
            }
        }

        protected override void onAfterGetByID(object entityObj, object typedKeyObject, GetByIDParameters parameters)
        {
            if (entityObj != null)
            {
                long senderId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vCallLog.ColumnNames.SenderUserID);
                var senderProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)senderId);
                FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "SenderProfilePicUrl", entityObj, senderProfileImageUrl);

                long receiverId = (long)FWUtils.EntityUtils.GetObjectFieldValue(entityObj, vCallLog.ColumnNames.ReceiverUserID);
                var receiverProfileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)receiverId);
                FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "ReceiverProfilePicUrl", entityObj, receiverProfileImageUrl);
            }
        }


        public void Cancel(long PaymentID)
        {
            PaymentBR biz = (PaymentBR)this.BusinessLogicObject;
            vPayment payment = (vPayment)GetByID(PaymentID, new GetByIDParameters(GetSourceTypeEnum.View));
            biz.Cancel(payment);

            UpdateStatusPaymentInDatabase(PaymentID, EntityEnums.PaymentStatusEnum.Cancelled, false);
        }


        private Payment UpdateStatusPaymentInDatabase(long paymentID, EntityEnums.PaymentStatusEnum newStatus, bool setCompletedDate)
        {
            Payment payment = (Payment)GetByID(paymentID, new GetByIDParameters());

            UpdateParameters updateParameters = new UpdateParameters();

            payment.PaymentStatusID = (int)newStatus;
            if (setCompletedDate)
                payment.CompletedDateTime = DateTime.UtcNow;

            Update(payment, updateParameters);
            return payment;
        }

        /// <summary>
        /// Gets payment url for a payment
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        public string GetPaymentUrl(PaymentGetPaymentUrlSP p)
        {
            Payment payment = (Payment)GetByID(p.PaymentID, new GetByIDParameters());

            if (payment != null) {
                payment = this.SyncPaymentInfoFromPaymentWebsite(payment);

                if (payment.PaymentStatusID == (int) EntityEnums.PaymentStatusEnum.PendingWithPayKey)
                    return FWUtils.ConfigUtils.GetAppSettings().Paypal.GetSenderRedirectUrlPayKey(payment.PayKey, p.IsMobileClient);
            }
            return "";
        }

        ///// <summary>
        ///// Gets the latest information about the payment from its related website (i.e. PayPal)
        ///// and updates data based on that
        ///// </summary>
        ///// <param name="paymentId">paymentId</param>
        public void SyncPaymentInfoFromPaymentWebsiteByID(long paymentId)
        {
            Payment payment = GetByIDT(paymentId);
            SyncPaymentInfoFromPaymentWebsite(payment);
        }

        /// <summary>
        /// Gets the latest information about the payment from its related website (i.e. PayPal)
        /// and updates data based on that
        /// </summary>
        /// <param name="paymentId">paymentId</param>
        public Payment SyncPaymentInfoFromPaymentWebsite(Payment payment)
        {
            //Payment payment = (Payment)GetByID(paymentId, new GetByIDParameters());
            PaymentBR biz = (PaymentBR)this.BusinessLogicObject;

            biz.UpdatePaymentInfoFromPaymentWebsite(payment);

            if (string.IsNullOrEmpty(payment.PayKey) == false)
            {
                PayPalService paypalService = new PayPalService();
                var executionStatus = paypalService.GetPaymentExecutionStatus(payment.PayKey);
                if (executionStatus == PaypalApi.PaymentExecStatusSEnum.COMPLETED)
                {
                    this.CompletePaymentInDatabase(payment);
                }
                else if (executionStatus == PaypalApi.PaymentExecStatusSEnum.EXPIRED || 
                    executionStatus == PaypalApi.PaymentExecStatusSEnum.ERROR || 
                    executionStatus == PaypalApi.PaymentExecStatusSEnum.REVERSALERROR ||
                    executionStatus == PaypalApi.PaymentExecStatusSEnum.INCOMPLETE)
                {
                    // if there was an error (like token expiration) just get a new key and try again
                    return this.UpdatePayPalKey(payment.PaymentID);
                }
            }
            else
            {
                return this.UpdatePayPalKey(payment.PaymentID);
            }

            return payment;
        }

        #endregion

    }
}

