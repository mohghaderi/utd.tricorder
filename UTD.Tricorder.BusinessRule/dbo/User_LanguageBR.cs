using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;

namespace UTD.Tricorder.BusinessRule
{
    public class User_LanguageBR : BusinessRuleBase<User_Language, vUser_Language>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            base.CheckRules(entitySet, fnName, errors);

            // check to make sure that no duplicate item is exists in the database
            CheckUtils.CheckDuplicateTwoKeyNotToBeExists(entitySet,
                vUser_Language.ColumnNames.LanguageID,
                vUser_Language.ColumnNames.UserID,
                vUser_Language.ColumnNames.User_LanguageID,
                errors,
                null,
                fnName == RuleFunctionSEnum.Insert,
                null);
        }
		
		

		#endregion

    }
}

