using Framework.Business;
using System;

namespace Framework.Common
{
    [Serializable]
    /// <summary>
    /// Business rule errors that needs to be reported to the user
    /// </summary>
    public class BRException : UserException
    {

        private BusinessRuleErrorList _RuleErrors;
        /// <summary>
        /// Gets or sets the rule errors.
        /// </summary>
        /// <value>
        /// The rule errors.
        /// </value>
        public BusinessRuleErrorList RuleErrors { get { return _RuleErrors; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="BRException" /> class.
        /// </summary>
        /// <param name="ruleErrors">The rule errors.</param>
        public BRException(BusinessRuleErrorList ruleErrors)
            : base(StringMsgs.Exceptions.GeneralBusinessRuleException)
        {
            _RuleErrors = ruleErrors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BRException" /> class.
        /// </summary>
        /// <param name="ruleErrors">The rule errors.</param>
        /// <param name="message">The message.</param>
        public BRException(BusinessRuleErrorList ruleErrors, string message)
            :base(message)
        {
            _RuleErrors = ruleErrors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BRException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public BRException(BusinessRuleError err)
            : base(err.ErrorDescription)
        {
            _RuleErrors = new BusinessRuleErrorList();
            _RuleErrors.Add(err);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BRException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public BRException(string msg)
            : base(msg)
        {
            _RuleErrors = new BusinessRuleErrorList();
        }

        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            base.GetObjectData(info, context);
            info.AddValue("RuleErrors", RuleErrors);
        }


        public override string ToString()
        {
            string msg = base.ToString();

            BusinessRuleErrorList errors = this.RuleErrors;
            foreach (BusinessRuleError err in errors)
            {
                msg += err.ColumnTitle + ":" + err.ErrorDescription + "\r\n";
            }

            return msg;
        }




    }
}
