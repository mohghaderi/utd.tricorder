using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.SP
{
    public struct PaymentGetPaymentUrlSP
    {
        public long PaymentID;
        public bool IsMobileClient;
    }

    public struct PaymentCreatePaymentForVisitSP
    {
        /// <summary>
        /// Visit idntifier
        /// </summary>
        public long VisitID;
        /// <summary>
        /// It is Total amount that the user needs to pay for it. (It is not doctor's share only)
        /// </summary>
        public decimal Amount;
        /// <summary>
        /// Amount that we charge for each transaction
        /// </summary>
        public decimal ServiceChargeAmount;
    }


}
