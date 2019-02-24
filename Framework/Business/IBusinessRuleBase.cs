using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common;

namespace Framework.Business
{
    /// <summary>
    /// Business rule interface for specific business rule functions
    /// </summary>
    public interface IBusinessRuleBase : IEntityCRUDFunctions , IInitializeByEntity
    {
        void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors);
    }



}
