/// <reference path="entityController.js" />
// ----------------------------- Patient Insurance ---------------------------------

entityControllerFactory.create("PatientInsurance", "Form", function ($scope, sParams) {

    BaseControllers.AddEditFormServices($scope, sParams);
    $scope.InsurancePlanService = EntityService.create("InsurancePlan", sParams.$http, sParams.ngAuthSettings);

    if ($scope.MasterID)
        $scope.PatientUserID = $scope.MasterID;
    else
        $scope.PatientUserID = $scope.CurrentUserID;

    $scope.onBeforeInsert = function () {
        $scope.model.PatientUserID = $scope.PatientUserID;
    }

    $scope.$watch("model.InsuranceID", function () {
        if ($scope.model.InsuranceID)
        {
            $scope.InsurancePlanService.Exec({
                methodName: 'GetByInsuranceID',
                data: {
                    InsuranceID: $scope.model.InsuranceID
                },
                successFn: function (p) {
                    sParams.$window.LoadComboBox("InsurancePlanID", p.response.data, $scope.model.InsurancePlanID);
                }
            });
        }
    });



});

entityControllerFactory.create("PatientInsurance", "Grid", function ($scope, sParams) {

    BaseControllers.AddGridFunctions($scope, sParams);

    $scope.msgs.selectedItemsListIsEmpty = "No insurance plan added to the list. Please use 'Add New' button to add registered insurance plans.";

    if ($scope.MasterID)
        $scope.PatientUserID = $scope.MasterID;
    else
        $scope.PatientUserID = $scope.CurrentUserID;

    $scope.ListFilter = {
        "FiltersList":
        [
            { "ColumnName": "PatientUserID", "Value": $scope.PatientUserID }
        ]
    };


    $scope.ShowNewForm = function () {
        //$scope.PatientInsuranceFormController.ViewNewForm();
        //sParams.$window.ShowDialog("PatientInsuranceDialog");
        $scope.GotoView("PatientInsurance-Form?MasterID=" + $scope.PatientUserID);
    }

    $scope.ShowEditForm = function (itemId) {
        //$scope.PatientInsuranceFormController.View(itemId);
        //sParams.$window.ShowDialog("PatientInsuranceDialog");
        $scope.GotoView("PatientInsurance-Form?MasterID=" + $scope.PatientUserID + "&RecordID=" + itemId);
    }

});