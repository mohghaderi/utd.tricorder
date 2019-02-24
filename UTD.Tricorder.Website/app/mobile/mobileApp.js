/* this class contains all functions that can be called from Air client */

'use strict';
app.controller('MobileAppCallBackController', ['$scope', '$http', '$location', 'authService', 'ngAuthSettings', '$window', function ($scope, $http, $location, authService, ngAuthSettings, $window) {

    var visitService = EntityService.create("Visit", $http, ngAuthSettings);
    $scope.userDeviceSettingService = EntityService.create("UserDeviceSetting", $http, ngAuthSettings);

    $scope.Call_PhoneRing = function (p) {
        //$location.url("/Visit-PhoneRing");
        if ($location.path().indexOf("/CallLog-") === -1) { // not in any call pages
            $scope.OpenPath("CallLog-PhoneRing", { MasterID: p.CallLogID }, true);
        }
        else {
            // TODO: Automatically decline the call because the user is busy
            $window.ShowWarning("Incoming call from " + p.SenderFullName + " declined");
        }
    }

    $scope.Call_AnswerCall = function (p) {
        if ($scope.$root.NoAnswerTimer)
            clearTimeout($scope.$root.NoAnswerTimer);
        $scope.OpenPath("CallLog-VideoMeeting", { MasterID: p.CallLogID, IsCaller: p.IsCaller });
    }

    $scope.Call_DeclineCall = function (p) {
        if($scope.$root.NoAnswerTimer)
            clearTimeout($scope.$root.NoAnswerTimer);
        $window.ShowMessage("User is busy. Call Declined.");
        $scope.GoBackToCheckPoint();
    }

    $scope.Call_EndCall = function(p) {
        if($scope.$root.NoAnswerTimer)
            clearTimeout($scope.$root.NoAnswerTimer);
        //$window.ShowMessage("Call ended.");
        //WebRtcApp.WebRtcVideo.stop(); it is now loaded in iframe, so it will be stopped automatically
        $scope.GoBackToCheckPoint();
    }

    $scope.Call_CancelCall = function (p) {
        if ($scope.$root.NoAnswerTimer)
            clearTimeout($scope.$root.NoAnswerTimer);
        $window.ShowMessage("Call Misssed");
        $scope.GoBackToCheckPoint();
    }


    $scope.PushTokenRecieved = function (token) {

        var appTypeId = 0; // cordova;
        if ($window.isCordovaApp() === false)
            appTypeId = 1; // Adobe Air

        var registerDeviceParams = {
            GeneratedUUID: $window.mobileApp.getGeneratedUUID(),
            UserID: $window.getLoginData().userName,
            CapabilitiesServerString: $window.mobileApp.getDeviceInfoString(),
            PushToken: token,
            UserDeviceClientAppTypeID: appTypeId,
            UserDeviceClientAppVersion: String($window.cordovaAppVersion)
        };
        $scope.userDeviceSettingService.ExecInline("RegisterDevice", registerDeviceParams);
    }

    $scope.AirClientReady = function (p) {
        // asking to register device and send its information
        airBridge.callAir("registerDevice", null);
        airBridge.isActive = true;
    }

    // initializing mobile app
    $scope.init = function() {
        // registering push notification
        if ($location.absUrl().indexOf("/Dashboard/") > 0
            && $location.absUrl().indexOf("/Default/Login") === -1) { // not in any call pages

                if ($window.mobileApp)
                    $window.mobileApp.registerPushNotify();
        }
    }

    $scope.pushNotifyError = function (msg) {
        $window.ShowError(msg);
    }

    $scope.pushNotifyRecieved = function (event) {
        console.log("mobileAppScope.pushNotifyRecieved");
        if (event.alert) {
            //do something with the push message. This function is fired when push message is received or if user clicks on the tile.
            alert(event.alert);
        }

        if (event.sound) {
            $window.mobileApp.playMedia(event.sound);
        }

        if (event.badge) {
            $window.mobileApp.setBadge(event.badge);
        }
    }


}]);


window.mobileAppCallBack = {
    
    scope: null,

    callback: function (fnName, params) {
        if (mobileAppCallBack.scope == null)
            mobileAppCallBack.scope = angular.element("#MobileAppCallBackControllerDiv").scope();
        mobileAppCallBack.scope[fnName](params);
    },

    log: function (logInfo) {
        console.log("mobileApplog:" + logInfo);
    }

}
