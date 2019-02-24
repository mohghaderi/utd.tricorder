
entityControllerFactory.create("FoodGroup", "Form", function ($scope, sParams) {

    BaseControllers.AddEditFormServices($scope, sParams);

    $scope.init = function () {
        var p = {UserID: $scope.CurrentUserID,
            FoodServingTimeTypeID: sParams.$routeParams.FoodServingTimeTypeID
        };
        $scope.ExecInline("GetUnsavedFoodGroup", p, function (e) {
            $scope.model = e.response.data;
            $scope.IsInsertForm = false;
            $scope.EntityIDValue = $scope.model.FoodGroupID;

            var grid = $scope.FoodGroupItemGridDetailController;
            grid.FoodGroupID = $scope.model.FoodGroupID;
            grid.ListFilter = {
                "FiltersList":
                    [{ "ColumnName": "FoodGroupID", "Value": grid.FoodGroupID }
                    ]
            }
            grid.RefreshList();

        });
    }

    $scope.onSuccessUpdate = function () {
        $scope.GotoView("DailyActivityChart-CalorieChart");
    }

});
