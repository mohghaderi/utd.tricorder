using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.BusinessRule
{
    public class PaymentBR : BusinessRuleBase<Payment, vPayment>
    {
  #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        public void CreatePaymentForVisit(vVisit visit)
        {
            if (visit == null)
                throw new BRException(StringMsgs.BusinessErrors.RecordIsNotAvailable);

            // We may pay for the visit before its completion
            //if (visit.VisitStatusID != (int)EntityEnums.VisitStatusEnum.EndSuccess)
            //    throw new BRException(BusinessErrorStrings.Payment.VisitStatus_Equals_EndSuccess);

            // Only one payment is allowed per visit
            //FilterExpression filter = new FilterExpression();
            //filter.AddFilter(new Filter(vPayment.ColumnNames.AppEntityID, (int) EntityEnums.PaymentEntityEnum.Visit));
            //filter.AddFilter(new Filter(vPayment.ColumnNames.AppEntityRecordIDValue, visit.VisitID));
            //if (GetCount(filter) > 0)
            //    throw new BRException(BusinessErrorStrings.Payment.VisitAlreadyHasAPaymentRecord);

            //if (visit.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.NotStarted)
            //    throw new BRException(BusinessErrorStrings.Payment.PaymentStatus_Equlas_NotStarted);
        }

        public void UpdatePayKey(vPayment payment, UserPaymentInfo senderPaymentInfo, UserPaymentInfo receiverPaymentInfo)
        {
            // check sender and receiver have payment information
            if (senderPaymentInfo == null)
                throw new BRException(string.Format(BusinessErrorStrings.Payment.PaymentInfoIsNotDefinedForUser_, ": " + payment.SenderFirstName + " " + payment.SenderLastName));
            if (receiverPaymentInfo == null)
                throw new BRException(string.Format(BusinessErrorStrings.Payment.PaymentInfoIsNotDefinedForUser_, ": " + payment.ReceiverFirstName + " " + payment.ReceiverLastName));

            // check sender has a valid email
            if (string.IsNullOrEmpty(senderPaymentInfo.UserPaymentInfoPayPalEmail) == true)
                throw new BRException(string.Format(BusinessErrorStrings.Payment.PayPalEmailAddressNotDefinedForUser_, ": " + payment.SenderFirstName + " " + payment.SenderLastName));

            // check that receiver has a valid paypal email
            if (string.IsNullOrEmpty(receiverPaymentInfo.UserPaymentInfoPayPalEmail) == true)
                throw new BRException(string.Format(BusinessErrorStrings.Payment.PayPalEmailAddressNotDefinedForUser_, ": " + payment.ReceiverFirstName + " " + payment.ReceiverLastName));

            // Check payment status is in Pending situation
            if (payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.NotStarted 
                && payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.PendingWithoutPayKey
                && payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.PendingWithPayKey)
            {
                throw new BRException(BusinessErrorStrings.Payment.PaymentStatusIsNotPending);
            }
        }

        public void UpdatePaykeyInDatabase(string payKey)
        {
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            if (CheckUtils.CheckStringShouldNotBeNullOrEmpty(vPayment.ColumnNames.PayKey, payKey, errors) == false)
                throw new BRException(errors);

            // check if pay key is not duplicated in database
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vPayment.ColumnNames.PaymentStatusID, (int)EntityEnums.PaymentStatusEnum.PendingWithPayKey));
            if (CheckUtils.CheckDuplicateValueNotToBeExists(vPayment.ColumnNames.PayKey, payKey, null, errors, null, true, null) == false)
                throw new BRException(errors[0].ErrorDescription);
        }


        //public void PaymentReceived(List<Payment> payments, string payKey)
        //{
        //    if (payments.Count == 0)
        //    {
        //        FWUtils.ExpLogUtils.ExceptionLogger.LogError(new Exception("Payment.PaymentReceived: PayKey " + payKey + " not found for user " + FWUtils.SecurityUtils.GetCurrentUserIDString()), "");
        //        throw new BRException(BusinessErrorStrings.Payment.PayKeyNotFound);
        //    }
        //    else if (payments.Count > 1)
        //        throw new ImpossibleExecutionException("There are more than one payment record for a payKey: " + payKey); // if we have more than one payment record for a paykey there should be a problem in our system
        //    else
        //    {
        //        foreach (Payment payment in payments)
        //        {
        //            if (payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.PendingWithPayKey)
        //            {
        //                FWUtils.ExpLogUtils.ExceptionLogger.LogError(new Exception("Payment.PaymentReceived: PaymentIsNotPending " + payKey + " not found for user " + FWUtils.SecurityUtils.GetCurrentUserIDString()), "");
        //                throw new BRException(BusinessErrorStrings.Payment.PaymentIsNotPending);
        //            }
        //        }
        //    }
                
        //}


        /// <summary>
        /// Completes the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <exception cref="BRException"></exception>
        public void CompletePayment(Payment payment)
        {
            if (payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.PendingWithPayKey)
            {
                throw new BRException(BusinessErrorStrings.Payment.PaymentIsNotPending);
            }
        }


        /// <summary>
        /// Refunds the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <param name="receiverPaymentInfo">The receiver payment information.</param>
        /// <exception cref="BRException">
        /// </exception>
        public void RefundPayment(vPayment payment, UserPaymentInfo receiverPaymentInfo)
        {
            Check.Require(payment != null);

            if (payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.Done)
                throw new BRException(BusinessErrorStrings.Payment.OnlyCompletedPaymentsCanBeRefunded);

            // check sender and receiver have payment information
            if (receiverPaymentInfo == null)
                throw new BRException(string.Format(BusinessErrorStrings.Payment.PaymentInfoIsNotDefinedForUser_, " " + payment.ReceiverUserID + ": " + payment.ReceiverFirstName + " " + payment.ReceiverLastName));

            // check that receiver has a valid paypal email
            if (string.IsNullOrEmpty(receiverPaymentInfo.UserPaymentInfoPayPalEmail) == true)
                throw new BRException(string.Format(BusinessErrorStrings.Payment.PayPalEmailAddressNotDefinedForUser_, " " + payment.ReceiverUserID + ": " + payment.ReceiverFirstName + " " + payment.ReceiverLastName));

        }


        public void Cancel(vPayment payment)
        {
            Check.Require(payment != null);

            if (payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.NotStarted
                && payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.PendingWithoutPayKey
                && payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.PendingWithPayKey)
                throw new BRException(BusinessErrorStrings.Payment.OnlyIncompletedPaymentsCanBeCanceled);
        }

        /// <summary>
        /// Check business rules for updating payment information from payment website
        /// </summary>
        /// <param name="payment">payment data</param>
        public void UpdatePaymentInfoFromPaymentWebsite(Payment payment)
        {
            Check.Require(payment != null);

            if (payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.NotStarted
                && payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.PendingWithoutPayKey
                && payment.PaymentStatusID != (int)EntityEnums.PaymentStatusEnum.PendingWithPayKey)
            {
                throw new BRException(BusinessErrorStrings.Payment.ThisPaymentIsNotPendingToBeUpdated);
            }
        }

        #endregion

    }
}

