using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common;

namespace Framework.Business
{
    /// <summary>
    /// Business rule interface for the typed classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBusinessRuleBase<T, V> : IEntityCRUDFunctions<T, V> , IBusinessRuleBase
    {
        void CheckRulesT(T entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors);
    }
}
