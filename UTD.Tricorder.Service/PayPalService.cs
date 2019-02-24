using Framework.Common;
using PayPal;
using PayPal.AdaptivePayments;
using PayPal.AdaptivePayments.Model;
using PaypalApi;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.Service
{
    public class PayPalService
    {
        /// <summary>
        /// Creating a request to get PayKey from PayPal
        /// </summary>
        /// <param name="receiver1amount">amount that receiver1 receives</param>
        /// <param name="receiver2amount">amount that receiver2 receives</param>
        /// <param name="receiver1email">email of receiver1 (max length 127 characters)</param>
        /// <param name="receiver2email">email of receiver2 (max length 127 characters)</param>
        /// <param name="senderEmail">Sender's email address. Maximum length: 127 characters</param>
        /// <returns></returns>
        public string GetPayKey(VisitParallelPaymentParameters p)
        {
            var payRequest = CreateVisitPaymentRequest(p);
            var payResponse = CallPaypalPay(payRequest);
            return payResponse.payKey;
        }



        /// <summary>
        /// Creates paypal payment and its key
        /// It uses Pay action as of now to make do the payment
        /// </summary>
        /// <returns></returns>
        private PayResponse CallPaypalPay(PayRequest request)
        {

            Dictionary<string, string> configurationMap = FWUtils.ConfigUtils.GetAppSettings().Paypal.GetAcctAndConfig();
            AdaptivePaymentsService service = new AdaptivePaymentsService(configurationMap);

            // executing adaptive payment pay service
            PayResponse response = service.Pay(request);

            string ack = response.responseEnvelope.ack.ToString().Trim().ToUpper();

            // if no error happened
            if (!ack.Equals(AckCode.FAILURE.ToString()) &&
                !ack.Equals(AckCode.FAILUREWITHWARNING.ToString()))
            {
                //PaymentExecStatusSEnum execStatus = new PaymentExecStatusSEnum(response.paymentExecStatus);
                
                return response;
            }
            else
            {
                throw new UserException(GetPayPalErrorString(response.error));
            }

        }


        private string GetPayPalErrorString(List<ErrorData> errorList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ErrorData error in errorList)
            {
                sb.AppendLine(error.message);
            }
            return sb.ToString();
        }


        /// <summary>
        /// Creating a request to get PayKey from PayPal
        /// </summary>
        /// <param name="receiver1amount">amount that receiver1 receives</param>
        /// <param name="receiver2amount">amount that receiver2 receives</param>
        /// <param name="receiver1email">email of receiver1 (max length 127 characters)</param>
        /// <param name="receiver2email">email of receiver2 (max length 127 characters)</param>
        /// <param name="senderEmail">Sender's email address. Maximum length: 127 characters</param>
        /// <returns></returns>
        private PayRequest CreateVisitPaymentRequest(VisitParallelPaymentParameters p)
        {
            Check.Require(string.IsNullOrEmpty(p.receiver1email) == false);
            Check.Require(string.IsNullOrEmpty(p.receiver2email) == false);
            //Check.Require(string.IsNullOrEmpty(p.senderEmail) == false);
            Check.Require(p.receiver1email.Length <= 127);
            Check.Require(p.receiver2email.Length <= 127);
            if (string.IsNullOrEmpty(p.senderEmail) == false)
                Check.Require(p.senderEmail.Length <= 127);


            //// (Optional) Sender's email address. Maximum length: 127 characters
            ////TODO: See why it is optional. It should deduct from the sender only

            // URL to redirect the sender's browser to after canceling the approval
            // for a payment; it is always required but only used for payments that
            // require approval (explicit payments)
            string cancelUrl = FWUtils.ConfigUtils.GetAppSettings().Paypal.GetCancelUrlPaymentID(p.paymentId);
            
            // The code for the currency in which the payment is made; you can
            // specify only one currency, regardless of the number of receivers
            string currencyCode = p.currencyCode;
            // URL to redirect the sender's browser to after the sender has logged
            // into PayPal and approved a payment; it is always required but only
            // used if a payment requires explicit approval
            string returnURL = FWUtils.ConfigUtils.GetAppSettings().Paypal.GetReturnUrlByPaymentID(p.paymentId);

            // (Optional) The URL to which you want all IPN messages for this
            // payment to be sent. Maximum length: 1024 characters
            string ipnNotificationURL = FWUtils.ConfigUtils.GetAppSettings().Paypal.GetIpnNotificationUrl(p.paymentId); // MAX 1024


            string errorLanguage = p.errorLanguage;


            // The action for this request. Possible values are: PAY ï؟½ Use this
            // option if you are not using the Pay request in combination with
            // ExecutePayment. CREATE ï؟½ Use this option to set up the payment
            // instructions with SetPaymentOptions and then execute the payment at a
            // later time with the ExecutePayment. PAY_PRIMARY ï؟½ For chained
            // payments only, specify this value to delay payments to the secondary
            // receivers; only the payment to the primary receiver is processed.
            AdaptivePaymentActionSEnum action = AdaptivePaymentActionSEnum.PAY;


            System.Collections.Specialized.NameValueCollection parameters = new System.Collections.Specialized.NameValueCollection();

            ReceiverList receiverList = new ReceiverList();
            receiverList.receiver = new List<Receiver>();

            PayRequest request = new PayRequest();
            RequestEnvelope requestEnvelope = new RequestEnvelope(errorLanguage);
            request.requestEnvelope = requestEnvelope;

            AddReceiver(p.receiver1amount, p.receiver1email, receiverList);
            AddReceiver(p.receiver2amount, p.receiver2email, receiverList);

            ReceiverList receiverlst = new ReceiverList(receiverList.receiver);
            request.receiverList = receiverlst;

            request.senderEmail = p.senderEmail;
            request.actionType = action.getFnName();
            request.cancelUrl = cancelUrl;
            request.currencyCode = currencyCode;
            request.returnUrl = returnURL;
            request.requestEnvelope = requestEnvelope;
            request.ipnNotificationUrl = ipnNotificationURL;

            return request;
        }

        private void AddReceiver(decimal amount, string email, ReceiverList receiverList)
        {
            Check.Require(email.Length < 127);

            Receiver receiver = new Receiver();
            // (Required) Amount to be paid to the receiver
            receiver.amount = amount;
            // Receiver's email address. This address can be unregistered with
            // paypal.com. If so, a receiver cannot claim the payment until a PayPal
            // account is linked to the email address. The PayRequest must pass
            // either an email address or a phone number. Maximum length: 127 characters
            receiver.email = email;
            receiverList.receiver.Add(receiver);
        }

        /// <summary>
        /// Gets execution status of a payment by PayKey
        /// </summary>
        /// <param name="payKey"></param>
        /// <returns></returns>
        public PaymentExecStatusSEnum GetPaymentExecutionStatus(string payKey)
        {
            Check.Require(string.IsNullOrEmpty(payKey) == false, "PayPalService.GetPaymentStatus: PayKey is required.");

            PaymentDetailsRequest request = new PaymentDetailsRequest(new RequestEnvelope("en_US"));
            request.payKey = payKey;

            Dictionary<string, string> configurationMap = FWUtils.ConfigUtils.GetAppSettings().Paypal.GetAcctAndConfig();
            AdaptivePaymentsService service = new AdaptivePaymentsService(configurationMap);
            PaymentDetailsResponse response = service.PaymentDetails(request);

            string ack = response.responseEnvelope.ack.ToString().Trim().ToUpper();

            // if no error happened
            if (!ack.Equals(AckCode.FAILURE.ToString()) &&
                !ack.Equals(AckCode.FAILUREWITHWARNING.ToString()))
            {
                PaymentExecStatusSEnum execStatus = new PaymentExecStatusSEnum(response.status);
                return execStatus;
            }
            else
            {
                throw new UserException(GetPayPalErrorString(response.error));
            }
        }


        /// <summary>
        /// IPN messages received.
        /// This is only for handling special cases like sending email or
        /// automating a workflow. It is not for simple transactions
        /// </summary>
        public void HandleIPNMessage(byte[] parameters)
        {

            if (parameters != null && parameters.Length > 0)
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer at 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = FWUtils.ConfigUtils.GetAppSettings().Paypal.GetConfig();

                IPNMessage ipn = new IPNMessage(configurationMap, parameters);
                bool isIpnValidated = ipn.Validate();
                string transactionType = ipn.TransactionType;
                NameValueCollection map = ipn.IpnMap;

                string logMsg = "Map:" + map + "\r\n"
                               + "TranType:" + transactionType + "\r\n"
                               + "IsValidated:" + isIpnValidated;

                long? userId = null;
                if (FWUtils.SecurityUtils.IsUserAuthenticated())
                    userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
                FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.PayPal_IPNURL, UserID = userId, ExtraString1 = logMsg });
            }
        }



        /// <summary>
        /// Refunds the payment.
        /// </summary>
        /// <param name="p">The parameters.</param>
        /// <exception cref="UserException">If refund was not suceessful, it throws an exception for the user</exception>
        public void RefundPayment(RefundParameters p)
        {
            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            RefundRequest request = new RefundRequest(new RequestEnvelope("en_US"));
            request.payKey = p.payKey;
            request.currencyCode = p.currencyCode;

            List<Receiver> receivers = new List<Receiver>();
            request.receiverList = new ReceiverList(receivers);
            if (p.receiver1amount != 0)
                AddReceiver(p.receiver1amount, p.receiver1email, request.receiverList);
            if (p.receiver2amount != 0)
                AddReceiver(p.receiver2amount, p.receiver2email, request.receiverList);

            AdaptivePaymentsService service = null;
            RefundResponse response = null;

            // Configuration map containing signature credentials and other required configuration.
            // For a full list of configuration parameters refer in wiki page 
            // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
            Dictionary<string, string> configurationMap = FWUtils.ConfigUtils.GetAppSettings().Paypal.GetAcctAndConfig();

            // Creating service wrapper object to make an API call and loading
            // configuration map for your credentials and endpoint
            service = new AdaptivePaymentsService(configurationMap);
            response = service.Refund(request);

            string ack = response.responseEnvelope.ack.ToString().Trim().ToUpper();

            // if no error happened
            if (!ack.Equals(AckCode.FAILURE.ToString()) &&
                !ack.Equals(AckCode.FAILUREWITHWARNING.ToString()))
            {
                StringBuilder sbErrors = new StringBuilder();
                bool hasError = false;
                foreach (RefundInfo refund in response.refundInfoList.refundInfo)
                {
                    RefundStatusSEnum refundStatus = new RefundStatusSEnum(refund.refundStatus);
                    if (refundStatus != RefundStatusSEnum.REFUNDED &&
                        refundStatus != RefundStatusSEnum.REFUNDED_PENDING)
                    {
                        sbErrors.Append(refundStatus.GetUserFriendlyMessage());
                        hasError = true;

                        if (refundStatus == RefundStatusSEnum.NO_API_ACCESS_TO_RECEIVER)
                        {
                            EmailPersonRefundError(refund.receiver.email, refundStatus);
                        }
                    }
                }
                if (hasError)
                    throw new UserException(sbErrors.ToString());
            }
            else
            {
                throw new UserException(GetPayPalErrorString(response.error));
            }
        
        }

        private void EmailPersonRefundError(string personEmail, RefundStatusSEnum refundStatus)
        {
            // TODO: Email person about the happened refund error

        }



    }
}
