/// <reference path="entityController.js" />
// ----------------------------- User_Language ---------------------------------

entityControllerFactory.create("User_Language", "TwoKey", function ($scope, sParams) {
    BaseControllers.AddTwoKeyFormFunctions($scope, sParams);

    if ($scope.MasterID)
        $scope.UserID = $scope.MasterID;
    else
        $scope.UserID = $scope.CurrentUserID;

    $scope.ListFilter = {
        "FiltersList":
            [
                { "ColumnName": "UserID", "Value": $scope.UserID }
            ]
    };

    $scope.onBeforeInsert = function () {
        $scope.model.UserID = $scope.UserID;
    }
});