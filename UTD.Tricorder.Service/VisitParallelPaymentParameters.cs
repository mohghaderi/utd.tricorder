using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Service
{
    public class VisitParallelPaymentParameters
    {
        public string errorLanguage = "en_US";
        public string currencyCode = "USD";
        public long paymentId;
        public decimal receiver1amount;
        public decimal receiver2amount;
        public string receiver1email;
        public string receiver2email;
        public string senderEmail;
    }
}
