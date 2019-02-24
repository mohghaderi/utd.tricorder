using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Tricorder.Common.SP
{

    public struct UserRegisterSP
    {
        public string UserName;
        public string FirstName;
        public string LastName;
        public string Email;
        public string PhoneNumber;
        public string Password;
        public string ConfirmPassword;
        public long DefaultRoleID;
        public long? ReferrerUserID;
        public bool IsQuickRegister;
    }

    public struct UserRegisterQuickFromDoctorSP
    {
        public string FirstName;
        public string LastName;
        public string PhoneNumber;
        public long ReferrerUserID;
    }

    
    public struct UserChangePasswordSP
    {
        public long UserID;
        public string OldPassword;
        public string NewPassword;
        public string ConfirmNewPassword;
    }


    public struct UserChangePasswordAdminSP
    {
        public string UserName;
        public string NewPassword;
    }


    public struct UserValidateUserNamePasswordSP
    {
        public string UserName;
        public string Password;
        public bool ThrowIfError;
    }

    public struct UserCancelMembershipSP
    {
        public long UserID;
    }

    public struct UserUpdateProfileInfoSP
    {
        public long UserID;
        public string UserName;
        public string FirstName;
        public string LastName;
        public string Email;
        public string PhoneNumber;
    }

    public struct UserVerifyEmailSP
    {
        public string Email;
        public string EmailVerificationCode;
    }

    public struct UserVerifyPhoneNumberSP
    {
        public string PhoneNumber;
        public int PhoneVerificationCode;
    }

    public struct UserGetDataByPhoneForQRegSP
    {
        public string PhoneNumber;
        public int PhoneVerificationCode;
    }

    public struct UserContinueQRegSP
    {
        public string UserName;
        public string FirstName;
        public string LastName;
        public string Email;
        public string PhoneNumber;
        public int PhoneVerificationCode;
        public string Password;
        public string ConfirmPassword;
    }

    public struct UserResetPasswordRequestSP
    {
        public string EmailOrPhoneNumber { get; set; }
    }

    public struct UserResetPasswordSP
    {
        public string EmailOrPhoneNumber { get; set; }
        public string ResetPasswordCode { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }


    /// <summary>
    /// registeration info comes from offsite
    /// </summary>
    public struct RegisterInfoOffsite
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public int DefaultRoleID;
        public string PhoneNumber;
    }

    public struct RegisterAndGetLoginTokenSecureSP
    {
        /// <summary>
        /// encrypted registeration info
        /// </summary>
        public string RegisterInfoEncBase64;
    }

    public struct RegisterAndGetLoginTokenSecureRP
    {
        public bool Result;
        public string Error;
        public string LoginToken;
    }


    public struct LoginTokenData
    {
        public int IssueDateTime;
        public long UserID;
        public byte[] Checksum; // don't make it private because of Json serialization

        /// <summary>
        /// sets check sum based on current info
        /// </summary>
        public void SetChecksum()
        {
            this.Checksum = _GenerateChecksum();
        }

        /// <summary>
        /// Generates check sum based on the current state
        /// </summary>
        /// <returns></returns>
        private byte[] _GenerateChecksum()
        {
            return Framework.Common.Utils.EncryptionUtils.ConvertStringKeyToBytes(this.UserID.ToString() + this.IssueDateTime.ToString());
        }

        /// <summary>
        /// Check that the check sum is valid with current properties
        /// </summary>
        /// <returns></returns>
        public bool IsChecksumValid()
        {
            if (Checksum == null)
                return false;

            byte[] chash = _GenerateChecksum();

            for (int i = 0; i < Checksum.Length; i++)
                if (Checksum[i] != chash[i])
                    return false;

            return true;
        }
    }

}
