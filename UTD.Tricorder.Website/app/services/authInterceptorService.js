'use strict';
app.factory('authInterceptorService', ['$q', '$injector','$location', 'localStorageService', '$window', function ($q, $injector,$location, localStorageService, $window) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};
       
        if (config.fields)
            if (config.fields.AWSAccessKeyId) // we shouldn't add authorization token to Amazon S3
                return config;

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    //var _responseError = function (rejection) {
    //    if (rejection.status === 401) {
    //        var authService = $injector.get('authService');
    //        var authData = localStorageService.get('authorizationData');

    //        if (authData) {
    //            if (authData.useRefreshTokens) {
    //                $location.redirectTo("~/Default/RefreshToken");
    //                return $q.reject(rejection);
    //            }
    //        }
    //        authService.logOut();
    //        $location.redirectTo("~/Default/Login");
    //    }
    //    if (rejection.status === 500) { // internal server error
    //        $window.ShowMessage("Internal server error. The data of this page may not be valid anymore. Please try again later.", true);
    //        if (rejection.data)
    //        {
    //            var msg = rejection.data.Message;
    //            if (msg !== undefined && msg !== null && msg !== "")
    //                $window.ShowMessage(msg, true);
    //        }
    //    }
    //    return $q.reject(rejection);
    //}

    authInterceptorServiceFactory.request = _request;
    //authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);