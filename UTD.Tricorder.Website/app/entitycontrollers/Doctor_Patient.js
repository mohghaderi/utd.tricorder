/// <reference path="entityController.js" />
// ----------------------------- Doctor_Patient --------------------------------


entityControllerFactory.create("Doctor_Patient", null, function ($scope, sParams) {
    $scope.AddDoctor = function (doctorId) {
        $scope.model = {
            DoctorID: doctorId,
            PatientUserID: $scope.CurrentUserID
        }
        $scope.CallService({ sName: 'Insert', data: $scope.model });
    }

    $scope.onSuccessInsert = function (e) {
        $scope.GoBack();
    }
});


entityControllerFactory.create("Doctor_Patient", "MyDoctors", function ($scope, sParams) {

    BaseControllers.AddGridFunctions($scope, sParams);

    $scope.msgs.selectedItemsListIsEmpty = "Selected items list is empty. Please select an item and use 'Add to list' button.";

    $scope.ListFilter = {
        "FiltersList":
        [
            { "ColumnName": "PatientUserID", "Value": $scope.CurrentUserID }
        ]
    };

});



entityControllerFactory.create("Doctor_Patient", "MyPatients", function ($scope, sParams) {

    BaseControllers.AddGridFunctions($scope, sParams);

    $scope.msgs.selectedItemsListIsEmpty = "None of your patients are registered with our app. You may ask them to add you using your provided clinic phone number.";

    $scope.ListFilter = {
        "FiltersList":
        [
            { "ColumnName": "DoctorID", "Value": $scope.CurrentUserID }
        ]
    };

});