
entityControllerFactory.create("FoodGroupItem", "Form", function ($scope, sParams) {
    EntityService.create("Food", sParams.$http, sParams.ngAuthSettings); // food service for combobox
    BaseControllers.AddEditFormServices($scope, sParams);

    $scope.onBeforeInsert = function () {
        $scope.model.FoodGroupID = $scope.MasterID;
    }

});


entityControllerFactory.create("FoodGroupItem", "Grid", function ($scope, sParams) {

    $scope.FoodGroupID = sParams.$routeParams.FoodGroupID;

    $scope.ShowNewForm = function () {
        $scope.GotoView("FoodGroupItem-Form?MasterID=" + $scope.FoodGroupID);
    }

    $scope.ShowEditForm = function (itemId) {
        $scope.GotoView("FoodGroupItem-Form?MasterID=" + $scope.FoodGroupID + "&RecordID=" + itemId);
    }

    $scope.ListFilter = {
        "FiltersList":
            [{ "ColumnName": "FoodGroupID", "Value": $scope.FoodGroupID }
            ]
    }

    BaseControllers.AddGridFunctions($scope, sParams);

});


entityControllerFactory.create("FoodGroupItem", "GridDetail", function ($scope, sParams) {

    entityControllerFactory.InheritFns.FoodGroupItemGrid($scope, sParams);

    $scope.init = function () { };

});