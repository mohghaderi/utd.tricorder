/// <reference path="entityController.js" />
// ----------------------------- User ---------------------------------

BaseControllers.UserSignupAddServices = function ($scope, sParams) {
    $scope.AfterSignUp = function (p) {
        sParams.$window.ShowMessage($scope.msgs.user.signup.successmessage)
        var loginData = {
            userName: $scope.model.UserName,
            password: $scope.model.Password,
            useRefreshTokens: false
        }
        sParams.authService.login(loginData).then(
            function (response) {
                setTimeout(function () {
                    sParams.$location.redirectTo('~/Dashboard/Index#/');
                }, 1000);
            });
    }
}

entityControllerFactory.create("User", "Signup", function ($scope, sParams) {

    BaseControllers.UserSignupAddServices($scope, sParams);

    $scope.Signup = function () {
        if ($scope.IsFormValid()) {
            $scope.ExecInline('Register', $scope.model,
                $scope.AfterSignUp
            );
        }
    }

    $scope.ValidateUserNameForInsert = function (userName, successFn, failureFn) {
        $scope.ExecInline('ValidateUserNameForInsert', userName, successFn, failureFn);
    };
});


entityControllerFactory.create("User", "PatientProfileTabs", function ($scope, sParams) {

    if (!$scope.MasterID) // if no master id was provided for tabs, we use current user
        $scope.MasterID = $scope.CurrentUserID;

});

entityControllerFactory.create("User", "RegisterQuickFromDoctor", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);

    $scope.RegisterQuickFromDoctor = function () {
        if ($scope.IsFormValid()) {
            $scope.ExecInline('RegisterQuickFromDoctor', $scope.model);
        }
    }

    $scope.onBeforeRegisterQuickFromDoctor = function () {
        $scope.model.ReferrerUserID = $scope.CurrentUserID;
        $scope.model.DefaultRoleID = 1; //patient
    }

    $scope.onSuccessRegisterQuickFromDoctor = function () {
        if ($scope.CloseDialog)
            $scope.CloseDialog($scope.model);
        else
            $scope.GoBack();
    }

});


entityControllerFactory.create("User", "SearchFromVisitBook", function ($scope, sParams) {

    BaseControllers.AddGridFunctions($scope, sParams);

    $scope.msgs.selectedItemsListIsEmpty = $scope.msgs.user.searchfromvisitbook.selectedItemsListIsEmpty;

    $scope.PageSize = 5;
    $scope.init = function () { }; // prevent default refresh list
    //$scope.SelectColumns = ["UserID", "FullName", ""];

    $scope.$watch('SearchPhoneNumber', function () {
        $scope.FindByInfo();
    });

    $scope.$watch('SearchFirstName', function () {
        $scope.FindByInfo();
    });

    $scope.$watch('SearchLastName', function () {
        $scope.FindByInfo();
    });

    $scope.FindByInfo = function () {

        var filtersList = [];
        if ($scope.SearchPhoneNumber) {
            filtersList.push({ "ColumnName": "PhoneNumber", "Operator": "Contains", "Value": $scope.SearchPhoneNumber });
        }
        if ($scope.SearchFirstName) {
            filtersList.push({ "ColumnName": "FirstName", "Operator": "Contains", "Value": $scope.SearchFirstName });
        }
        if ($scope.SearchLastName) {
            filtersList.push({ "ColumnName": "LastName", "Operator": "Contains", "Value": $scope.SearchLastName });
        }

        var listFilter = {
            "FiltersList": filtersList
        };

        $scope.ListFilter = listFilter;

        if (filtersList.length > 0)
            $scope.RefreshList();
    }

});


entityControllerFactory.create("User", "RegisterQuickFromDoctorDialog", function ($scope, sParams) {

    BaseControllers.AddDialogFunction($scope, sParams);

});


entityControllerFactory.create("User", "CancelMyAccount", function ($scope, sParams) {

    $scope.CancelAccount = function () {
        if ($scope.IsFormValid()) {
            $scope.Confirm("Are you sure that you want to cancel your account?", function () {
                $scope.Exec({
                    methodName: 'CancelMembership',
                    data: {
                        UserID: $scope.CurrentUserID
                    }
                });
            }); // end confirm
        } // end if
    }

    $scope.onSuccessCancelMembership = function () {
        sParams.authService.logOut();
        sParams.$location.redirectTo('~/Default/Signout');
    }

});


entityControllerFactory.create("User", "ChangePasswordForm", function ($scope, sParams) {

    $scope.init = function () {
        if (!$scope.CurrentUserID)
            throw "CurrentUserID not defined.";

        $scope.model.UserID = $scope.CurrentUserID;
    }

    $scope.ChangePassword = function () {
        if ($scope.IsFormValid()) {
            $scope.Exec({
                methodName: 'ChangePassword',
                data: $scope.model
            });
        }
    }

    $scope.onSuccessChangePassword = function () {
        $scope.model = {};
        $scope.GoBack();
    }

});


