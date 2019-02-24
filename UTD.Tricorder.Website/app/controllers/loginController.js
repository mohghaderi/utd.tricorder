'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', "$window", "$routeParams", function ($scope, $location, authService, $window, $routeParams) {

    //Developer Note: Change this file with User.js (signup form)
    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };

    $scope.message = "";

    $scope.login = function ($event) {

        if ($event)
            $event.preventDefault();

        if ($window.isFormValid("#UserLoginFrm"))
        {
            $scope._callLoginService();
        }


        return false;
    };

    $scope._callLoginService = function () {
        $("#UserLoginFrm").mask($scope.msgs.common.pleasewait);
        authService.login($scope.loginData).then(function (response) {

            //$("#UserLoginFrm").unmask();
            //$location.path('/dashboard');
            //$location.redirectTo("~/Default/DoFormAuth");
            $window.ShowMessage($scope.msgs.login.welcome, false);

            setTimeout(function () {
                var qsReturnUrl = $location.getQueryString('ReturnUrl');
                if (qsReturnUrl)
                {
                    //var redirectUrl = decodeURIComponent("~/" + qsReturnUrl);
                    window.location.href = decodeURIComponent(qsReturnUrl);
                }
                else
                    $location.redirectTo('~/Dashboard/Index#/');
            }, 1000);

        },
         function (err) {
             $("#UserLoginFrm").unmask();
             //$window.ShowMessage("Login failed! Please try again.", true);
         });
    }



    // if login token was provided we login using login token
    if ($location.getQueryString("logintoken"))
    {
        $scope.loginData.userName = "loginwithsinglesignontoken#"
        $scope.loginData.password = decodeURIComponent($location.getQueryString("logintoken"));
        $scope._callLoginService();
    }

    // if registration info was provided then login with registration info
    if ($location.getQueryString("registertoken"))
    {
        $scope.loginData.userName = "loginwithregistertoken#"
        $scope.loginData.password = decodeURIComponent($location.getQueryString("registertoken"));
        $scope._callLoginService();
    }

}]);