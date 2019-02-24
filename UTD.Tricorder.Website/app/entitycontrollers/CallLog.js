// ---------------------------- Calling patient -----------------------------


entityControllerFactory.create("CallLog", "VisitCallPatient", function ($scope, sParams) {

    $scope.init = function () {
        $scope.ExecInline("VisitCallPatient", { VisitID: $scope.MasterID }, function (e) {
            $scope.model = e.response.data;
        });

        console.log($scope);
        $scope.$root.NoAnswerTimer = setTimeout(function () {
            $scope.GoBackToCheckPoint();
            sParams.$window.ShowMessage("No answer");
        }, 10000);
    }

    $scope.CancelCall = function () {
        $scope.ExecInline("CancelCall", { CallLogID: $scope.model.CallLogID },
            function (e) {
                $scope.GoBackToCheckPoint();
        });
    }

});

entityControllerFactory.create("CallLog", "PhoneRing", function ($scope, sParams) {
    BaseControllers.AddViewPageFunctions($scope, sParams);

    $scope.init = function () {
        $scope.View($scope.MasterID);

        $scope.$root.NoAnswerTimer = setTimeout(function () {
            $scope.GoBackToCheckPoint();
        }, 10000);
    }

    $scope.AnswerCall = function () {
        $scope.ExecInline("AnswerCall", { CallLogID: $scope.MasterID }, function (e) {

        });
    }

    $scope.DeclineCall = function () {
        $scope.ExecInline("DeclineCall", { CallLogID: $scope.MasterID }, 
            function () {
                $scope.GoBackToCheckPoint();
            });
    }

});

entityControllerFactory.create("CallLog", "VideoMeeting", function ($scope, sParams) {

    $scope.init = function () {
        $scope.IsCaller = sParams.$routeParams.IsCaller;

        //if (sParams.$routeParams.IsCaller)
        //    sParams.$window.WebRtcApp.WebRtcVideo.run($scope.MasterID);
        //else
        //    sParams.$window.WebRtcApp.WebRtcVideo.run();
    }

    $scope.$on('$locationChangeSuccess', function (next, current) {
        //sParams.$window.WebRtcApp.WebRtcVideo.stop();
        $scope.ExecInline("EndCall", { CallLogID: $scope.MasterID }, function (e) {
        });
    });

    $scope.EndCall = function () {

        //sParams.$window.WebRtcApp.WebRtcVideo.stop();
        $scope.GoBackToCheckPoint();
    }

});


function injectIframeComponents(iframe) {

    console.log("injectIframeComponents");

    var iwindow = iframe.contentWindow;
    if (iframe.contentWindow) {
        iwindow.navigator = window.navigator;
        iwindow.cordova = window.cordova;
        iwindow.cordovaAppVersion = window.cordovaAppVersion;
        iwindow.$ = window.$;
        iwindow.isLoaded = true;

        var $scope = angular.element("#CallLogVideoMeetingControllerDiv").scope();
        if ($scope.IsCaller) {
            console.log('start video as caller');
            iwindow.initVideo($scope.MasterID);
        }
        else {
            console.log('start video as callee');
            iwindow.initVideo();
        }

        ////////////////////////////////////////////////

        iwindow.$('#mainloading').remove();
        iwindow.$('#mainloading-mask').fadeOut({ remove: true });


        // cordova support for later
        if (iwindow.onDeviceReady)
            iwindow.onDeviceReady();
    }
    //var doc = iframe.contentDocument || iframe.contentWindow.document;

}

//(function () {
//    var myHub = $.connection.mainHub;
//    // Hub Callback: WebRTC Signal Received
//    myHub.on("receiveSignal", function (callingConnectionId, data) {
//        console.log("signalr receiveSignal", data);
//        var iwindow = $("#VideoMeetingIFrame")[0].contentWindow;
//        iwindow.WebRtcApp.WebRtcVideo.connectionManager.newSignal(callingConnectionId, data);
//    });

//    myHub.on("clientStartVideoCall", function (callingConnectionId, callLogId) {
//        console.log("signalr clientStartVideoCall", callingConnectionId);
//        var iwindow = $("#VideoMeetingIFrame")[0].contentWindow;
//        iwindow.WebRtcApp.WebRtcVideo.initiateOffer(callingConnectionId);
//    });
//});