/// <reference path="entityController.js" />
// ----------------------------- UserPaymentInfo ---------------------------------

entityControllerFactory.create("UserPaymentInfo", "Form", function ($scope, sParams) {
    BaseControllers.AddFormServices($scope, sParams);

    $scope.UserID = $scope.CurrentUserID;

    $scope.init = function () {
        $scope.View($scope.UserID);
    }

    $scope.onSuccessInsert = function () {
        $scope.View($scope.CurrentUserID);
    }
});
