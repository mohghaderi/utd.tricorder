using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.BusinessRule;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Service
{
    public class UserService : ServiceBase<User, vUser>, IUserService
    {
	
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        protected class UserEntitySecurity : MyRowViewAllEditMeEntitySecurity
        {
            public UserEntitySecurity(IServiceBase service, string fieldName, object fieldValue)
                :base (service, fieldName, fieldValue)
            {
 
            }

            public override void Insert(object entitySet, InsertParameters parameters)
            {
                // don't check security for insert
            }
        }

        public override void OnAfterInitialize()
        {
            base.OnAfterInitialize();
            //// TODO: Re-Write the security engine. 
            //// It is very hard to modify with lots of empty functions
            ////if (FWUtils.SecurityUtils.IsUserAuthenticated())
            //{
            //    long userId = FWUtils.SecurityUtils.GetCurrentUserIDLong();
            //    this.SecurityCheckers.Add(new UserEntitySecurity(this, vUser.ColumnNames.UserID, userId));
            //}

        }




        /// <summary>
        /// Checks if provided user name is valid or not
        /// if it was not valid, it throws an exception
        /// </summary>
        /// <param name="userName">user name for check</param>
        /// <exception cref="BRException"></exception>
        public void ValidateUserNameForInsert(string userName)
        {
            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.ValidateUserName(userName, null, new Framework.Business.BusinessRuleErrorList(), RuleFunctionSEnum.Insert, throwIfErrors: true);
        }


        /// <summary>
        /// Validates the email for insert.
        /// </summary>
        /// <param name="email">The email.</param>
        public void ValidateEmailForInsert(string email)
        {
            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.ValidateEmail(email, null, new Framework.Business.BusinessRuleErrorList(), RuleFunctionSEnum.Insert, throwIfErrors: true);
        }

        /// <summary>
        /// Validates the phone number for insert.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        public void ValidatePhoneNumberForInsert(string phoneNumber)
        {
            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.ValidatePhoneNumber(phoneNumber, null, true, new Framework.Business.BusinessRuleErrorList(), RuleFunctionSEnum.Insert, throwIfErrors: true);
        }


        /// <summary>
        /// Gets user data for insert
        /// </summary>
        /// <param name="p">User registration parameters</param>
        /// <returns></returns>
        private User GetUserDataForInsert(UserRegisterSP p)
        {
            User user = new User();
            // just in the case that we didn't have any user name,
            // we can use email as username (it is to simplify registration for now)
            if (string.IsNullOrEmpty(p.UserName))
                user.UserName = p.Email.ToLower();
            else
                user.UserName = p.UserName.ToLower();

            user.FirstName = p.FirstName;
            user.LastName = p.LastName;
            GeneratePasswordHash(user, p.Password);
            if (string.IsNullOrEmpty(p.Email) == false)
                user.Email = p.Email.ToLower();
            user.PhoneNumber = p.PhoneNumber;

            user.MembershipAreaID = (int)EntityEnums.MembershipAreaEnum.Root;
            user.InsertUserID = null;
            DateTime now = DateTime.UtcNow;
            user.InsertDate = now;
            user.UpdateUserID = null;
            user.UpdateDate = null;
            user.LastLoginDate = now;
            user.LastPasswordChangedDate = now;
            user.LastStatusChangeDate = now;
            user.FailedPasswordAttemptCount = 0;
            user.DefaultRoleID = p.DefaultRoleID;
            if (p.IsQuickRegister)
                user.UserApprovalStatusID = (int)EntityEnums.UserApprovalStatusEnum.IncompleteRegistration;
            else
                user.UserApprovalStatusID = (int)EntityEnums.UserApprovalStatusEnum.WaitingForApproval;
            //user.CountryID = EntityEnums.CountrySEnum.United_States;
            user.WorldTimeZoneID = (short)EntityEnums.WorldTimeZoneEnum.America_Chicago; //US central time
            user.PrimaryLanguageID = (short)EntityEnums.LanguageEnum.English; // English e
            user.ReferrerUserID = p.ReferrerUserID;

            GeneratePhoneVerificationCode(user);
            user.EmailVerificationCode = Guid.NewGuid();
            user.InsertSiteID = FWUtils.SecurityUtils.GetCurrentSiteID();

            return user;
        }

        /// <summary>
        /// Registers the specified user name.
        /// </summary>
        /// <param name="p">Registration parameters</param>
        /// <returns>if successful, returns user object, otherwise returns null</returns>
        public object Register(UserRegisterSP p)
        {
            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.Register(p, new Framework.Business.BusinessRuleErrorList(), true);
            //biz.ValidatePassword(p.password, new Framework.Business.BusinessRuleErrorList(), true);

            var user = GetUserDataForInsert(p);
            InsertUserWithDependancies(user);

            return user;
        }

        private void InsertUserWithDependancies(User user)
        {
            // --------------------------------------------------------
            // add user in role to parameters
            UserInRole uInRole = (UserInRole)EntityFactory.GetEntityObject(vUserInRole.EntityName, GetSourceTypeEnum.Table);
            uInRole.RoleID =user.DefaultRoleID;
            uInRole.StartDate = user.InsertDate;
            uInRole.IsActive = true;

            InsertParameters iParams = new InsertParameters();
            iParams.DetailEntityObjects.Add(new DetailObjectInfo()
            {
                EntityName = vUserInRole.EntityName,
                AdditionalDataKey = "",
                EntitySet = uInRole,
                FnName = RuleFunctionSEnum.Insert,
                FKColumnNameForAutoSet = vUserInRole.ColumnNames.UserID
            });

            // add user language
            User_Language user_language = (User_Language)EntityFactory.GetEntityObject(vUser_Language.EntityName, GetSourceTypeEnum.Table);
            user_language.LanguageID = (short)EntityEnums.LanguageEnum.English; // English - us
            iParams.DetailEntityObjects.Add(new DetailObjectInfo()
            {
                EntityName = vUser_Language.EntityName,
                AdditionalDataKey = "",
                EntitySet = user_language,
                FnName = RuleFunctionSEnum.Insert,
                FKColumnNameForAutoSet = vUser_Language.ColumnNames.UserID
            });

            Insert(user, iParams);
        }


        private static void GeneratePasswordHash(User user, string password)
        {
            user.PasswordSalt = Framework.Common.Security.PasswordHash.CreateSalt();
            user.PasswordHash = Framework.Common.Security.PasswordHash.CreateHash(password, user.PasswordSalt);
        }

        //public object RegisterQuick(UserRegisterQuickSP p)
        //{
        //    UserRegisterSP sp = new UserRegisterSP();
        //    UserBR biz = (UserBR)this.BusinessLogicObject;
        //    biz.RegisterQuick(p, new Framework.Business.BusinessRuleErrorList(), true);

        //    string randomPass = FWUtils.RandomUtils.RandomString(20);

        //    sp.FirstName = p.FirstName;
        //    sp.LastName = p.LastName;
        //    sp.PhoneNumber = p.PhoneNumber;
        //    sp.Password = randomPass;
        //    sp.ConfirmPassword = randomPass;
        //    sp.UserName = "User" + FWUtils.RandomUtils.RandomString(40, "0123456789");
        //    sp.Email = "XecareRandomEmail" + FWUtils.RandomUtils.RandomString(20) + "@" + "SmartTelemed.com";
        //    sp.DefaultRoleID = p.DefaultRoleID;
        //    sp.ReferrerUserID = p.ReferrerUserID;

        //    return Register(sp);
        //}

        /// <summary>
        /// Registers a user from doctor's panel by its minimum requirements
        /// </summary>
        /// <param name="p">register</param>
        /// <returns></returns>
        public object RegisterQuickFromDoctor(UserRegisterQuickFromDoctorSP p)
        {
            UserRegisterSP sp = new UserRegisterSP();
            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.RegisterQuickFromDoctor(p, new Framework.Business.BusinessRuleErrorList(), true);

            string randomPass = FWUtils.RandomUtils.RandomString(20);

            sp.FirstName = p.FirstName;
            sp.LastName = p.LastName;
            sp.PhoneNumber = p.PhoneNumber;
            sp.Password = randomPass;
            sp.ConfirmPassword = randomPass;
            sp.UserName = FWUtils.RandomUtils.RandomUserName();
            //sp.Email = "XecareRandomEmail" + FWUtils.RandomUtils.RandomString(20) + "@" + "Xecare.com";
            sp.DefaultRoleID = 1; // patient
            sp.ReferrerUserID = p.ReferrerUserID;
            sp.IsQuickRegister = true;

            User u = (User) Register(sp);

            try  // we need to add the new patient to the doctor's list
        	{	        
                Doctor_Patient doctorPatient = new Doctor_Patient();
                doctorPatient.DoctorID = p.ReferrerUserID;
                doctorPatient.PatientUserID = u.UserID;
                var doctor_patientService = Doctor_PatientEN.GetService();
                doctor_patientService.Insert(doctorPatient, new InsertParameters());

                // sending notification for continue registeration
                SendRegisterQuickFromDoctorNotification(p.ReferrerUserID, u);
	        }
	        catch (Exception ex)
	        {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, "PatientUserID = " + u.UserID);
	        }

            return u;
        }


        /// <summary>
        /// Changes the password.
        /// </summary>
        public void ChangePassword(UserChangePasswordSP p)
        {
            var user = GetByIDT(p.UserID);

            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.ChangePassword(user, p);

            // checking security
            if (user.UserID != FWUtils.SecurityUtils.GetCurrentUserIDLong())
                throw new ServiceSecurityException("Only the user can update change his password.");

            user.PasswordSalt = Framework.Common.Security.PasswordHash.CreateSalt();
            user.PasswordHash = Framework.Common.Security.PasswordHash.CreateHash(p.NewPassword, user.PasswordSalt);
            user.LastPasswordChangedDate = DateTime.UtcNow;
            user.FailedPasswordAttemptCount = 0;

            Update(user, new UpdateParameters());
        }


        /// <summary>
        /// change password for admins. This shouldn't be used by any other users because it allows to change password without having the previous password
        /// In addition, it can be used to reset password by the user
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="newPassword">The new password.</param>
        public void ChangePasswordAdmin(UserChangePasswordAdminSP p)
        {
            User user = (User)GetByUserName(p.UserName, GetSourceTypeEnum.Table);
            if (user == null)
                throw new UserException(BusinessErrorStrings.User.UserName_UserNameNotExistsInDatabase);

            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.ValidatePassword(p.NewPassword, new Framework.Business.BusinessRuleErrorList(), true);

            user.PasswordSalt = Framework.Common.Security.PasswordHash.CreateSalt();
            user.PasswordHash = Framework.Common.Security.PasswordHash.CreateHash(p.NewPassword, user.PasswordSalt);
            user.LastPasswordChangedDate = DateTime.UtcNow;
            user.FailedPasswordAttemptCount = 0;
            user.UserApprovalStatusID = (int)EntityEnums.UserApprovalStatusEnum.Approved; // unlocking the user information if it is locked

            Update(user, new UpdateParameters());
        }

        /// <summary>
        /// Checks the password.
        /// </summary>
        /// <returns>if username and password match, returns user object, otherwise returns null</returns>
        public object ValidateUserNamePassword(UserValidateUserNamePasswordSP p)
        {
            User user = (User) GetByUserName(p.UserName, GetSourceTypeEnum.Table);
            try 
	        {	        
                ValidatePasswordByUser(user, p.Password);
                return user;
	        }
	        catch (Exception)
	        {
                FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short) EntityEnums.AppLogType.User_FailedLogin, ExtraString1 = p.UserName });
		        if(p.ThrowIfError)
		            throw;
	        }

            return null;
        }

        /// <summary>
        /// Validates the password by user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        private void ValidatePasswordByUser(User user, string password)
        {
            bool validationResult = false;
            // if user was not provided (i.e. not found in database)
            if (user == null)
                throw new UserException(BusinessErrorStrings.PasswordValidation.UserName_Or_Password_Is_Not_Correct);

            // Check Canceled account
            if (user.UserApprovalStatusID == (int)EntityEnums.UserApprovalStatusEnum.Canceled)
                throw new UserException(BusinessErrorStrings.PasswordValidation.AccountCanceled);

            // Check Locked account
            if (user.UserApprovalStatusID == (int) EntityEnums.UserApprovalStatusEnum.Locked)
                throw new UserException(BusinessErrorStrings.PasswordValidation.AccountLocked);

            // check locked because of failed password
            if (user.UserApprovalStatusID == (int)EntityEnums.UserApprovalStatusEnum.FailedPasswordLocked)
                throw new UserException(BusinessErrorStrings.PasswordValidation.AccountFailedPasswordLocked);

            // check approval not rejected
            if (user.UserApprovalStatusID == (int)EntityEnums.UserApprovalStatusEnum.Rejected)
                throw new UserException(BusinessErrorStrings.PasswordValidation.ApprovalRejected);

            // check password
            validationResult = Framework.Common.Security.PasswordHash.ValidatePassword(password, user.PasswordSalt, user.PasswordHash);

            //updating failed attempts
            if (validationResult == false)
            {
                user.FailedPasswordAttemptCount = user.FailedPasswordAttemptCount + 1;
                if (user.FailedPasswordAttemptCount > ConfigurationBase.DefaultInstance.FailedPasswordCountAllowed)
                {
                    user.UserApprovalStatusID = (int)EntityEnums.UserApprovalStatusEnum.FailedPasswordLocked;
                    user.LastStatusChangeDate = DateTime.UtcNow;
                }
            }
            else
            {
                user.FailedPasswordAttemptCount = 0; // reset the failed password to prevent further mistakes
                user.LastLoginDate = DateTime.UtcNow;
            }

            this.Update(user, new UpdateParameters());


            if (validationResult == false)
                throw new UserException(BusinessErrorStrings.PasswordValidation.UserName_Or_Password_Is_Not_Correct);
        }

        /// <summary>
        /// Gets the data by provided user name from its view
        /// </summary>
        /// <param name="userName">the user name</param>
        /// <returns></returns>
        public vUser GetByUserNameV(string userName)
        {
            return (vUser)GetByUserName(userName, GetSourceTypeEnum.View);
        }

        /// <summary>
        /// Gets the data by provided user name from its table
        /// </summary>
        /// <param name="userName">the user name</param>
        /// <returns></returns>
        public User GetByUserNameT(string userName)
        {
            return (User)GetByUserName(userName, GetSourceTypeEnum.Table);
        }
             
        /// <summary>
        /// Gets the name of the by user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <returns></returns>
        private object GetByUserName(string userName, GetSourceTypeEnum sourceType)
        {
            if (string.IsNullOrEmpty(userName))
                throw new UserException(BusinessErrorStrings.User.UserName_UserNameCannotBeNullOrEmpty);

                
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vUser.ColumnNames.UserName, userName.ToLower()));

            System.Collections.IList userList = GetByFilter(new GetByFilterParameters(filter, new SortExpression(), 0, 1, null, sourceType));
            if (userList.Count == 0)
                return null; //throw new UserException(string.Format(BusinessErrorStrings.User.UserName_UserNameNotExistsInDatabase, userName));

            return userList[0];
        }

        /// <summary>
        /// Gets user data by email address
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="sourceType">source type</param>
        /// <returns></returns>
        private object GetByEmail(string email, GetSourceTypeEnum sourceType)
        {
            if (string.IsNullOrEmpty(email))
                throw new UserException(BusinessErrorStrings.User.Email_InvalidEmailAddress);

            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vUser.ColumnNames.Email, email.ToLower()));

            System.Collections.IList userList = GetByFilter(new GetByFilterParameters(filter, new SortExpression(), 0, 1, null, sourceType));
            if (userList.Count == 0)
                return null; //throw new UserException(string.Format(BusinessErrorStrings.User.UserName_UserNameNotExistsInDatabase, userName));

            return userList[0];
        }


        /// <summary>
        /// changes status of a user to approved status
        /// </summary>
        /// <param name="userId">user identifier</param>
        public void Approve(long userId)
        {
            ChangeApprovalStatus(userId, EntityEnums.UserApprovalStatusEnum.Approved);
        }

        /// <summary>
        /// changes status of a user to locked status
        /// </summary>
        /// <param name="userId">user identifier</param>
        public void Lock(long userId)
        {
            ChangeApprovalStatus(userId, EntityEnums.UserApprovalStatusEnum.Locked);
        }

        /// <summary>
        /// changes status of a user to rejected status
        /// </summary>
        /// <param name="userId">user identifier</param>
        public void Reject(long userId)
        {
            ChangeApprovalStatus(userId, EntityEnums.UserApprovalStatusEnum.Rejected);
        }

        /// <summary>
        /// changes status of a user to Approved status (unlocks a locked account)
        /// </summary>
        /// <param name="userId">user identifier</param>
        public void UnLock(long userId)
        {
            ChangeApprovalStatus(userId, EntityEnums.UserApprovalStatusEnum.Approved);
        }

        /// <summary>
        /// Cancels the membership.
        /// </summary>
        /// <param name="p">parameters</param>
        public void CancelMembership(UserCancelMembershipSP p)
        {
            ChangeApprovalStatus(p.UserID, EntityEnums.UserApprovalStatusEnum.Canceled);
        }

        /// <summary>
        /// changes approval status of a user
        /// </summary>
        /// <param name="userId">user identifier</param>
        /// <param name="newStatus">new status</param>
        private void ChangeApprovalStatus(long userId, EntityEnums.UserApprovalStatusEnum newStatus)
        {
            User user = (User)GetByID(userId, new GetByIDParameters(GetSourceTypeEnum.Table, GetModeEnum.Load));

            if (user.UserApprovalStatusID == (int)EntityEnums.UserApprovalStatusEnum.IncompleteRegistration)
                throw new UserException(BusinessErrorStrings.User.ApprovalChange_RegistrationOfThisUserIsIncomplete);

            // changes the data in the database
            user.UserApprovalStatusID = (int)newStatus;
            user.LastStatusChangeDate = DateTime.UtcNow;
            this.Update(user, new UpdateParameters());
        }


        public override void DoAction(string recordId, string actionName, string parameters)
        {
            throw new NotImplementedException();
            //long userID = Convert.ToInt64(recordId);
            //User user = (User)GetByID(userID, new GetByIDParameters(GetSourceTypeEnum.Table, GetModeEnum.Load));

            //if (user.UserApprovalStatusID == (int)EntityEnums.UserApprovalStatusEnum.IncompleteRegistration)
            //    throw new UserException(BusinessErrorStrings.User.ApprovalChange_RegistrationOfThisUserIsIncomplete);

            //switch (actionName)
            //{
            //    case UserEN.Action_Approve:
            //        ChangeApprovalStatus(user, EntityEnums.UserApprovalStatusEnum.Approved);
            //        break;
            //    case UserEN.Action_Lock:
            //        ChangeApprovalStatus(user, EntityEnums.UserApprovalStatusEnum.Locked);
            //        break;
            //    case UserEN.Action_Reject:
            //        ChangeApprovalStatus(user, EntityEnums.UserApprovalStatusEnum.Rejected);
            //        break;
            //    case UserEN.Action_UnLock:
                    
            //        if (user.UserApprovalStatusID != (int) EntityEnums.UserApprovalStatusEnum.Locked &&
            //            user.UserApprovalStatusID != (int) EntityEnums.UserApprovalStatusEnum.FailedPasswordLocked)
            //            throw new UserException(BusinessErrorStrings.User.ApprovalChange_OnlyLockedAccountsCanBeUnlocked);

            //            ChangeApprovalStatus(user, EntityEnums.UserApprovalStatusEnum.Approved);
            //        break;
            //    case UserEN.Action_ChangePasswordAdmin:
            //        ChangePasswordAdmin(new UserChangePasswordAdminSP() { userName = user.UserName, newPassword = parameters });
            //        break;
            //}

        }



        /// <summary>
        /// Sends the email verification template.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public void SendEmailVerificationLetter(long userId)
        {
            long userID = Convert.ToInt64(userId);
            User user = (User)GetByID(userID, new GetByIDParameters(GetSourceTypeEnum.Table));
            if (user == null)
                throw new UserException(StringMsgs.BusinessErrors.UserNotExistsInDatabase);

            // checking security
            if (user.UserID != FWUtils.SecurityUtils.GetCurrentUserIDLong())
                throw new ServiceSecurityException();

            user.EmailVerificationCode = Guid.NewGuid();
            user.IsEmailVerified = false;

            Notification notification = CreateEmailVerificationNotification(user);

            // inserting notification in one transaction
            UpdateParameters updateParameters = new UpdateParameters();
            DetailObjectInfo detailObject = new DetailObjectInfo();
            detailObject.EntityName = vNotification.EntityName;
            detailObject.AdditionalDataKey = "";
            detailObject.EntitySet = notification;
            detailObject.FnName = RuleFunctionSEnum.Insert;
            updateParameters.DetailEntityObjects.Add(detailObject);

            this.Update(user, updateParameters);
        }

        /// <summary>
        /// Sends the email verification template.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public void SendPhoneNumberVerification(long userId)
        {
            long userID = Convert.ToInt64(userId);
            User user = (User)GetByID(userID, new GetByIDParameters(GetSourceTypeEnum.Table));
            if (user == null)
                throw new UserException(StringMsgs.BusinessErrors.UserNotExistsInDatabase);
            
            // checking security
            if (user.UserID != FWUtils.SecurityUtils.GetCurrentUserIDLong())
                throw new ServiceSecurityException();

            GeneratePhoneVerificationCode(user);

            Notification notification = CreatePhoneNumberVerificationNotification(user);

            // inserting notification in one transaction
            UpdateParameters updateParameters = new UpdateParameters();
            DetailObjectInfo detailObject = new DetailObjectInfo();
            detailObject.EntityName = vNotification.EntityName;
            detailObject.AdditionalDataKey = "";
            detailObject.EntitySet = notification;
            detailObject.FnName = RuleFunctionSEnum.Insert;
            updateParameters.DetailEntityObjects.Add(detailObject);

            this.Update(user, updateParameters);
        }

        /// <summary>
        /// generates a new phone verification code
        /// </summary>
        /// <returns></returns>
        private static void GeneratePhoneVerificationCode(User user)
        {
            user.PhoneVerificationCode = FWUtils.RandomUtils.RandomNumber(10000000, 99999999);
            user.IsPhoneVerified = false;
        }

        /// <summary>
        /// Creates the email verification notification.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        private static Notification CreateEmailVerificationNotification(User user)
        {
            //string verificationLink = string.Format(FWUtils.ConfigUtils.GetAppSettings().Project.EmailVerificationUrl, user.EmailVerificationCode.ToString());
            Notification notification = new Notification();
            notification.InsertDate = DateTime.UtcNow;
            notification.EmailSendDate = null;
            notification.SMSSendDate = null;
            notification.SenderUserID = null;
            notification.ReceiverUserID = user.UserID;
            notification.NotificationTemplateID = (int)EntityEnums.NotificationTemplateEnum.EmailVerification;
            notification.ParametersValues = null;// All parameters moved to NotificationSenderBase class to reduce database storage size.
            notification.SMSNotificationStatusID = (byte)EntityEnums.NotificationStatusEnum.Pending;
            notification.EmailNotificationStatusID = (byte)EntityEnums.NotificationStatusEnum.Pending;
            notification.NotificationErrorMessage = null;
            notification.IsSMS = false;
            notification.IsEmail = true;
            notification.IsWebMessage = false;
            notification.IsMobilePushMessage = false;
            notification.GotoURL = null;
            return notification;
        }

        /// <summary>
        /// Creates the email verification notification.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        private static Notification CreatePhoneNumberVerificationNotification(User user)
        {
            //string verificationLink = string.Format(FWUtils.ConfigUtils.GetAppSettings().Project.EmailVerificationUrl, user.EmailVerificationCode.ToString());
            Notification notification = new Notification();
            notification.InsertDate = DateTime.UtcNow;
            notification.ReceiverUserID = user.UserID;
            notification.NotificationTemplateID = (byte)EntityEnums.NotificationTemplateEnum.PhoneNumberVerification;
            notification.SMSNotificationStatusID = (byte)EntityEnums.NotificationStatusEnum.Pending;
            notification.IsSMS = true;
            return notification;
        }


        /// <summary>
        /// Creates the phone number verification notification.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        private static Notification CreatePhoneNumberNotification(User user)
        {
            //string verificationLink = string.Format(FWUtils.ConfigUtils.GetAppSettings().Project.EmailVerificationUrl, user.EmailVerificationCode.ToString());
            Notification notification = new Notification();
            notification.InsertDate = DateTime.UtcNow;
            notification.EmailSendDate = null;
            notification.SMSSendDate = null;
            notification.SenderUserID = null;
            notification.ReceiverUserID = user.UserID;
            notification.NotificationTemplateID = (short)EntityEnums.NotificationTemplateEnum.PhoneNumberVerification;
            notification.ParametersValues = null;// All parameters moved to NotificationSenderBase class to reduce database storage size.
            notification.SMSNotificationStatusID = (byte)EntityEnums.NotificationStatusEnum.Pending;
            notification.EmailNotificationStatusID = (byte)EntityEnums.NotificationStatusEnum.Pending;
            notification.NotificationErrorMessage = null;
            notification.IsSMS = true;
            notification.IsEmail = false;
            notification.IsWebMessage = false;
            notification.IsMobilePushMessage = false;
            notification.GotoURL = null;
            return notification;
        }


        /// <summary>
        /// Verifies the email.
        /// </summary>
        /// <param name="verificationCode">The verification code.</param>
        public void VerifyEmail(UserVerifyEmailSP p)
        {
            bool couldnotVerify = true;
            try
            {
                if (string.IsNullOrEmpty(p.EmailVerificationCode) == false)
                {
                    Guid vCode;
                    if (Guid.TryParse(p.EmailVerificationCode, out vCode))
                    {
                        FilterExpression filter = new FilterExpression();
                        filter.AddFilter(new Filter(vUser.ColumnNames.EmailVerificationCode, vCode));
                        filter.AddFilter(new Filter(vUser.ColumnNames.Email, p.Email));
                        List<User> users = (List<User>)GetByFilter(new GetByFilterParameters(filter));
                        if (users.Count == 1)
                        {
                            User user = users[0];
                            user.IsEmailVerified = true;
                            Update(user, new UpdateParameters());
                            couldnotVerify = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, FWUtils.EntityUtils.ConvertObjectToString(p));
                couldnotVerify = true;
            }

            if (couldnotVerify)
                throw new UserException(BusinessErrorStrings.User.InvalidEmailCode);
        }


        /// <summary>
        /// Verifies the phone number.
        /// </summary>
        /// <param name="p">parameters</param>
        public void VerifyPhoneNumber(UserVerifyPhoneNumberSP p)
        {
            bool couldnotVerify = true;
            try
            {
                if (p.PhoneVerificationCode != 0)
                {
                    FilterExpression filter = new FilterExpression();
                    filter.AddFilter(new Filter(vUser.ColumnNames.PhoneVerificationCode, p.PhoneVerificationCode));
                    filter.AddFilter(new Filter(vUser.ColumnNames.PhoneNumber, p.PhoneNumber));
                    List<User> users = (List<User>)GetByFilter(new GetByFilterParameters(filter));
                    if (users.Count == 1)
                    {
                        User user = users[0];
                        user.IsPhoneVerified = true;
                        Update(user, new UpdateParameters());
                        couldnotVerify = false;
                    }
                }
            }
            catch (Exception ex)
            {
                FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, FWUtils.EntityUtils.ConvertObjectToString(p));
                couldnotVerify = true;
            }

            if (couldnotVerify)
                throw new UserException(BusinessErrorStrings.User.InvalidEmailCode);
        }

        /// <summary>
        /// Gets the world zone identifier.
        /// If it couldn't find the return it returns DateTimeEpoch.DefaultTimeZoneID
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public short GetWorldZoneIDByUserID(long userId)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(new Filter(vUser.ColumnNames.UserID, userId));
            List<String> columns = new List<string>();
            columns.Add(vUser.ColumnNames.UserID);
            columns.Add(vUser.ColumnNames.WorldTimeZoneID);
            List<User> users = (List<User>) GetByFilter(new GetByFilterParameters(filter, new SortExpression(), 0, 1, columns, GetSourceTypeEnum.Table));
            if (users.Count > 0)
            {
                return users[0].WorldTimeZoneID;
            }
            return DateTimeEpoch.DefaultTimeZoneID;
        }

        /// <summary>
        /// updates the user profile based on the provided information
        /// </summary>
        /// <param name="p">parameters</param>
        public void UpdateProfileInfo(UserUpdateProfileInfoSP p)
        {
            User user = (User)GetByID(p.UserID, new GetByIDParameters(GetSourceTypeEnum.Table, GetModeEnum.Load));

            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.UpdateProfileInfo(p, user);

            // checking security
            if (user.UserID != FWUtils.SecurityUtils.GetCurrentUserIDLong())
                throw new ServiceSecurityException("Only the user can update his own profile.");

            bool sendEmailVerification = false;
            bool sendPhoneNumberVerification = false;
            
            user.UserName = p.UserName.ToLower();
            user.FirstName = p.FirstName;
            user.LastName = p.LastName;

            if (user.Email != p.Email.ToLower())
            {
                user.Email = p.Email.ToLower();
                user.IsEmailVerified = false;
                sendEmailVerification = true;
            }          

            if (user.PhoneNumber != p.PhoneNumber)
            {
                user.PhoneNumber = p.PhoneNumber;
                //user.PhoneNumberSearchable = UTD.Tricorder.Common.PhoneNumberUtils.MakeSearchablePhoneNumber(p.PhoneNumber);
                user.IsPhoneVerified = false;
                sendPhoneNumberVerification = true;
            }

            Update(user); // updates the user information

            // sending verification letters
            if (sendEmailVerification)
                SendEmailVerificationLetter(user.UserID);

            if (sendPhoneNumberVerification)
                SendPhoneNumberVerification(user.UserID);
        }



        /// <summary>
        /// Creates the quick register notification
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        private static Notification CreateRegisterQuickFromDoctorNotification(long doctorId, User receiverUser)
        {
            string continueRegUrl = FWUtils.ConfigUtils.GetAppSettings().Project.GetContinueQuickRegisterUrl(receiverUser.UserID, receiverUser.PhoneVerificationCode);

            Notification notification = new Notification();
            notification.InsertDate = DateTime.UtcNow;
            notification.EmailSendDate = null;
            notification.SMSSendDate = null;
            notification.SenderUserID = doctorId;
            notification.ReceiverUserID = receiverUser.UserID;
            notification.NotificationTemplateID = (int)EntityEnums.NotificationTemplateEnum.DoctorQuickRegisterAPatient;
            TemplateParams p = new TemplateParams();
            p.AddParameter("ContinueRegLink", continueRegUrl);
            notification.SetParametersValues(p);
            notification.SMSNotificationStatusID = (int)EntityEnums.NotificationStatusEnum.Pending;
            notification.EmailNotificationStatusID = (int)EntityEnums.NotificationStatusEnum.Pending;
            notification.NotificationErrorMessage = null;
            notification.IsSMS = true;
            notification.IsEmail = true;
            notification.IsWebMessage = false;
            notification.IsMobilePushMessage = false;
            notification.GotoURL = null;
            return notification;
        }

        /// <summary>
        /// Sends quick registeration notification to the newly registered user over the phone
        /// </summary>
        /// <param name="doctorId">doctor identifier</param>
        /// <param name="registeredUser"></param>
        public void SendRegisterQuickFromDoctorNotification(long doctorId, User registeredUser)
        {
            Notification n = CreateRegisterQuickFromDoctorNotification(doctorId, registeredUser);
            NotificationEN.GetService().Insert(n, new InsertParameters());
        }

        /// <summary>
        /// Gets users data by its phone number information for continuing quick registration
        /// if the person is already completed its registration then, throws a userexception
        /// if the data has not found, it returns a userexception
        /// </summary>
        /// <param name="p"></param>
        public vUser GetDataByPhoneForQReg(UserGetDataByPhoneForQRegSP p)
        {
            FilterExpression filter = new FilterExpression();
            filter.AddFilter(vUser.ColumnNames.PhoneNumber, p.PhoneNumber);
            filter.AddFilter(vUser.ColumnNames.PhoneVerificationCode, p.PhoneVerificationCode);

            List<string> columns = new List<string>();
            columns.Add(vUser.ColumnNames.UserID);
            columns.Add(vUser.ColumnNames.PhoneNumber);
            columns.Add(vUser.ColumnNames.PhoneVerificationCode);
            columns.Add(vUser.ColumnNames.FirstName);
            columns.Add(vUser.ColumnNames.LastName);
            columns.Add(vUser.ColumnNames.NamePrefix);
            columns.Add(vUser.ColumnNames.UserApprovalStatusID);

            var data = GetByFilterV(new GetByFilterParameters(filter, new SortExpression(), 0, 1, columns, GetSourceTypeEnum.Table));
            if (data.Count == 0)
            {
                throw new UserException(BusinessErrorStrings.User.GetDataByPhoneForQReg_NotFound);
            }
            else
            {
                if (data[0].UserApprovalStatusID != (int)EntityEnums.UserApprovalStatusEnum.IncompleteRegistration)
                    throw new UserException(BusinessErrorStrings.User.GetDataByPhoneForQReg_UserApprovalStatusIDNotIncomplete);
                return data[0];
            }
        }

        /// <summary>
        /// continues quick registration for a user
        /// </summary>
        /// <param name="p"></param>
        public void ContinueQReg(UserContinueQRegSP p)
        {
            vUser u = GetDataByPhoneForQReg(new UserGetDataByPhoneForQRegSP()
            {
                PhoneVerificationCode = p.PhoneVerificationCode,
                PhoneNumber = p.PhoneNumber
            });

            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.ContinueQReg(p);

            var user = GetByIDT(u.UserID);
            user.Email = p.Email.ToLower();
            user.FirstName = p.FirstName;
            user.LastName = p.LastName;
            user.UserName = p.UserName.ToLower();
            user.UserApprovalStatusID = (int)EntityEnums.UserApprovalStatusEnum.WaitingForApproval;
            GeneratePasswordHash(user, p.Password);
            Update(user);
        }

        /// <summary>
        /// Requests for reset password. It generates a new reset password code
        /// so that the user can reset its password
        /// </summary>
        /// <param name="p">parameters</param>
        public void ResetPasswordRequest(UserResetPasswordRequestSP p)
        {
            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.ResetPasswordIsValidEmailOrPhone(p.EmailOrPhoneNumber);

            User u = GetUserForResetPassword(p.EmailOrPhoneNumber);
            biz.ResetPasswordRequest(p, u);

            u.ResetPasswordCode = FWUtils.RandomUtils.RandomNumber(100000,999999);
            u.ResetPasswordRequestDate = DateTime.UtcNow;

            var notification = CreateResetPasswordRequestNotification(u, p.EmailOrPhoneNumber);

            UpdateParameters up = new UpdateParameters();
            up.DetailEntityObjects.Add(new DetailObjectInfo()
            {
                EntityName = vNotification.EntityName,
                EntitySet = notification,
                FnName = RuleFunctionSEnum.Insert
            });

            Update(u, up);
        }



        /// <summary>
        /// Resets a user password
        /// </summary>
        /// <param name="p">parameters</param>
        public void ResetPassword(UserResetPasswordSP p)
        {
            UserBR biz = (UserBR)this.BusinessLogicObject;
            biz.ResetPasswordIsValidEmailOrPhone(p.EmailOrPhoneNumber);

            User user = GetUserForResetPassword(p.EmailOrPhoneNumber);
            biz.ResetPassword(p, user);

            biz.ValidatePassword(p.NewPassword, new Framework.Business.BusinessRuleErrorList(), true);

            user.PasswordSalt = Framework.Common.Security.PasswordHash.CreateSalt();
            user.PasswordHash = Framework.Common.Security.PasswordHash.CreateHash(p.NewPassword, user.PasswordSalt);
            user.LastPasswordChangedDate = DateTime.UtcNow;
            user.FailedPasswordAttemptCount = 0;
            user.ResetPasswordCode = null;
            user.ResetPasswordRequestDate = null;

            Update(user);

            SendResetPasswordChangedNotification(user);

            FWUtils.ExpLogUtils.Logger.WriteLog(new AppLog() { AppLogTypeID = (short)EntityEnums.AppLogType.User_ResetPassword, ExtraBigInt = user.UserID });
        }



        /// <summary>
        /// Gets user information for reset password
        /// </summary>
        /// <param name="emailOrPhoneNumber">email or phone number of the user</param>
        /// <returns></returns>
        private User GetUserForResetPassword(string emailOrPhoneNumber)
        {
            string fieldName = vUser.ColumnNames.Email;
            if (emailOrPhoneNumber.IndexOf('@') < 0)
                fieldName = vUser.ColumnNames.PhoneNumber;

            FilterExpression filter = new FilterExpression();
            filter.AddFilter(fieldName, emailOrPhoneNumber.ToLower());

            //List<string> cols = new List<string>();
            //cols.Add(vUser.ColumnNames.UserID);
            //cols.Add(vUser.ColumnNames.Email);
            //cols.Add(vUser.ColumnNames.ResetPasswordCode);
            //cols.Add(vUser.ColumnNames.ResetPasswordRequestDate);
            //cols.Add(vUser.ColumnNames.PhoneNumber);

            User u = null;
            var list = GetByFilterT(new GetByFilterParameters(filter, null, 0, 1, null, GetSourceTypeEnum.Table));
            if (list.Count == 1)
                u = list[0];
            return u;
        }



        /// <summary>
        /// Creates the quick register notification
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        private static Notification CreateResetPasswordRequestNotification(User receiverUser, string emailOrPhoneNumber)
        {
            string resetPasswordUrl = FWUtils.ConfigUtils.GetAppSettings().Project.GetResetPasswordUrl(emailOrPhoneNumber, receiverUser.ResetPasswordCode.Value);

            Notification notification = new Notification();
            notification.ReceiverUserID = receiverUser.UserID;
            notification.NotificationTemplateID = (int)EntityEnums.NotificationTemplateEnum.ResetPasswordRequest;
            notification.EmailNotificationStatusID = (int)EntityEnums.NotificationStatusEnum.Pending;
            notification.SMSNotificationStatusID = (int)EntityEnums.NotificationStatusEnum.Pending;
            TemplateParams p = new TemplateParams();
            p.AddParameter("Code", receiverUser.ResetPasswordCode.Value.ToString());
            p.AddParameter("ResetUrl", resetPasswordUrl);
            notification.SetParametersValues(p);
            notification.IsSMS = true;
            notification.IsEmail = true;
            return notification;
        }


        /// <summary>
        /// Creates the quick register notification
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        private static Notification CreateResetPasswordNotification(User receiverUser)
        {
            Notification notification = new Notification();
            notification.ReceiverUserID = receiverUser.UserID;
            notification.NotificationTemplateID = (int)EntityEnums.NotificationTemplateEnum.ResetPasswordChanged;
            notification.EmailNotificationStatusID = (int)EntityEnums.NotificationStatusEnum.Pending;
            notification.SMSNotificationStatusID = (int)EntityEnums.NotificationStatusEnum.Pending;
            notification.IsSMS = true;
            notification.IsEmail = true;
            return notification;
        }


        /// <summary>
        /// Sends quick registeration notification to the newly registered user over the phone
        /// </summary>
        /// <param name="registeredUser"></param>
        public void SendResetPasswordChangedNotification(User registeredUser)
        {
            Notification n = CreateResetPasswordNotification(registeredUser);
            NotificationEN.GetService().Insert(n, new InsertParameters());
        }

        /// <summary>
        /// Changes Is Online status for a user
        /// </summary>
        public void ChangeIsOnline(long UserID, bool isOnline)
        {
            var user = GetByIDT(UserID);
            user.IsOnline = isOnline;
            if (isOnline == true)
                user.LastOnlineDate = DateTime.UtcNow;
            Update(user);
        }


        protected override void onAfterGetByID(object entityObj, object typedKeyObject, GetByIDParameters parameters)
        {
            if (this.AdditionalDataKey == UserEN.AdditionalData_ProfileEdit
                || this.AdditionalDataKey == UserEN.AdditionalData_SearchFromVisitBook)
            {
                var profileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)typedKeyObject);
                FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "UserProfilePicUrl", entityObj, profileImageUrl);
            }
        }

        protected override void onAfterGetByFilter(System.Collections.IList list, GetByFilterParameters parameters)
        {
            if (this.AdditionalDataKey == UserEN.AdditionalData_ProfileEdit
                || this.AdditionalDataKey == UserEN.AdditionalData_SearchFromVisitBook)
            {
                foreach (EntityObjectBase entityObj in list)
                {
                    long typedKeyObject = (long)entityObj.GetPrimaryKeyValue();
                    var profileImageUrl = AppFileEN.GetService().GetUserProfileImageUrl((long)typedKeyObject);
                    FWUtils.EntityUtils.SetEntityFieldValue(this.Entity, "UserProfilePicUrl", entityObj, profileImageUrl);
                }
            }
        }


        /// <summary>
        /// Registers a user and does login authentication
        /// </summary>
        /// <param name="p">parameters</param>
        public RegisterAndGetLoginTokenSecureRP RegisterAndGetLoginToken(RegisterInfoOffsite p)
        {
            try
            {
                User user = RegisterOffsite(ref p);
                return new RegisterAndGetLoginTokenSecureRP() { Result = true, LoginToken = GenerateLoginToken(user.UserID) };
            }
            catch (Exception ex)
            {
                if (!(ex is BRException))
                    FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, p);
                return new RegisterAndGetLoginTokenSecureRP() { Result = false, Error = FWUtils.ExpLogUtils.ExceptionTranslator.TryToTranslate(ex).Message };
            }

        }

        private User RegisterOffsite(ref RegisterInfoOffsite p)
        {
            User user = (User)GetByEmail(p.Email.ToLower(), GetSourceTypeEnum.Table);
            if (user == null)
            {
                // this email doesn't exists and we need to register the user

                UserBR biz = (UserBR)this.BusinessLogicObject;
                biz.RegisterAndLogin(p, new Framework.Business.BusinessRuleErrorList(), true);
                //biz.ValidatePassword(p.password, new Framework.Business.BusinessRuleErrorList(), true);

                user = GetUserDataForInsert(new UserRegisterSP()
                {
                    ConfirmPassword = p.Password,
                    Password = p.Password,
                    DefaultRoleID = p.DefaultRoleID,
                    Email = p.Email.ToLower(),
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    IsQuickRegister = true,
                    PhoneNumber = p.PhoneNumber,
                    ReferrerUserID = null,
                    UserName = FWUtils.RandomUtils.RandomUserName()
                });
                InsertUserWithDependancies(user);
            }
            else
            {

                SameSiteIDSecurity.Check("Access Denied. You don't have access to accounts of other sites.", user, vUser.ColumnNames.InsertSiteID);
                
                var newPass = Framework.Common.Security.PasswordHash.CreateHash(p.Password, user.PasswordSalt);
                // if password had changed, we need to update the password
                if (Convert.ToBase64String(newPass) != Convert.ToBase64String(user.PasswordHash))
                {
                    GeneratePasswordHash(user, p.Password);
                    Update(user);
                }
            }

            return user;
        }

        /// <summary>
        /// Registers a user and does login authentication
        /// Since this is very vulnearable service, we made it in a way that 
        /// the caller should encrypt the request to access it
        /// We probably don't need to call it
        /// </summary>
        /// <param name="p">parameters</param>
        public RegisterAndGetLoginTokenSecureRP RegisterAndGetLoginTokenSecure(RegisterAndGetLoginTokenSecureSP p)
        {
            RegisterInfoOffsite p2 = DecryptRegisterInfo(p.RegisterInfoEncBase64);

            try 
	        {
                return RegisterAndGetLoginToken(p2);
	        }
	        catch (Exception)
	        {
		        throw new UserException("Login failed because the format of data is not valid from server");
	        }

        }

        private static RegisterInfoOffsite DecryptRegisterInfo(string registerInfoEncBase64)
        {
            string decryptionKey = "64C6B83A-0EFF-4122-A15A-507D4765FC9A";

            //byte[] keyBytes = { 95, 8, 90, 86, 202, 165, 217, 248, 62, 130, 210, 231, 66, 233, 34, 176, 134, 213, 7, 151, 11, 74, 47, 133, 215, 172, 14, 244, 29, 157, 157, 1 };
            string decyptedString = "";
            try
            {
                decyptedString = FWUtils.EncryptionUtils.DecryptString(registerInfoEncBase64, decryptionKey);
            }
            catch (Exception)
            {
                throw new UserException("Login failed because security decryption didn't work");
            }

            RegisterInfoOffsite p2 = (RegisterInfoOffsite)
                FWUtils.EntityUtils.JsonDeserializeObject(decyptedString, typeof(RegisterInfoOffsite));

            return p2;
        }


        private const string tokenEncryptionKey = "923rf29ejn*^^#";


        /// <summary>
        /// Generates a login token for automated login of a certain user
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        private string GenerateLoginToken(long userId)
        {
            LoginTokenData data = new LoginTokenData();
            data.UserID = userId;
            data.IssueDateTime = DateTimeEpoch.GetUtcNowEpoch();
            data.SetChecksum();
            string tokenJson = FWUtils.EntityUtils.JsonSerializeObject(data);
            return FWUtils.EncryptionUtils.EncryptString(tokenJson, tokenEncryptionKey);
        }


        /// <summary>
        /// Validates a generated login token an
        /// </summary>
        /// <param name="loginToken"></param>
        /// <returns></returns>
        public long? LoginWithLoginToken(string loginToken)
        {
            string tokenJson = FWUtils.EncryptionUtils.DecryptString(loginToken, tokenEncryptionKey);
            LoginTokenData data = (LoginTokenData) FWUtils.EntityUtils.JsonDeserializeObject(tokenJson, typeof(LoginTokenData));
            if (data.IsChecksumValid() == false)
                throw new HoneyPotException("Login token has tamered.");
            else
                return data.UserID;
        }

        /// <summary>
        /// Uses Register offsite info to login
        /// </summary>
        /// <param name="registerOffsiteInfo">encrypted information of offsite register</param>
        /// <returns></returns>
        public User LoginWithRegisterOffsiteInfo(string registerOffsiteInfo)
        {
            var l = DecryptRegisterInfo(registerOffsiteInfo);
            return RegisterOffsite(ref l);
        }


        #endregion

    }
}

