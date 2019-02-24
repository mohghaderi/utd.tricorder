using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTD.Tricorder.BusinessRule
{
    public class BusinessErrorStrings
    {
        public class User
        {
            public const string ns = "FW.BusinessErrorStrings.User" + ".";
            public static i18nText UserName_MustAtLeastFiveCharacters = i18nText.Create(ns + "UserName_MustAtLeastFiveCharacters", "Must consist at least five characters that are alpha characters a-zA-Z");
            public static i18nText UserName_RegularExpressionCheck = i18nText.Create(ns + "UserName_RegularExpressionCheck", "UserName must be 5-50 characters (not case sensitive)" +
                            "\r\n" + "should be a sequence of alphanumerics (A-Z, a-z, 0-9)," +
                            "\r\n" + "can have dot (.) or underscore (_) but not consecutive");
            public static i18nText UserName_DuplicateUserName = i18nText.Create(ns + "UserName_DuplicateUserName", "Another user is registered with this user name. Please choose another user name.");
            public static i18nText UserTitle_CanNotBeEmpty = i18nText.Create(ns + "UserTitle_CanNotBeEmpty", "First name and Last Name fields can not be null or empty.");
            public static i18nText UserName_UserNameNotExistsInDatabase = i18nText.Create(ns + "UserName_UserNameNotExistsInDatabase", "UserName {0} is not exists in database. Please check that you entered a correct user name.");
            public static i18nText UserName_UserNameCannotBeNullOrEmpty = i18nText.Create(ns + "UserName_UserNameCannotBeNullOrEmpty", "UserName can not be null or empty. Please enter a valid UserName.");
            public static i18nText Email_InvalidEmailAddress = i18nText.Create(ns + "Email_InvalidEmailAddress", "Invalid Email address");
            public static i18nText Email_Duplicate = i18nText.Create(ns + "Email_Duplicate", "Another user is registered with this email address. If this is your email and you forget your password, you can get access to your accout using 'Forget password' option in the login page.");
            public static i18nText Password_RegularExpression = i18nText.Create(ns + "Password_RegularExpression", "Password should have at least 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be between 6-64 characters. The sequence of the characters is not important. ");
            public static i18nText PasswordAndConfirmPasswordDoesntMatch = i18nText.Create(ns + "PasswordAndConfirmPasswordDoesntMatch", "Password and confirm password doesn't match. Please re-enter your password.");
            public static i18nText PhoneNumber_DuplicatePhoneNumber = i18nText.Create(ns + "PhoneNumber_DuplicatePhoneNumber", "This phone number is already registered in our database. If you have an account, you can login or retreive your password.");
            public static i18nText PhoneNumber_NotE164 = i18nText.Create(ns + "PhoneNumber_NotE164", "Incorrect phone number formatting. Phone numbers should be formatted as E.164 ([+][country code][subscriber number including area code]). For example: +12343003690 is a valid number in the US.");

            public static i18nText ApprovalChange_OnlyLockedAccountsCanBeUnlocked = i18nText.Create(ns + "ApprovalChange_OnlyLockedAccountsCanBeUnlocked", "This account is not locked. Only locked accounts can be unlocked.");
            public static i18nText ApprovalChange_RegistrationOfThisUserIsIncomplete = i18nText.Create(ns + "ApprovalChange_RegistrationOfThisUserIsIncomplete", "Registration of this user is still incomplete. This operation can't be done on incomplete accounts.");

            // email verification
            public static i18nText InvalidEmailCode = i18nText.Create(ns + "InvalidEmailCode", "We are sorry that we can't verify your email because your email or the verification code is not valid. Please request new verification code and follow the instructions.");
            public static i18nText InvalidPhoneNumber = i18nText.Create(ns + "InvalidPhoneNumber", "We are sorry that we can't verify your phone number because your number or the verification code is invalid. Please request new verification code and follow the instructions.");

            // GetDataByPhoneForQReg
            public static i18nText GetDataByPhoneForQReg_NotFound = i18nText.Create(ns + "GetDataByPhoneForQReg_NotFound", "No user found with the provided information. Please verify that you typed the phone number and the verification code correctly.");
            public static i18nText GetDataByPhoneForQReg_UserApprovalStatusIDNotIncomplete = i18nText.Create(ns + "GetDataByPhoneForQReg_UserApprovalStatusIDNotIncomplete", "Your registration is not incomplete. Please use login form login to your account.");

            // ResetPassword
            public static i18nText ResetPasswordInvalidEmailOrPhoneNumber = i18nText.Create(ns + "ResetPasswordInvalidEmailOrPhoneNumber", "The email or phone number you entered in not valid");
            public static i18nText ResetPasswordTooSoon = i18nText.Create(ns + "ResetPasswordTooSoon", "You can order Reset password only every {0} minutes. Please wait for {1} minute(s) and try again.");
            public static i18nText ResetPasswordNoUserFound = i18nText.Create(ns + "ResetPasswordNoUserFound", "No user found with the provided information. Please make sure that you entered your information correcly.");
            public static i18nText ResetPasswordInvalidCode = i18nText.Create(ns + "ResetPasswordInvalidCode", "Invalid reset password code. Please check that you entered a correct code. You may also re-send the reset password code and re-enter it.");
            public static i18nText ResetPasswordCodeExpired = i18nText.Create(ns + "ResetPasswordCodeExpired", "Reset password code has expired. Please re-send a new code and try again.");
            public static i18nText ResetPasswordUserAccountIsLocked = i18nText.Create(ns + "ResetPasswordUserAccountIsLocked", "This user account is locked, and you can't reset its password. Please contact the administrator to unlock the account and reset your password.");
        }

        public class PasswordValidation
        {
            public const string ns = "FW.BusinessErrorStrings.PasswordValidation" + ".";
            public static i18nText PasswordIsInvalid = i18nText.Create(ns + "PasswordIsInvalid", "Password is invalid. Please enter the correct password and try again.");
            public static i18nText UserName_Or_Password_Is_Not_Correct = i18nText.Create(ns + "UserName_Or_Password_Is_Not_Correct", "Entered username or password is not correct. Please verify that you entered a correct user name and type your password again.");
            public static i18nText AccountLocked = i18nText.Create(ns + "AccountLocked", "According to our rules and policies, your account is locked by an administrator. Please contact the support team to unlock it.");
            public static i18nText AccountFailedPasswordLocked = i18nText.Create(ns + "AccountFailedPasswordLocked", "Your account is locked because you or another person entered a wrong password several times. Please contact the support team to unlock it.");
            public static i18nText ApprovalRejected = i18nText.Create(ns + "ApprovalRejected", "Unfortunately, we couldn't approve your account. If you think that it was a mistake, please contact our support team.");
            public static i18nText AccountCanceled = i18nText.Create(ns + "AccountCanceled", "Your account is canceled. You won't be able to use this account any more. Please contact system admin if you would like to re-activate your account.");
        }


        public class Payment
        { 
            public const string ns = "FW.BusinessErrorStrings.Payment" + ".";
            // For CreatePaymentForVisitCheckVisitData
            public static i18nText VisitStatus_Equals_EndSuccess = i18nText.Create(ns + "VisitStatus_Equals_EndSuccess", "Visit should be completed before processing of payments");
            public static i18nText PaymentStatus_Equlas_NotStarted = i18nText.Create(ns + "PaymentStatus_Equlas_NotStarted", "Payment process for this visit has already started.");
            public static i18nText VisitAlreadyHasAPaymentRecord = i18nText.Create(ns + "VisitAlreadyHasAPaymentRecord", "Payment information already created for this visit");

            // For UpdatePayKeyCheck
            public static i18nText PayPalEmailAddressNotDefinedForUser_ = i18nText.Create(ns + "PayPalEmailAddressNotDefinedForUser_", "PayPal Email address is not defined for user {0}");
            public static i18nText PaymentInfoIsNotDefinedForUser_ = i18nText.Create(ns + "PaymentInfoIsNotDefinedForUser_", "This user has not setup any payment option yet. Please contact him/her directly regarding the issue.");
            public static i18nText PaymentStatusIsNotPending = i18nText.Create(ns + "PaymentStatusIsNotPending", "This payment is already processed.");

            //For PaymentReceived
            public static i18nText PayKeyNotFound = i18nText.Create(ns + "PayKeyNotFound", "Your payment has been received, but we couldn't process it because of some errors. All errors are reported to the administrator of the site. We will call you as soon as we fixed the problem.");
            public static i18nText PaymentIsNotPending = i18nText.Create(ns + "PaymentIsNotPending", "Our records show that this payment is already processed, so we can't process it again. This is a problem in the payment system. All errors are reported to the administrator of the site. We will call you as soon as we fixed the problem.");
            public static i18nText PaymentIsNotCompletedInPayPal = i18nText.Create(ns + "PaymentIsNotCompletedInPayPal", "PayPal says that you haven't completed your transaction yet.");

            //RefundPayment
            public static i18nText OnlyCompletedPaymentsCanBeRefunded = i18nText.Create(ns + "OnlyCompletedPaymentsCanBeRefunded", "Only completed payments can be refunded. Operation not done.");

            // Cancel
            public static i18nText OnlyIncompletedPaymentsCanBeCanceled = i18nText.Create(ns + "OnlyIncompletedPaymentsCanBeCanceled", "Only incomplete payments can be canceled. Operation not done.");

            //UpdatePaymentInfoFromPaymentWebsite
            public static i18nText ThisPaymentIsNotPendingToBeUpdated = i18nText.Create(ns + "ThisPaymentIsNotPendingToBeUpdated", "ThisPaymentIsNotPendingToBeUpdated. This is an internal error. Please contact our support team to fix the problem.");
        }

        public class Visit
        {
            public const string ns = "FW.BusinessErrorStrings.Visit" + ".";
            //Complete Visit
            public static i18nText CompleteVisit_StatusIsNotScheduledOrInWaitingRoom = i18nText.Create(ns + "CompleteVisit_StatusIsNotScheduledOrInWaitingRoom", "This visit is already processed. You can't complete it at this time.");
            //ReverseToRescheduled
            public static i18nText ReverseToRescheduled_StatusIsNotCompletedOrCanceled = i18nText.Create(ns + "ReverseToRescheduled_StatusIsNotCompletedOrCanceled", "This visit is not completed or canceled. So, you can't revert it to the scheduled status.");
            //Doctor Report
            public static i18nText OnlyDoctorOfVisitCanWriteAReport = i18nText.Create(ns + "OnlyDoctorOfVisitCanWriteAReport", "Only the doctor whom visited the patient can write a visit report.");
            //Cancel
            public static i18nText CancelVisit_ThisVisitIsNotCancelable = i18nText.Create(ns + "CancelVisit_ThisVisitIsNotCancelable", "This visit is already processed. You can't cancel it at this time.");
            //Reschedule
            public static i18nText RescheduleVisit_ThisVisitCannotBeChange = i18nText.Create(ns + "RescheduleVisit_ThisVisitCannotBeChange", "This visit is already processed. You can't re-schedule it anymore.");
            public static i18nText RescheduleVisit_DoctorScheduleDeleted = i18nText.Create(ns + "RescheduleVisit_DoctorScheduleDeleted", "This doctor is not available at this time. Please select another time slot.");
            public static i18nText RescheduleVisit_ReschuleOnlyForSameDoctor = i18nText.Create(ns + "RescheduleVisit_ReschuleOnlyForSameDoctor", "Visits can be rescheduled only for the same doctor.");
            public static i18nText RescheduleVisit_CantDoRescheduleOnTheSameTime = i18nText.Create(ns + "RescheduleVisit_CantDoRescheduleOnTheSameTime", "Rescheduling cannot be done on the same time. Please select another time for re-scheduling.");
            //Delete
            public static i18nText Visit_Deleted = i18nText.Create(ns + "Visit_Deleted", "Information of this visit is deleted from the database. Operation cannot be completed.");

            // insert
            public static i18nText Insert_TheTimeForThisScheduleHasPassed = i18nText.Create(ns + "Insert_TheTimeForThisScheduleHasPassed", "This time slot is no longer available because it is earlier than current time. Please select another time slot.");
            public static i18nText Insert_ScheduleIsDisabled = i18nText.Create(ns + "Insert_ScheduleIsDisabled", "This time slot is no longer available because it is disabled. Please select another time slot.");

            // both insert and re-schedule
            public static i18nText TimeSlotIsFull = i18nText.Create(ns + "TimeSlotIsFull", "This slot is full, and it is not available now. Please try another slot.");

            // call patient
            public static i18nText CallPatient_NoDeviceAttachedToThisUser = i18nText.Create(ns + "CallPatient_NoDeviceAttachedToThisUser", "There currently no mobile device available for this user. Please use his contact information to contact him.");
        }

        public class DoctorSchedule
        {
            public const string ns = "FW.BusinessErrorStrings.DoctorSchedule" + ".";
            // insert
            public static i18nText TimeAllocatedBefore = i18nText.Create(ns + "TimeAllocatedBefore", "This time slot is already exists. Please use another time slot.");

            // insert / update
            public static i18nText CannotInsertOldTime = i18nText.Create(ns + "CannotInsertOldTime", "Selected time belongs to an older time.");

            // delete
            public static i18nText CannotDeleteBecauseVisitExists = i18nText.Create(ns + "CannotDeleteBecauseVisitExists", "A patient is registered in this time slot. You can't delete this before re-scheduling all the patients");
            public static i18nText CannotDeleteOldTimeSchedules = i18nText.Create(ns + "CannotDeleteOldTimeSchedules", "This schedule belongs to an older time. So, it can't be deleted.");

            // copy
            public static i18nText CopyOverlapInCopy = i18nText.Create(ns + "CopyOverlapInCopy", "Selected source day has overlap with the end day. Please select a farther end day or decrease number of days to copy.");
            public static i18nText DeleteRangeEndDateShouldBeGreaterStartDate = i18nText.Create(ns + "DeleteRangeEndDateShouldBeGreaterStartDate", "Selected range is not valid. End date should be greater than start date.");

        }

        public class AppFile
        {
            public const string ns = "FW.BusinessErrorStrings.DoctorSchedule" + ".";
            public static i18nText InvalidFileSize_MinMax = i18nText.Create(ns + "InvalidFileSize_MinMax", "File Size should be less than {1} and more than {0}");
            public static i18nText InvalidFileType = i18nText.Create(ns + "InvalidFileType", "File type {0} is not acceptable. Please select your file among types {1}");
            public static i18nText FileTypeEmpty = i18nText.Create(ns + "FileTypeEmpty", "Selected file doesn't have a file type. File names should be have a filename a dot and filetype, for example, profile.jpg");
        }

        public class FoodGroup
        {
            public const string ns = "FW.BusinessErrorStrings.FoodGroup" + ".";
            public static i18nText NotItemInFoodGroup = i18nText.Create(ns + "NotItemInFoodGroup", "Please add foods to this group before saving.");
        }

    }
}
