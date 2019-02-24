/// <reference path="entityController.js" />
// ----------------------------- UserDeviceSetting ---------------------------------

entityControllerFactory.create("UserDeviceSetting", "SendPushSanity", function ($scope, sParams) {

    $scope.SendPushSanity = function () {

        if (!$scope.CurrentUserID)
            alert("you need to login before using this function.");

        $scope.ExecInline("SendPushSanity",
            {
                UserID: $scope.CurrentUserID
            }
            , function (p) {
                if (p.response.data == null || p.response.data.length === 0)
                    throw "No device registered for this user";
        });

    };

});