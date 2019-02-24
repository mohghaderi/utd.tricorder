/// <reference path="entityController.js" />
// ----------------------------- Doctor_* (Details) ---------------------------------

BaseControllers.DoctorTwoKeysBaseAddServises = function ($scope, sParams) {
    BaseControllers.AddTwoKeyFormFunctions($scope, sParams);

    if ($scope.MasterID)
        $scope.DoctorID = $scope.MasterID;
    else
        $scope.DoctorID = $scope.CurrentUserID; // use logged in user

    $scope.ListFilter = {
        "FiltersList":
            [
                { "ColumnName": "DoctorID", "Value": $scope.DoctorID }
            ]
    };

    $scope.onBeforeInsert = function () {
        $scope.model.DoctorID = $scope.DoctorID;
    }

    $scope.ViewNeedsParams = { DoctorID: "" + $scope.DoctorID };
    $scope.CheckViewNeeds();
}


entityControllerFactory.create("Doctor_Specialty", "TwoKey", function ($scope, sParams) {
    BaseControllers.DoctorTwoKeysBaseAddServises($scope, sParams);
});



entityControllerFactory.create("Doctor_USState", "TwoKey", function ($scope, sParams) {
    BaseControllers.DoctorTwoKeysBaseAddServises($scope, sParams);
});

entityControllerFactory.create("Doctor_Insurance", "TwoKey", function ($scope, sParams) {
    BaseControllers.DoctorTwoKeysBaseAddServises($scope, sParams);

    $scope.msgs.NotSelectedListIsEmpty = "Please select an insurance company with available insurance plans. No company is selected or all insurance plans are already added.";

    $scope.InsuranceService = EntityService.create("Insurance", sParams.$http, sParams.ngAuthSettings);
    $scope.InsurancePlanService = EntityService.create("InsurancePlan", sParams.$http, sParams.ngAuthSettings);

    $scope.$watch("SelectedInsuranceID", function () {
        $scope.RefreshNotSelectedList();
    });

    $scope.RefreshNotSelectedList = function () {
        var insuranceId = $scope.SelectedInsuranceID;
        if (insuranceId) {
            $scope.InsurancePlanService.Exec({
                methodName: 'GetNotSelectedPlans',
                data: {
                    InsuranceID: insuranceId,
                    UserID: $scope.DoctorID
                },
                successFn: function (e) {
                    $scope.insurancePlansList = e.response.data;
                }
            });
        }
    }

    $scope.AddInsurancePlan = function (insurancePlan, $event) {
        $event.preventDefault();

        $scope.CallService({
            sName: "Insert",
            data: {
                InsurancePlanID: insurancePlan.InsurancePlanID,
                DoctorID: $scope.DoctorID
            }
        });
    }

    $scope.onSuccessInsert = function () {
        $scope.RefreshList();
        $scope.RefreshNotSelectedList();
    }

    $scope.onSuccessDelete = function () {
        $scope.RefreshList();
        $scope.RefreshNotSelectedList();
    }


});