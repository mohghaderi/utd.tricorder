using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UTD.Tricorder.Common.EntityInfos;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;
using UTD.Tricorder.Website.Base;
using UTD.Tricorder.Common.SP;
using Framework.Common;

namespace UTD.Tricorder.Website.Controllers
{
    public class UserController : EntityServiceControllerBase
    {
        #region Generator-Safe Area

        public UserController()
        {
            // security removing insert update delete from user information
            this.HasDefaultInsert = false;
            this.HasDefaultUpdate = false;
            this.HasDefaultDelete = false;
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public ServiceActionResult Signup([FromBody] UserRegisterSP sp)
        //{
        //    try
        //    {
        //        IUserService service = (IUserService) GetService();
        //        service.Register(sp);
        //        return new ServiceActionResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        return UIUtils.GetExceptionActionResult(ex);
        //    }
        //}



    //    //Please write your properties and functions here. This part will not be replaced.

    //    /// <summary>
    //    /// Checks if provided user name is valid or not
    //    /// if it was not valid, it throws an exception
    //    /// </summary>
    //    /// <param name="userName">user name for check</param>
    //    /// <exception cref="BRException"></exception>
    //    public ServiceActionResult ValidateUserNameForInsert(string userName)
    //    {
    //        try
    //        {
    //            IUserService service = (IUserService)GetService();
    //            service.ValidateUserNameForInsert(userName);
    //            return new ServiceActionResult(true);
    //        }
    //        catch (Exception ex)
    //        {
    //            return UIUtils.GetExceptionActionResult(ex);
    //        }
            
    //    }


    //    /// <summary>
    //    /// Checks if provided user name is valid or not
    //    /// if it was not valid, it throws an exception
    //    /// </summary>
    //    /// <param name="userName">user name for check</param
    //    /// <param name="fnName">is insert or update or delete function</param>
    //    public void ValidateEmailForInsert(string email)
    //    {

    //    }


    //    /// <summary>
    //    /// Registers the specified user name.
    //    /// </summary>
    //    /// <param name="p">Registration parameters</param>
    //    /// <returns>if successful, returns user object, otherwise returns null</returns>
    //    public object Register(UserRegisterParameters p)
    //    {

    //    }

    //    /// <summary>
    //    /// Changes the password.
    //    /// </summary>
    //    /// <param name="userID">Name of the user.</param>
    //    /// <param name="oldPassword">The old password.</param>
    //    /// <param name="newPassword">The new password.</param>
    //    public void ChangePassword(string userName, string oldPassword, string newPassword)
    //    {

    //    }

    //    /// <summary>
    //    /// Checks the password.
    //    /// </summary>
    //    /// <param name="userName">Name of the user.</param>
    //    /// <param name="password">The password.</param>
    //    /// <param name="throwIfError">Throw an exception if error happened</param>
    //    /// <returns>if username and password match, returns user object, otherwise returns null</returns>
    //    public object ValidateUserNamePassword(string userName, string password,  bool throwIfError)
    //    {
    //    }



    //    /// <summary>
    //    /// Gets the name of the by user.
    //    /// </summary>
    //    /// <param name="userName">Name of the user.</param>
    //    /// <param name="sourceType">Type of the source.</param>
    //    /// <returns></returns>
    //    public object GetByUserName(string userName, GetSourceTypeEnum sourceType)
    //    {

    //    }



    //    /// <summary>
    //    /// Cancels the membership.
    //    /// </summary>
    //    /// <param name="userId">The user identifier.</param>
    //    public void CancelMembership(long userId)
    //    {
    //    }


    //    /// <summary>
    //    /// Sends the email verification template.
    //    /// </summary>
    //    /// <param name="userId">The user identifier.</param>
    //    public void SendEmailVerificationLetter(long userId)
    //    {

    //    }


    //    /// <summary>
    //    /// Verifies the email.
    //    /// </summary>
    //    /// <param name="verificationCode">The verification code.</param>
    //    public void VerifyEmail(string verificationCode)
    //    {

    //    }

    //    /// <summary>
    //    /// Gets the world zone identifier.
    //    /// If it couldn't find the return it returns DateTimeEpoch.DefaultTimeZoneID
    //    /// </summary>
    //    /// <param name="userId">The user identifier.</param>
    //    /// <returns></returns>
    //    public short GetWorldZoneIDByUserID(long userId)
    //    {

    //    }

        #endregion
    }
}

