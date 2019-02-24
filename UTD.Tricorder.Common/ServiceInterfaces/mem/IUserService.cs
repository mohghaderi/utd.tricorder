using System;
using System.Collections.Generic;
using Framework.Common;
using Framework.Service;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.SP;

namespace UTD.Tricorder.Common.ServiceInterfaces
{
    public interface IUserService : IServiceBaseT<User, vUser>
    {
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        /// <summary>
        /// Checks if provided user name is valid or not
        /// if it was not valid, it throws an exception
        /// </summary>
        /// <param name="userName">user name for check</param>
        void ValidateUserNameForInsert(string userName);


        /// <summary>
        /// Validates the email for insert.
        /// </summary>
        /// <param name="email">The email.</param>
        void ValidateEmailForInsert(string email);


        /// <summary>
        /// Validates the phone number for insert.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        void ValidatePhoneNumberForInsert(string phoneNumber);


        /// <summary>
        /// Registers the specified user name.
        /// </summary>
        /// <param name="p">Registration parameters</param>
        /// <returns>if successful, returns userid, otherwise returns null</returns>
        object Register(UserRegisterSP p);



        /// <summary>
        /// Checks the password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="throwIfError">Throw an exception if error happened</param>
        /// <param name="userID">if successful, returns user id, otherwise returns null</param>
        /// <returns>if username and password match</returns>
        object ValidateUserNamePassword(UserValidateUserNamePasswordSP p);

        /// <summary>
        /// Changes the password.
        /// </summary>
        void ChangePassword(UserChangePasswordSP p);

        /// <summary>
        /// change password for admins. This shouldn't be used by any other users because it allows to change password without having the previous password
        /// In addition, it can be used to reset password by the user
        /// </summary>
        void ChangePasswordAdmin(UserChangePasswordAdminSP p);

        /// <summary>
        /// Gets the data by provided user name from its view
        /// </summary>
        /// <param name="userName">the user name</param>
        /// <returns></returns>
        vUser GetByUserNameV(string userName);

        
        /// <summary>
        /// Gets the data by provided user name from its table
        /// </summary>
        /// <param name="userName">the user name</param>
        /// <returns></returns>
        User GetByUserNameT(string userName);


        /// <summary>
        /// changes status of a user to approved status
        /// </summary>
        /// <param name="userId">user identifier</param>
        void Approve(long userId);

        /// <summary>
        /// changes status of a user to locked status
        /// </summary>
        /// <param name="userId">user identifier</param>
        void Lock(long userId);

        /// <summary>
        /// changes status of a user to rejected status
        /// </summary>
        /// <param name="userId">user identifier</param>
        void Reject(long userId);

        /// <summary>
        /// changes status of a user to Approved status (unlocks a locked account)
        /// </summary>
        /// <param name="userId">user identifier</param>
        void UnLock(long userId);
        
        /// <summary>
        /// Cancels the membership.
        /// </summary>
        /// <param name="p">parameters</param>
        void CancelMembership(UserCancelMembershipSP p);


        /// <summary>
        /// Verifies the email.
        /// </summary>
        /// <param name="verificationCode">The verification code.</param>
        void VerifyEmail(UserVerifyEmailSP p);


        /// <summary>
        /// Verifies the phone number.
        /// </summary>
        /// <param name="p">parameters</param>
        void VerifyPhoneNumber(UserVerifyPhoneNumberSP p);


        /// <summary>
        /// Gets the world zone identifier.
        /// If it couldn't find the return it returns DateTimeEpoch.DefaultTimeZoneID
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        short GetWorldZoneIDByUserID(long userId);

        /// <summary>
        /// updates the user profile based on the provided information
        /// </summary>
        /// <param name="p">parameters</param>
        void UpdateProfileInfo(UserUpdateProfileInfoSP p);

        /// <summary>
        /// Registers a user from doctor's panel by its minimum requirements
        /// </summary>
        /// <param name="p">parameters</param>
        /// <returns></returns>
        object RegisterQuickFromDoctor(UserRegisterQuickFromDoctorSP p);


        /// <summary>
        /// Gets users data by its phone number information for continuing quick registration
        /// if the person is already completed its registration then, throws a userexception
        /// if the data has not found, it returns a userexception
        /// </summary>
        /// <param name="p"></param>
        vUser GetDataByPhoneForQReg(UserGetDataByPhoneForQRegSP p);


        /// <summary>
        /// continues quick registration for a user
        /// </summary>
        /// <param name="p"></param>
        void ContinueQReg(UserContinueQRegSP p);


        /// <summary>
        /// Changes Is Online status for a user
        /// </summary>
        void ChangeIsOnline(long UserID, bool isOnline);


        /// <summary>
        /// Registers a user and does login authentication
        /// </summary>
        /// <param name="p">parameters</param>
        RegisterAndGetLoginTokenSecureRP RegisterAndGetLoginTokenSecure(RegisterAndGetLoginTokenSecureSP p);


        /// <summary>
        /// Validates a generated login token an
        /// </summary>
        /// <param name="loginToken"></param>
        /// <returns></returns>
        long? LoginWithLoginToken(string loginToken);


        /// <summary>
        /// Uses Register offsite info to login
        /// </summary>
        /// <param name="registerOffsiteInfo">encrypted information of offsite register</param>
        /// <returns></returns>
        User LoginWithRegisterOffsiteInfo(string registerOffsiteInfo);

		#endregion
    }
}

