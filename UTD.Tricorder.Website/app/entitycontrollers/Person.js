/// <reference path="entityController.js" />
// ----------------------------- Person ---------------------------------

entityControllerFactory.create("Person", "Form", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);

    if ($scope.MasterID)
        $scope.PersonID = $scope.MasterID;
    else
        $scope.PersonID = $scope.CurrentUserID; // using login data for current person


    $scope.init = function () {
        $scope.View($scope.PersonID);
    }

    $scope.onBeforeInsert = function () {
        $scope.model.PersonID = $scope.PersonID;
    }

    $scope.onSuccessInsert = function () {
        $scope.View($scope.PersonID);
    }

});


entityControllerFactory.create("Person", "ProfileView", function ($scope, sParams) {

    BaseControllers.AddViewPageFunctions($scope, sParams);

    if ($scope.MasterID)
        $scope.ViewID = $scope.MasterID;
    else
        $scope.ViewID = $scope.CurrentUserID; // using login data for current person

    $scope.init = function () {
        $scope.View($scope.ViewID);
    }

});