entityControllerFactory.create("User", "ResetPasswordForm", function ($scope, sParams) {

    $scope.IsEmail = true;
    $scope.ResetPasswordCodeSent = false;

    $scope.init = function () {
        if (sParams.$location.getQueryString("Code")) {
            // initializing form from query string values
            $scope.ResetPasswordCodeSent = true;
            $scope.model.ResetPasswordCode = Number(sParams.$location.getQueryString("Code"));
            $scope.model.EmailOrPhoneNumber = sParams.$location.getQueryString("EorP");
            if ($scope.model.EmailOrPhoneNumber.indexOf('@'))
                $scope.model.Email = $scope.model.EmailOrPhoneNumber;
            else
                $scope.model.PhoneNumber = $scope.model.EmailOrPhoneNumber;
        }
    }


    $scope.ResetPasswordRequest = function () {
        if (sParams.$window.isValidContainer("#RequestSection")) {
            $scope.model.EmailOrPhoneNumber = $scope.model.Email;
            if (!$scope.IsEmail)
                $scope.model.EmailOrPhoneNumber = $scope.model.PhoneNumber;

            $scope.ExecInline('ResetPasswordRequest',
                {
                    EmailOrPhoneNumber: $scope.model.EmailOrPhoneNumber
                }
            , function (e) {
                $scope.ResetPasswordCodeSent = true;
                sParams.$window.ShowMessage("A reset password code has been sent to your email.");
                sParams.$window.resetFormValidation("#UserResetPasswordFormFrm");
            });
        }
    }

    $scope.ResetPassword = function () {
        if (sParams.$window.isValidContainer("#ResetPasswordSection")) {
            $scope.ExecInline('ResetPassword', {
                EmailOrPhoneNumber: $scope.model.EmailOrPhoneNumber,
                ResetPasswordCode: $scope.model.ResetPasswordCode,
                NewPassword: $scope.model.NewPassword,
                ConfirmNewPassword: $scope.model.ConfirmNewPassword
            }
            , function () {
                sParams.$window.ShowMessage("Your password changed successfully. You can now <a href='Login'>login</a> with your user name and password.");
                setTimeout(function () {
                    sParams.$location.redirectTo('~/Default/Login');
                }, 2000);
            });
        }
    }

});


entityControllerFactory.create("User", "ProfileEdit", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);

    $scope.UserID = $scope.CurrentUserID;

    //profile picture file upload settings
    $scope.AppFileTypeID = 1000; // profile picture
    $scope.AppEntityRecordIDValue = $scope.UserID;
    $scope.FileUploadSuccess = function (e) {
        //refresh the picture here!
        $scope.model.UserProfilePicUrl = e.DownloadUrl;
        sParams.$window.ShowMessage("Profile picture changed :)");
    };

    $scope.UpdateProfileInfo = function () {
        if ($scope.IsFormValid()) {
            $scope.Exec({
                methodName: 'UpdateProfileInfo',
                data: $scope.model
            });
        }
    }

    $scope.init = function () {
        $scope.View($scope.UserID);
    }

});

entityControllerFactory.create("User", "MyAccountTabs", function ($scope, sParams) {

});


entityControllerFactory.create("User", "VerifyEmail", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);

    $scope.UserID = $scope.CurrentUserID;

    $scope.init = function () {
        $scope.View($scope.UserID);
    }

    $scope.VerifyEmail = function () {
        if ($scope.IsFormValid()) {
            $scope.Exec({
                methodName: 'VerifyEmail',
                data: {
                    Email: $scope.model.Email,
                    EmailVerificationCode: $scope.model.EmailVerificationCode
                }
            });
        } // end if
    }

    $scope.SendEmailVerificationLetter = function () {
        $scope.Exec({
            methodName: 'SendEmailVerificationLetter',
            data: Number($scope.CurrentUserID)
        });
    }

    $scope.onSuccessVerifyEmail = function () {
        $scope.GoBack();
    }

});



entityControllerFactory.create("User", "VerifyPhoneNumber", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);

    $scope.UserID = $scope.CurrentUserID;

    $scope.init = function () {
        $scope.View($scope.UserID);
    }

    $scope.VerifyPhoneNumber = function () {
        if ($scope.IsFormValid()) {
            $scope.Exec({
                methodName: 'VerifyPhoneNumber',
                data: {
                    PhoneNumber: $scope.model.PhoneNumber,
                    PhoneVerificationCode: $scope.model.PhoneVerificationCode
                }
            });
        } // end if
    }

    $scope.SendPhoneNumberVerificationLetter = function () {
        $scope.Exec({
            methodName: 'SendPhoneNumberVerification',
            data: Number($scope.CurrentUserID)
        });
    }

    $scope.onSuccessVerifyPhoneNumber = function () {
        $scope.GoBack();
    }

});



entityControllerFactory.create("User", "ContinueQReg", function ($scope, sParams) {
    BaseControllers.UserSignupAddServices($scope, sParams);

    $scope.GetDataByPhoneForQReg = function () {
        if (sParams.$window.isValidContainer("#CheckPhoneSection")) {
            $scope.Exec({
                methodName: 'GetDataByPhoneForQReg',
                data: {
                    PhoneNumber: $scope.model.PhoneNumber,
                    PhoneVerificationCode: $scope.model.PhoneVerificationCode
                },
                successFn: function (p) {
                    $scope.model = p.response.data;
                    $scope.PhoneNumberChecked = true;
                    sParams.$window.resetFormValidation("#UserContinueQRegFrm");
                }
            });
        } // end if
    }


    $scope.ContinueQReg = function () {
        if ($scope.IsFormValid()) {
            $scope.ExecInline('ContinueQReg', $scope.model, $scope.AfterSignUp);
        }
    }
});

// ---------------------------- Attachments -----------------------------

entityControllerFactory.create("User", "Attachments", function ($scope, sParams) {
    $scope.AppFileTypeID = 1001;
    $scope.FileUploadSuccess = function (file) {
        var doRefresh = false;
        if (!$scope.WaitForRefresh)
            doRefresh = true;

        if (doRefresh) {
            $scope.WaitForRefresh = setTimeout(function () {
                $scope.AppFileGridController.RefreshList();
                $scope.WaitForRefresh = null;
            }, 1000);
        }
    }
});