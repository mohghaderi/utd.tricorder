/// <reference path="entityController.js" />
// ----------------------------- UserInRole ---------------------------------

entityControllerFactory.create("UserInRole", "RoleSelector", function ($scope, sParams) {

    $scope.init = function () {

        $scope.ExecInline("GetRolesByUserID", Number($scope.CurrentUserID), function (p) {
            if (p.response.data.length == 0)
                throw "No Role found for this user. Please contact administrator.";
            var userInRole = p.response.data[0]
            $scope.$parent.CurrentRoleID = userInRole.RoleID;
            $scope.$parent.CurrentRoleCode = userInRole.RoleCode;
            if (sParams.$location.path() == "" || sParams.$location.path() == "/")
                $scope.$parent.GotoMainMenu();
        });

    };

});