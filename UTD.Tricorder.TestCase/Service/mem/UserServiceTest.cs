using UTD.Tricorder.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.BusinessRule;
using System.Collections.Generic;
using UTD.Tricorder.Common.ServiceInterfaces;
using Framework.TestCase.CommonClasses;
using UTD.Tricorder.Common.SP;
using UTD.Tricorder.Common;
using UTD.Tricorder.Common.EntityInfos;

namespace UTD.Tricorder.TestCase
{

    [DeploymentItem("_Config\\")]
    /// <summary>
    ///This is a test class for UserServiceTest and is intended
    ///to contain all UserServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{

        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for UserService Constructor
        ///</summary>
        [TestMethod()]
        public void UserServiceConstructorTest()
        {
            UserService target = CreateNewUserService();
        }

        private UserService CreateNewUserService()
        {
            return (UserService)EntityFactory.GetEntityServiceByName(vUser.EntityName, "");
        }


        ///// <summary>
        /////A test for GetByUserName
        /////</summary>
        //[TestMethod()]
        //public void GetByUserNameTest()
        //{
        //    UserService target = CreateNewUserService(); 
        //    string userName = string.Empty;
        //    object actual;
        //    try
        //    {
        //        actual = target.GetByUserNameT(userName);
        //    }
        //    catch (UserException ex)
        //    {
        //        Assert.AreEqual(ex.Message, BusinessErrorStrings.User.UserName_UserNameCannotBeNullOrEmpty);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        ///A test for GetByUserName
        ///</summary>
        [TestMethod()]
        public void GetByUserNameTest2()
        {
            UserService target = CreateNewUserService();
            string userName = "testExistingUserName";
            User actual = (User) target.GetByUserNameT(userName);
            Assert.AreEqual(actual.UserName, userName.ToLower());
            Assert.AreEqual(actual.UserID, 1);
            Assert.AreEqual(actual.Email, "ValidRegisteredEmailTest@testdomain.com".ToLower());
        }

        /// <summary>
        ///A test for GetByUserName
        ///</summary>
        [TestMethod()]
        public void GetByUserNameTest3()
        {
            UserService target = CreateNewUserService();
            string userName = "testExistingUserName";
            vUser actual = (vUser)target.GetByUserNameV(userName);
            Assert.AreEqual(actual.UserName, userName.ToLower());
            Assert.AreEqual(actual.UserID, 1);
            Assert.AreEqual(actual.Email, "ValidRegisteredEmailTest@testdomain.com".ToLower());
        }


        /// <summary>
        ///A test for Register
        ///</summary>
        [TestMethod()]
        public void RegisterTest()
        {
            UserService target = CreateNewUserService();
            UserRegisterSP p = new UserRegisterSP();
            p.UserName = TestUtils.RandomUtils.RandomUserName(); 
            p.FirstName = TestUtils.RandomUtils.RandomString(100);
            p.LastName = TestUtils.RandomUtils.RandomString(100); 
            p.Password = TestUtils.RandomUtils.RandomString(64);
            p.ConfirmPassword = p.Password;
            p.Email = TestUtils.RandomUtils.RandomEmail(); 
            p.PhoneNumber = TestUtils.RandomUtils.RandomPhoneNumber(); 
            //p.membershipAreaID = 0;
            p.DefaultRoleID = (long) EntityEnums.RoleEnum.Patient;
            target.Register(p);

            User u = (User) target.GetByUserNameT(p.UserName);
            Assert.AreEqual(p.UserName.ToLower(), u.UserName);
            Assert.AreEqual(p.Email.ToLower(), u.Email);

            UserInRoleService uInRoleService = (UserInRoleService)EntityFactory.GetEntityServiceByName(vUserInRole.EntityName, "");
            var count = uInRoleService.GetCount(new FilterExpression(new Filter(vUserInRole.ColumnNames.UserID, u.UserID)));
            Assert.AreEqual(1, count , "UserInRole should have 1 default role"); // we expect that user be in one of the assigned roles

            TestUtils.Access.SetPrivateStaticField(typeof(FWUtils), "_SecurityUtils", new SecurityUtilsFake(u.UserID));

            var ulService = User_LanguageEN.GetService();
            var count2 = uInRoleService.GetCount(new FilterExpression(new Filter(vUser_Language.ColumnNames.UserID, u.UserID)));
            Assert.AreEqual(1, count2, "User_Language should have 1 default language"); // we expect that user be in one of the assigned roles
        }

