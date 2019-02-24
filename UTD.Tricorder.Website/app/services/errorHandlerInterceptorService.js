'use strict';
app.factory('errorHandlerInterceptorService', ['$q', '$injector', '$location', 'localStorageService', '$window', function ($q, $injector, $location, localStorageService, $window) {

    var errorHandlerInterceptorServiceFactory = {};

    var _responseError = function (rejection) {

        if (rejection.status === 0) {
            $window.ShowError("Server didn't respond. Please make sure that you have access to the Internet.");
        }

        // if error had a description, we show that
        if (rejection.data)
            if (rejection.data.error_description) {
                $window.ShowError(rejection.data.error_description);
                return $q.reject(rejection);
            }

        // otherwise, we show a default error based on the error code
        if (rejection.status === 401) {
            $window.ShowError("Error 401: Please login before using this system.");
            var authService = $injector.get('authService');
            var authData = localStorageService.get('authorizationData');

            if (authData) {
                if (authData.useRefreshTokens) {
                    $location.redirectTo("~/Default/RefreshToken");
                    return $q.reject(rejection);
                }
            }
            authService.logOut();
            $location.redirectTo("~/Default/Login");
        }

        if (rejection.status === 400) {
            $window.ShowError("Error 400: The application you are using accessed a resource incorrectly or that the request was somehow corrupted on the way. Please contact us if it didn't work after a while.");
        }

        if (rejection.status === 403) {
            $window.ShowError("Error 403: You don't have enough permission to do this action.");
        }

        if (rejection.status === 404) {
            $window.ShowError("Error 404: Requested page is not available.");
        }

        if (rejection.status === 500) { // internal server error
            $window.ShowError("Error 500: Internal server error. We are sorry, but something went wrong. We recorded the error, and we fix it as soon as possible. The data of this page may not be valid anymore. Please go back try again later.");
            if (rejection.data) {
                var msg = rejection.data.Message;
                if (msg !== undefined && msg !== null && msg !== "")
                    $window.ShowError(msg);
            }
        }
        return $q.reject(rejection);
    }

    errorHandlerInterceptorServiceFactory.responseError = _responseError;

    return errorHandlerInterceptorServiceFactory;
}]);