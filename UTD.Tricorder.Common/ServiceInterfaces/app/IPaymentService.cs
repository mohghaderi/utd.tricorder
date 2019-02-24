using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IPaymentService : IServiceBaseT<Payment, vPayment>
    {
  #region Generator-Safe Area
        //Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Precondition: 
        /// Have Visit record in database with PaymentStatusID = NotStarted 
        /// Steps:
        /// 1- Select a visit record (visitID) and enter amount and description required
        /// 2- CreatePaymentForVisit (PaymentStatusID = PendingWithoutPayKey)
        /// 3- UpdatePayPalKey (payment records in database PaymentStatusID = PendingWithPayKey)
        /// 4- PaymentReceived (PaymentStatusID = Done)
        /// </summary>
        Payment CreatePaymentForVisit(PaymentCreatePaymentForVisitSP p);


        /// <summary>
        /// Gets PayKey from PayPal and updates in the database
        /// </summary>
        /// <param name="paymentId">Payment indentifier</param>
        Payment UpdatePayPalKey(long paymentId);


        /// <summary>
        /// Updates the payment status if completed.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns></returns>
        Payment CompletePayment(long paymentId);


        /// <summary>
        /// Refunds a payment that is already done
        /// </summary>
        /// <param name="paymentID">Payment identifier</param>
        void RefundPayment(long paymentID);


        /// <summary>
        /// Gets payment url for a payment
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        string GetPaymentUrl(PaymentGetPaymentUrlSP p);


        ///// <summary>
        ///// Gets the latest information about the payment from its related website (i.e. PayPal)
        ///// and updates data based on that
        ///// </summary>
        ///// <param name="paymentId">paymentId</param>
        void SyncPaymentInfoFromPaymentWebsiteByID(long paymentId);

        #endregion
    }
}