        /// <summary>
        ///A test for Register
        ///registeration of existing username should fail
        ///</summary>
        [TestMethod()]
        public void RegisterTest2()
        {
            UserService target = CreateNewUserService();
            UserRegisterSP p = new UserRegisterSP();
            p.UserName = "testExistingUserName";
            p.FirstName = "fName";
            p.LastName = "lName";
            p.Password = "testSecurePasssword123!";
            p.ConfirmPassword = p.Password;
            p.Email = "ValidRegisteredEmailTest@testdomain.com";
            p.PhoneNumber = TestUtils.RandomUtils.RandomPhoneNumber();
            //p.membershipAreaID = 0;
            p.DefaultRoleID = (long)EntityEnums.RoleEnum.Patient; 
            try
            {
                target.Register(p);
                throw new Exception("Test failed because of duplicate username couldn't be found in database");
            }
            catch (BRException ex)
            {
                Assert.AreEqual(1, ex.RuleErrors.Count);
                Assert.AreEqual(BusinessErrorStrings.User.UserName_DuplicateUserName, ex.RuleErrors[0].ErrorDescription);
                // test success;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        ///A test for ValidateEmail
        ///This is just integration testing. We don't need to test all possible email values here as we did it in its business unit testing
        ///</summary>
        [TestMethod()]
        public void ValidateEmailTest()
        {
            UserService target = CreateNewUserService();
            string email = "ValidRegisteredEmailTest@testdomain.com";
            try
            {
                target.ValidateEmailForInsert(email);
                throw new Exception("Test failed because of duplicate email couldn't be found in database");
            }
            catch (BRException ex)
            {
                Assert.AreEqual(1, ex.RuleErrors.Count);
                Assert.AreEqual(BusinessErrorStrings.User.Email_Duplicate, ex.RuleErrors[0].ErrorDescription);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///A test for ValidatePassword
        ///</summary>
        [TestMethod()]
        public void ValidatePasswordTest()
        {
            UserService target = CreateNewUserService();
            UserValidateUserNamePasswordSP p = new UserValidateUserNamePasswordSP();
            p.UserName = "testExistingUserName";
            p.Password = "testSecurePasssword123!";
            p.ThrowIfError = false; 
            long expected = 1; //UserID 
            User actual = (User) target.ValidateUserNamePassword(p);
            Assert.AreEqual(expected, actual.UserID);
            Assert.IsTrue(actual.LastLoginDate.Value.AddMinutes(1) > DateTime.UtcNow); // recently changed :)
        }

        /// <summary>
        ///A test for ValidatePassword
        ///</summary>
        [TestMethod()]
        public void ValidatePasswordTest2()
        {
            UserService target = CreateNewUserService();
            UserValidateUserNamePasswordSP p = new UserValidateUserNamePasswordSP();
            p.UserName = "testExistingUserName";
            p.Password = "invalidpassword";
            p.ThrowIfError = false;
            object expected = null;
            ResetFailedAttemp(p.UserName, 0); //reset situation
            object actual = target.ValidateUserNamePassword(p);
            Assert.AreEqual(expected, actual);
        }

        private void ResetFailedAttemp(string userName, int attemptCount)
        {
            UserService target = CreateNewUserService();
            User u = (User) target.GetByUserNameT(userName);
            u.FailedPasswordAttemptCount = attemptCount;
            u.UserApprovalStatusID = (int) EntityEnums.UserApprovalStatusEnum.Approved;
            target.Update(u, new UpdateParameters());
        }



        /// <summary>
        ///A test for ValidatePassword
        ///</summary>
        [TestMethod()]
        public void ValidatePasswordTest3()
        {
            UserService target = CreateNewUserService();
            UserValidateUserNamePasswordSP p = new UserValidateUserNamePasswordSP();
            p.UserName = "testExistingUserName";
            p.Password = "invalidpassword";
            p.ThrowIfError = true;
            try
            {
                ResetFailedAttemp(p.UserName, 0);
                var actual = target.ValidateUserNamePassword(p);
                Assert.AreNotEqual(null, actual); // should never happen
            }
            catch(UserException ex)
            {
                Assert.AreEqual(ex.Message, BusinessErrorStrings.PasswordValidation.UserName_Or_Password_Is_Not_Correct);
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        ///A test for ValidatePassword
        ///</summary>
        [TestMethod()]
        public void ValidatePasswordTest4()
        {
            UserService target = CreateNewUserService();
            UserValidateUserNamePasswordSP p = new UserValidateUserNamePasswordSP();
            p.UserName = "testNOTExistingUserName";
            p.Password = "SomePassword";
            p.ThrowIfError = true;
            try
            {
                var actual = target.ValidateUserNamePassword(p);
                Assert.AreNotEqual(null, actual); // should never happen
            }
            catch (UserException ex)
            {
                Assert.AreEqual(ex.Message, BusinessErrorStrings.PasswordValidation.UserName_Or_Password_Is_Not_Correct);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        ///A test for ValidatePassword
        ///</summary>
        [TestMethod()]
        public void ValidatePasswordTest5()
        {
            UserService target = CreateNewUserService();
            UserChangePasswordAdminSP p = new UserChangePasswordAdminSP();
            p.UserName = "testUserNameRejected";
            p.NewPassword = "Password123!";
            target.ChangePasswordAdmin(p); // make sure that password never changed
            try
            {
                UserValidateUserNamePasswordSP pv = new UserValidateUserNamePasswordSP();
                pv.UserName = p.UserName;
                pv.Password = p.NewPassword;
                pv.ThrowIfError = true;
                var actual = target.ValidateUserNamePassword(pv);
                Assert.AreNotEqual(null, actual); // should never happen
            }
            catch (UserException ex)
            {
                Assert.AreEqual(ex.Message, BusinessErrorStrings.PasswordValidation.ApprovalRejected);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///A test for ValidatePassword
        ///</summary>
        [TestMethod()]
        public void ValidatePasswordTest6()
        {
            UserService target = CreateNewUserService();
            UserChangePasswordAdminSP p = new UserChangePasswordAdminSP();
            p.UserName = "testuserNameLocked";
            p.NewPassword = "Password123!";
            target.ChangePasswordAdmin(p); // make sure that password never changed
            try
            {
                UserValidateUserNamePasswordSP pv = new UserValidateUserNamePasswordSP();
                pv.UserName = p.UserName;
                pv.Password = p.NewPassword;
                pv.ThrowIfError = true;
                var actual = target.ValidateUserNamePassword(pv); 
                Assert.AreNotEqual(null, actual); // should never happen
            }
            catch (UserException ex)
            {
                Assert.AreEqual(ex.Message, BusinessErrorStrings.PasswordValidation.AccountLocked);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///A test for ValidatePassword
        ///</summary>
        [TestMethod()]
        public void ValidatePasswordTest7()
        {
            UserService target = CreateNewUserService();
            UserChangePasswordAdminSP p = new UserChangePasswordAdminSP();
            p.UserName = "testuserNameLockedFailedPassword";
            p.NewPassword = "Password123!";
            target.ChangePasswordAdmin(p); // make sure that password never changed
            try
            {
                UserValidateUserNamePasswordSP pv = new UserValidateUserNamePasswordSP();
                pv.UserName = p.UserName;
                pv.Password = p.NewPassword;
                pv.ThrowIfError = true;
                var actual = target.ValidateUserNamePassword(pv); 
                Assert.AreNotEqual(null, actual); // should never happen
            }
            catch (UserException ex)
            {
                Assert.AreEqual(ex.Message, BusinessErrorStrings.PasswordValidation.AccountFailedPasswordLocked);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        ///A test for ValidatePassword
        ///Number of failed passwords should be increased by one for an approved user
        ///</summary>
        [TestMethod()]
        public void ValidatePasswordForFailedPasswordCount()
        {
            UserService target = CreateNewUserService();
            UserValidateUserNamePasswordSP p = new UserValidateUserNamePasswordSP();
            p.UserName = "testUserForFailedPasswordCount";
            p.Password = "invalidpassword";
            p.ThrowIfError = false;
            object expected = null;
            ResetFailedAttemp(p.UserName, 1); //reset situation
            object actual = target.ValidateUserNamePassword(p);
            Assert.AreEqual(expected, actual);
            User user = target.GetByUserNameT(p.UserName);
            Assert.AreEqual(2, user.FailedPasswordAttemptCount);
        }

        /// <summary>
        ///A test for ValidatePassword
        ///Steps:
        /// Step 1 : Reset conditions (Count = LastPossibleAttempt)
        /// Step 2: Validate with invalid password to get invalid password message
        /// Step 3: Validate with valid password and check if you get locked exception
        /// Step 4: Validate field values stored in database
        ///</summary>
        [TestMethod()]
        public void ValidatePasswordForFailedPasswordCount2()
        {
            UserService target = CreateNewUserService();
            string userName = "testUserForFailedPasswordCount";
            string password = "Password123!";
            string invalidPassword = "InvalidPassword";
            // Step 1: Reset conditions (Count = LastPossibleAttempt)
            ResetFailedPasswordCount(userName, password, ConfigurationBase.DefaultInstance.FailedPasswordCountAllowed);
            // Step 2: Validate with invalid password to get invalid password message
            try 
	        {
                UserValidateUserNamePasswordSP pv = new UserValidateUserNamePasswordSP();
                pv.UserName = userName;
                pv.Password = invalidPassword;
                pv.ThrowIfError = true;
                var actual = target.ValidateUserNamePassword(pv); 
                Assert.AreNotEqual(null, actual); // should never happen
	        }
	        catch (UserException ex)
	        {
                Assert.AreEqual(ex.Message, BusinessErrorStrings.PasswordValidation.UserName_Or_Password_Is_Not_Correct);
	        }
            catch(Exception)
            {
                throw;
            }

            // Step 3: Validate with valid password and check if you get locked exception
            try
            {
                UserValidateUserNamePasswordSP pv = new UserValidateUserNamePasswordSP();
                pv.UserName = userName;
                pv.Password = password;
                pv.ThrowIfError = true;
                object actual = target.ValidateUserNamePassword(pv);
            }
            catch (UserException ex)
            {
                Assert.AreEqual(ex.Message, BusinessErrorStrings.PasswordValidation.AccountFailedPasswordLocked);
            }
            catch (Exception)
            {
                throw;
            }
            // Step 4: Validate field values stored in database
            User user = (User)target.GetByUserNameT(userName);
            Assert.AreEqual(ConfigurationBase.DefaultInstance.FailedPasswordCountAllowed + 1, user.FailedPasswordAttemptCount);
            Assert.AreEqual((int)EntityEnums.UserApprovalStatusEnum.FailedPasswordLocked, user.UserApprovalStatusID);
        }


        private void ResetFailedPasswordCount(string userName, string password, int failedAttempt)
        {
            UserService userService = CreateNewUserService();
            User user = (User)userService.GetByUserNameT(userName);
            user.UserApprovalStatusID = (int)EntityEnums.UserApprovalStatusEnum.WaitingForApproval;
            user.FailedPasswordAttemptCount = failedAttempt;
        }


        /// <summary>
        ///A test for ValidateUserName
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest()
        {
            UserService target = CreateNewUserService(); 
            string userName = "testExistingUserName";
            try
            {
                target.ValidateUserNameForInsert(userName);
            }
            catch (BRException ex)
            {
                Assert.AreEqual(1, ex.RuleErrors.Count);
                Assert.AreEqual(ex.RuleErrors[0].ErrorDescription, BusinessErrorStrings.User.UserName_DuplicateUserName);
            }
            catch (Exception)
            {
                throw;
            }
        }





        /// <summary>
        ///A test for ValidateUserName
        ///</summary>
        [TestMethod()]
        public void ValidateUserNameTest2()
        {
            UserService target = CreateNewUserService();
            
            for (int i = 0; i < 100; i++)
            {
                string userName = TestUtils.RandomUtils.RandomUserName();
                target.ValidateUserNameForInsert(userName);
            }
            
        }


        /// <summary>
        ///A test for ChangePasswordAdmin
        ///Steps: 
        /// 1- Change to a random password
        /// 2- Check that random password is not valid with newPassword
        /// 3- Change to new password
        /// 4- Check that newPassword is valid now
        ///</summary>
        [TestMethod()]
        public void ChangePasswordAdminTest()
        {
            UserService target = CreateNewUserService();
            string userName = "testUserForChangePasswordAdmin";
            string newPassword = "Password123!";
            string randomPassword = "RandomPassword1!@#";  //TestUtils.RandomUtils.RandomString(20);
            
            // Step 1 - changing to a random password
            target.ChangePasswordAdmin(
                new UserChangePasswordAdminSP()
                {
                    UserName = userName,
                    NewPassword = randomPassword
                });
            // Step 2 - validating with random password
            object valresult = target.ValidateUserNamePassword(
                new UserValidateUserNamePasswordSP()
                {
                    UserName = userName,
                    Password = randomPassword,
                    ThrowIfError = true
                });
            Assert.AreNotEqual(valresult, null);
            // Step 3 - changing to new password
            target.ChangePasswordAdmin(
                new UserChangePasswordAdminSP()
                {
                    UserName = userName,
                    NewPassword = newPassword
                });
            // Step 4 - validating with new password
            valresult = target.ValidateUserNamePassword(
                new UserValidateUserNamePasswordSP()
            {
                UserName = userName,
                Password = newPassword,
                ThrowIfError = true
            });
        }

        [TestMethod()]
        public void ChangePasswords()
        {
            UserService target = CreateNewUserService();

            string[] s = {"testusernameneedspersonregistration",
                "testUserNameWithoutNeedsForPersonRegistration",
                "testUserNameIncompleteRegistration",
                "testUserNameNeedsApproval",
                "testUserNameApproved",
                "testUserNameRejected",
                "testuserNameLocked",
                "testuserNameLockedFailedPassword",
                "testUserForChangePassword"};

            string newPassword = "Password123!";

            foreach (string userName in s)
            {
                target.ChangePasswordAdmin(new UserChangePasswordAdminSP()
                {
                    UserName = userName,
                    NewPassword = newPassword
                });
            }
        
        }
        /// <summary>
        ///A test for ChangePassword
        ///</summary>
        [TestMethod()]
        public void ChangePasswordTest()
        {
            UserService target = CreateNewUserService();
            long userId = 10;
            string userName = "testUserForChangePassword";
            string oldPassword = "Password123!";
            string newPassword = "newPassword1!@#";

            target.ChangePasswordAdmin(new UserChangePasswordAdminSP()
            {
                 UserName = userName,
                 NewPassword = oldPassword
            });

            TestUtils.Security.SetCurrentUser(target.GetByUserNameT(userName).UserID);

            // changing password from old to new
            target.ChangePassword(new UserChangePasswordSP()
            {
                UserID = userId,
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmNewPassword = newPassword
            });

            target.ValidateUserNamePassword(new UserValidateUserNamePasswordSP()
            {
                UserName = userName,
                Password = newPassword,
                ThrowIfError = true
            });

            // reset changes from new to old
            target.ChangePassword(new UserChangePasswordSP()
            {
                UserID = userId,
                OldPassword = newPassword,
                NewPassword = oldPassword,
                ConfirmNewPassword = oldPassword
            });

            target.ValidateUserNamePassword(new UserValidateUserNamePasswordSP()
            {
                UserName = userName,
                Password = oldPassword,
                ThrowIfError = true
            });
        }

        /// <summary>
        ///A test for ChangePassword
        ///</summary>
        [TestMethod()]
        public void ChangePasswordTest2()
        {
            // checks an invalid password. It should return an exception

            UserService target = CreateNewUserService();
            long userId = 10;
            string userName = "testUserForChangePassword";
            string oldPassword = "Password123!";
            string newPassword = "invalidPassword";

            // changing password from old to new
            try
            {
                target.ChangePassword(new UserChangePasswordSP() {
                    UserID = userId, 
                    OldPassword = oldPassword, 
                    NewPassword = newPassword,
                    ConfirmNewPassword = newPassword
                });
            }
            catch (BRException ex)
            {
                Assert.AreEqual(BusinessErrorStrings.User.Password_RegularExpression, ex.RuleErrors[0].ErrorDescription);
                return;
            }
            catch (Exception)
            {
                throw;
            }

            // reset changes from new to old if it didn't detect the error
            target.ChangePassword(new UserChangePasswordSP() {
                UserID = userId,
                OldPassword = newPassword,
                NewPassword = oldPassword,
                ConfirmNewPassword = newPassword
            });

            throw new Exception("invalid password accepted.");
        }



        /// <summary>
        ///A test for sending verification email
        ///</summary>
        [TestMethod()]
        public void SendEmailVerificationTest()
        {
            long userId = TestEnums.User.constPatientUserID;
            TestUtils.Security.SetCurrentUser(userId);
            UserService target = CreateNewUserService();
            target.SendEmailVerificationLetter(userId);

            User user = (User)target.GetByID(userId, new GetByIDParameters());
            Assert.IsNotNull(user.EmailVerificationCode, "user.EmailVerificationCode shouldn't be null");

            // Checking the notification and log
            DateTime afewSecondsAgoDate = DateTime.UtcNow.AddSeconds(-3);
            INotificationService notificationService = (INotificationService)
                EntityFactory.GetEntityServiceByName(vNotification.EntityName, "");
            FilterExpression nFilter = new FilterExpression();
            nFilter.AddFilter(new Filter(vNotification.ColumnNames.ReceiverUserID, userId));
            nFilter.AddFilter(new Filter(vNotification.ColumnNames.NotificationTemplateID, (int)EntityEnums.NotificationTemplateEnum.EmailVerification));
            nFilter.AddFilter(new Filter(vNotification.ColumnNames.InsertDate, afewSecondsAgoDate, FilterOperatorEnum.GreaterThan));
            List<Notification> notificationsList = (List<Notification>)notificationService.GetByFilter(new GetByFilterParameters(nFilter));
            Assert.AreEqual(1, notificationsList.Count, "notificationsList.Count should be 1. One notification should be sent for emailing to user");
            

            // We don't check log because it depends on the notification service. We don't need it for our unit testing.

            //IAppLogService logService = (IAppLogService)
            //    EntityFactory.GetEntityServiceByName(AppLog.EntityName, "");
            //FilterExpression filter = new FilterExpression();
            //filter.AddFilter(new Filter())
        }

        /// <summary>
        /// Test for VerifyEmail (when user opened the verification link)
        /// </summary>
        [TestMethod()]
        public void VerifyEmailTest()
        {
            long userId = TestEnums.User.constPatientUserID;
            UserService target = CreateNewUserService();
            target.SendEmailVerificationLetter(userId);
            User user = (User)target.GetByID(userId, new GetByIDParameters());

            UserVerifyEmailSP p = new UserVerifyEmailSP()
            {
                EmailVerificationCode = user.EmailVerificationCode.ToString(),
                Email = user.Email
            };

            target.VerifyEmail(p);

            User userAfterVerification = (User)target.GetByID(userId, new GetByIDParameters());
            bool expected = true;
            Assert.AreEqual(expected, userAfterVerification.IsEmailVerified, "user.IsEmailVerified should be true after verification.");
        }

        /// <summary>
        /// Test for PhoneNumber (when user opened the verification link)
        /// </summary>
        [TestMethod()]
        public void VerifyPhoneNumberTest()
        {
            long userId = TestEnums.User.constPatientUserID;
            TestUtils.Security.SetCurrentUser(userId);
            UserService target = CreateNewUserService();
            target.SendPhoneNumberVerification(userId);
            User user = (User)target.GetByID(userId, new GetByIDParameters());

            UserVerifyPhoneNumberSP p = new UserVerifyPhoneNumberSP()
            {
                PhoneVerificationCode = user.PhoneVerificationCode,
                PhoneNumber = user.PhoneNumber
            };

            target.VerifyPhoneNumber(p);

            User userAfterVerification = (User)target.GetByID(userId, new GetByIDParameters());
            bool expected = true;
            Assert.AreEqual(expected, userAfterVerification.IsPhoneVerified, "user.IsPhoneNumber should be true after verification.");
        }


        [TestMethod()]
        public void GetWorldZoneIDByUserIDTest()
        {
            long userId = TestEnums.User.constPatientUserID;
            UserService target = CreateNewUserService();
            short actual = target.GetWorldZoneIDByUserID(userId);
            short expected = 381; // America/Chicago
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for Register
        ///</summary>
        [TestMethod()]
        public void RegisterQuickTest()
        {
            UserService target = CreateNewUserService();
            UserRegisterQuickFromDoctorSP p = new UserRegisterQuickFromDoctorSP();
            p.FirstName = TestUtils.RandomUtils.RandomString(100);
            p.LastName = TestUtils.RandomUtils.RandomString(100);
            p.PhoneNumber = TestUtils.RandomUtils.RandomPhoneNumber();
            p.ReferrerUserID = (long)TestEnums.User.constDoctorID;
            User insertedUser = (User) target.RegisterQuickFromDoctor(p);

            string phoneNumberSearchable = PhoneNumberUtils.MakeSearchablePhoneNumber(p.PhoneNumber);

            User u = (User)target.GetByUserNameT(insertedUser.UserName);
            Assert.AreEqual(insertedUser.UserName.ToLower(), u.UserName, "User name didn't inserted correctly");
            //Assert.AreEqual(phoneNumberSearchable, u.PhoneNumberSearchable, "phoneNumber didn't inserted correctly");

            UserInRoleService uInRoleService = (UserInRoleService)EntityFactory.GetEntityServiceByName(vUserInRole.EntityName, "");
            var count = uInRoleService.GetCount(new FilterExpression(new Filter(vUserInRole.ColumnNames.UserID, u.UserID)));
            Assert.AreEqual(1, count, "we expect that user be in one of the assigned roles"); // we expect that user be in one of the assigned roles

            IDoctor_PatientService doctor_PatientService = Doctor_PatientEN.GetService();
            FilterExpression filter = new FilterExpression(vDoctor_Patient.ColumnNames.DoctorID, p.ReferrerUserID);
            filter.AddFilter(vDoctor_Patient.ColumnNames.PatientUserID, u.UserID);
            Assert.AreEqual(1, doctor_PatientService.GetCount(filter), "Doctor_Patient is not exists.");
        }

        [TestMethod]
        public void UpdateProfileInfo()
        {
            long userId = 15;
            TestUtils.Security.SetCurrentUser(userId);

            UserService target = CreateNewUserService();
            UserUpdateProfileInfoSP p1 = new UserUpdateProfileInfoSP();
            p1.FirstName = "random f name";
            p1.LastName = "random l name";
            p1.PhoneNumber = FWUtils.RandomUtils.RandomPhoneNumber();
            p1.UserName = FWUtils.RandomUtils.RandomUserName();
            p1.Email = "AVeryUniqueEmailNew1@gmail.com";
            p1.UserID = userId;

            target.UpdateProfileInfo(p1);

            UserUpdateProfileInfoSP p2 = new UserUpdateProfileInfoSP()
            {
                FirstName = "New firstName",
                LastName = "New LastName",
                PhoneNumber = FWUtils.RandomUtils.RandomPhoneNumber(),
                UserName = "NewUserName1234",
                Email = "AVeryUniqueEmailNew2@gmail.com",
                UserID = userId
            };

            target.UpdateProfileInfo(p2);

            User u = target.GetByIDT(userId);

            Assert.AreNotEqual(p1.UserName, u.UserName, "UserName not updated");
            Assert.AreNotEqual(p1.FirstName, u.FirstName, "FirstName not updated");
            Assert.AreNotEqual(p1.LastName, u.LastName, "LastName not updated");
            Assert.AreNotEqual(p1.PhoneNumber, u.PhoneNumber, "PhoneNumber not updated");
            Assert.AreNotEqual(p1.Email, u.Email, "Email not updated");

            Assert.AreEqual(p2.UserName.ToLower(), u.UserName, "UserName not updated");
            Assert.AreEqual(p2.FirstName, u.FirstName, "FirstName not updated");
            Assert.AreEqual(p2.LastName, u.LastName, "LastName not updated");
            Assert.AreEqual(p2.PhoneNumber, u.PhoneNumber, "PhoneNumber not updated");
            Assert.AreEqual(p2.Email.ToLower(), u.Email, "Email not updated");

            Assert.AreEqual(false, u.IsEmailVerified, "IsEmailVerified not false");
            Assert.AreEqual(false, u.IsPhoneVerified, "IsPhoneVerified not false");
        }

        [TestMethod]
        public void GetDataByPhoneForQReg()
        {
            UserService target = CreateNewUserService();
            User insertedUser = (User)target.RegisterQuickFromDoctor(new UserRegisterQuickFromDoctorSP()
            {
                FirstName = TestUtils.RandomUtils.RandomString(100),
                LastName = TestUtils.RandomUtils.RandomString(100),
                PhoneNumber = TestUtils.RandomUtils.RandomPhoneNumber(),
                ReferrerUserID = (long)TestEnums.User.constDoctorID
            });

            var p = new UserGetDataByPhoneForQRegSP()
            {
                PhoneNumber = insertedUser.PhoneNumber,
                PhoneVerificationCode = insertedUser.PhoneVerificationCode
            };

            try
            {
                var u = target.GetDataByPhoneForQReg(p);
            }
            catch (Exception ex)
            {
                Assert.Fail("GetDataByPhoneForQReg didn't work with current exception:" + ex.ToString());
            }

            // cascade problems TODO: Fix delete cascade problems
            //target.Delete(insertedUser);
        }


        [TestMethod]
        public void ContinueQReg()
        {
            UserService target = CreateNewUserService();
            User insertedUser = (User)target.RegisterQuickFromDoctor(new UserRegisterQuickFromDoctorSP(){
                FirstName = TestUtils.RandomUtils.RandomString(100),
                LastName = TestUtils.RandomUtils.RandomString(100),
                PhoneNumber = TestUtils.RandomUtils.RandomPhoneNumber(),
                ReferrerUserID = (long)TestEnums.User.constDoctorID
            });

            string password = TestUtils.RandomUtils.RandomString(64);

            UserContinueQRegSP p = new UserContinueQRegSP()
            {
                UserName = TestUtils.RandomUtils.RandomUserName(),
                FirstName = TestUtils.RandomUtils.RandomString(100),
                LastName = TestUtils.RandomUtils.RandomString(100),
                PhoneNumber = insertedUser.PhoneNumber,
                PhoneVerificationCode = insertedUser.PhoneVerificationCode,
                Password = password,
                ConfirmPassword = password,
                Email = TestUtils.RandomUtils.RandomEmail()
            };

            target.ContinueQReg(p);

            var u = target.GetByIDV(insertedUser.UserID);
            Assert.AreEqual(p.UserName.ToLower(), u.UserName, "UserName not updated");
            Assert.AreEqual(p.FirstName, u.FirstName, "FirstName not updated");
            Assert.AreEqual(p.LastName, u.LastName, "LastName not updated");
            Assert.AreEqual(p.PhoneNumber, u.PhoneNumber, "PhoneNumber not updated");
            Assert.AreEqual(p.Email.ToLower(), u.Email, "Email not updated");

            target.ValidateUserNamePassword(new UserValidateUserNamePasswordSP()
            {
                ThrowIfError = true,
                Password = password,
                UserName = p.UserName
            });

            // cascade problems TODO: Fix delete cascade problems
            //target.Delete(insertedUser);
        }

        [TestMethod]
        public void ResetPasswordRequest()
        {
            UserService target = CreateNewUserService();

            string userName = "testUserForResetPassword";
            var user = (User)target.GetByUserNameT(userName);

            UserResetPasswordRequestSP p = new UserResetPasswordRequestSP()
            {
                EmailOrPhoneNumber = user.Email
            };

            target.ResetPasswordRequest(p);

            var userAfterRequest = target.GetByIDT(user.UserID);
            Assert.IsTrue(userAfterRequest.ResetPasswordCode != null);
            Assert.IsTrue((DateTime.UtcNow - user.ResetPasswordRequestDate.Value).TotalSeconds < 30);

            AssertNotificationExists(user.UserID, EntityEnums.NotificationTemplateEnum.ResetPasswordRequest);
        }

        [TestMethod]
        public void ResetPassword()
        {
            UserService target = CreateNewUserService();

            string userName = "testUserForResetPassword";
            var user = (User)target.GetByUserNameT(userName);


            target.ResetPasswordRequest(new UserResetPasswordRequestSP()
            {
                EmailOrPhoneNumber = user.Email
            });

            //// check if reset password notification is done
            //AssertNotificationExists(user.UserID, EntityEnums.NotificationTemplateEnum.ResetPasswordRequest);
            var userAfterRequest = target.GetByIDT(user.UserID);
            //Assert.IsTrue(userAfterRequest.ResetPasswordCode != null);
            //Assert.IsTrue((DateTime.UtcNow - user.ResetPasswordRequestDate.Value).TotalSeconds < 30);


            // trying to reset the passsword with completely new password and validate
            string newPassword = FWUtils.RandomUtils.RandomString(10) + "123!@#";

            target.ResetPassword(new UserResetPasswordSP()
            {
                EmailOrPhoneNumber = user.Email,
                NewPassword= newPassword,
                ConfirmNewPassword = newPassword,
                ResetPasswordCode = userAfterRequest.ResetPasswordCode.Value.ToString()
            });


            target.ValidateUserNamePassword(new UserValidateUserNamePasswordSP()
            {
                Password = newPassword,
                UserName = user.UserName,
                ThrowIfError = true
            });


            AssertNotificationExists(user.UserID, EntityEnums.NotificationTemplateEnum.ResetPasswordChanged);
        }


        [TestMethod]
        public void LoginTokenDataChecksumTest1()
        {
            // checking if checksum behavior works properly in LoginTokenData
            // Note: I put all four test cases in one function for simplification
            LoginTokenData data = new LoginTokenData();
            data.UserID = 1;
            data.IssueDateTime = 100000000;
            Assert.AreEqual(false, data.IsChecksumValid(), "Checksum should be invalid when it has not been generated.");

            // test set check sum
            data.SetChecksum();
            Assert.AreEqual(true, data.IsChecksumValid(), "Checksum should be valid when it is set by data.");

            // test change of UserID
            data.UserID = 2;
            Assert.AreEqual(false, data.IsChecksumValid(), "Checksum should be invalid when UserID is different.");

            // test change of IssueDateTime
            data.UserID = 1;
            data.IssueDateTime = 1;
            Assert.AreEqual(false, data.IsChecksumValid(), "Checksum should be invalid when IssueDateTime is different.");

            // test set check sum
            data.SetChecksum();
            Assert.AreEqual(true, data.IsChecksumValid(), "Checksum should be valid when it is set by data.");
        }




        [TestMethod]
        public void RegisterAndLoginTest()
        {
            // test when it's a completely new user
            UserService target = CreateNewUserService();

            // 1- do register and login
            RegisterInfoOffsite p = new RegisterInfoOffsite()
            {
                DefaultRoleID = 1,
                Email = TestUtils.RandomUtils.RandomEmail(),
                FirstName = TestUtils.RandomUtils.RandomString(10),
                LastName = TestUtils.RandomUtils.RandomString(10),
                Password = "Password1234"
            };

            var result = target.RegisterAndGetLoginToken(p);
            Assert.AreEqual(true, result.Result, "Result of RegisterAndLogin should be true:" + result.Error);

            // 2- validate returned token
            var u = target.LoginWithLoginToken(result.LoginToken);
            Assert.IsTrue(u.HasValue, "RegisterAndLogin should return a valid user id");

            // 3- see if user is saved in the database
            var user = target.GetByID(u.Value);
            Assert.IsTrue(user != null, "User information should be saved in the database");

            // 4- clean up test
            try
            {
                target.Delete(user);
            }
            catch (Exception)
            {
            }
        }



        [TestMethod]
        public void RegisterAndLoginTest2()
        {
            // test when the user was registered before
            UserService target = CreateNewUserService();

            // 1- do register and login
            RegisterInfoOffsite p = new RegisterInfoOffsite()
            {
                DefaultRoleID = TestEnums.Role.constPatientRoleID,
                Email = "ExistingUser@RegisterAndLoginSP.com",
                FirstName = TestUtils.RandomUtils.RandomString(10),
                LastName = TestUtils.RandomUtils.RandomString(10),
                Password = "Password1234"
            };

            var result = target.RegisterAndGetLoginToken(p);
            Assert.AreEqual(true, result.Result, "Result of RegisterAndLogin should be true");
            //string sampleLoginToken = "YKjsZNbws0wkxvIs/82PrCBeIU2Ig2yT8FtWTiZx+fepFD5M01GD1aJsbkLe7Brxmh9WYk1t0j/nKiyNzP8ZYysT2EwtXUAqn7PGrRaXmFKIFuA3h7WI7V86dQ2l6X0PzlUMTmH+r+IZbqAtGe6vCw==";
            // can't validate by string as it changes by time

            // 2- validate returned token
            var u = target.LoginWithLoginToken(result.LoginToken);
            var expectedUserID = 17;
            Assert.IsTrue(u.HasValue, "RegisterAndLogin should return a valid user id");
            Assert.AreEqual(expectedUserID, u.Value, "RegisterAndLogin should return a valid user id");
        }


        [TestMethod]
        public void RegisterAndLoginSecureTest()
        {
            // test when it's a completely new user
            UserService target = CreateNewUserService();

            // 1- Creating register and login encrypted data
            RegisterInfoOffsite p = new RegisterInfoOffsite()
            {
                DefaultRoleID = TestEnums.Role.constPatientRoleID,
                Email = TestUtils.RandomUtils.RandomEmail(),
                FirstName = TestUtils.RandomUtils.RandomString(10),
                LastName = TestUtils.RandomUtils.RandomString(10),
                Password = "Password1234"
            };

            string loginInfoJson = FWUtils.EntityUtils.JsonSerializeObject(p);
            string encryptedData = FWUtils.EncryptionUtils.EncryptString(loginInfoJson, "64C6B83A-0EFF-4122-A15A-507D4765FC9A");

            //string sampleEncryptedData = "IqX8tHxoAt+XMCzhFgpLA6pwaxY0GyCqM5NyM3dRrCBNIm96cbaE5DIuera8/vJXzWTffx80cWTyJn/7mPQQrbx18F8OVoyjHv4m1W5XZQ8+d4+Bf7X97FioLg1oVLa8F1PReCdFu4MROpDZT290WSRD+yqXHk8F5yQrhyvRin9/dSdz2cN7Enh8J+LTItyUGCk+F37vnE5twqqL8FQilNeQlzBxIUWXe2aXl1KO1fQ=";

            // 2- do register and login
            var result = target.RegisterAndGetLoginTokenSecure(new RegisterAndGetLoginTokenSecureSP()
            {
                RegisterInfoEncBase64 = encryptedData
            });

            Assert.AreEqual(true, result.Result, "Result of RegisterAndLogin should be true");

            // 3- validate returned token
            var u = target.LoginWithLoginToken(result.LoginToken);
            Assert.IsTrue(u.HasValue, "RegisterAndLogin should return a valid user id");

            // 4- see if user is saved in the database
            var user = target.GetByID(u.Value);
            Assert.IsTrue(user != null, "User information should be saved in the database");

            // 5- clean up test
            try
            {
                target.Delete(user);
            }
            catch (Exception)
            {
            }
        }


        private void AssertNotificationExists(long receiverUserID, EntityEnums.NotificationTemplateEnum template)
        {
            DateTime afewSecondsAgoDate = DateTime.UtcNow.AddSeconds(-30);
            INotificationService notificationService = NotificationEN.GetService();
            FilterExpression nFilter = new FilterExpression();
            nFilter.AddFilter(new Filter(vNotification.ColumnNames.ReceiverUserID, receiverUserID));
            nFilter.AddFilter(new Filter(vNotification.ColumnNames.NotificationTemplateID, (int)template));
            nFilter.AddFilter(new Filter(vNotification.ColumnNames.InsertDate, afewSecondsAgoDate, FilterOperatorEnum.GreaterThan));
            List<Notification> notificationsList = (List<Notification>)notificationService.GetByFilter(new GetByFilterParameters(nFilter));
            Assert.IsTrue(notificationsList.Count > 0, "notificationsList.Count should be 1. One notification should be sent for emailing to user");
        }


    }
}
