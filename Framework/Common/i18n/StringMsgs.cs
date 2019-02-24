using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    public class StringMsgs
    {
        public class BusinessErrors
        {
            public const string ns = "FW.BusinessErrors" + ".";
            public static i18nText NotNull = i18nText.Create(ns + "NotNull", "Field {0} is required. Please enter a value for it.");
            public static i18nText StringNotNullOrEmpty = i18nText.Create(ns + "StringNotNullOrEmpty", "Field {0} is required. Please don't leave it blank.");
            public static i18nText StringLenBetweenMinMax = i18nText.Create(ns + "StringLenBetweenMinMax", "Field {0} should have at least {1} characters and at most {2} characters.");
            public static i18nText DuplicateValueExists = i18nText.Create(ns + "DuplicateValueExists", "Another record found for field {0}. Please choose another value for this field.");
            public static i18nText DuplicateTwoKeyValueExists = i18nText.Create(ns + "DuplicateTwoKeyValueExists", "This item is currently in your list.");
            public static i18nText ValueBetweenMinMax = i18nText.Create(ns + "ValueBetweenMinMax", "Field {0} should be between {1} and {2}.");
            public static i18nText ValueMin = i18nText.Create(ns + "ValueMin", "Minimum value for field {0} is {1}");
            public static i18nText ValueMax = i18nText.Create(ns + "ValueMax", "Maximum value for field {0} is {1}");
            public static i18nText PasswordNotMatchVerifyPassword = i18nText.Create(ns + "PasswordNotMatchVerifyPassword", "Entered password does not match the verify password field. Please re-enter password and verify password fields again.");
            public static i18nText UserNotExistsInDatabase = i18nText.Create(ns + "UserNotExistsInDatabase", "User information is not available in database. Please contact admin to fix the problem.");
            public static i18nText ValueNotEqual = i18nText.Create(ns + "ValueNotEqual", "Value for field {0} cannot be equal to {1}");
            public static i18nText RecordIsNotAvailable = i18nText.Create(ns + "RecordIsNotAvailable", "This record is not available in the database. It might be deleted by someone else. If you think that it's a mistake please try again.");
        }


        public class Exceptions
        {
            public const string ns = "FW.Exceptions" + ".";
            public static i18nText GeneralBusinessRuleException = i18nText.Create(ns + "GeneralBusinessRuleException", "The provided information is not valid.");
            public static i18nText UnknownExceptionHappened = i18nText.Create(ns + "UnknownExceptionHappened", "Unknown exception happened. We applogize for any inconvenience. The program saved the error information and contacted the administrator. We will try to fix the error as soon as possible. Please try later. Please call the administrator in the case of emergency.");
            public static i18nText DatabaseServerIsNotAccessible = i18nText.Create(ns + "DatabaseServerIsNotAccessible", "Database server is not accessible. It is a server-side issue. Please contact the support team or your system administrator to fix the problem.");
            public static i18nText AccessDenied = i18nText.Create(ns + "AccessDenied", "Access denied. You don't have enough permission to do this action. If you think that you need this access, please contact the administrator.");
            public static i18nText AccessDenied_ = i18nText.Create(ns + "AccessDenied_", "Access denied : {0}");
            public static i18nText InsertFunctionIsNotAvailable = i18nText.Create(ns + "InsertFunctionIsNotAvailable", "Insert function is not available.");
            public static i18nText UpdateFunctionIsNotAvailable = i18nText.Create(ns + "UpdateFunctionIsNotAvailable", "Update function is not available.");
            public static i18nText DeleteFunctionIsNotAvailable = i18nText.Create(ns + "DeleteFunctionIsNotAvailable", "Delete function is not available.");
            public static i18nText ObjectChangedBeforeUpdate = i18nText.Create(ns + "ObjectChangedBeforeUpdate", "This record is updated by another user before you update it.");
        }
        

        public class GeneralMessages
        {
            public const string ns = "FW.GeneralMessages" + ".";
            public static i18nText ErrorInRow = i18nText.Create(ns + "ErrorInRow", "Error in row");
            public static i18nText PasswordChangedSuccessfully = i18nText.Create(ns + "PasswordChangedSuccessfully", "Password Changed successfully.");
            public static i18nText OperationDoneSuccessfully = i18nText.Create(ns + "OperationDoneSuccessfully", "Operation done successfully.");
            public static i18nText Operation_ActionTitle_DoneSuccessfully = i18nText.Create(ns + "Operation_ActionTitle_DoneSuccessfully", "Operation {0} done successfully.");
            public static i18nText Operation_ActionTitle_DoneSuccessfullyOn_X_Items = i18nText.Create(ns + "Operation_ActionTitle_DoneSuccessfullyOn_X_Items", "Operation {0} done successfully on {1} item(s).");
            public static i18nText UserCanceledSuccessfully = i18nText.Create(ns + "UserCanceledSuccessfully", "Your account canceled successfully..");
            public static i18nText EmailValidation = i18nText.Create(ns + "EmailValidation", "The value is not a valid email address.");
            public static i18nText PhoneNumebrE164Validation = i18nText.Create(ns + "PhoneNumebrE164Validation", "Phone number should be in E.164 standard format: [+][CountryCode][AreaCode] For example: +12343003690");
        }

        public class RestfulMessages
        {
            public const string ns = "FW.RestfulMessages" + ".";
            public static i18nText ServiceApiIsNotAvailable = i18nText.Create(ns + "ServiceApiIsNotAvailable", "This service API is not available.");
            public static i18nText ObjectedInsertedSuccessfully = i18nText.Create(ns + "ObjectedInsertedSuccessfully", "Object inserted successfully!");
            public static i18nText ObjectedUpdatedSuccessfully = i18nText.Create(ns + "ObjectedUpdatedSuccessfully", "Object updated successfully!");
            public static i18nText ObjectedDeletedSuccessfully = i18nText.Create(ns + "ObjectedDeletedSuccessfully", "Object deleted successfully!");
            public static i18nText ObjectedInsertionFailed = i18nText.Create(ns + "ObjectedInsertionFailed", "Object insertion failed.");
            public static i18nText ObjectedDeletionFailed = i18nText.Create(ns + "ObjectedDeletionFailed", "Object deletion failed.");
            public static i18nText ObjectedUpdateFailed = i18nText.Create(ns + "ObjectedUpdateFailed", "Object update failed.");

        }

    }
}
