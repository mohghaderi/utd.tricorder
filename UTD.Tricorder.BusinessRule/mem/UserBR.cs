using System;
using System.Collections.Generic;
using Framework.Business;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.BusinessRule
{
    public class UserBR : BusinessRuleBase<User, vUser>
    {
		#region Generator-Safe Area

		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Checks the rules.
        /// </summary>
        /// <param name="entitySet">The entity set.</param>
        /// <param name="fnName">Name of the function.</param>
        /// <param name="errors">The errors.</param>
        public override void CheckRules(object entitySet, RuleFunctionSEnum fnName, BusinessRuleErrorList errors)
        {
            this.CheckAutomatedRules(entitySet, fnName, errors);
            if (errors.Count > 0)
                return;
            
            User obj = (User) entitySet;

            obj.UserName = obj.UserName.ToLower();
            if (string.IsNullOrEmpty(obj.Email) == false)
                obj.Email = obj.Email.ToLower();

            ValidateUserName(obj.UserName, obj.UserID, errors, fnName, false);
            ValidateEmail(obj.Email, obj.UserID, errors, fnName, false);
            ValidatePhoneNumber(obj.PhoneNumber, obj.UserID, true, errors, fnName, false);
        }


        public bool Register(UserRegisterSP p, BusinessRuleErrorList errors, bool throwIfException)
        {
            if (p.Password != p.ConfirmPassword)
            {
                errors.Add(vUser.ColumnNames.PasswordHash, BusinessErrorStrings.User.PasswordAndConfirmPasswordDoesntMatch);
            }

            ValidatePassword(p.Password, errors, false);
            ValidateUserName(p.UserName, null, errors, RuleFunctionSEnum.Insert, false);
            ValidateEmail(p.Email, null, errors, RuleFunctionSEnum.Insert, false);
            ValidatePhoneNumber(p.PhoneNumber, null, false, errors, RuleFunctionSEnum.Insert, false);

            if (errors.Count > 0 && throwIfException)
                throw new BRException(errors);

            return errors.Count == 0;
        }


        public bool RegisterAndLogin(RegisterInfoOffsite p, BusinessRuleErrorList errors, bool throwIfException)
        {
            //ValidatePassword(p.Password, errors, false);
            //ValidateUserName(p.UserName, null, errors, RuleFunctionSEnum.Insert, false);
            ValidateEmail(p.Email, null, errors, RuleFunctionSEnum.Insert, false);
            ValidatePhoneNumber(p.PhoneNumber, null, true, errors, RuleFunctionSEnum.Insert, false);

            if (errors.Count > 0 && throwIfException)
                throw new BRException(errors);

            return errors.Count == 0;
        }

        public bool ValidatePassword(string value, BusinessRuleErrorList errors, bool throwIfException)
        {
            string colName = vUser.ColumnNames.PasswordHash;
            if (CheckUtils.CheckStringShouldNotBeNullOrEmpty(vUser.ColumnNames.PasswordHash, value, errors))
            {
                // Pattern obtained from 
                //http://regexlib.com/(A(13E-t-BjvZ-WvDNI3kEXWexqe-dnRabCLhUJT4HCwiq39cFxk1bCp2xTgMv4ZLuwh4z02qwn-LwirPbo_Y1NF6Tnx6zEJKJ9ukU7WXcOnRM1))/Search.aspx?k=password&c=-1&m=-1&ps=20
                string valuePattern = @"(?=^.{6,64}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$";
                if (System.Text.RegularExpressions.Regex.IsMatch(
                    value, valuePattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase) == false)
                {
                    errors.Add(colName, BusinessErrorStrings.User.Password_RegularExpression
                        );
                }
            }
            if (errors.Count > 0 && throwIfException)
                throw new BRException(errors);

            return errors.Count == 0;
        }

        public void ChangePassword(User user, UserChangePasswordSP p)
        {
            if (user == null)
                throw new UserException(BusinessErrorStrings.User.UserName_UserNameNotExistsInDatabase);

            if (Framework.Common.Security.PasswordHash.ValidatePassword(p.OldPassword, user.PasswordSalt, user.PasswordHash) == false)
                throw new UserException(BusinessErrorStrings.PasswordValidation.PasswordIsInvalid);

            if (p.NewPassword != p.ConfirmNewPassword)
                throw new UserException(BusinessErrorStrings.User.PasswordAndConfirmPasswordDoesntMatch);

            ValidatePassword(p.NewPassword, new Framework.Business.BusinessRuleErrorList(), true);
        }



        public bool ValidateEmail(string value, long? idValue, BusinessRuleErrorList errors, RuleFunctionSEnum fnName, bool throwIfErrors)
        {
            if (string.IsNullOrEmpty(value))
                return true;
            //if (CheckUtils.CheckStringShouldNotBeNullOrEmpty(vUser.ColumnNames.Email, value, errors) == false)
            //    if (throwIfErrors)
            //        throw new BRException(errors);
            //    else
            //        return false;


            if (fnName == RuleFunctionSEnum.Delete)
                return true;

            string colName = vUser.ColumnNames.Email;
            // format check
            // we try to create a mail address. If format was incorrect then its an error
            //http://stackoverflow.com/questions/5342375/c-sharp-regex-email-validation
            try
            {

                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(value);
            }
            catch (Exception)
            {
                errors.Add(colName, BusinessErrorStrings.User.Email_InvalidEmailAddress);
            }

            // check duplicate
            if (errors.Count == 0) // Perfomance: We check database only if no error is there.
            {
                value = value.ToLower(); // we store all emails in lower case
                CheckUtils.CheckDuplicateValueNotToBeExists(colName, value, idValue, errors, null, fnName == RuleFunctionSEnum.Insert, BusinessErrorStrings.User.Email_Duplicate);
            }

            if (errors.Count > 0 && throwIfErrors)
                throw new BRException(errors);

            return errors.Count == 0;

        }


        /// <summary>
        /// Validates the name of the user.
        /// </summary>
        /// <param name="value">Name of the user.</param>
        /// <param name="idValue">id value of the entity. It will be used in update mode to check duplicate</param>
        /// <param name="fnName">Business rule function if it is insert or update</param>
        /// <param name="errors">The errors.</param>
        /// <param name="throwIfErrors">Throw BRException if an error happened</param>
        public bool ValidateUserName(string value, long? idValue, BusinessRuleErrorList errors, RuleFunctionSEnum fnName, bool throwIfErrors)
        {
            int errCount = errors.Count;

            if (CheckUtils.CheckStringShouldNotBeNullOrEmpty(vUser.ColumnNames.UserName, value, errors) == false)
                if (throwIfErrors && errors.Count > errCount)
                    throw new BRException(errors);
                else
                    return false;

            string colName = vUser.ColumnNames.UserName;
            //Must consist at least two characters that are alpha characters a-zA-Z
            //Must consist only ONE underscore or dash allowed anywhere AFTER the first check, 
            //the dash/underscore cannot be at the end as the same rule to apply as the first step
            //Must be alpha-numeric characters.

            //var colInfo = this.Entity.EntityColumns[User.ColumnNames.UserName];

            if (fnName == RuleFunctionSEnum.Delete)
                return true;

            // DEVELOPER NOTE: Change this pattern with pattern specified in UI in FWHtml.cs file for editor 
            // format check
            // http://stackoverflow.com/questions/3588623/c-sharp-regex-for-a-username-with-a-few-restrictions
            string valuePattern = @"^(?=.{5,50}$)([A-Za-z0-9][._]?)*$";
            //(?=.{5,50}$)                   Must be 5-50 characters in the string
            //([A-Za-z0-9][._()\[\]-]?)*   The string is a sequence of alphanumerics,
            //                              each of which may be followed by a symbol
            if (System.Text.RegularExpressions.Regex.IsMatch(
                value, valuePattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase) == false)
            {
                errors.Add(colName, BusinessErrorStrings.User.UserName_RegularExpressionCheck
                    );
            }

            // duplicate check
            if (errors.Count == 0) // Perfomance: We check database only if no error is there.
            {
                value = value.ToLower(); // we store all user names in lower case
                CheckUtils.CheckDuplicateValueNotToBeExists(colName, value, idValue, errors, null, fnName == RuleFunctionSEnum.Insert, BusinessErrorStrings.User.UserName_DuplicateUserName);
            }

            if (errors.Count > 0 && throwIfErrors)
                throw new BRException(errors);

            return errors.Count == 0;
        }



        /// <summary>
        /// Validates the phone number
        /// </summary>
        /// <param name="value">Phone Number</param>
        /// <param name="idValue">id value of the entity. It will be used in update mode to check duplicate</param>
        /// <param name="fnName">Business rule function if it is insert or update</param>
        /// <param name="canBeNull">See if Phone number can be null or empty</param>
        /// <param name="errors">The errors.</param>
        /// <param name="throwIfErrors">Throw BRException if an error happened</param>
        public bool ValidatePhoneNumber(string value, long? idValue, bool canBeNull, BusinessRuleErrorList errors, RuleFunctionSEnum fnName, bool throwIfErrors)
        {
            int errCount = errors.Count;

            // To simplify Signup, we removed Phone number as mandatory 
            // in addition, RegisterAndLogin option doesn't need to have a phone number
            // However, if a phone number is provided, we need to check its format
            if (string.IsNullOrEmpty(value) && canBeNull)
                return true;

            if (CheckUtils.CheckStringShouldNotBeNullOrEmpty(vUser.ColumnNames.PhoneNumber, value, errors) == false)
                if (throwIfErrors && errors.Count > errCount)
                    throw new BRException(errors);
                else
                    return false;

            string colName = vUser.ColumnNames.PhoneNumber;

            if (fnName == RuleFunctionSEnum.Delete)
                return true;

            if (IsValidPhoneNumberE164(value) == false)
                errors.Add(colName, BusinessErrorStrings.User.PhoneNumber_NotE164);



            // duplicate check
            if (errors.Count == 0) // Perfomance: We check database only if no error is there.
            {
                value = value.ToLower(); // we store all user names in lower case
                CheckUtils.CheckDuplicateValueNotToBeExists(colName, value, idValue, errors, null, fnName == RuleFunctionSEnum.Insert, BusinessErrorStrings.User.PhoneNumber_DuplicatePhoneNumber);
            }

            if (errors.Count > 0 && throwIfErrors)
                throw new BRException(errors);

            return errors.Count == 0;
        }


        /// <summary>
        /// Checks that Phone number be a E.164 standard
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsValidPhoneNumberE164(string value)
        {
            // Check E164 format: We used E.164 because its standard for all international phone numbers
            // https://www.twilio.com/help/faq/phone-numbers/how-do-i-format-phone-numbers-to-work-internationally
            // http://en.wikipedia.org/wiki/E.164

            // DEVELOPER NOTE: Change this pattern with pattern specified in UI in FWHtml.cs file for editor of phone number
            string valuePattern = @"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$";
            // http://stackoverflow.com/questions/2113908/what-regular-expression-will-match-valid-international-phone-numbers
            if (System.Text.RegularExpressions.Regex.IsMatch(
                value, valuePattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase) == false)
            {
                return false;
            }
            return true;
        }

        //public void CheckApprovalStatus(EntityEnums.UserApprovalStatusEnum oldStatus, EntityEnums.UserApprovalStatusEnum newStatus)
        //{
        //    if (newStatus == EntityEnums.UserApprovalStatusEnum.Approved)
        //}

        /// <summary>
        /// Checks business rules for Register Quick
        /// </summary>
        /// <param name="p">parameters</param>
        /// <param name="errors">errors</param>
        /// <param name="throwIfException">throws an exception if an exception happened</param>
        public void RegisterQuickFromDoctor(UserRegisterQuickFromDoctorSP p, BusinessRuleErrorList errors, bool throwIfException)
        {
            ValidatePhoneNumber(p.PhoneNumber, null, true, errors, RuleFunctionSEnum.Insert, false);

        }

        /// <summary>
        /// Business rules for updating user profile information
        /// </summary>
        /// <param name="p">parameters</param>
        /// <param name="user"></param>
        public void UpdateProfileInfo(UserUpdateProfileInfoSP p, User user)
        {

        }

        /// <summary>
        /// Check business rules for continuing quick registration
        /// </summary>
        /// <param name="p"></param>
        public void ContinueQReg(UserContinueQRegSP p)
        {
            BusinessRuleErrorList errors = new BusinessRuleErrorList();
            if (p.Password != p.ConfirmPassword)
            {
                errors.Add(vUser.ColumnNames.PasswordHash, BusinessErrorStrings.User.PasswordAndConfirmPasswordDoesntMatch);
            }

            CheckUtils.CheckStringShouldNotBeNullOrEmpty(vUser.ColumnNames.Email, p.Email, errors);
            CheckUtils.CheckStringShouldNotBeNullOrEmpty(vUser.ColumnNames.UserName, p.UserName, errors);
            CheckUtils.CheckStringShouldNotBeNullOrEmpty(vUser.ColumnNames.PasswordHash, p.Password, errors);
            CheckUtils.CheckStringShouldNotBeNullOrEmpty(vUser.ColumnNames.PhoneNumber, p.PhoneNumber, errors);

            if (errors.Count > 0)
                throw new BRException(errors);
        }

        /// <summary>
        /// Pre requisite reset password checks
        /// </summary>
        /// <param name="p"></param>
        public void ResetPasswordIsValidEmailOrPhone(string EmailOrPhoneNumber)
        {
            string value = EmailOrPhoneNumber;

            if (string.IsNullOrEmpty(value))
                throw new BRException(BusinessErrorStrings.User.ResetPasswordInvalidEmailOrPhoneNumber);


            bool isEmail = false;
            if (value.IndexOf('@') > 0)
                isEmail = true;

            if (isEmail)
            {
                try
                {
                    System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(value);
                }
                catch (Exception)
                {
                    throw new BRException(BusinessErrorStrings.User.ResetPasswordInvalidEmailOrPhoneNumber);
                }

            }
            else // it's a phone number
            {
                if (IsValidPhoneNumberE164(value))
                    throw new BRException(BusinessErrorStrings.User.ResetPasswordInvalidEmailOrPhoneNumber);
            }
        }

        /// <summary>
        /// checks Reset password business rules
        /// </summary>
        /// <param name="p">check password parameters</param>
        /// <param name="u">user information</param>
        public void ResetPasswordRequest(UserResetPasswordRequestSP p, User u)
        {
            if (u == null)
                throw new BRException(BusinessErrorStrings.User.ResetPasswordNoUserFound);

            if (FWUtils.ConfigUtils.GetAppSettings().Project.IsDebug == false)
            {
                // not checking request delay only in debug mode because of test cases
                int resetPasswordWaitSeconds = FWUtils.ConfigUtils.GetAppSettings().Project.ResetPasswordNewRequestWaitSeconds;
                if (u.ResetPasswordRequestDate != null)
                {
                    var diff = DateTime.UtcNow - u.ResetPasswordRequestDate.Value;
                    if (diff.TotalSeconds < resetPasswordWaitSeconds)
                        throw new BRException(string.Format(BusinessErrorStrings.User.ResetPasswordTooSoon,
                            Math.Ceiling((double)resetPasswordWaitSeconds / 60), Math.Ceiling((double)diff.TotalSeconds / 60)) + 1);
                }
            }
        }

        public void ResetPassword(UserResetPasswordSP p, User u)
        {
            if (u == null)
                throw new BRException(BusinessErrorStrings.User.ResetPasswordNoUserFound);

            if (u.UserApprovalStatusID != (int) EntityEnums.UserApprovalStatusEnum.Approved
                && u.UserApprovalStatusID != (int) EntityEnums.UserApprovalStatusEnum.FailedPasswordLocked)

            if (string.IsNullOrEmpty(p.ResetPasswordCode))
                throw new BRException(BusinessErrorStrings.User.ResetPasswordInvalidCode);

            int userInputResetCode = 0;
            if (int.TryParse(p.ResetPasswordCode, out userInputResetCode) == false)
                throw new BRException(BusinessErrorStrings.User.ResetPasswordInvalidCode);

            if (u.ResetPasswordCode.HasValue == false)
                throw new BRException(BusinessErrorStrings.User.ResetPasswordInvalidCode);

            if (userInputResetCode != u.ResetPasswordCode.Value)
                throw new BRException(BusinessErrorStrings.User.ResetPasswordInvalidCode);

            if (p.NewPassword != p.ConfirmNewPassword)
                throw new BRException(BusinessErrorStrings.User.PasswordAndConfirmPasswordDoesntMatch);


            int resetPasswordExpireSeconds = FWUtils.ConfigUtils.GetAppSettings().Project.ResetPasswordCodeExpireSeconds;
            if (u.ResetPasswordRequestDate != null)
            {
                var diff = DateTime.UtcNow - u.ResetPasswordRequestDate.Value;
                if (diff.TotalSeconds > resetPasswordExpireSeconds)
                    throw new BRException(BusinessErrorStrings.User.ResetPasswordCodeExpired);
            }

        }

		#endregion

    }
}

