/// <reference path="entityController.js" />
// ----------------------------- Doctor ---------------------------------

entityControllerFactory.create("Doctor", "SearchByPhoneForm", function ($scope, sParams) {

    //$scope.Doctor_PatientService = EntityService.create("Doctor_Patient", sParams.$http, sParams.ngAuthSettings);
    $scope.msgs.selectedItemsListIsEmpty = "No doctor found with the entered phone number.";

    $scope.ClinicPhoneNumber = "";

    $scope.$watch('ClinicPhoneNumber', function () {
        $scope.FindDoctorSearchByClinicPhoneNumber($scope.ClinicPhoneNumber);
    });

    $scope.DoSearch = function () {
        $scope.FindDoctorSearchByClinicPhoneNumber($scope.ClinicPhoneNumber);
    }

    $scope.FindDoctorSearchByClinicPhoneNumber = function (phoneNumber) {
        if (phoneNumber) {
            if (phoneNumber.length >= 5) {
                $scope.Exec({
                    methodName: 'SearchByClinicPhoneNumber',
                    data: {
                        PhoneNumber: phoneNumber
                    },
                    successFn: function (e) {
                        $scope.itemsList = e.response.data;
                    }
                });
            }
            else {
                $scope.itemsList = [];
            }
        }
    }

    //$scope.AddDoctor = function (doctorId) {
    //    $scope.Doctor_PatientService.Insert({ data: $scope.model });
    //}



});

entityControllerFactory.create("Doctor", "ProfileDialog", function ($scope, sParams) {

    BaseControllers.AddDialogFunction($scope, sParams);

    $scope.OnLoadDialog = function (entityId) {
        $scope.DoctorProfileController.View(entityId);
    }

});



entityControllerFactory.create("Doctor", "Form", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);

    $scope.init = function () {
        $scope.View($scope.CurrentUserID);
    }

    $scope.onBeforeInsert = function () {
        $scope.model.DoctorID = $scope.CurrentUserID;
    }

    $scope.onSuccessInsert = function () {
        $scope.View($scope.CurrentUserID);
    }

});

entityControllerFactory.create("Doctor", "Profile", function ($scope, sParams) {

    BaseControllers.AddViewPageFunctions($scope, sParams);

    if ($scope.MasterID)
        $scope.ViewID = $scope.MasterID;

    $scope.init = function () {
        $scope.View($scope.ViewID);
    }

    $scope.FormatCommaList = function (strList) {
        if (strList)
            return strList.replace(/(,)/gm, "<br />");
        else
            return "";
    }


});
